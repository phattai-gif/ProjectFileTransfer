using ProjectFileTransferClient.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

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
            // Kiểm tra nếu không có hàng nào được chọn thì xóa trắng khung thông tin
            if (lvFiles.SelectedItems.Count == 0)
            {
                lblFileName.Text = "Tên file :";
                lblFileSize.Text = "Kích thước :";
                lblFileType.Text = "Loại file :";
                pictureBox1.Image = null; // Khung chứa ảnh đại diện file
                return;
            }

            // Lấy item đang được chọn đầu tiên
            ListViewItem item = lvFiles.SelectedItems[0];

            string fileName = item.Text;
            string fileSize = item.SubItems[1].Text;
            string fileExt = item.SubItems[2].Text;

            // 1. Hiển thị file: Cập nhật thông tin lên các Label giao diện
            lblFileName.Text = $"Tên file :  {fileName}";
            lblFileSize.Text = $"Kích thước :  {fileSize}";
            lblFileType.Text = $"Loại file :  {fileExt}";

            // Thay đổi Icon hình ảnh đại diện tùy thuộc vào đuôi định dạng file (.pdf, .mp4, ...)
            //switch (fileExt.ToLower())
            //{
            //    //Phần này chưa xong
            //    case ".pdf":
            //        picLogo.Image = Properties.Resources.Screenshot_2026_06_20_031745;
            //        break;
            //    case ".mp4":
            //    case ".avi":
            //        // picSelectedIcon.Image = Properties.Resources.video_icon;
            //        break;
            //    default:
            //        // picSelectedIcon.Image = Properties.Resources.default_file_icon;
            //        break;
            //}

            // Cập nhật tên file xuống khu vực "TIẾN TRÌNH TRUYỀN FILE" 
            lblTransferFileName.Text = fileName;
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
            frmConnect.UpdateDisconnectStatus();

            frmConnect.Show();

            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            clientManager.Disconnect();
            frmConnect.UpdateDisconnectStatus();
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

        private async void btnDownloadFile_Click(object sender, EventArgs e)
        {
            // 1. KIỂM TRA CHỌN FILE (Chỉ để ở đây, dùng luồng UI chính)
            if (lvFiles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một file từ danh sách để tải.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fileName = lvFiles.SelectedItems[0].Text;
            string fileExt = lvFiles.SelectedItems[0].SubItems[2].Text; // Lấy đuôi file từ cột thứ 3

            // 2. Chọn thư mục lưu 
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            saveFileDialog.Title = "Chọn thư mục và vị trí lưu file tải về";
            saveFileDialog.Filter = $"{fileExt.ToUpper()} Files (*{fileExt})|*{fileExt}|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return; // Người dùng hủy chọn thư mục lưu
            }

            string savePath = saveFileDialog.FileName;
            btnDownloadFile.Enabled = false; // Khóa nút tránh click trùng

            // Reset UI tiến trình truyền
            progressTransfer.Value = 0;
            lblTransferred.Text = "Bắt đầu tải xuống...";
            lblTransferFileName.Text = $"{fileName} (Đang tải xuống...)";

            // 3. Chạy đa luồng ngầm xử lý nhận dữ liệu và ghi file
            await Task.Run(() =>
            {
                try
                {
                    // Gửi yêu cầu tải file tới Server theo Protocol
                    string cmd = $"{Protocol.DOWNLOAD}{Protocol.DELIMITER}{fileName}";
                    clientManager.SendMessage(cmd);

                    // Nhận phản hồi từ Server
                    string response = clientManager.ReceiveMessage();

                    // Tách bằng cả ký tự DELIMITER (|) và dấu # để không bị lỗi cấu trúc chuỗi
                    string[] parts = response.Split(new char[] { Protocol.DELIMITER, '#' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts[0] == Protocol.DOWNLOAD_SUCCESS)
                    {
                        long fileSize = long.Parse(parts[1]);
                        NetworkStream stream = clientManager.GetStream();

                        FileReceiver receiver = new FileReceiver();

                        // Nhận chunk & Ghi file xuống máy
                        receiver.ReceiveFile(savePath, fileSize, stream, (received, total) =>
                        {
                            // Cập nhật phần trăm tiến trình lên UI giao diện chính
                            this.Invoke(new Action(() =>
                            {
                                int percent = (int)((received * 100) / total);
                                progressTransfer.Value = percent;

                                double receivedMB = received / 1024.0 / 1024.0;
                                double totalMB = total / 1024.0 / 1024.0;
                                lblTransferred.Text = $"Đã truyền: {receivedMB:F2} MB / {totalMB:F2} MB ({percent}%)";
                            }));
                        });

                        // Hoàn thành chu trình tải xuống
                        this.Invoke(new Action(() =>
                        {
                            lblTransferFileName.Text = $"{fileName} (Hoàn thành)";
                            MessageBox.Show($"Tải file '{fileName}' thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            MessageBox.Show("Server từ chối yêu cầu tải file hoặc file không tồn tại.", "Lỗi từ Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show($"Lỗi trong quá trình truyền dữ liệu: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
            });

            btnDownloadFile.Enabled = true; // Mở khóa lại nút sau khi hoàn thành
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

        private void progressTransfer_Click(object sender, EventArgs e)
        {

        }

        private void lblTransferStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
