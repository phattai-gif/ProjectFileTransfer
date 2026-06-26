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
        private List<ListViewItem> allFiles = new List<ListViewItem>(); //Lưu toàn bộ danh sách file gốc.
        public FrmMain(ClientManager manager, FrmConnect connectForm)
        {
            InitializeComponent();

            clientManager = manager;
            frmConnect = connectForm;

        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadFileList();

            dgvHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvHistory.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            dgvHistory.RowTemplate.Height = 35;

            dgvHistory.EnableHeadersVisualStyles = false;
        }

        private ClientManager clientManager;//khaibao clientManager
        private FrmConnect frmConnect;

        // Lớp lưu trữ trạng thái tiến trình của từng file riêng biệt
        public class TransferProgressState
        {
            public string FileName { get; set; }
            public int Percent { get; set; } = 0;
            public string TransferredText { get; set; } = "Đã truyền: 0,00 MB / 0,00 MB";
            public string RemainingText { get; set; } = "Còn lại: 0,00 MB";
            public string SpeedText { get; set; } = "0,00 MB/s";
            public string ElapsedText { get; set; } = "00:00:00";
            public string RemainTimeText { get; set; } = "00:00:00";
            public string StateText { get; set; } = "Sẵn sàng";
        }

        // Từ điển quản lý bộ nhớ tiến trình (Key là tên file)
        private Dictionary<string, TransferProgressState> fileProgresses = new Dictionary<string, TransferProgressState>();

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
                allFiles.Clear(); //kho dữ liệu" để tìm kiếm.

                // Bắt đầu đọc từng file từ Server
                for (int i = 1; i < parts.Length; i++)
                {
                    // Ví dụ dữ liệu nhận:btnRefreshList.Text = "🔄 REFRESH";
                    // abc.pdf|24576

                    string[] fileInfo = parts[i].Split('#');

                    // Tên file
                    string fileName = fileInfo[0];

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

                    allFiles.Add((ListViewItem)item.Clone()); //Lưu toàn bộ danh sách file gốc.
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

            // --- ĐỌC TIẾN TRÌNH RIÊNG BIỆT CỦA FILE ĐƯỢC CHỌN ---
            if (fileProgresses.ContainsKey(fileName))
            {
                // Nếu file này đã hoặc đang chạy truyền dữ liệu, bốc dữ liệu cũ đắp lên UI
                var state = fileProgresses[fileName];

                lblTransferFileName.Text = $"{state.FileName} ({state.StateText})";
                progressTransfer.Value = state.Percent;
                lblTransferred.Text = state.TransferredText;
                lblRemaining.Text = state.RemainingText;
                lblSpeed.Text = state.SpeedText;
                lblElapsed.Text = state.ElapsedText;
                lblRemainTime.Text = state.RemainTimeText;
                lblState.Text = state.StateText;
            }
            else
            {
                // Nếu file này chưa từng được bấm tải/gửi, trả các thanh về trạng thái trống mặc định
                lblTransferFileName.Text = fileName;
                progressTransfer.Value = 0;
                lblTransferred.Text = "Đã truyền: 0,00 MB / 0,00 MB";
                lblRemaining.Text = "Còn lại: 0,00 MB";
                lblSpeed.Text = "0,00 MB/s";
                lblElapsed.Text = "00:00:00";
                lblRemainTime.Text = "00:00:00";
                lblState.Text = "Sẵn sàng";
            }
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

        private async void btnUploaddown_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Chọn file cần upload lên Server";
            open.Filter = "All files (*.*)|*.*";

            if (open.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = open.FileName;
                string fileName = Path.GetFileName(localFilePath);

                btnUploaddown.Enabled = false;

                // Khởi tạo trạng thái file vào Dictionary
                if (!fileProgresses.ContainsKey(fileName)) fileProgresses[fileName] = new TransferProgressState();
                fileProgresses[fileName].FileName = fileName;
                fileProgresses[fileName].StateText = "Đang tải lên...";

                await Task.Run(() =>
                {
                    try
                    {
                        NetworkStream stream = clientManager.GetStream();
                        if (stream != null)
                        {
                            while (stream.DataAvailable) { clientManager.ReceiveMessage(); }
                        }

                        FileInfo fileInfo = new FileInfo(localFilePath);
                        long fileSize = fileInfo.Length;

                        string cmd = $"{Protocol.UPLOAD}{Protocol.DELIMITER}{fileName}{Protocol.DELIMITER}{fileSize}";
                        clientManager.SendMessage(cmd);

                        string response = clientManager.ReceiveMessage();
                        string[] parts = response.Split(new char[] { Protocol.DELIMITER, '#' }, StringSplitOptions.RemoveEmptyEntries);

                        if (parts[0] == "UPLOAD_SUCCESS" || parts[0] == "OK" || parts[0] == Protocol.UPLOAD)
                        {
                            FileSender senderFile = new FileSender();
                            DateTime startTime = DateTime.Now;

                            // Khai báo một biến để theo dõi dung lượng cập nhật lần trước 
                            long lastReportedBytes = 0;

                            senderFile.SendFile(localFilePath, stream, (sentBytes, totalBytes) =>
                            {
                                if (sentBytes - lastReportedBytes < 500 * 1024 && sentBytes < totalBytes)
                                {
                                    return; 
                                }
                                lastReportedBytes = sentBytes; // Cập nhật mốc đánh dấu mới

                                int percent = (int)(((double)sentBytes / totalBytes) * 100);
                                if (percent > 100) percent = 100;

                                double sentMB = sentBytes / 1024.0 / 1024.0;
                                double totalMB = totalBytes / 1024.0 / 1024.0;
                                double remainingMB = totalMB - sentMB;

                                double elapsedSeconds = (DateTime.Now - startTime).TotalSeconds;
                                string speedStr = "0,00 MB/s";
                                string remainTimeStr = "00:00:00";
                                if (elapsedSeconds > 0)
                                {
                                    double speedValue = sentMB / elapsedSeconds;
                                    speedStr = $"{speedValue:F2} MB/s";
                                    if (speedValue > 0)
                                    {
                                        remainTimeStr = TimeSpan.FromSeconds(remainingMB / speedValue).ToString(@"hh\:mm\:ss");
                                    }
                                }
                                string elapsedStr = TimeSpan.FromSeconds(elapsedSeconds).ToString(@"hh\:mm\:ss");

                                var state = fileProgresses[fileName];
                                state.Percent = percent;
                                state.TransferredText = $"Đã truyền: {sentMB:F2} MB / {totalMB:F2} MB";
                                state.RemainingText = $"Còn lại: {remainingMB:F2} MB";
                                state.SpeedText = speedStr;
                                state.ElapsedText = elapsedStr;
                                state.RemainTimeText = remainTimeStr;
                                state.StateText = "Đang tải lên...";

                                this.Invoke(new Action(() =>
                                {
                                    lblTransferFileName.Text = $"{fileName} (Đang tải lên...)";
                                    progressTransfer.Value = state.Percent;
                                    lblPercent.Text = $"{state.Percent}%"; 

                                    lblTransferred.Text = state.TransferredText;
                                    lblRemaining.Text = state.RemainingText;
                                    lblSpeed.Text = state.SpeedText;
                                    lblElapsed.Text = state.ElapsedText;
                                    lblRemainTime.Text = state.RemainTimeText;
                                    lblState.Text = state.StateText;
                                }));
                            });

                            // Hoàn thành chu trình tải lên
                            var finalState = fileProgresses[fileName];
                            finalState.StateText = "Hoàn thành";
                            finalState.Percent = 100;

                            this.Invoke(new Action(() =>
                            {
                                lblTransferFileName.Text = $"{fileName} (Hoàn thành)";
                                lblState.Text = "Hoàn thành";
                                progressTransfer.Value = 100;

                                MessageBox.Show("Upload file thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadFileList();
                            }));
                        }
                        else
                        {
                            this.Invoke(new Action(() => MessageBox.Show("Server từ chối yêu cầu upload file.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Invoke(new Action(() => MessageBox.Show($"Lỗi truyền dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                    }
                });

                btnUploaddown.Enabled = true;
            }
        }

        private async void btnDownloadFile_Click(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một file từ danh sách để tải.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fileName = lvFiles.SelectedItems[0].Text;
            string fileExt = lvFiles.SelectedItems[0].SubItems[2].Text;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            saveFileDialog.Title = "Chọn thư mục và vị trí lưu file tải về";
            saveFileDialog.Filter = $"{fileExt.ToUpper()} Files (*{fileExt})|*{fileExt}|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            string savePath = saveFileDialog.FileName;
            btnDownloadFile.Enabled = false;

            // Khởi tạo nhanh trạng thái ban đầu cho file này trong Dictionary
            if (!fileProgresses.ContainsKey(fileName)) fileProgresses[fileName] = new TransferProgressState();
            fileProgresses[fileName].FileName = fileName;
            fileProgresses[fileName].StateText = "Đang tải xuống...";

            await Task.Run(() =>
            {
                try
                {
                    NetworkStream stream = clientManager.GetStream();
                    if (stream != null)
                    {
                        while (stream.DataAvailable) { clientManager.ReceiveMessage(); }
                    }

                    string cmd = $"{Protocol.DOWNLOAD}{Protocol.DELIMITER}{fileName}";
                    clientManager.SendMessage(cmd);

                    string response = clientManager.ReceiveMessage();
                    string[] parts = response.Split(new char[] { Protocol.DELIMITER, '#' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts[0] == Protocol.DOWNLOAD_SUCCESS)
                    {
                        long fileSize = long.Parse(parts[1]);
                        FileReceiver receiver = new FileReceiver();
                        DateTime startTime = DateTime.Now;

                        // Khai báo biến mốc trước khi gọi ReceiveFile
                        long lastReportedBytes = 0;

                        receiver.ReceiveFile(savePath, fileSize, stream, (received, total) =>
                        {
                            if (received - lastReportedBytes < 500 * 1024 && received < total)
                            {
                                return;
                            }
                            lastReportedBytes = received;

                            int percent = (int)(((double)received / total) * 100);
                            if (percent > 100) percent = 100;

                            double receivedMB = received / 1024.0 / 1024.0;
                            double totalMB = total / 1024.0 / 1024.0;
                            double remainingMB = totalMB - receivedMB;

                            double elapsedSeconds = (DateTime.Now - startTime).TotalSeconds;
                            string speedStr = "0,00 MB/s";
                            string remainTimeStr = "00:00:00";
                            if (elapsedSeconds > 0)
                            {
                                double speedValue = receivedMB / elapsedSeconds;
                                speedStr = $"{speedValue:F2} MB/s";
                                if (speedValue > 0)
                                {
                                    remainTimeStr = TimeSpan.FromSeconds(remainingMB / speedValue).ToString(@"hh\:mm\:ss");
                                }
                            }
                            string elapsedStr = TimeSpan.FromSeconds(elapsedSeconds).ToString(@"hh\:mm\:ss");

                            var state = fileProgresses[fileName];
                            state.Percent = percent;
                            state.TransferredText = $"Đã truyền: {receivedMB:F2} MB / {totalMB:F2} MB";
                            state.RemainingText = $"Còn lại: {remainingMB:F2} MB";
                            state.SpeedText = speedStr;
                            state.ElapsedText = elapsedStr;
                            state.RemainTimeText = remainTimeStr;
                            state.StateText = "Đang tải xuống...";

                            this.Invoke(new Action(() =>
                            {
                                if (lvFiles.SelectedItems.Count > 0 && lvFiles.SelectedItems[0].Text == fileName)
                                {
                                    lblTransferFileName.Text = $"{fileName} (Đang tải xuống...)";
                                    progressTransfer.Value = state.Percent;
                                    lblPercent.Text = $"{state.Percent}%"; 

                                    lblTransferred.Text = state.TransferredText;
                                    lblRemaining.Text = state.RemainingText;
                                    lblSpeed.Text = state.SpeedText;
                                    lblElapsed.Text = state.ElapsedText;
                                    lblRemainTime.Text = state.RemainTimeText;
                                    lblState.Text = state.StateText;
                                }
                            }));
                        });

                        // Hoàn thành chu trình tải
                        var finalState = fileProgresses[fileName];
                        finalState.StateText = "Hoàn thành";
                        finalState.Percent = 100;

                        this.Invoke(new Action(() =>
                        {
                            if (lvFiles.SelectedItems.Count > 0 && lvFiles.SelectedItems[0].Text == fileName)
                            {
                                lblTransferFileName.Text = $"{fileName} (Hoàn thành)";
                                lblState.Text = "Hoàn thành";
                                progressTransfer.Value = 100;
                            }
                            MessageBox.Show($"Tải file '{fileName}' thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() => MessageBox.Show("Server từ chối yêu cầu tải file.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() => MessageBox.Show($"Lỗi truyền dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                }
            });

            btnDownloadFile.Enabled = true;
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
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower();

            foreach (ListViewItem item in lvFiles.Items)
            {
                if (item.Text.ToLower().Contains(keyword))
                {
                    item.BackColor = Color.LightYellow;
                }
                else
                {
                    item.BackColor = Color.White;
                }
            }
        }

        private void lblSpeed_Click(object sender, EventArgs e)
        {

        }

        private void lblElapsed_Click(object sender, EventArgs e)
        {

        }

        private void lblSpeedTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
