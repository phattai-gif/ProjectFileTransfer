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

        // 🌟 MỚI: Đường dẫn lưu thông tin metadata (Tên người upload, ngày upload)
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
        //Delete file có phân quyền ai up người đó mới được xóa, người khác không được xóa
        private void ProcessDelete(string[] parts)
        {
            if (parts.Length < 3)
            {
                writer.WriteLine("DELETE_ERROR");
                return;
            }

            // Dùng .Trim() để loại bỏ hoàn toàn khoảng trắng thừa ở đầu/cuối
            string fileToDelete = parts[1].Trim();
            string requestUser = parts[2].Trim();

            logCallback?.Invoke($"[DELETE] Client '{requestUser}' đang yêu cầu xóa file '{fileToDelete}'...");

            bool isOwner = false;
            bool fileExistsInMeta = false;
            List<string> updatedMetadata = new List<string>();

            try
            {
                if (File.Exists(metadataFilePath))
                {
                    string[] lines = File.ReadAllLines(metadataFilePath, Encoding.UTF8);
                    foreach (string line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        string[] metaParts = line.Split('|');

                        // Kiểm tra tên file KHÔNG phân biệt chữ hoa chữ thường và có .Trim()
                        if (metaParts.Length >= 2 && metaParts[0].Trim().Equals(fileToDelete, StringComparison.OrdinalIgnoreCase))
                        {
                            fileExistsInMeta = true;

                            // Kiểm tra người sở hữu KHÔNG phân biệt chữ hoa chữ thường
                            if (metaParts[1].Trim().Equals(requestUser, StringComparison.OrdinalIgnoreCase))
                            {
                                isOwner = true;
                                continue; // Khớp chủ sở hữu -> Bỏ qua dòng này (Xóa khỏi danh sách lịch sử)
                            }
                        }

                        // Giữ lại các dòng khác hoặc dòng của file này nếu sai tên người yêu cầu xóa
                        updatedMetadata.Add(line);
                    }
                }

                if (isOwner)
                {
                    // Cập nhật lại file txt danh sách
                    File.WriteAllLines(metadataFilePath, updatedMetadata, Encoding.UTF8);

                    // Xóa file vật lý trên ổ cứng
                    string physicalPath = Path.Combine(Application.StartupPath, fileToDelete);
                    if (File.Exists(physicalPath))
                    {
                        File.Delete(physicalPath);
                    }

                    writer.WriteLine("DELETE_SUCCESS");
                    logCallback?.Invoke($"[DELETE] Thành công: Client '{requestUser}' đã xóa file '{fileToDelete}'");
                }
                else if (fileExistsInMeta)
                {
                    // Tên file trùng nhưng sai tên người up
                    writer.WriteLine("DELETE_DENIED");
                    logCallback?.Invoke($"[SECURITY] Cảnh báo: '{requestUser}' cố gắng xóa file '{fileToDelete}' của người khác!");
                }
                else
                {
                    // Thực sự không tìm thấy tên file khớp trong danh sách metadata
                    writer.WriteLine("DELETE_ERROR");
                    logCallback?.Invoke($"[DELETE] Lỗi: Không tìm thấy file '{fileToDelete}' trong hệ thống metadata.");
                }
            }
            catch (Exception ex)
            {
                writer.WriteLine("DELETE_ERROR");
                logCallback?.Invoke($"[DELETE] Lỗi ngoại lệ khi xóa file: {ex.Message}");
            }
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

            //  Lấy Tên người dùng từ vị trí cuối cùng do Client gửi lên
            string uploader = "Hệ thống";
            if (parts.Length >= 5)
            {
                uploader = parts[4]; // Vị trí số 4 là Username
            }

            logCallback?.Invoke($"Nhận yêu cầu UPLOAD file: {fileName} ({fileSize} bytes) từ [{uploader}].");

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

                        if (bytesRead == 0)
                            throw new Exception("Mạng đứt quãng.");

                        fs.Write(buffer, 0, bytesRead);
                        totalBytesRead += bytesRead;
                    }
                }

                // Lưu thông tin người Upload vào file Metadata
                SaveMetadata(fileName, uploader);

                writer.WriteLine(Protocol.UPLOAD_SUCCESS);
                logCallback?.Invoke("Đã gửi UPLOAD_SUCCESS về Client");
                logCallback?.Invoke($"[UPLOAD] Thành công: Đã lưu '{fileName}' của '{uploader}' vào hệ thống.");
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
                writer.WriteLine($"{Protocol.DOWNLOAD_SUCCESS}{Protocol.DELIMITER}{fileSize}");

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
                string[] files = fileManager.GetFileListWithSize();
                StringBuilder response = new StringBuilder(Protocol.LIST_SUCCESS);

                foreach (string file in files)
                {
                    // Tách tên file và size (Giả sử FileManager trả về dạng "TenFile.ext#Size")
                    string[] fileInfo = file.Split('#');
                    string fName = fileInfo[0];
                    string fSize = fileInfo.Length > 1 ? fileInfo[1] : "0";

                    // Đọc thông tin người upload từ file Metadata
                    var meta = GetMetadata(fName);
                    string uploader = meta.Uploader;
                    string date = meta.UploadDate;
                    string path = $"/server/storage/uploads/{fName}";

                    //  Ghép chuỗi theo đúng cấu trúc Client đang chờ: FileName#Size#Username#UploadDate#ServerPath
                    response.Append(Protocol.DELIMITER);
                    response.Append($"{fName}#{fSize}#{uploader}#{date}#{path}");
                }

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

                string hashResult = fileManager.CalculateSHA256(fileName);

                writer.WriteLine($"{Protocol.HASH_SUCCESS}{Protocol.DELIMITER}{hashResult}");
                logCallback?.Invoke($"[HASH] Thành công: Đã gửi mã SHA256 của file '{fileName}' ({hashResult})");
            }
            catch (Exception ex)
            {
                logCallback?.Invoke($"[HASH] Lỗi khi xử lý tính toán file: {ex.Message}");
                writer.WriteLine(Protocol.HASH_ERROR);
            }
        }

        // ========================================================================
        // CÁC HÀM HỖ TRỢ LƯU VÀ ĐỌC THÔNG TIN NGƯỜI DÙNG (METADATA)
        // ========================================================================
        private void SaveMetadata(string fileName, string uploader)
        {
            try
            {
                string date = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                // Ghi vào file txt: Tên file | Tên người dùng | Ngày tháng
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
                        // Nếu tìm thấy file, lấy thông tin ra (Lấy bản mới nhất)
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
    }
}