namespace SIS
{
    partial class FrmProductRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductRegistration));
            this.cbxAgreement = new System.Windows.Forms.CheckBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEnvironmentCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSN = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.PicBox_ok = new System.Windows.Forms.PictureBox();
            this.btnExplain = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_ok)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxAgreement
            // 
            this.cbxAgreement.AutoSize = true;
            this.cbxAgreement.Location = new System.Drawing.Point(520, 189);
            this.cbxAgreement.Name = "cbxAgreement";
            this.cbxAgreement.Size = new System.Drawing.Size(120, 16);
            this.cbxAgreement.TabIndex = 24;
            this.cbxAgreement.Text = "同意上述五大條款";
            this.cbxAgreement.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GroupBox2.Controls.Add(this.txtEnvironmentCode);
            this.GroupBox2.Controls.Add(this.label6);
            this.GroupBox2.Controls.Add(this.PicBox_ok);
            this.GroupBox2.Controls.Add(this.txtSN);
            this.GroupBox2.Controls.Add(this.txtUserName);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.Label4);
            this.GroupBox2.Location = new System.Drawing.Point(12, 189);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(492, 146);
            this.GroupBox2.TabIndex = 20;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "註冊資料填寫區";
            // 
            // txtEnvironmentCode
            // 
            this.txtEnvironmentCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtEnvironmentCode.Location = new System.Drawing.Point(112, 72);
            this.txtEnvironmentCode.MaxLength = 30;
            this.txtEnvironmentCode.Name = "txtEnvironmentCode";
            this.txtEnvironmentCode.Size = new System.Drawing.Size(171, 22);
            this.txtEnvironmentCode.TabIndex = 6;
            this.txtEnvironmentCode.TextChanged += new System.EventHandler(this.txtEnvironmentCode_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "環境代碼";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSN
            // 
            this.txtSN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSN.Location = new System.Drawing.Point(112, 106);
            this.txtSN.MaxLength = 100;
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(267, 22);
            this.txtSN.TabIndex = 3;
            this.txtSN.TextChanged += new System.EventHandler(this.txtSN_TextChanged);
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtUserName.Location = new System.Drawing.Point(112, 31);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(130, 22);
            this.txtUserName.TabIndex = 2;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(33, 116);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(41, 12);
            this.Label5.TabIndex = 1;
            this.Label5.Text = "註冊碼";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(20, 31);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(65, 12);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "使用者名稱";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GroupBox1.Controls.Add(this.label8);
            this.GroupBox1.Controls.Add(this.label7);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(623, 162);
            this.GroupBox1.TabIndex = 19;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "註冊條款說明";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(601, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "(5) 本程式實屬免費軟體，作者沒有修正或更新軟體之義務與責任，軟體無法使用或可能造成的損失作者概不負責.";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(18, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(519, 25);
            this.label7.TabIndex = 3;
            this.label7.Text = "(4) 本軟體實屬隨書附贈，僅供研究測試使用，作者保留軟體相關權利.";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(18, 82);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(280, 12);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "(3) 請注意,若沒有完成註冊此系統只能使用部分功能.";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(18, 55);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(203, 12);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "(2) 關於註冊碼(SN)請洽系統安裝人員.";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(18, 28);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(292, 12);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "(1) 感謝您使用本軟體,完成註冊動作便能正常使用系統.";
            // 
            // btnOK
            // 
            this.btnOK.Image = global::SIS.Properties.Resources.OK;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(520, 224);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 27);
            this.btnOK.TabIndex = 21;
            this.btnOK.Text = "確定";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // PicBox_ok
            // 
            this.PicBox_ok.Image = ((System.Drawing.Image)(resources.GetObject("PicBox_ok.Image")));
            this.PicBox_ok.Location = new System.Drawing.Point(385, 88);
            this.PicBox_ok.Name = "PicBox_ok";
            this.PicBox_ok.Size = new System.Drawing.Size(37, 40);
            this.PicBox_ok.TabIndex = 4;
            this.PicBox_ok.TabStop = false;
            this.PicBox_ok.Visible = false;
            // 
            // btnExplain
            // 
            this.btnExplain.Image = global::SIS.Properties.Resources.Explain;
            this.btnExplain.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExplain.Location = new System.Drawing.Point(520, 297);
            this.btnExplain.Name = "btnExplain";
            this.btnExplain.Size = new System.Drawing.Size(75, 28);
            this.btnExplain.TabIndex = 23;
            this.btnExplain.Text = "說明";
            this.btnExplain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExplain.UseVisualStyleBackColor = true;
            this.btnExplain.Click += new System.EventHandler(this.btnExplain_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::SIS.Properties.Resources.Cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(520, 261);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmProductRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 355);
            this.Controls.Add(this.cbxAgreement);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.btnExplain);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.GroupBox1);
            this.Name = "FrmProductRegistration";
            this.Text = "產品註冊";
            this.Load += new System.EventHandler(this.FrmProductRegistration_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_ok)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxAgreement;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txtEnvironmentCode;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.PictureBox PicBox_ok;
        internal System.Windows.Forms.TextBox txtSN;
        internal System.Windows.Forms.TextBox txtUserName;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button btnExplain;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}