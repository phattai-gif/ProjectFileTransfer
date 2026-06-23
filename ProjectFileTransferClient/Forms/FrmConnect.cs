using ProjectFileTransferClient.Forms;
using ProjectFileTransferClient.Network;
using System.Drawing;
namespace ProjectFileTransferClient
{
    public partial class FrmConnect : Form
    {
        private ClientManager clientManager;
        public FrmConnect()
        {
            InitializeComponent();  
            clientManager = new ClientManager();
        }

        private void FrmConnect_Load(object sender, EventArgs e)
        {

        }

        private void FrmConnect_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grpConnection_Enter(object sender, EventArgs e)
        {

        }

        private void lblIP_Click(object sender, EventArgs e)
        {

        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void lblicon1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
        //Tao hàm connect
        private void btnConnect_Click(object? sender, EventArgs e)
        {
            string ip = txtIP.Text.Trim();

            if (!int.TryParse(txtPort.Text.Trim(), out int port))
            {
                MessageBox.Show("Port không hợp lệ!");
                return;
            }

            bool result = clientManager.Connect(ip, port);

            if (result)
            {
                clientManager.SendMessage("CONNECT");

                lblStatus.Text = "🟢 Connected";
                lblStatus.ForeColor = Color.Green;

                FrmMain frm = new FrmMain(clientManager, this);
                frm.Show();

                this.Hide();
            }
            else
            {
                lblStatus.Text = "🔴 Connection Failed";
                lblStatus.ForeColor = Color.Red;
            }
        }
        //Ham disconnect
        private void btnDisconnect_Click(object? sender, EventArgs e)
        {
            clientManager.Disconnect();

            lblStatus.Text = "🔴 Disconnected";
            lblStatus.ForeColor = Color.Red;

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
        }
    }
}
