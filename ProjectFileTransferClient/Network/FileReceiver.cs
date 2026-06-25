using System;
using System.IO;
using System.Net.Sockets;

namespace ProjectFileTransferClient.Network
{
    public class FileReceiver
    {
        // Thêm tham số thứ 4: Action<long, long> progressCallback
        public void ReceiveFile(string savePath, long fileSize, NetworkStream stream, Action<long, long> progressCallback)
        {
            long totalBytesReceived = 0;

            using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[8192]; // Đọc theo từng chunk 8KB
                int bytesRead;

                while (totalBytesReceived < fileSize && (bytesRead = stream.Read(buffer, 0, (int)Math.Min(buffer.Length, fileSize - totalBytesReceived))) > 0)
                {
                    fs.Write(buffer, 0, bytesRead);
                    totalBytesReceived += bytesRead;

                    // Gọi callback báo cáo số byte đã nhận về UI theo thời gian thực
                    progressCallback?.Invoke(totalBytesReceived, fileSize);
                }
                fs.Flush();
            }
        }
    }
}