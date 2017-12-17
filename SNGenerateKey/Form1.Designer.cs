namespace SNGenerateKey
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCheckEnvironmentCode = new System.Windows.Forms.Button();
            this.btnVerifySN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEnvironmentCodeSN = new System.Windows.Forms.Button();
            this.cbxOS = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxNIC = new System.Windows.Forms.ComboBox();
            this.btnGenEnviornmentCode = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGenSN = new System.Windows.Forms.Button();
            this.txtEnvironmentCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSN = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCheckEnvironmentCode
            // 
            this.btnCheckEnvironmentCode.Location = new System.Drawing.Point(326, 78);
            this.btnCheckEnvironmentCode.Name = "btnCheckEnvironmentCode";
            this.btnCheckEnvironmentCode.Size = new System.Drawing.Size(103, 35);
            this.btnCheckEnvironmentCode.TabIndex = 35;
            this.btnCheckEnvironmentCode.Text = "檢查環境代碼";
            this.btnCheckEnvironmentCode.UseVisualStyleBackColor = true;
            this.btnCheckEnvironmentCode.Click += new System.EventHandler(this.btnCheckEnvironmentCode_Click);
            // 
            // btnVerifySN
            // 
            this.btnVerifySN.Location = new System.Drawing.Point(160, 177);
            this.btnVerifySN.Name = "btnVerifySN";
            this.btnVerifySN.Size = new System.Drawing.Size(69, 45);
            this.btnVerifySN.TabIndex = 34;
            this.btnVerifySN.Text = "序號驗證  (真實環境)";
            this.btnVerifySN.UseVisualStyleBackColor = true;
            this.btnVerifySN.Click += new System.EventHandler(this.btnVerifySN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEnvironmentCodeSN);
            this.groupBox1.Controls.Add(this.cbxOS);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxNIC);
            this.groupBox1.Controls.Add(this.btnGenEnviornmentCode);
            this.groupBox1.Location = new System.Drawing.Point(459, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 185);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "環境代碼資訊區";
            // 
            // btnEnvironmentCodeSN
            // 
            this.btnEnvironmentCodeSN.Location = new System.Drawing.Point(164, 114);
            this.btnEnvironmentCodeSN.Name = "btnEnvironmentCodeSN";
            this.btnEnvironmentCodeSN.Size = new System.Drawing.Size(134, 43);
            this.btnEnvironmentCodeSN.TabIndex = 18;
            this.btnEnvironmentCodeSN.Text = "驗證產生環境代碼序號(測試環境)";
            this.btnEnvironmentCodeSN.UseVisualStyleBackColor = true;
            this.btnEnvironmentCodeSN.Click += new System.EventHandler(this.btnEnvironmentCodeSN_Click);
            // 
            // cbxOS
            // 
            this.cbxOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOS.FormattingEnabled = true;
            this.cbxOS.Items.AddRange(new object[] {
            "Windows 8.1",
            "Windows 8",
            "Windows 7",
            "Windows Vista",
            "Windows XP",
            "Windows 2003",
            "Windows 2000",
            "Other OS"});
            this.cbxOS.Location = new System.Drawing.Point(108, 47);
            this.cbxOS.Name = "cbxOS";
            this.cbxOS.Size = new System.Drawing.Size(190, 20);
            this.cbxOS.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "作業系統名稱";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "網路卡廠商";
            // 
            // cbxNIC
            // 
            this.cbxNIC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNIC.FormattingEnabled = true;
            this.cbxNIC.Items.AddRange(new object[] {
            "D-Link",
            "Intel",
            "3Com",
            "Realtek",
            "Broadcom",
            "ASUS",
            "Corega",
            "Atheros",
            "Other NIC"});
            this.cbxNIC.Location = new System.Drawing.Point(108, 81);
            this.cbxNIC.Name = "cbxNIC";
            this.cbxNIC.Size = new System.Drawing.Size(190, 20);
            this.cbxNIC.TabIndex = 16;
            // 
            // btnGenEnviornmentCode
            // 
            this.btnGenEnviornmentCode.Location = new System.Drawing.Point(15, 114);
            this.btnGenEnviornmentCode.Name = "btnGenEnviornmentCode";
            this.btnGenEnviornmentCode.Size = new System.Drawing.Size(126, 43);
            this.btnGenEnviornmentCode.TabIndex = 17;
            this.btnGenEnviornmentCode.Text = "產生環境代碼";
            this.btnGenEnviornmentCode.UseVisualStyleBackColor = true;
            this.btnGenEnviornmentCode.Click += new System.EventHandler(this.btnGenEnviornmentCode_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(339, 177);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 45);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "關閉";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(250, 177);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(63, 45);
            this.btnClear.TabIndex = 31;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGenSN
            // 
            this.btnGenSN.Location = new System.Drawing.Point(50, 177);
            this.btnGenSN.Name = "btnGenSN";
            this.btnGenSN.Size = new System.Drawing.Size(82, 45);
            this.btnGenSN.TabIndex = 30;
            this.btnGenSN.Text = "產生序號";
            this.btnGenSN.UseVisualStyleBackColor = true;
            this.btnGenSN.Click += new System.EventHandler(this.btnGenSN_Click);
            // 
            // txtEnvironmentCode
            // 
            this.txtEnvironmentCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtEnvironmentCode.Location = new System.Drawing.Point(128, 87);
            this.txtEnvironmentCode.MaxLength = 10;
            this.txtEnvironmentCode.Name = "txtEnvironmentCode";
            this.txtEnvironmentCode.Size = new System.Drawing.Size(171, 22);
            this.txtEnvironmentCode.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "環境代碼";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSN
            // 
            this.txtSN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSN.Location = new System.Drawing.Point(128, 134);
            this.txtSN.MaxLength = 100;
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(314, 22);
            this.txtSN.TabIndex = 27;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtUserName.Location = new System.Drawing.Point(128, 42);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(130, 22);
            this.txtUserName.TabIndex = 26;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(52, 134);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(41, 12);
            this.Label5.TabIndex = 25;
            this.Label5.Text = "註冊碼";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(36, 45);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(65, 12);
            this.Label4.TabIndex = 24;
            this.Label4.Text = "使用者名稱";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 239);
            this.Controls.Add(this.btnCheckEnvironmentCode);
            this.Controls.Add(this.btnVerifySN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnGenSN);
            this.Controls.Add(this.txtEnvironmentCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSN);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "超級進銷存系統 V1.0 序號產生器";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheckEnvironmentCode;
        private System.Windows.Forms.Button btnVerifySN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEnvironmentCodeSN;
        private System.Windows.Forms.ComboBox cbxOS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxNIC;
        private System.Windows.Forms.Button btnGenEnviornmentCode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnGenSN;
        internal System.Windows.Forms.TextBox txtEnvironmentCode;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtSN;
        internal System.Windows.Forms.TextBox txtUserName;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
    }
}

