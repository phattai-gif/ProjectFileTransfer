namespace ProjectFileTransferClient.Network
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

        public const string UPLOAD_SUCCESS = "UPLOAD_SUCCESS";
        public const string UPLOAD_ERROR = "UPLOAD_ERROR";

        public const string DOWNLOAD_SUCCESS = "DOWNLOAD_SUCCESS";
        public const string DOWNLOAD_ERROR = "DOWNLOAD_ERROR";

        public const string LIST_SUCCESS = "LIST_SUCCESS";

        public const string HASH_SUCCESS = "HASH_SUCCESS";
        public const string HASH_ERROR = "HASH_ERROR";
    }
}