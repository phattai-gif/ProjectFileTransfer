using System;
using System.IO;
using System.Net.Sockets;

namespace ProjectFileTransferClient.Network
{
    public class FileSender
    {
        public void SendFile(string filePath, NetworkStream stream, Action<long, long> progressCallback)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                long totalBytes = fs.Length;
                long sentBytes = 0;

                // Khởi tạo buffer 8KB cho mỗi chunk truyền đi
                byte[] buffer = new byte[8192];
                int bytesRead;

                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    // Gửi chunk dữ liệu qua Socket
                    stream.Write(buffer, 0, bytesRead);
                    stream.Flush();

                    // Tích lũy số lượng byte đã gửi thành công
                    sentBytes += bytesRead;

                    // Gọi Callback để bắn số liệu ngược về luồng UI trên Form
                    progressCallback?.Invoke(sentBytes, totalBytes);
                }
            }
        }
    }
}