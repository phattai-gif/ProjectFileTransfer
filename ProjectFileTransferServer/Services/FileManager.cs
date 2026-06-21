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
            if (!Directory.Exists(storageFolderPath))
            {
                return new string[0];
            }

            // Lấy toàn bộ đường dẫn file đầy đủ
            string[] fullPaths = Directory.GetFiles(storageFolderPath);
            string[] fileNames = new string[fullPaths.Length];

            // Chỉ lọc lấy tên file và phần mở rộng (bỏ đường dẫn thư mục cha)
            for (int i = 0; i < fullPaths.Length; i++)
            {
                fileNames[i] = Path.GetFileName(fullPaths[i]);
            }
            return fileNames;
        }

    }
}