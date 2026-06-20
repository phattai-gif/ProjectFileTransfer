using System.Net.Sockets;

namespace ProjectFileTransferClient
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            TcpClient client = new TcpClient();

            client.Connect("127.0.0.1", 8888);

            Console.WriteLine("Connected!");
        }
    }
}