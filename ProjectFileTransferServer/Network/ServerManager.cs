using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ProjectFileTransferServer.Network
{
    internal class ServerManager
    {
        private TcpListener listener;

        public void StartServer()
        {
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
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();

                ClientHandler handler = new ClientHandler(client);

                Task.Run(() =>
                {
                    handler.HandleClient();
                });
            }
        }
    }
}   
