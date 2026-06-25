using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ProjectFileTransferServer.Services
{
    internal class FileManager
    {
        private readonly string storageFolderPath;

        public FileManager()
        {
            // Trỏ trực tiếp vào thư mục Storage nằm tại nơi thực thi ứng dụng Server
            storageFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Storage");

            // Nếu chưa có thư mục Storage thì tự động tạo mới
            if (!Directory.Exists(storageFolderPath))
            {
                Directory.CreateDirectory(storageFolderPath);
            }
        }

        public FileStream CreateFileStream(string fileName)
        {
            string filePath = Path.Combine(storageFolderPath, fileName);
            return new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
        }

        public bool FileExists(string fileName)
        {
            string filePath = Path.Combine(storageFolderPath, fileName);
            return File.Exists(filePath);
        }

        public long GetFileSize(string fileName)
        {
            string filePath = Path.Combine(storageFolderPath, fileName);
            return new FileInfo(filePath).Length;
        }

        public FileStream OpenFileStreamForRead(string fileName)
        {
            string filePath = Path.Combine(storageFolderPath, fileName);
            return new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        }
        public string[] GetFileList()
        {
            //Kiểm tra thư mục Storage (Kiểm tra thư mục Storage có tồn tại không.Nếu không có thì trả về mảng rỗng.)
            if (!Directory.Exists(storageFolderPath))
                return new string[0];
            //Lấy tất cả file
            string[] files = Directory.GetFiles(storageFolderPath);
            //Tạo mảng kết quả
            string[] result = new string[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                //đọc thông tin file
                FileInfo info = new FileInfo(files[i]);

                result[i] = info.Name + "#" + info.Length;
            }

            return result;
        }
        // ======================================================
        // HÀM LẤY DANH SÁCH FILE KÈM KÍCH THƯỚC TỪ THƯ MỤC STORAGE
        public string[] GetFileListWithSize()
        {
            // Lấy toàn bộ đường dẫn file trong Storage
            string[] fullPaths = Directory.GetFiles(storageFolderPath);

            // Mảng kết quả gửi về Client
            string[] result = new string[fullPaths.Length];

            // Duyệt từng file
            for (int i = 0; i < fullPaths.Length; i++)
            {
                // Lấy thông tin file
                FileInfo info = new FileInfo(fullPaths[i]);

                // Ghép tên file và kích thước
                result[i] = info.Name + "#" + info.Length;
            }

            return result;
        }
        public string CalculateSHA256(string fileName)
        {
            string filePath = Path.Combine(storageFolderPath, fileName);
            if (!File.Exists(filePath)) return string.Empty;

            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hashBytes = sha256.ComputeHash(stream);

                    // Chuyển mảng byte thu được thành chuỗi Hex (ký tự liền nhau)
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        sb.Append(b.ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
        }

    }
}