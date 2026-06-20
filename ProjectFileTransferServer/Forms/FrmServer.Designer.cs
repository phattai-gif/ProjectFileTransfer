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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 206);
            label1.Name = "label1";
            label1.Size = new Size(118, 25);
            label1.TabIndex = 0;
            label1.Text = "Server Status:";
            // 
            // txtStatus
            // 
            txtStatus.BackColor = SystemColors.ActiveCaption;
            txtStatus.Location = new Point(72, 245);
            txtStatus.Multiline = true;
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.ScrollBars = ScrollBars.Vertical;
            txtStatus.Size = new Size(608, 203);
            txtStatus.TabIndex = 1;
            // 
            // btnStartServer
            // 
            btnStartServer.Location = new Point(195, 159);
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
            btnStopServer.Location = new Point(351, 159);
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
            label2.Location = new Point(72, 105);
            label2.Name = "label2";
            label2.Size = new Size(48, 25);
            label2.TabIndex = 4;
            label2.Text = "Port:";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(137, 99);
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
            label4.Location = new Point(265, 30);
            label4.Name = "label4";
            label4.Size = new Size(280, 32);
            label4.TabIndex = 7;
            label4.Text = "FILE TRANSFER SERVER";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmServer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(800, 450);
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
    }
}
