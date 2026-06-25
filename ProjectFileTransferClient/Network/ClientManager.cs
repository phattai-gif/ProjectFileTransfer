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
            try
            {
                if (client != null && client.Client != null && client.Client.Connected)
                {
                    // Sử dụng kỹ thuật Poll để kiểm tra xem Socket có thực sự còn phản hồi hay không
                    if (client.Client.Poll(0, SelectMode.SelectRead))
                    {
                        byte[] buff = new byte[1];
                        if (client.Client.Receive(buff, SocketFlags.Peek) == 0)
                        {
                            // Client đã mất kết nối thực sự
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}