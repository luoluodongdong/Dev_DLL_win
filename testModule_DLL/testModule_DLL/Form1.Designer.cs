namespace testModule_DLL
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.test3497xxBtn = new System.Windows.Forms.Button();
            this.testDMMbtn = new System.Windows.Forms.Button();
            this.devicesListCB = new System.Windows.Forms.ComboBox();
            this.scanDevBtn = new System.Windows.Forms.Button();
            this.testPOWERbtn = new System.Windows.Forms.Button();
            this.testLOADbtn = new System.Windows.Forms.Button();
            this.scanFixBtn = new System.Windows.Forms.Button();
            this.fixCB = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.testFIXbtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.logListBox = new System.Windows.Forms.ListBox();
            this.ClearLogBtn = new System.Windows.Forms.Button();
            this.startServerBtn = new System.Windows.Forms.Button();
            this.ipTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.portTB = new System.Windows.Forms.TextBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.SocketSendBtn = new System.Windows.Forms.Button();
            this.commandTB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // test3497xxBtn
            // 
            this.test3497xxBtn.Location = new System.Drawing.Point(24, 74);
            this.test3497xxBtn.Name = "test3497xxBtn";
            this.test3497xxBtn.Size = new System.Drawing.Size(106, 37);
            this.test3497xxBtn.TabIndex = 0;
            this.test3497xxBtn.Text = "test3497xx";
            this.test3497xxBtn.UseVisualStyleBackColor = true;
            this.test3497xxBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // testDMMbtn
            // 
            this.testDMMbtn.Location = new System.Drawing.Point(150, 76);
            this.testDMMbtn.Name = "testDMMbtn";
            this.testDMMbtn.Size = new System.Drawing.Size(106, 35);
            this.testDMMbtn.TabIndex = 1;
            this.testDMMbtn.Text = "testDMM";
            this.testDMMbtn.UseVisualStyleBackColor = true;
            this.testDMMbtn.Click += new System.EventHandler(this.testDMMbtn_Click);
            // 
            // devicesListCB
            // 
            this.devicesListCB.FormattingEnabled = true;
            this.devicesListCB.Location = new System.Drawing.Point(24, 36);
            this.devicesListCB.Name = "devicesListCB";
            this.devicesListCB.Size = new System.Drawing.Size(232, 23);
            this.devicesListCB.TabIndex = 2;
            // 
            // scanDevBtn
            // 
            this.scanDevBtn.Location = new System.Drawing.Point(306, 35);
            this.scanDevBtn.Name = "scanDevBtn";
            this.scanDevBtn.Size = new System.Drawing.Size(75, 23);
            this.scanDevBtn.TabIndex = 3;
            this.scanDevBtn.Text = "ScanDev";
            this.scanDevBtn.UseVisualStyleBackColor = true;
            this.scanDevBtn.Click += new System.EventHandler(this.scanDevBtn_Click);
            // 
            // testPOWERbtn
            // 
            this.testPOWERbtn.Location = new System.Drawing.Point(275, 76);
            this.testPOWERbtn.Name = "testPOWERbtn";
            this.testPOWERbtn.Size = new System.Drawing.Size(106, 36);
            this.testPOWERbtn.TabIndex = 4;
            this.testPOWERbtn.Text = "testPOWER";
            this.testPOWERbtn.UseVisualStyleBackColor = true;
            this.testPOWERbtn.Click += new System.EventHandler(this.testPOWERbtn_Click);
            // 
            // testLOADbtn
            // 
            this.testLOADbtn.Location = new System.Drawing.Point(403, 76);
            this.testLOADbtn.Name = "testLOADbtn";
            this.testLOADbtn.Size = new System.Drawing.Size(92, 36);
            this.testLOADbtn.TabIndex = 5;
            this.testLOADbtn.Text = "testLOAD";
            this.testLOADbtn.UseVisualStyleBackColor = true;
            this.testLOADbtn.Click += new System.EventHandler(this.testLOADbtn_Click);
            // 
            // scanFixBtn
            // 
            this.scanFixBtn.Location = new System.Drawing.Point(174, 29);
            this.scanFixBtn.Name = "scanFixBtn";
            this.scanFixBtn.Size = new System.Drawing.Size(117, 38);
            this.scanFixBtn.TabIndex = 6;
            this.scanFixBtn.Text = "ScanFixture";
            this.scanFixBtn.UseVisualStyleBackColor = true;
            this.scanFixBtn.Click += new System.EventHandler(this.scanFixBtn_Click);
            // 
            // fixCB
            // 
            this.fixCB.FormattingEnabled = true;
            this.fixCB.Location = new System.Drawing.Point(45, 39);
            this.fixCB.Name = "fixCB";
            this.fixCB.Size = new System.Drawing.Size(96, 23);
            this.fixCB.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.testFIXbtn);
            this.groupBox1.Controls.Add(this.fixCB);
            this.groupBox1.Controls.Add(this.scanFixBtn);
            this.groupBox1.Location = new System.Drawing.Point(23, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 96);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fixture";
            // 
            // testFIXbtn
            // 
            this.testFIXbtn.Location = new System.Drawing.Point(322, 30);
            this.testFIXbtn.Name = "testFIXbtn";
            this.testFIXbtn.Size = new System.Drawing.Size(124, 37);
            this.testFIXbtn.TabIndex = 8;
            this.testFIXbtn.Text = "testFIX";
            this.testFIXbtn.UseVisualStyleBackColor = true;
            this.testFIXbtn.Click += new System.EventHandler(this.testFIXbtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.devicesListCB);
            this.groupBox2.Controls.Add(this.scanDevBtn);
            this.groupBox2.Controls.Add(this.testLOADbtn);
            this.groupBox2.Controls.Add(this.test3497xxBtn);
            this.groupBox2.Controls.Add(this.testPOWERbtn);
            this.groupBox2.Controls.Add(this.testDMMbtn);
            this.groupBox2.Location = new System.Drawing.Point(23, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(635, 126);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Instrument";
            // 
            // logListBox
            // 
            this.logListBox.FormattingEnabled = true;
            this.logListBox.ItemHeight = 15;
            this.logListBox.Location = new System.Drawing.Point(23, 296);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(635, 244);
            this.logListBox.TabIndex = 10;
            // 
            // ClearLogBtn
            // 
            this.ClearLogBtn.Location = new System.Drawing.Point(529, 310);
            this.ClearLogBtn.Name = "ClearLogBtn";
            this.ClearLogBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearLogBtn.TabIndex = 11;
            this.ClearLogBtn.Text = "Clear";
            this.ClearLogBtn.UseVisualStyleBackColor = true;
            this.ClearLogBtn.Click += new System.EventHandler(this.ClearLogBtn_Click);
            // 
            // startServerBtn
            // 
            this.startServerBtn.Location = new System.Drawing.Point(743, 98);
            this.startServerBtn.Name = "startServerBtn";
            this.startServerBtn.Size = new System.Drawing.Size(184, 35);
            this.startServerBtn.TabIndex = 6;
            this.startServerBtn.Text = "StartServerSocket";
            this.startServerBtn.UseVisualStyleBackColor = true;
            this.startServerBtn.Click += new System.EventHandler(this.startServerBtn_Click);
            // 
            // ipTB
            // 
            this.ipTB.Location = new System.Drawing.Point(780, 44);
            this.ipTB.Name = "ipTB";
            this.ipTB.Size = new System.Drawing.Size(158, 25);
            this.ipTB.TabIndex = 12;
            this.ipTB.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(743, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(961, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Port:";
            // 
            // portTB
            // 
            this.portTB.Location = new System.Drawing.Point(1014, 43);
            this.portTB.Name = "portTB";
            this.portTB.Size = new System.Drawing.Size(81, 25);
            this.portTB.TabIndex = 15;
            this.portTB.Text = "5555";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(743, 210);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(110, 33);
            this.ConnectBtn.TabIndex = 16;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // SocketSendBtn
            // 
            this.SocketSendBtn.Location = new System.Drawing.Point(1005, 260);
            this.SocketSendBtn.Name = "SocketSendBtn";
            this.SocketSendBtn.Size = new System.Drawing.Size(90, 32);
            this.SocketSendBtn.TabIndex = 17;
            this.SocketSendBtn.Text = "Send";
            this.SocketSendBtn.UseVisualStyleBackColor = true;
            this.SocketSendBtn.Click += new System.EventHandler(this.SocketSendBtn_Click);
            // 
            // commandTB
            // 
            this.commandTB.Location = new System.Drawing.Point(746, 260);
            this.commandTB.Multiline = true;
            this.commandTB.Name = "commandTB";
            this.commandTB.Size = new System.Drawing.Size(239, 73);
            this.commandTB.TabIndex = 18;
            this.commandTB.Text = "123456";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 564);
            this.Controls.Add(this.commandTB);
            this.Controls.Add(this.SocketSendBtn);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.portTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipTB);
            this.Controls.Add(this.startServerBtn);
            this.Controls.Add(this.ClearLogBtn);
            this.Controls.Add(this.logListBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button test3497xxBtn;
        private System.Windows.Forms.Button testDMMbtn;
        private System.Windows.Forms.ComboBox devicesListCB;
        private System.Windows.Forms.Button scanDevBtn;
        private System.Windows.Forms.Button testPOWERbtn;
        private System.Windows.Forms.Button testLOADbtn;
        private System.Windows.Forms.Button scanFixBtn;
        private System.Windows.Forms.ComboBox fixCB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button testFIXbtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox logListBox;
        private System.Windows.Forms.Button ClearLogBtn;
        private System.Windows.Forms.Button startServerBtn;
        private System.Windows.Forms.TextBox ipTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox portTB;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Button SocketSendBtn;
        private System.Windows.Forms.TextBox commandTB;
    }
}

