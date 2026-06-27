namespace ProjectFileTransferClient
{
    partial class FrmConnect
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSubTitle = new Label();
            panel1 = new Panel();
            grpConnection = new GroupBox();
            lblStatus1 = new Label();
            lblStatus = new Label();
            btnConnect = new Button();
            txtUsername = new TextBox();
            lblUsername = new Label();
            txtPort = new TextBox();
            lblPort = new Label();
            txtIP = new TextBox();
            lblIP = new Label();
            btnDisconnect = new Button();
            grpConnection.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.RoyalBlue;
            lblTitle.Location = new Point(266, 28);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(547, 65);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "FILE TRANSFER CLIENT";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 11F);
            lblSubTitle.ForeColor = Color.Gray;
            lblSubTitle.Location = new Point(251, 98);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(562, 30);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.Text = "Kết nối đến Server để truyền và nhận file dung lượng lớn";
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Location = new Point(0, 140);
            panel1.Name = "panel1";
            panel1.Size = new Size(1080, 2);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // grpConnection
            // 
            grpConnection.BackColor = Color.WhiteSmoke;
            grpConnection.Controls.Add(lblStatus1);
            grpConnection.Controls.Add(lblStatus);
            grpConnection.Controls.Add(btnDisconnect);
            grpConnection.Controls.Add(btnConnect);
            grpConnection.Controls.Add(txtUsername);
            grpConnection.Controls.Add(lblUsername);
            grpConnection.Controls.Add(txtPort);
            grpConnection.Controls.Add(lblPort);
            grpConnection.Controls.Add(txtIP);
            grpConnection.Controls.Add(lblIP);
            grpConnection.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpConnection.ForeColor = SystemColors.HotTrack;
            grpConnection.Location = new Point(63, 169);
            grpConnection.Name = "grpConnection";
            grpConnection.Size = new Size(950, 512);
            grpConnection.TabIndex = 3;
            grpConnection.TabStop = false;
            grpConnection.Text = "🖥️ THÔNG TIN KẾT NỐI";
            grpConnection.Enter += grpConnection_Enter;
            // 
            // lblStatus1
            // 
            lblStatus1.AutoSize = true;
            lblStatus1.ForeColor = SystemColors.Highlight;
            lblStatus1.Location = new Point(31, 463);
            lblStatus1.Name = "lblStatus1";
            lblStatus1.Size = new Size(222, 32);
            lblStatus1.TabIndex = 9;
            lblStatus1.Text = "Trạng thái kết nối:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.Red;
            lblStatus.Location = new Point(259, 463);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(210, 32);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "🔴 Disconnected";
            lblStatus.Click += lblStatus_Click;
            // 
            // btnConnect
            // 
            btnConnect.BackColor = Color.LightGreen;
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.ForeColor = SystemColors.ControlLightLight;
            btnConnect.Location = new Point(177, 373);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(216, 48);
            btnConnect.TabIndex = 6;
            btnConnect.Text = "🔗 KẾT NỐI";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.White;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(71, 292);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(850, 46);
            txtUsername.TabIndex = 5;
            txtUsername.Text = "Client";
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.ForeColor = SystemColors.ControlDarkDark;
            lblUsername.Location = new Point(40, 245);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(169, 32);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "👤Username:";
            // 
            // txtPort
            // 
            txtPort.Font = new Font("Segoe UI", 11F);
            txtPort.Location = new Point(71, 186);
            txtPort.Multiline = true;
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(848, 46);
            txtPort.TabIndex = 3;
            txtPort.Text = "8888";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.ForeColor = SystemColors.ControlDarkDark;
            lblPort.Location = new Point(36, 144);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(104, 32);
            lblPort.TabIndex = 2;
            lblPort.Text = "🔌Port:";
            // 
            // txtIP
            // 
            txtIP.Font = new Font("Segoe UI", 11F);
            txtIP.Location = new Point(71, 90);
            txtIP.Multiline = true;
            txtIP.Name = "txtIP";
            txtIP.RightToLeft = RightToLeft.No;
            txtIP.Size = new Size(850, 45);
            txtIP.TabIndex = 1;
            txtIP.TextChanged += txtIP_TextChanged;
            // 
            // lblIP
            // 
            lblIP.AutoSize = true;
            lblIP.ForeColor = SystemColors.ControlDarkDark;
            lblIP.Location = new Point(38, 48);
            lblIP.Name = "lblIP";
            lblIP.Size = new Size(244, 32);
            lblIP.TabIndex = 0;
            lblIP.Text = "🌐Địa chỉ IP Server:";
            lblIP.Click += lblIP_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.BackColor = Color.LightCoral;
            btnDisconnect.Enabled = false;
            btnDisconnect.FlatStyle = FlatStyle.Flat;
            btnDisconnect.ForeColor = SystemColors.ControlLightLight;
            btnDisconnect.Location = new Point(501, 370);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(216, 48);
            btnDisconnect.TabIndex = 7;
            btnDisconnect.Text = "NGẮT KẾT NỐI";
            btnDisconnect.UseVisualStyleBackColor = false;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // FrmConnect
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1078, 730);
            Controls.Add(grpConnection);
            Controls.Add(panel1);
            Controls.Add(lblSubTitle);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmConnect";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "File Transfer Client";
            Load += FrmConnect_Load_1;
            grpConnection.ResumeLayout(false);
            grpConnection.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSubTitle;
        private Panel panel1;
        private GroupBox grpConnection;
        private Label lblIP;
        private TextBox txtIP;
        private TextBox txtPort;
        private Label lblPort;
        private Button btnConnect;
        private Label lblUsername;
        private Label lblStatus;
        private Label lblStatus1;
        public TextBox txtUsername;
        private Button btnDisconnect;
    }
}
