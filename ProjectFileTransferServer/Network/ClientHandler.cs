using ProjectFileTransferServer.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ProjectFileTransferServer.Network
{
    internal class ClientHandler
    {
        private TcpClient client;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private FileManager fileManager;

        private Action<string> logCallback;
        private Action onDisconnected;

        private string metadataFilePath = "upload_metadata.txt";

        public ClientHandler(TcpClient client, Action<string> logCallback, Action onDisconnected)
        {
            this.client = client;
            this.stream = client.GetStream();
            this.logCallback = logCallback;
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
                // Vòng lặp chính luôn được giám sát chặt chẽ
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
                            ProcessHash(parts);
                            break;

                        case "DELETE":
                            ProcessDelete(parts);
                            break;

                        case "GET_ONLINE":
                            writer.WriteLine($"ONLINE_COUNT|{ServerManager.OnlineUsersCount}");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                // Bắt trọn mọi lỗi mất kết nối Socket đột ngột của riêng Client này
                logCallback?.Invoke($"[HỆ THỐNG] Ngắt kết nối đột ngột với một Client: {ex.Message}");
            }
            finally
            {
                // Ép giải phóng tài nguyên dứt điểm để không ảnh hưởng đến các máy Client khác
                CloseConnection();
            }
        }

        private void ProcessConnect()
        {
            logCallback?.Invoke("Một Client vừa kết nối thành công.");
            writer.WriteLine("CONNECT_OK");
        }

        private void ProcessDelete(string[] parts)
        {
            if (parts.Length < 3)
            {
                writer.WriteLine("DELETE_ERROR");
                return;
            }

            string fileToDelete = parts[1].Trim();
            string requestUser = parts[2].Trim();

            logCallback?.Invoke($"[DELETE] Client '{requestUser}' đang yêu cầu xóa file '{fileToDelete}'...");

            string currentOwner = "Hệ thống";
            bool fileExistsInMeta = false;

            try
            {
                if (File.Exists(metadataFilePath))
                {
                    string[] lines = File.ReadAllLines(metadataFilePath, Encoding.UTF8);
                    foreach (string line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        string[] metaParts = line.Split('|');
                        if (metaParts.Length >= 2 && metaParts[0].Trim().Equals(fileToDelete, StringComparison.OrdinalIgnoreCase))
                        {
                            fileExistsInMeta = true;
                            currentOwner = metaParts[1].Trim();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logCallback?.Invoke($"[DELETE ERROR] Lỗi đọc danh sách phân quyền: {ex.Message}");
            }

            bool isOwner = currentOwner.Equals(requestUser, StringComparison.OrdinalIgnoreCase);

            if (!isOwner)
            {
                writer.WriteLine("DELETE_DENIED");
                logCallback?.Invoke($"[SECURITY] Từ chối: '{requestUser}' không có quyền xóa file thuộc sở hữu của '{currentOwner}'!");
                return;
            }

            string physicalPath = "";
            try
            {
                // Thay thế Application.StartupPath bằng AppDomain để tương thích .NET Core / WinForms mới
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string[] foundFiles = Directory.GetFiles(basePath, fileToDelete, SearchOption.AllDirectories);
                if (foundFiles.Length > 0)
                {
                    physicalPath = foundFiles[0];
                }
            }
            catch { }

            if (string.IsNullOrEmpty(physicalPath) || !File.Exists(physicalPath))
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string[] probablePaths = new string[]
                {
                    Path.Combine(basePath, fileToDelete),
                    Path.Combine(basePath, "storage", "uploads", fileToDelete),
                    Path.Combine(basePath, "server", "storage", "uploads", fileToDelete)
                };
                foreach (string p in probablePaths)
                {
                    if (File.Exists(p))
                    {
                        physicalPath = p;
                        break;
                    }
                }
            }

            bool isPhysicalDeleted = false;
            if (!string.IsNullOrEmpty(physicalPath) && File.Exists(physicalPath))
            {
                try
                {
                    File.Delete(physicalPath);
                    isPhysicalDeleted = true;
                }
                catch (Exception ex)
                {
                    logCallback?.Invoke($"[DELETE ERROR] File đang bị khóa hoặc không thể xóa: {ex.Message}");
                }
            }
            else
            {
                logCallback?.Invoke($"[DELETE WARNING] File vật lý không tồn tại sẵn trên ổ cứng hệ thống.");
                isPhysicalDeleted = true;
            }

            if (isPhysicalDeleted)
            {
                try
                {
                    List<string> updatedMetadata = new List<string>();
                    if (File.Exists(metadataFilePath))
                    {
                        string[] lines = File.ReadAllLines(metadataFilePath, Encoding.UTF8);
                        foreach (string line in lines)
                        {
                            if (string.IsNullOrWhiteSpace(line)) continue;
                            string[] metaParts = line.Split('|');
                            if (metaParts.Length >= 1 && metaParts[0].Trim().Equals(fileToDelete, StringComparison.OrdinalIgnoreCase))
                            {
                                continue;
                            }
                            updatedMetadata.Add(line);
                        }
                        File.WriteAllLines(metadataFilePath, updatedMetadata, Encoding.UTF8);
                    }

                    writer.WriteLine("DELETE_SUCCESS");
                    logCallback?.Invoke($"[DELETE] Thành công: Client '{requestUser}' đã xóa hoàn toàn file '{fileToDelete}'");
                }
                catch (Exception ex)
                {
                    writer.WriteLine("DELETE_ERROR");
                    logCallback?.Invoke($"[DELETE ERROR] Lỗi đồng bộ file danh sách: {ex.Message}");
                }
            }
            else
            {
                writer.WriteLine("DELETE_ERROR");
                logCallback?.Invoke($"[DELETE] Thất bại: Không thể can thiệp xóa file cứng trên Server.");
            }
        }

        private void ReceiveFile(string[] parts)
        {
            if (parts.Length < 3)
            {
                writer.WriteLine(Protocol.UPLOAD_ERROR);
                return;
            }

            string fileName = parts[1];
            long fileSize = long.Parse(parts[2]);
            string uploader = "Hệ thống";
            if (parts.Length > 3) uploader = parts[3];

            if (parts.Length >= 5)
            {
                uploader = parts[4];
            }

            logCallback?.Invoke($"Nhận yêu cầu UPLOAD file: {fileName} ({fileSize} bytes) từ [{uploader}].");

            // Tạo biến quản lý đường dẫn để thực hiện dọn dẹp file lỗi nếu đứt mạng
            string serverStoragePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Storage");
            string physicalPath = Path.Combine(serverStoragePath, fileName);

            try
            {
                writer.WriteLine(Protocol.UPLOAD);

                using (FileStream fs = fileManager.CreateFileStream(fileName))
                {
                    byte[] buffer = new byte[Protocol.BUFFER_SIZE];
                    long totalBytesRead = 0;
                    int bytesRead;

                    while (totalBytesRead < fileSize)
                    {
                        int bytesToRead = (int)Math.Min(buffer.Length, fileSize - totalBytesRead);
                        bytesRead = stream.Read(buffer, 0, bytesToRead);

                        // MẠNG BỊ ĐỨT GIỮA CHỪNG: Kích hoạt ngoại lệ giải phóng luồng ngay lập tức
                        if (bytesRead == 0)
                            throw new Exception("Kết nối mạng bị ngắt quãng đột ngột từ phía Client.");

                        fs.Write(buffer, 0, bytesRead);
                        totalBytesRead += bytesRead;
                    }
                }

                // Kiểm tra cờ tự hủy
                if (parts.Length > 5 && parts[5] == "1")
                {
                    string securePath = physicalPath + ".auto_delete";
                    if (File.Exists(physicalPath))
                    {
                        File.Move(physicalPath, securePath);
                        logCallback?.Invoke($"[HỘP ĐEN] Đã kích hoạt chế độ tự hủy cho file: {fileName}");
                    }
                }

                SaveMetadata(fileName, uploader);

                writer.WriteLine(Protocol.UPLOAD_SUCCESS);
                logCallback?.Invoke("Đã gửi UPLOAD_SUCCESS về Client");
                logCallback?.Invoke($"[UPLOAD] Thành công: Đã lưu '{fileName}' của '{uploader}' vào hệ thống.");
            }
            catch (Exception ex)
            {
                logCallback?.Invoke($"[UPLOAD FATAL] Thất bại file {fileName}: {ex.Message}");
                writer.WriteLine(Protocol.UPLOAD_ERROR);

                // DỌN DẸP FILE RÁC: Nếu đang tải mà đứt mạng, xóa file tải dở để giải phóng bộ nhớ
                try
                {
                    if (File.Exists(physicalPath))
                    {
                        File.Delete(physicalPath);
                        logCallback?.Invoke($"[HỆ THỐNG] Đã dọn dẹp file lỗi '{fileName}' do sự cố đứt mạng.");
                    }
                }
                catch { }

                // Đẩy lỗi ra ngoài để hàm HandleClient() đóng hẳn kết nối chết này lại
                throw;
            }
        }

        private void SendFile(string[] parts)
        {
            if (parts.Length < 2)
            {
                writer.WriteLine(Protocol.DOWNLOAD_ERROR);
                return;
            }

            string fileName = parts[1];
            string serverStoragePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Storage");

            string physicalPath = "";
            string securePath = "";
            bool isSecureFileExists = false;

            if (fileName.EndsWith(".auto_delete"))
            {
                securePath = Path.Combine(serverStoragePath, fileName);
                isSecureFileExists = File.Exists(securePath);
            }
            else
            {
                physicalPath = Path.Combine(serverStoragePath, fileName);
                securePath = physicalPath + ".auto_delete";
                isSecureFileExists = File.Exists(securePath);
            }

            bool isNormalFileExists = fileManager.FileExists(fileName);

            if (isNormalFileExists == false && isSecureFileExists == false)
            {
                logCallback?.Invoke($"[DOWNLOAD] Thất bại: Client yêu cầu file '{fileName}' không tồn tại.");
                writer.WriteLine(Protocol.DOWNLOAD_ERROR);
                return;
            }

            long fileSize = 0;
            if (isSecureFileExists == true)
            {
                FileInfo fi = new FileInfo(securePath);
                fileSize = fi.Length;
            }
            else
            {
                fileSize = fileManager.GetFileSize(fileName);
            }

            logCallback?.Invoke($"[DOWNLOAD] Đang gửi file '{fileName}' ({fileSize} bytes) cho Client...");

            try
            {
                writer.WriteLine($"{Protocol.DOWNLOAD_SUCCESS}{Protocol.DELIMITER}{fileSize}");

                if (isSecureFileExists == true)
                {
                    using (FileStream fs = new FileStream(securePath, FileMode.Open, FileAccess.Read))
                    {
                        byte[] buffer = new byte[Protocol.BUFFER_SIZE];
                        int bytesRead;

                        while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            stream.Write(buffer, 0, bytesRead);
                        }
                        stream.Flush();
                    }

                    try
                    {
                        File.Delete(securePath);
                        logCallback?.Invoke($"[HỘP ĐEN] File '{fileName}' đã tự hủy vĩnh viễn trên Server.");
                    }
                    catch (Exception exDel)
                    {
                        logCallback?.Invoke($"[HỘP ĐEN] Lỗi thực thi tự hủy file: {exDel.Message}");
                    }
                }
                else
                {
                    using (FileStream fs = fileManager.OpenFileStreamForRead(fileName))
                    {
                        byte[] buffer = new byte[Protocol.BUFFER_SIZE];
                        int bytesRead;

                        while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            stream.Write(buffer, 0, bytesRead);
                        }
                        stream.Flush();
                    }
                }

                logCallback?.Invoke($"[DOWNLOAD] Thành công: Đã gửi xong file '{fileName}'.");
            }
            catch (Exception ex)
            {
                logCallback?.Invoke($"[DOWNLOAD] Lỗi khi đang truyền file {fileName}: {ex.Message}");
                throw;
            }
        }

        private void SendFileList()
        {
            logCallback?.Invoke("[LIST] Client đang yêu cầu lấy danh sách file...");

            try
            {
                string[] files = fileManager.GetFileListWithSize();
                StringBuilder response = new StringBuilder(Protocol.LIST_SUCCESS);

                foreach (string file in files)
                {
                    if (string.IsNullOrEmpty(file)) continue;

                    string[] fileInfo = file.Split('#');
                    string fName = fileInfo[0];

                    string fSize = "0";
                    if (fileInfo.Length > 1)
                    {
                        fSize = fileInfo[1];
                    }

                    var meta = GetMetadata(fName);

                    string uploader = "Hệ thống";
                    if (!string.IsNullOrEmpty(meta.Uploader))
                    {
                        uploader = meta.Uploader;
                    }
                    else if (fileInfo.Length > 2 && !string.IsNullOrEmpty(fileInfo[2]))
                    {
                        uploader = fileInfo[2];
                    }

                    string date = "";
                    if (!string.IsNullOrEmpty(meta.UploadDate))
                    {
                        date = meta.UploadDate;
                    }
                    else if (fileInfo.Length > 3 && !string.IsNullOrEmpty(fileInfo[3]))
                    {
                        date = fileInfo[3];
                    }
                    else
                    {
                        date = "28/06/2026 00:00";
                    }

                    string path = $"/server/storage/uploads/{fName}";
                    string fileData = $"{fName}#{fSize}#{uploader}#{date}#{path}";
                    response.Append(Protocol.DELIMITER).Append(fileData);
                }

                writer.WriteLine(response.ToString());
                writer.Flush();

                logCallback?.Invoke($"[LIST] Thành công: Đã gửi danh sách gồm {files.Length} file cho Client.");
            }
            catch (Exception ex)
            {
                logCallback?.Invoke($"[ERROR] Lỗi gửi danh sách file: {ex.Message}");
                throw;
            }
        }

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

                string hashResult = fileManager.CalculateSHA256(fileName);

                writer.WriteLine($"{Protocol.HASH_SUCCESS}{Protocol.DELIMITER}{hashResult}");
                logCallback?.Invoke($"[HASH] Thành công: Đã gửi mã SHA256 của file '{fileName}' ({hashResult})");
            }
            catch (Exception ex)
            {
                logCallback?.Invoke($"[HASH] Lỗi khi xử lý tính toán file: {ex.Message}");
                writer.WriteLine(Protocol.HASH_ERROR);
                throw;
            }
        }

        private void SaveMetadata(string fileName, string uploader)
        {
            try
            {
                string date = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                File.AppendAllText(metadataFilePath, $"{fileName}|{uploader}|{date}\n", Encoding.UTF8);
            }
            catch { }
        }

        private (string Uploader, string UploadDate) GetMetadata(string fileName)
        {
            string uploader = "Hệ thống";
            string uploadDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            try
            {
                if (File.Exists(metadataFilePath))
                {
                    string[] lines = File.ReadAllLines(metadataFilePath, Encoding.UTF8);
                    foreach (string line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        string[] parts = line.Split('|');
                        if (parts.Length == 3 && parts[0] == fileName)
                        {
                            uploader = parts[1];
                            uploadDate = parts[2];
                        }
                    }
                }
            }
            catch { }
            return (uploader, uploadDate);
        }

        public void SendMessageDirect(string message)
        {
            try
            {
                if (writer != null)
                {
                    writer.WriteLine(message);
                }
            }
            catch { }
        }

        // Tách hàm giải phóng tài nguyên an toàn ra khối riêng biệt để tái sử dụng
        private void CloseConnection()
        {
            try
            {
                onDisconnected?.Invoke();
                reader?.Close();
                writer?.Close();
                stream?.Close();
                client?.Close();
            }
            catch { }
        }
    }
}