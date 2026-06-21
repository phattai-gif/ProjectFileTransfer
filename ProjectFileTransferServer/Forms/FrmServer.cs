using System;
using System.IO;
using System.Windows.Forms;
using ProjectFileTransferServer.Network;

namespace ProjectFileTransferServer
{
    public partial class FrmServer : Form
    {
        private ServerManager serverManager;
        // Đường dẫn tới thư mục Storage
        private string storagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Storage");

        public FrmServer()
        {
            InitializeComponent();
            serverManager = new ServerManager();
            btnStopServer.Enabled = false;
        }

        // Hàm quét thư mục Storage và nạp tên file vào ListBox
        private void LoadServerFiles()
        {
            try
            {
                // Xóa danh sách cũ hiển thị trên UI đi trước
                lstServerFiles.Items.Clear();

                if (Directory.Exists(storagePath))
                {
                    // Lấy toàn bộ danh sách file trong thư mục Storage
                    string[] files = Directory.GetFiles(storagePath);
                    foreach (string file in files)
                    {
                        // Chỉ lấy tên file và phần mở rộng, bỏ đường dẫn dài ngoằng phía trước
                        lstServerFiles.Items.Add(Path.GetFileName(file));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách file: {ex.Message}");
            }
        }

        private void UpdateServerLog(string message)
        {
            if (txtStatus.InvokeRequired)
            {
                txtStatus.Invoke(new Action<string>(UpdateServerLog), message);
            }
            else
            {
                txtStatus.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\r\n");

                // Nếu có log báo hiệu UPLOAD thành công thì tự động làm mới lại danh sách hiển thị luôn
                if (message.Contains("[UPLOAD] Thành công"))
                {
                    LoadServerFiles();
                }
            }
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            serverManager.StartServer(UpdateServerLog);
            txtStatus.AppendText("Server started...\r\n");
            txtStatus.AppendText("Listening on port 8888...\r\n");

            btnStartServer.Enabled = false;
            btnStopServer.Enabled = true;

            // Quét danh sách file hiện có ngay khi bật server lên
            LoadServerFiles();
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
            // Đảm bảo tạo sẵn thư mục Storage khi Form vừa khởi động lên để không bị lỗi trống thư mục
            if (!Directory.Exists(storagePath))
            {
                Directory.CreateDirectory(storagePath);
            }
            LoadServerFiles();
        }

        // Làm mới danh sách
        private void btnRefreshFiles_Click(object sender, EventArgs e)
        {
            LoadServerFiles();
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn file nào trong ListBox chưa
            if (lstServerFiles.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một file trong danh sách để xóa!");
                return;
            }

            string selectedFile = lstServerFiles.SelectedItem.ToString();
            string filePath = Path.Combine(storagePath, selectedFile);

            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    txtStatus.AppendText($"[{DateTime.Now:HH:mm:ss}] Đã xóa file: {selectedFile}\r\n");
                    LoadServerFiles(); // Quét lại để cập nhật ListBox lập tức
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa file: {ex.Message}");
            }
        }
    }
}