using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectFileTransferServer.Network
{
    internal class ServerManager
    {
        private TcpListener listener;
        private Action<string> onLogReceived; // Nhận callback từ Form gửi vào

        public void StartServer(Action<string> logCallback)
        {
            this.onLogReceived = logCallback;
            listener = new TcpListener(IPAddress.Any, Protocol.PORT);
            listener.Start();
            MessageBox.Show("Server started on port 8888");

            Task.Run(() => AcceptClients());
        }

        public void StopServer()
        {
            if (listener != null)
            {
                listener.Stop();
                listener = null;
            }
        }

        public void AcceptClients()
        {
            try
            {
                while (listener != null)
                {
                    TcpClient client = listener.AcceptTcpClient();

                    // Truyền callback log vào từng client handler
                    ClientHandler handler = new ClientHandler(client, onLogReceived);

                    Task.Run(() => handler.HandleClient());
                }
            }
            catch (Exception)
            {
                // Khi stop server listener.AcceptTcpClient() sẽ ném ngoại lệ -> bỏ qua an toàn
            }
        }
    }
}