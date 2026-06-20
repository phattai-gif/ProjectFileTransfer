using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace ProjectFileTransferServer.Network
{
    internal class ClientHandler
    {
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;

        public ClientHandler(TcpClient client)
        {
            this.client = client;

            NetworkStream stream = client.GetStream();

            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);

            writer.AutoFlush = true;
        }

        public void HandleClient()
        {
            while (true)
            {
                string command = reader.ReadLine();

                switch (command)
                {
                    case Protocol.CONNECT:
                        ProcessConnect();
                        break;

                    case Protocol.UPLOAD:
                        ProcessUpload();
                        break;

                    case Protocol.DOWNLOAD:
                        ProcessDownload();
                        break;

                    case Protocol.LIST:
                        ProcessList();
                        break;

                    case Protocol.HASH:
                        ProcessHash();
                        break;
                }
            }
        }

        private void ProcessConnect()
        {
            Console.WriteLine("Client connected: ");
        }

        private void ProcessUpload()
        {

        }

        private void ProcessDownload()
        {

        }

        private void ProcessList()
        {

        }

        private void ProcessHash()
        {

        }

    }
}
