using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjectFileTransferClient.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            dgvHistory.Rows.Add(
     "BaoCao_DoAn.pdf",
     "PDF",
     "Upload thành công",
     "09:48");

            dgvHistory.Rows.Add(
                "Video_HoiThao.mp4",
                "MP4",
                "Download 72%",
                "10:15");

            dgvHistory.Rows.Add(
                "HinhAnh.zip",
                "ZIP",
                "Upload thành công",
                "08:30");

            dgvHistory.Rows.Add(
                "TaiLieu.docx",
                "DOCX",
                "Download thành công",
                "22:10");
            ////////////////
            dgvHistory.ColumnHeadersDefaultCellStyle.Font =
    new Font("Segoe UI", 10, FontStyle.Bold);

            dgvHistory.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvHistory.RowTemplate.Height = 35;

            dgvHistory.EnableHeadersVisualStyles = false;
        }

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

        }
    }
}
