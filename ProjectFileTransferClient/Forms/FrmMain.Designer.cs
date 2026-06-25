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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            pnlSidebar = new Panel();
            pnlConnection = new Panel();
            ConnectionInfo = new Label();
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
            btnRefreshList = new Button();
            txtSearch = new TextBox();
            btnDownloadFile = new Button();
            btnUploaddown = new Button();
            btnLogout2 = new Button();
            pnlContent = new Panel();
            btnDisconnect = new Button();
            grpHistory = new GroupBox();
            dgvHistory = new DataGridView();
            colHistoryFile = new DataGridViewTextBoxColumn();
            colHistoryType = new DataGridViewTextBoxColumn();
            colHistoryStatus = new DataGridViewTextBoxColumn();
            colHistoryTime = new DataGridViewTextBoxColumn();
            grpStatistics = new GroupBox();
            pnlOnline = new Panel();
            lblOnlineCount = new Label();
            lblTitleOnline = new Label();
            lblIconOnline = new Label();
            pnlUpload = new Panel();
            lblUploadCount = new Label();
            lblTitleUpload = new Label();
            lblIconUpload = new Label();
            pnlDownload = new Panel();
            lblDownloadCount = new Label();
            lblTitleDownload = new Label();
            lblIconDownload = new Label();
            pnlTotalFile = new Panel();
            lblTotalFiles = new Label();
            lblTextFile = new Label();
            lblIconFile = new Label();
            grpTransfer = new GroupBox();
            pnlRemainTime = new Panel();
            lblRemainTime = new Label();
            lblRemainTitle = new Label();
            pnlState = new Panel();
            lblState = new Label();
            lblStateTitle = new Label();
            pnlElapsed = new Panel();
            lblElapsed = new Label();
            lblElapsedTitle = new Label();
            pnlSpeed = new Panel();
            lblSpeed = new Label();
            lblSpeedTitle = new Label();
            lblRemaining = new Label();
            lblTransferred = new Label();
            lblPercent = new Label();
            progressTransfer = new ProgressBar();
            lblTransferStatus = new Label();
            lblTransferFileName = new Label();
            pictureBox2 = new PictureBox();
            grpFileInfo = new GroupBox();
            lblPath = new Label();
            lblUploadTime = new Label();
            lblFileType = new Label();
            lblFileSize = new Label();
            lblUploadDate = new Label();
            lblFileName = new Label();
            pictureBox1 = new PictureBox();
            grpFileList = new GroupBox();
            lvFiles = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            pnlSidebar.SuspendLayout();
            pnlConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlTopBar.SuspendLayout();
            pnlContent.SuspendLayout();
            grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            grpStatistics.SuspendLayout();
            pnlOnline.SuspendLayout();
            pnlUpload.SuspendLayout();
            pnlDownload.SuspendLayout();
            pnlTotalFile.SuspendLayout();
            grpTransfer.SuspendLayout();
            pnlRemainTime.SuspendLayout();
            pnlState.SuspendLayout();
            pnlElapsed.SuspendLayout();
            pnlSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            grpFileInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            grpFileList.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(337, 852);
            pnlSidebar.TabIndex = 0;
            // 
            // pnlConnection
            // 
            pnlConnection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlConnection.Controls.Add(ConnectionInfo);
            pnlConnection.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlConnection.Location = new Point(3, 587);
            pnlConnection.Name = "pnlConnection";
            pnlConnection.Size = new Size(334, 262);
            pnlConnection.TabIndex = 0;
            // 
            // ConnectionInfo
            // 
            ConnectionInfo.AutoSize = true;
            ConnectionInfo.BackColor = Color.Transparent;
            ConnectionInfo.ForeColor = SystemColors.ButtonFace;
            ConnectionInfo.Location = new Point(13, 13);
            ConnectionInfo.Name = "ConnectionInfo";
            ConnectionInfo.Size = new Size(162, 168);
            ConnectionInfo.TabIndex = 0;
            ConnectionInfo.Text = "KẾT NỐI\r\n\U0001f7e2 Connected\r\nNgười dùng:\r\nIP Server:\r\nPort:\r\nThời gian kết nối:";
            ConnectionInfo.Click += label1_Click;
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
            pnlTopBar.Controls.Add(btnRefreshList);
            pnlTopBar.Controls.Add(txtSearch);
            pnlTopBar.Controls.Add(btnDownloadFile);
            pnlTopBar.Controls.Add(btnUploaddown);
            pnlTopBar.Location = new Point(250, 0);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(1302, 80);
            pnlTopBar.TabIndex = 1;
            // 
            // btnRefreshList
            // 
            btnRefreshList.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRefreshList.BackColor = Color.RoyalBlue;
            btnRefreshList.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefreshList.Location = new Point(421, 10);
            btnRefreshList.Name = "btnRefreshList";
            btnRefreshList.Size = new Size(178, 59);
            btnRefreshList.TabIndex = 5;
            btnRefreshList.Text = "🔄 REFERECH";
            btnRefreshList.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(659, 20);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(368, 48);
            txtSearch.TabIndex = 3;
            txtSearch.Text = "Tìm kiếm file...";
            // 
            // btnDownloadFile
            // 
            btnDownloadFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDownloadFile.BackColor = Color.FromArgb(255, 128, 0);
            btnDownloadFile.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDownloadFile.Location = new Point(218, 9);
            btnDownloadFile.Name = "btnDownloadFile";
            btnDownloadFile.Size = new Size(183, 59);
            btnDownloadFile.TabIndex = 4;
            btnDownloadFile.Text = "📤 DOWNLOAD ";
            btnDownloadFile.UseVisualStyleBackColor = false;
            btnDownloadFile.Click += btnDownloadFile_Click;
            // 
            // btnUploaddown
            // 
            btnUploaddown.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUploaddown.BackColor = Color.ForestGreen;
            btnUploaddown.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUploaddown.Location = new Point(17, 10);
            btnUploaddown.Name = "btnUploaddown";
            btnUploaddown.Size = new Size(186, 59);
            btnUploaddown.TabIndex = 3;
            btnUploaddown.Text = "📤 UPLOAD FILE";
            btnUploaddown.UseVisualStyleBackColor = false;
            btnUploaddown.Click += btnUploaddown_Click;
            // 
            // btnLogout2
            // 
            btnLogout2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLogout2.BackColor = Color.Red;
            btnLogout2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout2.ForeColor = SystemColors.ButtonHighlight;
            btnLogout2.Location = new Point(1398, 9);
            btnLogout2.Name = "btnLogout2";
            btnLogout2.Size = new Size(142, 62);
            btnLogout2.TabIndex = 4;
            btnLogout2.Text = "Đăng xuất";
            btnLogout2.UseVisualStyleBackColor = false;
            btnLogout2.Click += btnLogout2_Click;
            // 
            // pnlContent
            // 
            pnlContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(btnDisconnect);
            pnlContent.Controls.Add(grpHistory);
            pnlContent.Controls.Add(grpStatistics);
            pnlContent.Controls.Add(grpTransfer);
            pnlContent.Controls.Add(grpFileInfo);
            pnlContent.Controls.Add(grpFileList);
            pnlContent.ForeColor = SystemColors.Control;
            pnlContent.Location = new Point(250, 80);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1302, 772);
            pnlContent.TabIndex = 2;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDisconnect.BackColor = Color.Red;
            btnDisconnect.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDisconnect.Location = new Point(93, 693);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(1105, 59);
            btnDisconnect.TabIndex = 6;
            btnDisconnect.Text = "DISCONNECT";
            btnDisconnect.UseVisualStyleBackColor = false;
            btnDisconnect.Click += button3_Click;
            // 
            // grpHistory
            // 
            grpHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            grpHistory.Controls.Add(dgvHistory);
            grpHistory.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpHistory.ForeColor = Color.RoyalBlue;
            grpHistory.Location = new Point(798, 443);
            grpHistory.Name = "grpHistory";
            grpHistory.Size = new Size(478, 237);
            grpHistory.TabIndex = 2;
            grpHistory.TabStop = false;
            grpHistory.Text = "LỊCH SỬ TRUYỀN FILE GẦN ĐÂY";
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.BackgroundColor = SystemColors.ButtonFace;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Columns.AddRange(new DataGridViewColumn[] { colHistoryFile, colHistoryType, colHistoryStatus, colHistoryTime });
            dgvHistory.Dock = DockStyle.Fill;
            dgvHistory.GridColor = SystemColors.ControlDark;
            dgvHistory.Location = new Point(3, 27);
            dgvHistory.MultiSelect = false;
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.RowHeadersWidth = 62;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new Size(472, 207);
            dgvHistory.TabIndex = 0;
            dgvHistory.CellContentClick += dgvHistory_CellContentClick;
            // 
            // colHistoryFile
            // 
            colHistoryFile.HeaderText = "File";
            colHistoryFile.MinimumWidth = 8;
            colHistoryFile.Name = "colHistoryFile";
            colHistoryFile.ReadOnly = true;
            colHistoryFile.Width = 180;
            // 
            // colHistoryType
            // 
            colHistoryType.HeaderText = "Loại";
            colHistoryType.MinimumWidth = 8;
            colHistoryType.Name = "colHistoryType";
            colHistoryType.ReadOnly = true;
            colHistoryType.Width = 60;
            // 
            // colHistoryStatus
            // 
            colHistoryStatus.HeaderText = "Trạng thái";
            colHistoryStatus.MinimumWidth = 8;
            colHistoryStatus.Name = "colHistoryStatus";
            colHistoryStatus.ReadOnly = true;
            colHistoryStatus.Width = 150;
            // 
            // colHistoryTime
            // 
            colHistoryTime.HeaderText = "Thời gian";
            colHistoryTime.MinimumWidth = 8;
            colHistoryTime.Name = "colHistoryTime";
            colHistoryTime.ReadOnly = true;
            colHistoryTime.Width = 80;
            // 
            // grpStatistics
            // 
            grpStatistics.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpStatistics.BackColor = Color.White;
            grpStatistics.Controls.Add(pnlOnline);
            grpStatistics.Controls.Add(pnlUpload);
            grpStatistics.Controls.Add(pnlDownload);
            grpStatistics.Controls.Add(pnlTotalFile);
            grpStatistics.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpStatistics.ForeColor = Color.RoyalBlue;
            grpStatistics.Location = new Point(798, 242);
            grpStatistics.Name = "grpStatistics";
            grpStatistics.Size = new Size(478, 210);
            grpStatistics.TabIndex = 2;
            grpStatistics.TabStop = false;
            grpStatistics.Text = "THỐNG KÊ";
            grpStatistics.Enter += grpStatistics_Enter;
            // 
            // pnlOnline
            // 
            pnlOnline.BackColor = Color.WhiteSmoke;
            pnlOnline.BorderStyle = BorderStyle.FixedSingle;
            pnlOnline.Controls.Add(lblOnlineCount);
            pnlOnline.Controls.Add(lblTitleOnline);
            pnlOnline.Controls.Add(lblIconOnline);
            pnlOnline.Location = new Point(263, 122);
            pnlOnline.Name = "pnlOnline";
            pnlOnline.Size = new Size(184, 72);
            pnlOnline.TabIndex = 3;
            // 
            // lblOnlineCount
            // 
            lblOnlineCount.AutoSize = true;
            lblOnlineCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOnlineCount.ForeColor = Color.Purple;
            lblOnlineCount.Location = new Point(67, 30);
            lblOnlineCount.Name = "lblOnlineCount";
            lblOnlineCount.Size = new Size(42, 32);
            lblOnlineCount.TabIndex = 2;
            lblOnlineCount.Text = "25";
            // 
            // lblTitleOnline
            // 
            lblTitleOnline.AutoSize = true;
            lblTitleOnline.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleOnline.ForeColor = SystemColors.ActiveCaptionText;
            lblTitleOnline.Location = new Point(60, 2);
            lblTitleOnline.Name = "lblTitleOnline";
            lblTitleOnline.Size = new Size(115, 25);
            lblTitleOnline.TabIndex = 1;
            lblTitleOnline.Text = " Tổng số file";
            lblTitleOnline.Click += label9_Click;
            // 
            // lblIconOnline
            // 
            lblIconOnline.AutoSize = true;
            lblIconOnline.BackColor = Color.MediumPurple;
            lblIconOnline.Font = new Font("Segoe UI", 12F);
            lblIconOnline.ForeColor = Color.Purple;
            lblIconOnline.Location = new Point(3, 17);
            lblIconOnline.Name = "lblIconOnline";
            lblIconOnline.Size = new Size(47, 32);
            lblIconOnline.TabIndex = 0;
            lblIconOnline.Text = "👥";
            // 
            // pnlUpload
            // 
            pnlUpload.BackColor = Color.WhiteSmoke;
            pnlUpload.BorderStyle = BorderStyle.FixedSingle;
            pnlUpload.Controls.Add(lblUploadCount);
            pnlUpload.Controls.Add(lblTitleUpload);
            pnlUpload.Controls.Add(lblIconUpload);
            pnlUpload.ForeColor = Color.RoyalBlue;
            pnlUpload.Location = new Point(263, 34);
            pnlUpload.Name = "pnlUpload";
            pnlUpload.Size = new Size(184, 72);
            pnlUpload.TabIndex = 4;
            // 
            // lblUploadCount
            // 
            lblUploadCount.AutoSize = true;
            lblUploadCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUploadCount.ForeColor = Color.Green;
            lblUploadCount.Location = new Point(54, 30);
            lblUploadCount.Name = "lblUploadCount";
            lblUploadCount.Size = new Size(42, 32);
            lblUploadCount.TabIndex = 2;
            lblUploadCount.Text = "12";
            // 
            // lblTitleUpload
            // 
            lblTitleUpload.AutoSize = true;
            lblTitleUpload.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleUpload.ForeColor = Color.Black;
            lblTitleUpload.Location = new Point(54, 3);
            lblTitleUpload.Name = "lblTitleUpload";
            lblTitleUpload.Size = new Size(97, 25);
            lblTitleUpload.TabIndex = 1;
            lblTitleUpload.Text = "Đã upload";
            // 
            // lblIconUpload
            // 
            lblIconUpload.AutoSize = true;
            lblIconUpload.BackColor = Color.FromArgb(192, 255, 192);
            lblIconUpload.Font = new Font("Segoe UI", 15F);
            lblIconUpload.ForeColor = Color.Green;
            lblIconUpload.Location = new Point(3, 13);
            lblIconUpload.Name = "lblIconUpload";
            lblIconUpload.Size = new Size(34, 41);
            lblIconUpload.TabIndex = 0;
            lblIconUpload.Text = "⬆";
            // 
            // pnlDownload
            // 
            pnlDownload.BackColor = Color.WhiteSmoke;
            pnlDownload.BorderStyle = BorderStyle.FixedSingle;
            pnlDownload.Controls.Add(lblDownloadCount);
            pnlDownload.Controls.Add(lblTitleDownload);
            pnlDownload.Controls.Add(lblIconDownload);
            pnlDownload.Location = new Point(32, 122);
            pnlDownload.Name = "pnlDownload";
            pnlDownload.Size = new Size(184, 72);
            pnlDownload.TabIndex = 3;
            pnlDownload.Paint += panel1_Paint;
            // 
            // lblDownloadCount
            // 
            lblDownloadCount.AutoSize = true;
            lblDownloadCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDownloadCount.ForeColor = Color.Orange;
            lblDownloadCount.Location = new Point(60, 30);
            lblDownloadCount.Name = "lblDownloadCount";
            lblDownloadCount.Size = new Size(28, 32);
            lblDownloadCount.TabIndex = 2;
            lblDownloadCount.Text = "9";
            // 
            // lblTitleDownload
            // 
            lblTitleDownload.AutoSize = true;
            lblTitleDownload.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleDownload.ForeColor = SystemColors.ActiveCaptionText;
            lblTitleDownload.Location = new Point(57, 2);
            lblTitleDownload.Name = "lblTitleDownload";
            lblTitleDownload.Size = new Size(122, 25);
            lblTitleDownload.TabIndex = 1;
            lblTitleDownload.Text = "Đã download";
            // 
            // lblIconDownload
            // 
            lblIconDownload.AutoSize = true;
            lblIconDownload.BackColor = Color.MistyRose;
            lblIconDownload.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIconDownload.ForeColor = Color.Orange;
            lblIconDownload.Location = new Point(7, 15);
            lblIconDownload.Name = "lblIconDownload";
            lblIconDownload.Size = new Size(32, 38);
            lblIconDownload.TabIndex = 0;
            lblIconDownload.Text = "⬇";
            // 
            // pnlTotalFile
            // 
            pnlTotalFile.BackColor = Color.WhiteSmoke;
            pnlTotalFile.BorderStyle = BorderStyle.FixedSingle;
            pnlTotalFile.Controls.Add(lblTotalFiles);
            pnlTotalFile.Controls.Add(lblTextFile);
            pnlTotalFile.Controls.Add(lblIconFile);
            pnlTotalFile.Location = new Point(32, 34);
            pnlTotalFile.Name = "pnlTotalFile";
            pnlTotalFile.Size = new Size(184, 72);
            pnlTotalFile.TabIndex = 0;
            // 
            // lblTotalFiles
            // 
            lblTotalFiles.AutoSize = true;
            lblTotalFiles.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalFiles.ForeColor = Color.RoyalBlue;
            lblTotalFiles.Location = new Point(67, 30);
            lblTotalFiles.Name = "lblTotalFiles";
            lblTotalFiles.Size = new Size(42, 32);
            lblTotalFiles.TabIndex = 2;
            lblTotalFiles.Text = "24";
            // 
            // lblTextFile
            // 
            lblTextFile.AutoSize = true;
            lblTextFile.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTextFile.ForeColor = SystemColors.ActiveCaptionText;
            lblTextFile.Location = new Point(60, 2);
            lblTextFile.Name = "lblTextFile";
            lblTextFile.Size = new Size(115, 25);
            lblTextFile.TabIndex = 1;
            lblTextFile.Text = " Tổng số file";
            lblTextFile.Click += lblTextFile_Click;
            // 
            // lblIconFile
            // 
            lblIconFile.AutoSize = true;
            lblIconFile.BackColor = SystemColors.GradientInactiveCaption;
            lblIconFile.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIconFile.ForeColor = SystemColors.HotTrack;
            lblIconFile.Location = new Point(3, 13);
            lblIconFile.Name = "lblIconFile";
            lblIconFile.Size = new Size(55, 38);
            lblIconFile.TabIndex = 0;
            lblIconFile.Text = "📁";
            // 
            // grpTransfer
            // 
            grpTransfer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpTransfer.BackColor = Color.Transparent;
            grpTransfer.Controls.Add(pnlRemainTime);
            grpTransfer.Controls.Add(pnlState);
            grpTransfer.Controls.Add(pnlElapsed);
            grpTransfer.Controls.Add(pnlSpeed);
            grpTransfer.Controls.Add(lblRemaining);
            grpTransfer.Controls.Add(lblTransferred);
            grpTransfer.Controls.Add(lblPercent);
            grpTransfer.Controls.Add(progressTransfer);
            grpTransfer.Controls.Add(lblTransferStatus);
            grpTransfer.Controls.Add(lblTransferFileName);
            grpTransfer.Controls.Add(pictureBox2);
            grpTransfer.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpTransfer.ForeColor = Color.RoyalBlue;
            grpTransfer.Location = new Point(15, 398);
            grpTransfer.Name = "grpTransfer";
            grpTransfer.Size = new Size(768, 272);
            grpTransfer.TabIndex = 2;
            grpTransfer.TabStop = false;
            grpTransfer.Text = "TIẾN TRÌNH TRUYỀN FILE";
            grpTransfer.Enter += grpTransfer_Enter;
            // 
            // pnlRemainTime
            // 
            pnlRemainTime.BackColor = Color.WhiteSmoke;
            pnlRemainTime.Controls.Add(lblRemainTime);
            pnlRemainTime.Controls.Add(lblRemainTitle);
            pnlRemainTime.Location = new Point(344, 183);
            pnlRemainTime.Name = "pnlRemainTime";
            pnlRemainTime.Size = new Size(157, 68);
            pnlRemainTime.TabIndex = 11;
            // 
            // lblRemainTime
            // 
            lblRemainTime.AutoSize = true;
            lblRemainTime.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRemainTime.ForeColor = SystemColors.ActiveCaptionText;
            lblRemainTime.Location = new Point(48, 29);
            lblRemainTime.Name = "lblRemainTime";
            lblRemainTime.Size = new Size(94, 28);
            lblRemainTime.TabIndex = 1;
            lblRemainTime.Text = "00:00:00";
            // 
            // lblRemainTitle
            // 
            lblRemainTitle.AutoSize = true;
            lblRemainTitle.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRemainTitle.ForeColor = SystemColors.ActiveCaptionText;
            lblRemainTitle.Location = new Point(27, 5);
            lblRemainTitle.Name = "lblRemainTitle";
            lblRemainTitle.Size = new Size(124, 21);
            lblRemainTitle.TabIndex = 0;
            lblRemainTitle.Text = "Thời gian còn lại";
            lblRemainTitle.Click += lblRemainTitle_Click;
            // 
            // pnlState
            // 
            pnlState.BackColor = Color.WhiteSmoke;
            pnlState.Controls.Add(lblState);
            pnlState.Controls.Add(lblStateTitle);
            pnlState.Location = new Point(508, 182);
            pnlState.Name = "pnlState";
            pnlState.Size = new Size(163, 68);
            pnlState.TabIndex = 10;
            // 
            // lblState
            // 
            lblState.AutoSize = true;
            lblState.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblState.ForeColor = SystemColors.ActiveCaptionText;
            lblState.Location = new Point(27, 35);
            lblState.Name = "lblState";
            lblState.Size = new Size(134, 21);
            lblState.TabIndex = 1;
            lblState.Text = "Đang hoạt động";
            // 
            // lblStateTitle
            // 
            lblStateTitle.AutoSize = true;
            lblStateTitle.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStateTitle.ForeColor = SystemColors.ActiveCaptionText;
            lblStateTitle.Location = new Point(47, 7);
            lblStateTitle.Name = "lblStateTitle";
            lblStateTitle.Size = new Size(79, 21);
            lblStateTitle.TabIndex = 0;
            lblStateTitle.Text = "Trạng thái";
            // 
            // pnlElapsed
            // 
            pnlElapsed.BackColor = Color.WhiteSmoke;
            pnlElapsed.Controls.Add(lblElapsed);
            pnlElapsed.Controls.Add(lblElapsedTitle);
            pnlElapsed.Location = new Point(180, 183);
            pnlElapsed.Name = "pnlElapsed";
            pnlElapsed.Size = new Size(157, 68);
            pnlElapsed.TabIndex = 9;
            // 
            // lblElapsed
            // 
            lblElapsed.AutoSize = true;
            lblElapsed.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblElapsed.ForeColor = SystemColors.ActiveCaptionText;
            lblElapsed.Location = new Point(49, 29);
            lblElapsed.Name = "lblElapsed";
            lblElapsed.Size = new Size(94, 28);
            lblElapsed.TabIndex = 1;
            lblElapsed.Text = "00:00:00";
            // 
            // lblElapsedTitle
            // 
            lblElapsedTitle.AutoSize = true;
            lblElapsedTitle.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblElapsedTitle.ForeColor = SystemColors.ActiveCaptionText;
            lblElapsedTitle.Location = new Point(8, 5);
            lblElapsedTitle.Name = "lblElapsedTitle";
            lblElapsedTitle.Size = new Size(145, 21);
            lblElapsedTitle.TabIndex = 0;
            lblElapsedTitle.Text = "Thời gian đã truyền";
            lblElapsedTitle.Click += label3_Click;
            // 
            // pnlSpeed
            // 
            pnlSpeed.BackColor = Color.WhiteSmoke;
            pnlSpeed.Controls.Add(lblSpeed);
            pnlSpeed.Controls.Add(lblSpeedTitle);
            pnlSpeed.Location = new Point(6, 184);
            pnlSpeed.Name = "pnlSpeed";
            pnlSpeed.Size = new Size(167, 68);
            pnlSpeed.TabIndex = 8;
            // 
            // lblSpeed
            // 
            lblSpeed.AutoSize = true;
            lblSpeed.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSpeed.ForeColor = SystemColors.ActiveCaptionText;
            lblSpeed.Location = new Point(55, 29);
            lblSpeed.Name = "lblSpeed";
            lblSpeed.Size = new Size(80, 28);
            lblSpeed.TabIndex = 1;
            lblSpeed.Text = "0 MB/s";
            // 
            // lblSpeedTitle
            // 
            lblSpeedTitle.AutoSize = true;
            lblSpeedTitle.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSpeedTitle.ForeColor = SystemColors.ActiveCaptionText;
            lblSpeedTitle.Location = new Point(45, 5);
            lblSpeedTitle.Name = "lblSpeedTitle";
            lblSpeedTitle.Size = new Size(105, 21);
            lblSpeedTitle.TabIndex = 0;
            lblSpeedTitle.Text = "Tốc độ truyền";
            // 
            // lblRemaining
            // 
            lblRemaining.AutoSize = true;
            lblRemaining.ForeColor = SystemColors.ActiveCaptionText;
            lblRemaining.Location = new Point(551, 118);
            lblRemaining.Name = "lblRemaining";
            lblRemaining.Size = new Size(124, 25);
            lblRemaining.TabIndex = 7;
            lblRemaining.Text = "Còn lại: 0 MB";
            // 
            // lblTransferred
            // 
            lblTransferred.AutoSize = true;
            lblTransferred.ForeColor = SystemColors.ActiveCaptionText;
            lblTransferred.Location = new Point(129, 117);
            lblTransferred.Name = "lblTransferred";
            lblTransferred.Size = new Size(212, 25);
            lblTransferred.TabIndex = 6;
            lblTransferred.Text = "Đã truyền: 0 MB / 0 MB";
            lblTransferred.Click += lblTransferred_Click;
            // 
            // lblPercent
            // 
            lblPercent.AutoSize = true;
            lblPercent.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPercent.ForeColor = SystemColors.ActiveCaptionText;
            lblPercent.Location = new Point(626, 77);
            lblPercent.Name = "lblPercent";
            lblPercent.Size = new Size(41, 28);
            lblPercent.TabIndex = 5;
            lblPercent.Text = "0%";
            // 
            // progressTransfer
            // 
            progressTransfer.Location = new Point(132, 80);
            progressTransfer.Name = "progressTransfer";
            progressTransfer.Size = new Size(488, 25);
            progressTransfer.TabIndex = 4;
            progressTransfer.Click += progressTransfer_Click;
            // 
            // lblTransferStatus
            // 
            lblTransferStatus.AutoSize = true;
            lblTransferStatus.ForeColor = Color.RoyalBlue;
            lblTransferStatus.Location = new Point(351, 44);
            lblTransferStatus.Name = "lblTransferStatus";
            lblTransferStatus.Size = new Size(0, 25);
            lblTransferStatus.TabIndex = 3;
            lblTransferStatus.Click += lblTransferStatus_Click;
            // 
            // lblTransferFileName
            // 
            lblTransferFileName.AutoSize = true;
            lblTransferFileName.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTransferFileName.ForeColor = SystemColors.ActiveCaptionText;
            lblTransferFileName.Location = new Point(129, 42);
            lblTransferFileName.Name = "lblTransferFileName";
            lblTransferFileName.Size = new Size(222, 30);
            lblTransferFileName.TabIndex = 2;
            lblTransferFileName.Text = "Video_HoiThao.mp4";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(20, 42);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(97, 112);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // grpFileInfo
            // 
            grpFileInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpFileInfo.Controls.Add(lblPath);
            grpFileInfo.Controls.Add(lblUploadTime);
            grpFileInfo.Controls.Add(lblFileType);
            grpFileInfo.Controls.Add(lblFileSize);
            grpFileInfo.Controls.Add(lblUploadDate);
            grpFileInfo.Controls.Add(lblFileName);
            grpFileInfo.Controls.Add(pictureBox1);
            grpFileInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpFileInfo.ForeColor = Color.RoyalBlue;
            grpFileInfo.Location = new Point(798, 10);
            grpFileInfo.Name = "grpFileInfo";
            grpFileInfo.Size = new Size(478, 228);
            grpFileInfo.TabIndex = 1;
            grpFileInfo.TabStop = false;
            grpFileInfo.Text = "THÔNG TIN FILE ĐƯỢC CHỌN";
            grpFileInfo.Enter += groupBox1_Enter;
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
            // lblUploadTime
            // 
            lblUploadTime.AutoSize = true;
            lblUploadTime.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblUploadTime.ForeColor = Color.FromArgb(0, 0, 64);
            lblUploadTime.Location = new Point(181, 172);
            lblUploadTime.Name = "lblUploadTime";
            lblUploadTime.Size = new Size(126, 20);
            lblUploadTime.TabIndex = 4;
            lblUploadTime.Text = "Ngày upload    :";
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
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Screenshot_2026_06_20_031745;
            pictureBox1.Location = new Point(28, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(93, 134);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // grpFileList
            // 
            grpFileList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpFileList.BackColor = Color.White;
            grpFileList.Controls.Add(lvFiles);
            grpFileList.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpFileList.ForeColor = Color.RoyalBlue;
            grpFileList.Location = new Point(19, 10);
            grpFileList.Name = "grpFileList";
            grpFileList.Size = new Size(760, 382);
            grpFileList.TabIndex = 0;
            grpFileList.TabStop = false;
            grpFileList.Text = "DANH SÁCH FILE TRÊN SERVER";
            grpFileList.Enter += grpFileList_Enter;
            // 
            // lvFiles
            // 
            lvFiles.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            lvFiles.Dock = DockStyle.Fill;
            lvFiles.FullRowSelect = true;
            lvFiles.GridLines = true;
            lvFiles.Location = new Point(3, 30);
            lvFiles.Name = "lvFiles";
            lvFiles.Size = new Size(754, 349);
            lvFiles.TabIndex = 0;
            lvFiles.UseCompatibleStateImageBehavior = false;
            lvFiles.View = View.Details;
            lvFiles.SelectedIndexChanged += lvFiles_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Tên File";
            columnHeader1.Width = 260;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Kích Thước";
            columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = " Loại File";
            columnHeader3.Width = 110;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Ngày Upload";
            columnHeader4.Width = 210;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1552, 852);
            Controls.Add(btnLogout2);
            Controls.Add(pnlContent);
            Controls.Add(pnlTopBar);
            Controls.Add(pnlSidebar);
            MinimumSize = new Size(1200, 800);
            Name = "FrmMain";
            Text = "LAN FILE TRANSFER CLIENT\n";
            WindowState = FormWindowState.Maximized;
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            pnlConnection.ResumeLayout(false);
            pnlConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlTopBar.ResumeLayout(false);
            pnlTopBar.PerformLayout();
            pnlContent.ResumeLayout(false);
            grpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            grpStatistics.ResumeLayout(false);
            pnlOnline.ResumeLayout(false);
            pnlOnline.PerformLayout();
            pnlUpload.ResumeLayout(false);
            pnlUpload.PerformLayout();
            pnlDownload.ResumeLayout(false);
            pnlDownload.PerformLayout();
            pnlTotalFile.ResumeLayout(false);
            pnlTotalFile.PerformLayout();
            grpTransfer.ResumeLayout(false);
            grpTransfer.PerformLayout();
            pnlRemainTime.ResumeLayout(false);
            pnlRemainTime.PerformLayout();
            pnlState.ResumeLayout(false);
            pnlState.PerformLayout();
            pnlElapsed.ResumeLayout(false);
            pnlElapsed.PerformLayout();
            pnlSpeed.ResumeLayout(false);
            pnlSpeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            grpFileInfo.ResumeLayout(false);
            grpFileInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            grpFileList.ResumeLayout(false);
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
        private TextBox txtSearch;
        private Button btnLogout2;
        private GroupBox grpFileList;
        private GroupBox grpFileInfo;
        private GroupBox grpHistory;
        private GroupBox grpStatistics;
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
        private Label lblUploadTime;
        private Button btnUploaddown;
        private Button btnDisconnect;
        private Button btnRefreshList;
        private Button btnDownloadFile;
        private Panel pnlTotalFile;
        private Label lblIconFile;
        private Label lblTextFile;
        private Label lblTotalFiles;
        private Panel pnlDownload;
        private Label lblDownloadCount;
        private Label lblTitleDownload;
        private Label lblIconDownload;
        private Panel pnlOnline;
        private Label lblOnlineCount;
        private Label lblTitleOnline;
        private Label lblIconOnline;
        private Panel pnlUpload;
        private Label lblUploadCount;
        private Label lblTitleUpload;
        private Label lblIconUpload;
        private GroupBox grpTransfer;
        private Panel pnlRemainTime;
        private Label lblRemainTime;
        private Label lblRemainTitle;
        private Panel pnlState;
        private Label lblState;
        private Label lblStateTitle;
        private Panel pnlElapsed;
        private Label lblElapsed;
        private Label lblElapsedTitle;
        private Panel pnlSpeed;
        private Label lblSpeed;
        private Label lblSpeedTitle;
        private Label lblRemaining;
        private Label lblTransferred;
        private Label lblPercent;
        private ProgressBar progressTransfer;
        private Label lblTransferStatus;
        private Label lblTransferFileName;
        private PictureBox pictureBox2;
        private DataGridView dgvHistory;
        private DataGridViewTextBoxColumn colHistoryFile;
        private DataGridViewTextBoxColumn colHistoryType;
        private DataGridViewTextBoxColumn colHistoryStatus;
        private DataGridViewTextBoxColumn colHistoryTime;
        private Label ConnectionInfo;
    }
}