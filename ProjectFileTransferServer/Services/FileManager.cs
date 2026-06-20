using System;
using System.IO;

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
    }
}