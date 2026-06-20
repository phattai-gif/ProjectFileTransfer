using System;
using System.Net.Sockets;

namespace ProjectFileTransferClient.Network
{
    public class ClientManager
    {
        private TcpClient client;

        public bool Connect(string ip, int port)
        {
            try
            {
                client = new TcpClient();
                client.Connect(ip, port);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Disconnect()
        {
            if (client != null)
            {
                client.Close();
            }
        }

        public bool IsConnected()
        {
            return client != null && client.Connected;
        }
    }
}