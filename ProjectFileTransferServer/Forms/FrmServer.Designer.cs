namespace ProjectFileTransferServer
{
    partial class FrmServer
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
            label1 = new Label();
            txtStatus = new TextBox();
            btnStartServer = new Button();
            btnStopServer = new Button();
            label2 = new Label();
            txtPort = new TextBox();
            label3 = new Label();
            label4 = new Label();
            lstServerFiles = new ListBox();
            label5 = new Label();
            btnRefreshFiles = new Button();
            btnDeleteFile = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 137);
            label1.Name = "label1";
            label1.Size = new Size(118, 25);
            label1.TabIndex = 0;
            label1.Text = "Server Status:";
            // 
            // txtStatus
            // 
            txtStatus.BackColor = SystemColors.ActiveCaption;
            txtStatus.Location = new Point(42, 182);
            txtStatus.Multiline = true;
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.ScrollBars = ScrollBars.Vertical;
            txtStatus.Size = new Size(387, 203);
            txtStatus.TabIndex = 1;
            // 
            // btnStartServer
            // 
            btnStartServer.Location = new Point(281, 71);
            btnStartServer.Name = "btnStartServer";
            btnStartServer.Size = new Size(112, 34);
            btnStartServer.TabIndex = 2;
            btnStartServer.Text = "Start Server";
            btnStartServer.UseVisualStyleBackColor = true;
            btnStartServer.Click += btnStartServer_Click;
            // 
            // btnStopServer
            // 
            btnStopServer.Enabled = false;
            btnStopServer.Location = new Point(421, 71);
            btnStopServer.Name = "btnStopServer";
            btnStopServer.Size = new Size(112, 34);
            btnStopServer.TabIndex = 3;
            btnStopServer.Text = "Stop Server";
            btnStopServer.UseVisualStyleBackColor = true;
            btnStopServer.Click += btnStopServer_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 33);
            label2.Name = "label2";
            label2.Size = new Size(48, 25);
            label2.TabIndex = 4;
            label2.Text = "Port:";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(96, 30);
            txtPort.Name = "txtPort";
            txtPort.ReadOnly = true;
            txtPort.Size = new Size(150, 31);
            txtPort.TabIndex = 5;
            txtPort.Text = "8888";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(313, 30);
            label3.Name = "label3";
            label3.Size = new Size(0, 25);
            label3.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(281, -2);
            label4.Name = "label4";
            label4.Size = new Size(280, 32);
            label4.TabIndex = 7;
            label4.Text = "FILE TRANSFER SERVER";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lstServerFiles
            // 
            lstServerFiles.FormattingEnabled = true;
            lstServerFiles.Location = new Point(466, 182);
            lstServerFiles.Name = "lstServerFiles";
            lstServerFiles.Size = new Size(373, 204);
            lstServerFiles.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(466, 137);
            label5.Name = "label5";
            label5.Size = new Size(217, 25);
            label5.TabIndex = 9;
            label5.Text = "Các file đã lưu trên Server:";
            // 
            // btnRefreshFiles
            // 
            btnRefreshFiles.Location = new Point(522, 404);
            btnRefreshFiles.Name = "btnRefreshFiles";
            btnRefreshFiles.Size = new Size(114, 34);
            btnRefreshFiles.TabIndex = 10;
            btnRefreshFiles.Text = "RefreshFile";
            btnRefreshFiles.UseVisualStyleBackColor = true;
            // 
            // btnDeleteFile
            // 
            btnDeleteFile.Location = new Point(678, 404);
            btnDeleteFile.Name = "btnDeleteFile";
            btnDeleteFile.Size = new Size(112, 34);
            btnDeleteFile.TabIndex = 11;
            btnDeleteFile.Text = "DeleteFile";
            btnDeleteFile.UseVisualStyleBackColor = true;
            btnDeleteFile.Click += btnDeleteFile_Click;
            // 
            // FrmServer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(857, 450);
            Controls.Add(btnDeleteFile);
            Controls.Add(btnRefreshFiles);
            Controls.Add(label5);
            Controls.Add(lstServerFiles);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtPort);
            Controls.Add(label2);
            Controls.Add(btnStopServer);
            Controls.Add(btnStartServer);
            Controls.Add(txtStatus);
            Controls.Add(label1);
            Name = "FrmServer";
            Text = "Form1";
            Load += FrmServer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtStatus;
        private Button btnStartServer;
        private Button btnStopServer;
        private Label label2;
        private TextBox txtPort;
        private Label label3;
        private Label label4;
        private ListBox lstServerFiles;
        private Label label5;
        private Button btnRefreshFiles;
        private Button btnDeleteFile;
    }
}
