using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.IO;
using ProjectFileTransferServer.Services;

namespace ProjectFileTransferServer.Network
{
    internal class ClientHandler
    {
        private TcpClient client;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private FileManager fileManager;

        // Bổ sung Action để truyền thông điệp log về cho UI
        private Action<string> logCallback;

        public ClientHandler(TcpClient client, Action<string> logCallback)
        {
            this.client = client;
            this.stream = client.GetStream();
            this.logCallback = logCallback; // Nhận hàm log từ phía ngoài

            reader = new StreamReader(stream, Encoding.UTF8);
            writer = new StreamWriter(stream, Encoding.UTF8);
            writer.AutoFlush = true;
            fileManager = new FileManager();
        }

        public void HandleClient()
        {
            try
            {
                string request;
                while ((request = reader.ReadLine()) != null)
                {
                    string[] parts = request.Split(Protocol.DELIMITER);
                    string command = parts[0];

                    switch (command)
                    {
                        case Protocol.CONNECT:
                            ProcessConnect();
                            break;

                        case Protocol.UPLOAD:
                            ProcessUpload(parts);
                            break;

                        case Protocol.DOWNLOAD:
                            ProcessDownload();
                            break;

                        case Protocol.LIST:
                            ProcessList();
                            break;

                        case Protocol.HASH:
                            ProcessHash();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                logCallback?.Invoke($"Client ngắt kết nối: {ex.Message}");
            }
            finally
            {
                reader.Close();
                writer.Close();
                stream.Close();
                client.Close();
            }
        }

        private void ProcessConnect()
        {
            logCallback?.Invoke("Một Client vừa kết nối thành công.");
            writer.WriteLine("CONNECT_OK");
        }

        private void ProcessUpload(string[] parts)
        {
            if (parts.Length < 3)
            {
                writer.WriteLine(Protocol.UPLOAD_ERROR);
                return;
            }

            string fileName = parts[1];
            long fileSize = long.Parse(parts[2]);

            // Thông báo lên giao diện là đang nhận file
            logCallback?.Invoke($"Đang nhận file: {fileName} ({fileSize} bytes)...");

            try
            {
                using (FileStream fs = fileManager.CreateFileStream(fileName))
                {
                    byte[] buffer = new byte[Protocol.BUFFER_SIZE];
                    long totalBytesRead = 0;
                    int bytesRead;

                    while (totalBytesRead < fileSize)
                    {
                        int bytesToRead = (int)Math.Min(buffer.Length, fileSize - totalBytesRead);
                        bytesRead = stream.Read(buffer, 0, bytesToRead);

                        if (bytesRead == 0)
                            throw new Exception("Mạng đứt quãng.");

                        fs.Write(buffer, 0, bytesRead);
                        totalBytesRead += bytesRead;
                    }
                }

                writer.WriteLine(Protocol.UPLOAD_SUCCESS);

                // THÔNG BÁO LÊN GIAO DIỆN KHI FILE ĐÃ VÀO THƯ MỤC STORAGE THÀNH CÔNG
                logCallback?.Invoke($"[UPLOAD] Thành công: Đã lưu '{fileName}' vào hệ thống.");
            }
            catch (Exception ex)
            {
                logCallback?.Invoke($"[UPLOAD] Thất bại file {fileName}: {ex.Message}");
                writer.WriteLine(Protocol.UPLOAD_ERROR);
            }
        }

        private void ProcessDownload() { }
        private void ProcessList() { }
        private void ProcessHash() { }
    }
}