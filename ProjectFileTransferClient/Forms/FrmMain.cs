using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProjectFileTransferClient.Network;
using System.IO;

namespace ProjectFileTransferClient.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain(ClientManager manager, FrmConnect connectForm)
        {
            InitializeComponent();

            clientManager = manager;
            frmConnect = connectForm;
          
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadFileList();
            ////////////////
            dgvHistory.ColumnHeadersDefaultCellStyle.Font =
    new Font("Segoe UI", 10, FontStyle.Bold);

            dgvHistory.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvHistory.RowTemplate.Height = 35;

            dgvHistory.EnableHeadersVisualStyles = false;
        }
        //===========================================================//
        private ClientManager clientManager;//khaibao clientManager
        private FrmConnect frmConnect;
        //===========================================================//
        //đóng FrmMain thì hiện lại FrmConnect//
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //===========================================================//
        //HÀM LOADFILELIST=========================================//
        private void LoadFileList()
        {
            clientManager.SendMessage(Protocol.LIST);

            string response =
                clientManager.ReceiveMessage();

            string[] parts =
                response.Split(Protocol.DELIMITER);

            if (parts[0] == Protocol.LIST_SUCCESS)
            {
                lvFiles.Items.Clear();

                for (int i = 1; i < parts.Length; i++)
                {
                    string fileName = parts[i];

                    ListViewItem item =
                        new ListViewItem(fileName);

                    item.SubItems.Add("-");
                    item.SubItems.Add(
                        Path.GetExtension(fileName));

                    item.SubItems.Add(
                        DateTime.Now.ToString("dd/MM/yyyy"));

                    lvFiles.Items.Add(item);
                }

                lblTotalFiles.Text =
                    (parts.Length - 1).ToString();
            }
        }
        //===========================================================//

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void picLogo_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void grpFileList_Enter(object sender, EventArgs e)
        {

        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTextFile_Click(object sender, EventArgs e)
        {

        }

        private void pnlDownload_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void grpStatistics_Enter(object sender, EventArgs e)
        {

        }

        private void lblTransferred_Click(object sender, EventArgs e)
        {

        }

        private void grpTransfer_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblRemainTitle_Click(object sender, EventArgs e)
        {

        }

        private void dgvHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            clientManager.Disconnect();

            frmConnect.Show();

            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            clientManager.Disconnect();

            frmConnect.Show();
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            LoadFileList();
        }
    }
}
