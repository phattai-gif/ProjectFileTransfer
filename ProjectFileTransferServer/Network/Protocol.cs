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

        public const char DELIMITER = '|';

        // Upload
        public const string UPLOAD_SUCCESS = "UPLOAD_SUCCESS";
        public const string UPLOAD_ERROR = "UPLOAD_ERROR";

        //Download
        public const string DOWNLOAD_SUCCESS = "DOWNLOAD_SUCCESS";
        public const string DOWNLOAD_ERROR = "DOWNLOAD_ERROR";

        //List
        public const string LIST_SUCCESS = "LIST_SUCCESS";

        //Hash
        public const string HASH_SUCCESS = "HASH_SUCCESS";
        public const string HASH_ERROR = "HASH_ERROR";
    }
}