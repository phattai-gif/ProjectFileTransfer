namespace ProjectFileTransferClient.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            btnSettings = new Button();
            picLogo = new PictureBox();
            btnLogout1 = new Button();
            btnNotify = new Button();
            btnRefresh = new Button();
            btnHistory = new Button();
            btnFileList = new Button();
            btnDownload = new Button();
            btnUpload = new Button();
            btnHome = new Button();
            lblTitle1 = new Label();
            lblTitle = new Label();
            pnlTopBar = new Panel();
            pnlContent = new Panel();
            pnlConnection = new Panel();
            label1 = new Label();
            btnUploadTop = new Button();
            btnDownloadTop = new Button();
            btnRefreshTop = new Button();
            txtSearch = new TextBox();
            btnLogout2 = new Button();
            grpFileList = new GroupBox();
            grpFileInfo = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            lvFiles = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            pictureBox1 = new PictureBox();
            lblFileName = new Label();
            lblUploadDate = new Label();
            lblFileSize = new Label();
            lblFileType = new Label();
            grpConnectionInfo = new Label();
            lblPath = new Label();
            btnUploaddown = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlTopBar.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlConnection.SuspendLayout();
            grpFileList.SuspendLayout();
            grpFileInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(11, 31, 58);
            pnlSidebar.Controls.Add(pnlConnection);
            pnlSidebar.Controls.Add(btnSettings);
            pnlSidebar.Controls.Add(picLogo);
            pnlSidebar.Controls.Add(btnLogout1);
            pnlSidebar.Controls.Add(btnNotify);
            pnlSidebar.Controls.Add(btnRefresh);
            pnlSidebar.Controls.Add(btnHistory);
            pnlSidebar.Controls.Add(btnFileList);
            pnlSidebar.Controls.Add(btnDownload);
            pnlSidebar.Controls.Add(btnUpload);
            pnlSidebar.Controls.Add(btnHome);
            pnlSidebar.Controls.Add(lblTitle1);
            pnlSidebar.Controls.Add(lblTitle);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(250, 852);
            pnlSidebar.TabIndex = 0;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.Transparent;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.ForeColor = SystemColors.Control;
            btnSettings.Location = new Point(-27, 451);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(241, 50);
            btnSettings.TabIndex = 10;
            btnSettings.Text = "⚙ Settings";
            btnSettings.UseVisualStyleBackColor = false;
            // 
            // picLogo
            // 
            picLogo.Image = Properties.Resources.Screenshot_2026_06_20_012052;
            picLogo.Location = new Point(53, 8);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(139, 90);
            picLogo.SizeMode = PictureBoxSizeMode.AutoSize;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            picLogo.Click += picLogo_Click;
            // 
            // btnLogout1
            // 
            btnLogout1.BackColor = Color.Transparent;
            btnLogout1.FlatAppearance.BorderSize = 0;
            btnLogout1.FlatStyle = FlatStyle.Flat;
            btnLogout1.ForeColor = SystemColors.Control;
            btnLogout1.Location = new Point(-30, 542);
            btnLogout1.Name = "btnLogout1";
            btnLogout1.Size = new Size(241, 50);
            btnLogout1.TabIndex = 9;
            btnLogout1.Text = "🚪 Logout";
            btnLogout1.UseVisualStyleBackColor = false;
            // 
            // btnNotify
            // 
            btnNotify.BackColor = Color.Transparent;
            btnNotify.FlatAppearance.BorderSize = 0;
            btnNotify.FlatStyle = FlatStyle.Flat;
            btnNotify.ForeColor = SystemColors.Control;
            btnNotify.Location = new Point(-16, 497);
            btnNotify.Name = "btnNotify";
            btnNotify.Size = new Size(241, 50);
            btnNotify.TabIndex = 8;
            btnNotify.Text = "🔔 Thông báo";
            btnNotify.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Transparent;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = SystemColors.Control;
            btnRefresh.Location = new Point(-28, 363);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(241, 50);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnHistory
            // 
            btnHistory.BackColor = Color.Transparent;
            btnHistory.FlatAppearance.BorderSize = 0;
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.ForeColor = SystemColors.Control;
            btnHistory.Location = new Point(9, 407);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(241, 50);
            btnHistory.TabIndex = 6;
            btnHistory.Text = "📜 Lịch sử truyền file";
            btnHistory.UseVisualStyleBackColor = false;
            btnHistory.Click += button5_Click;
            // 
            // btnFileList
            // 
            btnFileList.BackColor = Color.Transparent;
            btnFileList.FlatAppearance.BorderSize = 0;
            btnFileList.FlatStyle = FlatStyle.Flat;
            btnFileList.ForeColor = SystemColors.Control;
            btnFileList.Location = new Point(2, 315);
            btnFileList.Name = "btnFileList";
            btnFileList.Size = new Size(234, 50);
            btnFileList.TabIndex = 5;
            btnFileList.Text = "📁 Danh sách file";
            btnFileList.UseVisualStyleBackColor = false;
            // 
            // btnDownload
            // 
            btnDownload.BackColor = Color.Transparent;
            btnDownload.FlatAppearance.BorderSize = 0;
            btnDownload.FlatStyle = FlatStyle.Flat;
            btnDownload.ForeColor = SystemColors.Control;
            btnDownload.Location = new Point(-16, 268);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(241, 50);
            btnDownload.TabIndex = 4;
            btnDownload.Text = "📥 Download";
            btnDownload.UseVisualStyleBackColor = false;
            // 
            // btnUpload
            // 
            btnUpload.BackColor = Color.Transparent;
            btnUpload.FlatAppearance.BorderSize = 0;
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.ForeColor = SystemColors.Control;
            btnUpload.Location = new Point(-29, 222);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(241, 50);
            btnUpload.TabIndex = 3;
            btnUpload.Text = "📤 Upload";
            btnUpload.UseVisualStyleBackColor = false;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.Transparent;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.ForeColor = SystemColors.Control;
            btnHome.Location = new Point(-17, 175);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(241, 50);
            btnHome.TabIndex = 2;
            btnHome.Text = "🏠 Trang chủ\n";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += button1_Click;
            // 
            // lblTitle1
            // 
            lblTitle1.AutoSize = true;
            lblTitle1.BackColor = Color.Transparent;
            lblTitle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle1.ForeColor = Color.DeepSkyBlue;
            lblTitle1.Location = new Point(76, 139);
            lblTitle1.Name = "lblTitle1";
            lblTitle1.Size = new Size(80, 32);
            lblTitle1.TabIndex = 1;
            lblTitle1.Text = "Client";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 103);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(223, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "LAN FILE TRANSFER ";
            // 
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.WhiteSmoke;
            pnlTopBar.Controls.Add(btnLogout2);
            pnlTopBar.Controls.Add(txtSearch);
            pnlTopBar.Controls.Add(btnRefreshTop);
            pnlTopBar.Controls.Add(btnDownloadTop);
            pnlTopBar.Controls.Add(btnUploadTop);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(250, 0);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(1185, 80);
            pnlTopBar.TabIndex = 1;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(button3);
            pnlContent.Controls.Add(button2);
            pnlContent.Controls.Add(button1);
            pnlContent.Controls.Add(btnUploaddown);
            pnlContent.Controls.Add(groupBox4);
            pnlContent.Controls.Add(groupBox3);
            pnlContent.Controls.Add(groupBox2);
            pnlContent.Controls.Add(grpFileInfo);
            pnlContent.Controls.Add(grpFileList);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.ForeColor = SystemColors.Control;
            pnlContent.Location = new Point(250, 80);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1185, 772);
            pnlContent.TabIndex = 2;
            // 
            // pnlConnection
            // 
            pnlConnection.Controls.Add(label1);
            pnlConnection.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlConnection.Location = new Point(3, 587);
            pnlConnection.Name = "pnlConnection";
            pnlConnection.Size = new Size(247, 184);
            pnlConnection.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(13, 13);
            label1.Name = "label1";
            label1.Size = new Size(162, 168);
            label1.TabIndex = 0;
            label1.Text = "KẾT NỐI\r\n\U0001f7e2 Connected\r\nNgười dùng:\r\nIP Server:\r\nPort:\r\nThời gian kết nối:";
            label1.Click += label1_Click;
            // 
            // btnUploadTop
            // 
            btnUploadTop.Location = new Point(27, 15);
            btnUploadTop.Name = "btnUploadTop";
            btnUploadTop.Size = new Size(137, 48);
            btnUploadTop.TabIndex = 0;
            btnUploadTop.Text = "📤 Upload";
            btnUploadTop.UseVisualStyleBackColor = true;
            btnUploadTop.Click += button2_Click;
            // 
            // btnDownloadTop
            // 
            btnDownloadTop.Location = new Point(194, 15);
            btnDownloadTop.Name = "btnDownloadTop";
            btnDownloadTop.Size = new Size(137, 48);
            btnDownloadTop.TabIndex = 1;
            btnDownloadTop.Text = "Download";
            btnDownloadTop.UseVisualStyleBackColor = true;
            btnDownloadTop.Click += button2_Click_1;
            // 
            // btnRefreshTop
            // 
            btnRefreshTop.Location = new Point(364, 15);
            btnRefreshTop.Name = "btnRefreshTop";
            btnRefreshTop.Size = new Size(137, 48);
            btnRefreshTop.TabIndex = 2;
            btnRefreshTop.Text = "🔄 Refresh";
            btnRefreshTop.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(532, 23);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(300, 40);
            txtSearch.TabIndex = 3;
            txtSearch.Text = "Tìm kiếm file...";
            // 
            // btnLogout2
            // 
            btnLogout2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout2.ForeColor = SystemColors.ActiveCaptionText;
            btnLogout2.Location = new Point(936, 15);
            btnLogout2.Name = "btnLogout2";
            btnLogout2.Size = new Size(137, 48);
            btnLogout2.TabIndex = 4;
            btnLogout2.Text = "Đăng xuất";
            btnLogout2.UseVisualStyleBackColor = true;
            // 
            // grpFileList
            // 
            grpFileList.BackColor = Color.White;
            grpFileList.Controls.Add(lvFiles);
            grpFileList.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpFileList.ForeColor = Color.RoyalBlue;
            grpFileList.Location = new Point(10, 10);
            grpFileList.Name = "grpFileList";
            grpFileList.Size = new Size(673, 382);
            grpFileList.TabIndex = 0;
            grpFileList.TabStop = false;
            grpFileList.Text = "DANH SÁCH FILE TRÊN SERVER";
            grpFileList.Enter += grpFileList_Enter;
            // 
            // grpFileInfo
            // 
            grpFileInfo.Controls.Add(lblPath);
            grpFileInfo.Controls.Add(grpConnectionInfo);
            grpFileInfo.Controls.Add(lblFileType);
            grpFileInfo.Controls.Add(lblFileSize);
            grpFileInfo.Controls.Add(lblUploadDate);
            grpFileInfo.Controls.Add(lblFileName);
            grpFileInfo.Controls.Add(pictureBox1);
            grpFileInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpFileInfo.ForeColor = Color.RoyalBlue;
            grpFileInfo.Location = new Point(695, 10);
            grpFileInfo.Name = "grpFileInfo";
            grpFileInfo.Size = new Size(478, 228);
            grpFileInfo.TabIndex = 1;
            grpFileInfo.TabStop = false;
            grpFileInfo.Text = "THÔNG TIN FILE ĐƯỢC CHỌN";
            grpFileInfo.Enter += groupBox1_Enter;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Location = new Point(15, 398);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(668, 272);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // groupBox3
            // 
            groupBox3.Location = new Point(695, 235);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(478, 192);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "groupBox3";
            // 
            // groupBox4
            // 
            groupBox4.Location = new Point(695, 433);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(478, 237);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "groupBox4";
            // 
            // lvFiles
            // 
            lvFiles.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            lvFiles.Dock = DockStyle.Fill;
            lvFiles.FullRowSelect = true;
            lvFiles.GridLines = true;
            lvFiles.Location = new Point(3, 30);
            lvFiles.Name = "lvFiles";
            lvFiles.Size = new Size(667, 349);
            lvFiles.TabIndex = 0;
            lvFiles.UseCompatibleStateImageBehavior = false;
            lvFiles.View = View.Details;
            lvFiles.SelectedIndexChanged += lvFiles_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Tên File";
            columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Kích Thước";
            columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = " Loại File";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Ngày Upload";
            columnHeader4.Width = 180;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Screenshot_2026_06_20_031745;
            pictureBox1.Location = new Point(28, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(93, 134);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblFileName.ForeColor = Color.FromArgb(0, 0, 64);
            lblFileName.Location = new Point(181, 49);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(89, 20);
            lblFileName.TabIndex = 1;
            lblFileName.Text = "Tên file    :\r\n";
            lblFileName.Click += label2_Click;
            // 
            // lblUploadDate
            // 
            lblUploadDate.AutoSize = true;
            lblUploadDate.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblUploadDate.ForeColor = Color.FromArgb(0, 0, 64);
            lblUploadDate.Location = new Point(181, 139);
            lblUploadDate.Name = "lblUploadDate";
            lblUploadDate.Size = new Size(131, 20);
            lblUploadDate.TabIndex = 2;
            lblUploadDate.Text = "Người upload    :";
            // 
            // lblFileSize
            // 
            lblFileSize.AutoSize = true;
            lblFileSize.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblFileSize.ForeColor = Color.FromArgb(0, 0, 64);
            lblFileSize.Location = new Point(181, 79);
            lblFileSize.Name = "lblFileSize";
            lblFileSize.Size = new Size(123, 20);
            lblFileSize.TabIndex = 2;
            lblFileSize.Text = "Kích thước    :  ";
            // 
            // lblFileType
            // 
            lblFileType.AutoSize = true;
            lblFileType.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblFileType.ForeColor = Color.FromArgb(0, 0, 64);
            lblFileType.Location = new Point(181, 107);
            lblFileType.Name = "lblFileType";
            lblFileType.Size = new Size(93, 20);
            lblFileType.TabIndex = 3;
            lblFileType.Text = "Loại file    :";
            // 
            // grpConnectionInfo
            // 
            grpConnectionInfo.AutoSize = true;
            grpConnectionInfo.Font = new Font("Microsoft Sans Serif", 8.25F);
            grpConnectionInfo.ForeColor = Color.FromArgb(0, 0, 64);
            grpConnectionInfo.Location = new Point(181, 172);
            grpConnectionInfo.Name = "grpConnectionInfo";
            grpConnectionInfo.Size = new Size(126, 20);
            grpConnectionInfo.TabIndex = 4;
            grpConnectionInfo.Text = "Ngày upload    :";
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblPath.ForeColor = Color.FromArgb(0, 0, 64);
            lblPath.Location = new Point(181, 205);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(114, 20);
            lblPath.TabIndex = 5;
            lblPath.Text = "Đường dẫn    :";
            // 
            // btnUploaddown
            // 
            btnUploaddown.BackColor = Color.ForestGreen;
            btnUploaddown.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUploaddown.Location = new Point(24, 691);
            btnUploaddown.Name = "btnUploaddown";
            btnUploaddown.Size = new Size(271, 59);
            btnUploaddown.TabIndex = 3;
            btnUploaddown.Text = "📤 UPLOAD FILE";
            btnUploaddown.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 128, 0);
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(320, 693);
            button1.Name = "button1";
            button1.Size = new Size(260, 59);
            button1.TabIndex = 4;
            button1.Text = "📤 DOWNLOAD FILE";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.RoyalBlue;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(606, 693);
            button2.Name = "button2";
            button2.Size = new Size(254, 59);
            button2.TabIndex = 5;
            button2.Text = "🔄 REFERECH";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(884, 693);
            button3.Name = "button3";
            button3.Size = new Size(258, 59);
            button3.TabIndex = 6;
            button3.Text = "DISCONNECT";
            button3.UseVisualStyleBackColor = false;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1435, 852);
            Controls.Add(pnlContent);
            Controls.Add(pnlTopBar);
            Controls.Add(pnlSidebar);
            MinimumSize = new Size(1200, 800);
            Name = "FrmMain";
            Text = "LAN FILE TRANSFER CLIENT\n";
            WindowState = FormWindowState.Maximized;
            Load += FrmMain_Load;
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlTopBar.ResumeLayout(false);
            pnlTopBar.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlConnection.ResumeLayout(false);
            pnlConnection.PerformLayout();
            grpFileList.ResumeLayout(false);
            grpFileInfo.ResumeLayout(false);
            grpFileInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlTopBar;
        private Panel pnlContent;
        private Label lblTitle;
        private Label lblTitle1;
        private Button btnHome;
        private Button btnRefresh;
        private Button btnHistory;
        private Button btnFileList;
        private Button btnDownload;
        private Button btnUpload;
        private Button btnLogout1;
        private Button btnNotify;
        private PictureBox picLogo;
        private Button btnSettings;
        private Panel pnlConnection;
        private Label label1;
        private Button btnUploadTop;
        private Button btnRefreshTop;
        private Button btnDownloadTop;
        private TextBox txtSearch;
        private Button btnLogout2;
        private GroupBox grpFileList;
        private GroupBox groupBox2;
        private GroupBox grpFileInfo;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private ListView lvFiles;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Label lblFileName;
        private PictureBox pictureBox1;
        private Label lblFileType;
        private Label lblFileSize;
        private Label lblUploadDate;
        private Label lblPath;
        private Label grpConnectionInfo;
        private Button btnUploaddown;
        private Button button3;
        private Button button2;
        private Button button1;
    }
}