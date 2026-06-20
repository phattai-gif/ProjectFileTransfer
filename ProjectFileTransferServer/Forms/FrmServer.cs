using ProjectFileTransferServer.Network;
namespace ProjectFileTransferServer
{
    public partial class FrmServer : Form
    {
        private ServerManager serverManager;
        public FrmServer()
        {
            InitializeComponent();
            serverManager = new ServerManager();
            btnStopServer.Enabled = false;
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            serverManager.StartServer();
            txtStatus.AppendText("Server started...\r\n");
            txtStatus.AppendText("Listening on port 8888...\r\n");

            btnStartServer.Enabled = false;
            btnStopServer.Enabled = true;
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            serverManager.StopServer();
            txtStatus.AppendText("Server stopped...\r\n");

            btnStartServer.Enabled = true;
            btnStopServer.Enabled = false;
        }

        private void FrmServer_Load(object sender, EventArgs e)
        {

        }
    }
}
