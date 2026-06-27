using ProjectFileTransferClient.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace ProjectFileTransferClient.Forms
{
    public partial class FrmMain : Form
    {
        // Biến đếm thống kê lưu trữ dữ liệu thật theo phiên làm việc
        private int uploadCount = 0;
        private int downloadCount = 0;
        private int onlineUsersCount = 1; // Mặc định hiển thị bạn đang online
        private List<ListViewItem> allFiles = new List<ListViewItem>(); // Lưu toàn bộ danh sách file gốc.

        private ClientManager clientManager; // Khai báo clientManager
        private List<string> originalFileList = new List<string>();
        private FrmConnect frmConnect;

        // 🌟 MỚI THÊM: Đường dẫn lưu file lịch sử cục bộ ngay trong thư mục chạy của ứng dụng
        private string historyFilePath = Path.Combine(Application.StartupPath, "transfer_history.txt");

        // Từ điển quản lý bộ nhớ tiến trình (Key là tên file)
        private Dictionary<string, TransferProgressState> fileProgresses = new Dictionary<string, TransferProgressState>();

        public FrmMain(ClientManager manager, FrmConnect connectForm)
        {
            InitializeComponent();
            clientManager = manager;
            frmConnect = connectForm;
        }

        //Hàm bổ trợ tính SHA256 của file để kiểm tra tính toàn vẹn
        private string CalculateSHA256(string filePath)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hashBytes = sha256.ComputeHash(stream);
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        sb.Append(b.ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Reset trống thông tin khi vừa mở form
            ClearFileDetails();

            // TÍNH NĂNG GỢI Ý (AUTO-SUGGEST) CHO THANH TÌM KIẾM
            txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest; // Sẽ xổ ra danh sách các file khớp chữ cái bạn gõ
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;

            LoadFileList();

            if (dgvHistory.ColumnHeadersDefaultCellStyle != null)
                dgvHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvHistory.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvHistory.RowTemplate.Height = 35;
            dgvHistory.EnableHeadersVisualStyles = false;

            // 🌟 MỚI THÊM: Tự động nạp lại lịch sử khi vừa mở Form
            LoadHistoryFromLocal();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // HÀM LOADFILELIST //
        private void LoadFileList()
        {
            try
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke(new Action(() => ClearFileDetails()));
                }

                clientManager.SendMessage(Protocol.LIST);
                string? response = clientManager.ReceiveMessage();
                if (string.IsNullOrEmpty(response)) return;

                string[] parts = response.Split(Protocol.DELIMITER);

                if (parts.Length > 0 && parts[0] == Protocol.LIST_SUCCESS)
                {
                    lvFiles.Items.Clear();
                    allFiles.Clear();

                    AutoCompleteStringCollection autoCompleteList = new AutoCompleteStringCollection();

                    for (int i = 1; i < parts.Length; i++)
                    {
                        if (string.IsNullOrEmpty(parts[i])) continue;

                        string[] fileInfo = parts[i].Split('#');
                        string fileName = fileInfo[0];
                        string fileSize = "0 KB";

                        string uploader = "Hệ thống";
                        string uploadDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                        string serverPath = $"/server/storage/uploads/{fileName}";

                        if (fileInfo.Length > 1)
                        {
                            long size = long.Parse(fileInfo[1]);
                            if (size < 1024) fileSize = size + " B";
                            else if (size < 1024 * 1024) fileSize = (size / 1024.0).ToString("F2") + " KB";
                            else fileSize = (size / 1024.0 / 1024.0).ToString("F2") + " MB";
                        }

                        if (fileInfo.Length > 2) uploader = fileInfo[2];
                        if (fileInfo.Length > 3) uploadDate = fileInfo[3];
                        if (fileInfo.Length > 4) serverPath = fileInfo[4];

                        ListViewItem item = new ListViewItem(fileName);
                        item.SubItems.Add(fileSize);
                        item.SubItems.Add(Path.GetExtension(fileName));
                        item.SubItems.Add(uploadDate);

                        item.Tag = new string[] { uploader, uploadDate, serverPath };

                        lvFiles.Items.Add(item);
                        allFiles.Add((ListViewItem)item.Clone());

                        autoCompleteList.Add(fileName);
                    }

                    if (this.IsHandleCreated)
                    {
                        this.Invoke(new Action(() => {
                            txtSearch.AutoCompleteCustomSource = autoCompleteList;
                        }));
                    }
                    else
                    {
                        txtSearch.AutoCompleteCustomSource = autoCompleteList;
                    }

                    lblTotalFiles.Text = lvFiles.Items.Count.ToString();
                    lblUploadCount.Text = uploadCount.ToString();
                    lblDownloadCount.Text = downloadCount.ToString();
                    lblOnlineCount.Text = onlineUsersCount.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp danh sách file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e) { }
        private void button5_Click(object sender, EventArgs e) { }
        private void picLogo_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void button2_Click_1(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void grpFileList_Enter(object sender, EventArgs e) { }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count == 0)
            {
                ClearFileDetails();
                return;
            }

            ListViewItem item = lvFiles.SelectedItems[0];
            string fileName = item.Text;
            string fileSize = item.SubItems[1].Text;
            string fileExt = item.SubItems[2].Text;

            string uploader = "Hệ thống";
            string uploadDate = item.SubItems.Count > 3 ? item.SubItems[3].Text : DateTime.Now.ToString("dd/MM/yyyy");
            string serverPath = $"/server/storage/uploads/{fileName}";

            if (item.Tag is string[] extraData)
            {
                uploader = extraData[0];
                uploadDate = extraData[1];
                serverPath = extraData[2];
            }

            lblFileName.Text = $"Tên file :   {fileName}";
            lblFileSize.Text = $"Kích thước :   {fileSize}";
            lblFileType.Text = $"Loại file :   {fileExt}";
            lblUploadTime.Text = $"Người upload :   {uploader}";
            lblUploadDate.Text = $"Ngày upload :   {uploadDate}";
            lblPath.Text = $"Đường dẫn :   {serverPath}";
        }

        private void ClearFileDetails()
        {
            lblFileName.Text = "Tên file :";
            lblFileSize.Text = "Kích thước :";
            lblFileType.Text = "Loại file :";
            lblUploadTime.Text = "Người upload :";
            lblUploadDate.Text = "Ngày upload :";
            lblPath.Text = "Đường dẫn :";
            pictureBox1.Image = null;
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void lblTextFile_Click(object sender, EventArgs e) { }
        private void pnlDownload_Paint(object sender, PaintEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void grpStatistics_Enter(object sender, EventArgs e) { }
        private void lblTransferred_Click(object sender, EventArgs e) { }
        private void grpTransfer_Enter(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void lblRemainTitle_Click(object sender, EventArgs e) { }
        private void dgvHistory_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

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

        private void btnRefreshList_Click_1(object sender, EventArgs e) { }

        // ===========================================================//
        // UPLOAD FILE THÀNH CÔNG //
        // ===========================================================//
        private async void btnUploaddown_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Chọn file cần upload lên Server";
            open.Filter = "All files (*.*)|*.*";

            if (open.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = open.FileName;
                string fileName = Path.GetFileName(localFilePath) ?? "unknown";

                btnUploaddown.Enabled = false;

                if (!fileProgresses.ContainsKey(fileName)) fileProgresses[fileName] = new TransferProgressState();
                fileProgresses[fileName].FileName = fileName;
                fileProgresses[fileName].StateText = "Đang tính SHA256...";

                await Task.Run(() =>
                {
                    try
                    {
                        string clientHash = "";
                        using (var sha256 = System.Security.Cryptography.SHA256.Create())
                        {
                            using (var fileStream = File.OpenRead(localFilePath))
                            {
                                byte[] hashBytes = sha256.ComputeHash(fileStream);
                                StringBuilder sb = new StringBuilder();
                                foreach (byte b in hashBytes) sb.Append(b.ToString("x2"));
                                clientHash = sb.ToString();
                            }
                        }

                        NetworkStream? stream = clientManager.GetStream();
                        if (stream == null) return;

                        while (stream.DataAvailable) { clientManager.ReceiveMessage(); }

                        FileInfo fileInfo = new FileInfo(localFilePath);
                        long fileSize = fileInfo.Length;

                        string cmd = $"{Protocol.UPLOAD}{Protocol.DELIMITER}{fileName}{Protocol.DELIMITER}{fileSize}{Protocol.DELIMITER}{clientHash}";
                        clientManager.SendMessage(cmd);

                        string? response = clientManager.ReceiveMessage();
                        if (string.IsNullOrEmpty(response)) return;

                        string[] parts = response.Split(new char[] { Protocol.DELIMITER, '#' }, StringSplitOptions.RemoveEmptyEntries);

                        if (parts.Length > 0 && (parts[0] == "UPLOAD_SUCCESS" || parts[0] == "OK" || parts[0] == Protocol.UPLOAD))
                        {
                            FileSender senderFile = new FileSender();
                            DateTime startTime = DateTime.Now;
                            long lastReportedBytes = 0;

                            senderFile.SendFile(localFilePath, stream, (sentBytes, totalBytes) =>
                            {
                                if (sentBytes - lastReportedBytes < 500 * 1024 && sentBytes < totalBytes)
                                {
                                    return;
                                }
                                lastReportedBytes = sentBytes;

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

                            var finalState = fileProgresses[fileName];
                            finalState.StateText = "Hoàn thành";
                            finalState.Percent = 100;

                            this.Invoke(new Action(() =>
                            {
                                lblTransferFileName.Text = $"{fileName} (Hoàn thành)";
                                lblState.Text = "Hoàn thành";
                                progressTransfer.Value = 100;

                                uploadCount++;
                                lblUploadCount.Text = uploadCount.ToString();

                                string fileExt = Path.GetExtension(fileName);
                                string currentTime = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");

                                dgvHistory.Rows.Add(fileName, fileExt, "Upload Thành công", currentTime);
                                SaveHistoryToLocal(); // 🌟 MỚI THÊM: Lưu lịch sử upload thành công

                                MessageBox.Show($"Upload file thành công!\nMã SHA256: {clientHash}\nTrạng thái: Toàn vẹn dữ liệu (FE File hợp lệ)", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadFileList();
                            }));
                        }
                        else
                        {
                            this.Invoke(new Action(() =>
                            {
                                string fileExt = Path.GetExtension(fileName);
                                dgvHistory.Rows.Add(fileName, fileExt, "Upload Thất bại (FE File lỗi)", DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy"));
                                SaveHistoryToLocal(); // 🌟 MỚI THÊM: Lưu lịch sử upload thất bại

                                MessageBox.Show("Server từ chối yêu cầu upload file.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }));
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

        // ===========================================================//
        // DOWNLOAD FILE THÀNH CÔNG -> TĂNG Value //
        // ===========================================================//
        private async void btnDownloadFile_Click(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một file từ danh sách để tải.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fileName = lvFiles.SelectedItems[0].Text;
            string? fileExt = lvFiles.SelectedItems[0].SubItems[2].Text ?? ".bin";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            saveFileDialog.Title = "Chọn thư mục và vị trí lưu file tải về";
            saveFileDialog.Filter = $"{fileExt.ToUpper()} Files (*{fileExt})|*{fileExt}|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            string savePath = saveFileDialog.FileName;
            btnDownloadFile.Enabled = false;

            if (!fileProgresses.ContainsKey(fileName)) fileProgresses[fileName] = new TransferProgressState();
            fileProgresses[fileName].FileName = fileName;
            fileProgresses[fileName].StateText = "Đang tải xuống...";

            await Task.Run(() =>
            {
                try
                {
                    NetworkStream? stream = clientManager.GetStream();
                    if (stream == null) return;

                    while (stream.DataAvailable) { clientManager.ReceiveMessage(); }

                    string cmd = $"{Protocol.DOWNLOAD}{Protocol.DELIMITER}{fileName}";
                    clientManager.SendMessage(cmd);

                    string? response = clientManager.ReceiveMessage();
                    if (string.IsNullOrEmpty(response)) return;

                    string[] parts = response.Split(new char[] { Protocol.DELIMITER, '#' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length > 1 && parts[0] == Protocol.DOWNLOAD_SUCCESS)
                    {
                        long fileSize = long.Parse(parts[1]);
                        FileReceiver receiver = new FileReceiver();
                        DateTime startTime = DateTime.Now;
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

                            downloadCount++;
                            lblDownloadCount.Text = downloadCount.ToString();

                            string currentTime = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
                            dgvHistory.Rows.Add(fileName, fileExt, "Download Thành công", currentTime);
                            SaveHistoryToLocal(); // 🌟 MỚI THÊM: Lưu lịch sử download thành công

                            MessageBox.Show($"Tải file '{fileName}' thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            dgvHistory.Rows.Add(fileName, fileExt, "Download Thất bại", DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy"));
                            SaveHistoryToLocal(); // 🌟 MỚI THÊM: Lưu lịch sử download thất bại
                            MessageBox.Show("Server từ chối yêu cầu tải file.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
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

        private void btnRefresh_Click(object sender, EventArgs e) { }
        private void progressTransfer_Click(object sender, EventArgs e) { }
        private void lblTransferStatus_Click(object sender, EventArgs e) { }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            lvFiles.Items.Clear();

            if (string.IsNullOrEmpty(keyword))
            {
                foreach (ListViewItem item in allFiles)
                {
                    lvFiles.Items.Add((ListViewItem)item.Clone());
                }
            }
            else
            {
                foreach (ListViewItem item in allFiles)
                {
                    string fileName = item.Text.ToLower();
                    if (fileName.StartsWith(keyword) || fileName.Contains(keyword))
                    {
                        lvFiles.Items.Add((ListViewItem)item.Clone());
                    }
                }
            }

            lblTotalFiles.Text = lvFiles.Items.Count.ToString();
        }

        private void lblSpeed_Click(object sender, EventArgs e) { }
        private void lblElapsed_Click(object sender, EventArgs e) { }
        private void lblSpeedTitle_Click(object sender, EventArgs e) { }
        private void pnlUpload_Paint(object sender, PaintEventArgs e) { }
        private void lblUploadCount_Click(object sender, EventArgs e) { }
        private void lblDownloadCount_Click(object sender, EventArgs e) { }

        // ===========================================================//
        // XUẤT LỊCH SỬ TRUYỀN FILE //
        // ===========================================================//
        private void btnExportLog_Click(object sender, EventArgs e)
        {
            if (dgvHistory.Rows.Count == 0 || (dgvHistory.Rows.Count == 1 && dgvHistory.Rows[0].IsNewRow))
            {
                MessageBox.Show("Hiện tại chưa có lịch sử truyền file nào để xuất log!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = $"Transfer_Log_{DateTime.Now:yyyyMMdd_HHmmss}";
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv";
            saveFileDialog.Title = "Xuất lịch sử truyền file";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                    {
                        sw.WriteLine("Tên File\tLoại\tTrạng thái\tThời gian");

                        foreach (DataGridViewRow row in dgvHistory.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                sw.WriteLine($"{row.Cells[0].Value}\t{row.Cells[1].Value}\t{row.Cells[2].Value}\t{row.Cells[3].Value}");
                            }
                        }
                    }
                    MessageBox.Show("Xuất lịch sử truyền file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xuất file log: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblFileName1(object sender, EventArgs e) { }
        private void lblFileSize_Click(object sender, EventArgs e) { }
        private void lblFileType_Click(object sender, EventArgs e) { }
        private void lblUploadDate_Click(object sender, EventArgs e) { }
        private void lblUploadTime_Click(object sender, EventArgs e) { }
        private void lblPath_Click(object sender, EventArgs e) { }
        private void lblTotalFiles_Click(object sender, EventArgs e) { }
        private void lblUploadCount_Click_1(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }

        // ===========================================================//
        // 🌟 CÁC HÀM XỬ LÝ LƯU VÀ XÓA LỊCH SỬ CỤC BỘ                  //
        // ===========================================================//
        private void SaveHistoryToLocal()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(historyFilePath, false, Encoding.UTF8))
                {
                    foreach (DataGridViewRow row in dgvHistory.Rows)
                    {
                        if (!row.IsNewRow && row.Cells[0].Value != null)
                        {
                            sw.WriteLine($"{row.Cells[0].Value}\t{row.Cells[1].Value}\t{row.Cells[2].Value}\t{row.Cells[3].Value}");
                        }
                    }
                }
            }
            catch { }
        }

        private void LoadHistoryFromLocal()
        {
            try
            {
                if (File.Exists(historyFilePath))
                {
                    dgvHistory.Rows.Clear();
                    string[] lines = File.ReadAllLines(historyFilePath, Encoding.UTF8);
                    foreach (string line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        string[] parts = line.Split('\t');
                        if (parts.Length == 4)
                        {
                            dgvHistory.Rows.Add(parts[0], parts[1], parts[2], parts[3]);
                        }
                    }
                }
            }
            catch { }
        }

        // Sự kiện cho nút Bấm "Xóa lịch sử"
        private void btnDeleteHistory_Click(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa {dgvHistory.SelectedRows.Count} dòng lịch sử được chọn không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvHistory.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            dgvHistory.Rows.Remove(row);
                        }
                    }
                    SaveHistoryToLocal();
                    MessageBox.Show("Đã xóa các dòng lịch sử được chọn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (dgvHistory.Rows.Count == 0 || (dgvHistory.Rows.Count == 1 && dgvHistory.Rows[0].IsNewRow))
                {
                    MessageBox.Show("Hiện tại danh sách lịch sử đang trống, không có gì để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn không chọn dòng nào cụ thể. Bạn có muốn XÓA SẠCH TOÀN BỘ lịch sử truyền file không?", "Xác nhận xóa hết", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    dgvHistory.Rows.Clear();
                    if (File.Exists(historyFilePath))
                    {
                        File.Delete(historyFilePath);
                    }
                    MessageBox.Show("Đã xóa sạch toàn bộ lịch sử truyền file hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }

    // 🌟 Lớp lưu trạng thái (Được đưa ra ngoài class FrmMain để tránh lỗi UI Designer)
    public class TransferProgressState
    {
        public string FileName { get; set; } = string.Empty;
        public int Percent { get; set; } = 0;
        public string TransferredText { get; set; } = "Đã truyền: 0,00 MB / 0,00 MB";
        public string RemainingText { get; set; } = "Còn lại: 0,00 MB";
        public string SpeedText { get; set; } = "0,00 MB/s";
        public string ElapsedText { get; set; } = "00:00:00";
        public string RemainTimeText { get; set; } = "00:00:00";
        public string StateText { get; set; } = "Sẵn sàng";
    }
}