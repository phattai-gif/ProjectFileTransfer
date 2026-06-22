using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectFileTransferServer.Network
{
    internal class ServerManager
    {
        private TcpListener listener;
        private Action<string> onLogReceived;

        // --- KHAI BÁO DANH SÁCH LƯU CLIENT---
        private List<string> connectedClients = new List<string>();
        private Action<List<string>> onClientListChanged; // Callback cập nhật UI

        // Thêm tham số nhận callback danh sách client vào hàm StartServer
        public void StartServer(Action<string> logCallback, Action<List<string>> clientListCallback)
        {
            this.onLogReceived = logCallback;
            this.onClientListChanged = clientListCallback;

            listener = new TcpListener(IPAddress.Any, Protocol.PORT);
            listener.Start();

            Task.Run(() => AcceptClient());
        }

        public void AcceptClient()
        {
            try
            {
                while (listener != null)
                {
                    TcpClient client = listener.AcceptTcpClient();

                    var clientEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                    string clientInfo = clientEndPoint != null ? clientEndPoint.ToString() : "Unknown";

                    // --- LƯU CLIENT VÀO DANH SÁCH KHI KẾT NỐI ---
                    lock (connectedClients)
                    {
                        connectedClients.Add(clientInfo);
                        // Kích hoạt callback đẩy danh sách mới về cho UI cập nhật
                        onClientListChanged?.Invoke(new List<string>(connectedClients));
                    }

                    onLogReceived?.Invoke($"[CONNECT] Đã chấp nhận kết nối từ: {clientInfo}");

                    // Truyền thêm hành động xóa client khi client ngắt kết nối vào Handler
                    ClientHandler handler = new ClientHandler(client, onLogReceived, () => RemoveClient(clientInfo));

                    Task.Run(() => handler.HandleClient());
                }
            }
            catch (Exception) { }
        }

        // --- XÓA CLIENT KHỎI DANH SÁCH KHI ĐỨT KẾT NỐI ---
        private void RemoveClient(string clientInfo)
        {
            lock (connectedClients)
            {
                if (connectedClients.Contains(clientInfo))
                {
                    connectedClients.Remove(clientInfo);
                    onClientListChanged?.Invoke(new List<string>(connectedClients));
                }
            }
        }

        public void StopServer()
        {
            try
            {
                listener?.Stop();
                listener = null;
                lock (connectedClients)
                {
                    connectedClients.Clear();
                    onClientListChanged?.Invoke(new List<string>(connectedClients));
                }
            }
            catch (Exception) { }
        }
    }
}