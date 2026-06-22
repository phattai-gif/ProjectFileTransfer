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

        private Action onDisconnected;

        public ClientHandler(TcpClient client, Action<string> logCallback, Action onDisconnected)
        {
            this.client = client;
            this.stream = client.GetStream();
            this.logCallback = logCallback; // Nhận hàm log từ phía ngoài
            this.onDisconnected = onDisconnected;

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
                            ReceiveFile(parts); 
                            break;

                        case Protocol.DOWNLOAD:
                            SendFile(parts);    
                            break;

                        case Protocol.LIST:
                            SendFileList();     
                            break;

                        case Protocol.HASH:
                            ProcessHash(parts); // Truyền tham số parts để xử lý băm file
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
                onDisconnected?.Invoke();

                reader.Close();
                writer.Close();
                stream.Close();
                client.Close();
            }
        }

        //Connect
        private void ProcessConnect()
        {
            logCallback?.Invoke("Một Client vừa kết nối thành công.");
            writer.WriteLine("CONNECT_OK");
        }

        //Upload
        private void ReceiveFile(string[] parts)
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

        //Download
        private void SendFile(string[] parts)
        {
            if (parts.Length < 2)
            {
                writer.WriteLine(Protocol.DOWNLOAD_ERROR);
                return;
            }

            string fileName = parts[1];

            // Kiểm tra xem file Client muốn tải có trên Server không
            if (!fileManager.FileExists(fileName))
            {
                logCallback?.Invoke($"[DOWNLOAD] Thất bại: Client yêu cầu file '{fileName}' không tồn tại.");
                writer.WriteLine(Protocol.DOWNLOAD_ERROR);
                return;
            }

            long fileSize = fileManager.GetFileSize(fileName);
            logCallback?.Invoke($"[DOWNLOAD] Đang gửi file '{fileName}' ({fileSize} bytes) cho Client...");

            try
            {
                // Bước 1: Gửi thông báo thành công kèm kích thước file bằng ký tự phân tách
                writer.WriteLine($"{Protocol.DOWNLOAD_SUCCESS}{Protocol.DELIMITER}{fileSize}");

                // Bước 2: Đọc file từ ổ đĩa
                using (FileStream fs = fileManager.OpenFileStreamForRead(fileName))
                {
                    byte[] buffer = new byte[Protocol.BUFFER_SIZE];
                    int bytesRead;

                    // Đọc từ FileStream và ghi trực tiếp vào NetworkStream
                    while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, bytesRead);
                    }

                    // Đảm bảo dữ liệu được đẩy đi hết 
                    stream.Flush();
                }

                logCallback?.Invoke($"[DOWNLOAD] Thành công: Đã gửi xong file '{fileName}'.");
            }
            catch (Exception ex)
            {
                logCallback?.Invoke($"[DOWNLOAD] Lỗi khi đang truyền file {fileName}: {ex.Message}");
            }
        }

        //List
        private void SendFileList()
        {
            logCallback?.Invoke("[LIST] Client đang yêu cầu lấy danh sách file... ");

            try
            {
                // Lấy danh sách tên file từ FileManager
                string[] files = fileManager.GetFileList();
                // Khởi tạo chuỗi phản hồi
                StringBuilder response = new StringBuilder(Protocol.LIST_SUCCESS);
                // Ghép các tên file vào chuỗi
                foreach (string file in files)
                {
                    response.Append(Protocol.DELIMITER);
                    response.Append(file);
                }
                // Gửi toàn bộ chuỗi danh sách về cho Client trên một dòng
                writer.WriteLine(response.ToString());

                logCallback?.Invoke($"[LIST] Thành công: Đã gửi danh sách gồm {files.Length} file cho Client.");
            }
            catch (Exception ex)
            {
                logCallback?.Invoke($"[LIST] Lỗi khi xử lý gửi danh sách file: {ex.Message}");
            }
        }

        //Hash
        private void ProcessHash(string[] parts)
        {
            if (parts.Length < 2)
            {
                writer.WriteLine(Protocol.HASH_ERROR);
                return;
            }

            string fileName = parts[1];
            logCallback?.Invoke($"[HASH] Client yêu cầu tính mã hash cho file: '{fileName}'");

            try
            {
                if (!fileManager.FileExists(fileName))
                {
                    writer.WriteLine(Protocol.HASH_ERROR);
                    logCallback?.Invoke($"[HASH] Thất bại: File '{fileName}' không tồn tại để tính toán.");
                    return;
                }
                    
                // Thực hiện băm file
                string hashResult = fileManager.CalculateMD5(fileName);

                // Trả kết quả về cho Client
                writer.WriteLine($"{Protocol.HASH_SUCCESS}{Protocol.DELIMITER}{hashResult}");
                logCallback?.Invoke($"[HASH] Thành công: Đã gửi mã MD5 của file '{fileName}' ({hashResult})");
            }
            catch (Exception ex)
            {
                logCallback?.Invoke($"[HASH] Lỗi khi xử lý tính toán file: {ex.Message}");
                writer.WriteLine(Protocol.HASH_ERROR);
            }
        }
    }
}