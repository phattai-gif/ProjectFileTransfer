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
            // LoadFileList();

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
          
            // Gửi lệnh LIST sang Server để yêu cầu danh sách file
            clientManager.SendMessage(Protocol.LIST);

            // Nhận chuỗi phản hồi từ Server
            string response = clientManager.ReceiveMessage();

            // Tách dữ liệu dựa theo ký tự phân cách (# hoặc ký tự DELIMITER)
            string[] parts = response.Split(Protocol.DELIMITER);

            // Kiểm tra Server trả về thành công
            if (parts[0] == Protocol.LIST_SUCCESS)
            {
                // Xóa danh sách cũ trên ListView
                lvFiles.Items.Clear();

                // Bắt đầu đọc từng file từ Server
                for (int i = 1; i < parts.Length; i++)
                {
                    // Ví dụ dữ liệu nhận:btnRefreshList.Text = "🔄 REFRESH";
                    // abc.pdf|24576

                    string[] fileInfo =parts[i].Split('#');

                    // Tên file
                    string fileName =
                        fileInfo[0];

                    // Giá trị mặc định nếu không có kích thước
                    string fileSize = "0 KB";

                    // Nếu Server gửi kích thước
                    if (fileInfo.Length > 1)
                    {
                        long size = long.Parse(fileInfo[1]);

                        if (size < 1024)
                        {
                            fileSize = size + " B";
                        }
                        else if (size < 1024 * 1024)
                        {
                            fileSize =
                                (size / 1024.0).ToString("F2") + " KB";
                        }
                        else
                        {
                            fileSize =
                                (size / 1024.0 / 1024.0).ToString("F2") + " MB";
                        }
                    }

                    // Tạo dòng mới trong ListView
                    ListViewItem item =
                        new ListViewItem(fileName);

                    // Cột Kích thước
                    item.SubItems.Add(fileSize);

                    // Cột Loại file (.pdf .docx ...)
                    item.SubItems.Add(
                        Path.GetExtension(fileName));

                    // Cột ngày upload
                    item.SubItems.Add(
                        DateTime.Now.ToString("dd/MM/yyyy"));

                    // Thêm dòng vào ListView
                    lvFiles.Items.Add(item);
                }

                // Hiển thị tổng số file
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

        private void btnRefreshList_Click_1(object sender, EventArgs e)
        {

        }

        private void btnUploaddown_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog open =
                    new OpenFileDialog();

                if (open.ShowDialog() ==
                    DialogResult.OK)
                {
                    bool result =
                        clientManager.UploadFile(
                            open.FileName);

                    if (result)
                    {
                        MessageBox.Show(
                            "Upload thành công.");

                        LoadFileList();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Upload thất bại.");
                    }
                }
            }
        }

        private void btnDownloadFile_Click(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    "Chọn file cần tải.");

                return;
            }

            string fileName =
                lvFiles.SelectedItems[0].Text;

            SaveFileDialog save =
                new SaveFileDialog();

            save.FileName = fileName;

            if (save.ShowDialog()
                == DialogResult.OK)
            {
                bool result =
                    clientManager.DownloadFile(
                        fileName,
                        save.FileName);

                if (result)
                {
                    MessageBox.Show(
                        "Download thành công.");
                }
                else
                {
                    MessageBox.Show(
                        "Download thất bại.");
                }
            }
        }
        

        private void btnLogout2_Click(object sender, EventArgs e)
        {
            clientManager.Disconnect();

            frmConnect.Show();

            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
