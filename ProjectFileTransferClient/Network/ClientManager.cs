using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ProjectFileTransferClient.Network
{
    public class ClientManager
    {
        private TcpClient? client;
        private StreamReader? reader;
        private StreamWriter? writer;

        public bool Connect(string ip, int port)
        {
            try
            {
                client = new TcpClient();
                client.Connect(ip, port);

                NetworkStream stream = client.GetStream();

                reader = new StreamReader(stream, Encoding.UTF8);
                writer = new StreamWriter(stream, Encoding.UTF8);

                writer.AutoFlush = true;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public StreamReader? GetReader()
        {
            return reader;
        }

        public StreamWriter? GetWriter()
        {
            return writer;
        }

        public NetworkStream? GetStream()
        {
            return client?.GetStream();
        }

        public bool SendMessage(string message)
        {
            try
            {
                writer?.WriteLine(message);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //=============================================
        //HÀM LẤY DANH SÁCH FILE
        public string[] GetFileList()
        {
            try
            {
                writer?.WriteLine(Protocol.LIST);

                string? response = reader?.ReadLine();

                if (response == null)
                    return new string[0];

                string[] parts =
                    response.Split(Protocol.DELIMITER);

                if (parts[0] != Protocol.LIST_SUCCESS)
                    return new string[0];

                string[] files =
                    new string[parts.Length - 1];

                for (int i = 1; i < parts.Length; i++)
                {
                    files[i - 1] = parts[i];
                }

                return files;
            }
            catch
            {
                return new string[0];
            }
        }
        //Hàm recivemessage===============================//
        public string ReceiveMessage()
        {
            if (reader != null)
            {
                return reader.ReadLine() ?? "";
            }

            return "";
        }
        //===========================================
        //================================================
        // HÀM UPLOAD FILE LÊN SERVER
        public bool UploadFile(string filePath)
        {
            try
            {
                if (writer == null || client == null)
                    return false;

                FileInfo file = new FileInfo(filePath);

                string fileName = file.Name;
                long fileSize = file.Length;

                // Gửi lệnh upload
                writer.WriteLine(
                    $"{Protocol.UPLOAD}" +
                    $"{Protocol.DELIMITER}" +
                    $"{fileName}" +
                    $"{Protocol.DELIMITER}" +
                    $"{fileSize}");

                // Gửi dữ liệu file
                using (FileStream fs =
                       new FileStream(filePath,
                       FileMode.Open,
                       FileAccess.Read))
                {
                    byte[] buffer = new byte[Protocol.BUFFER_SIZE];

                    int bytesRead;

                    NetworkStream stream =
                        client.GetStream();

                    while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, bytesRead);
                    }

                    stream.Flush();
                }

                string response = reader?.ReadLine() ?? "";

                MessageBox.Show("Response = [" + response + "]");

                return response.Trim()==Protocol.UPLOAD_SUCCESS;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        //================================================
        // HÀM DOWNLOAD FILE TỪ SERVER
        public bool DownloadFile(string fileName,
                                 string savePath)
        {
            try
            {
                writer?.WriteLine(
                    $"{Protocol.DOWNLOAD}" +
                    $"{Protocol.DELIMITER}" +
                    $"{fileName}");

                string response = reader?.ReadLine() ?? "";
                string[] parts =
                    response.Split(Protocol.DELIMITER);

                if (parts[0] != Protocol.DOWNLOAD_SUCCESS)
                    return false;

                long fileSize =long.Parse(parts[1]);

                long totalRead = 0;

                byte[] buffer = new byte[Protocol.BUFFER_SIZE];

                NetworkStream stream =client!.GetStream();

                using (FileStream fs = new FileStream(savePath, FileMode.Create))
                {
                    while (totalRead < fileSize)
                    {
                        int bytesToRead = (int)Math.Min( buffer.Length,fileSize - totalRead);

                        int bytesRead = stream.Read( buffer,0,bytesToRead);

                        if (bytesRead == 0)
                            break;

                        fs.Write( buffer,0,bytesRead);

                        totalRead += bytesRead;
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public void Disconnect()
        {
            writer?.Close();
            reader?.Close();
            client?.Close();

            writer = null;
            reader = null;
            client = null;
        }

        public bool IsConnected()
        {
            return client != null && client.Connected;
        }
    }
}