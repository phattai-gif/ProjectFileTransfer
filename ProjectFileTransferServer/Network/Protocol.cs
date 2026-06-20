using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFileTransferServer.Network
{
    internal class Protocol
    {
        public const int PORT = 8888;
        public const int BUFFER_SIZE = 4096;

        public const string CONNECT = "CONNECT";
        public const string UPLOAD = "UPLOAD";
        public const string DOWNLOAD = "DOWNLOAD";
        public const string LIST = "LIST";
        public const string HASH = "HASH";
    }
}
