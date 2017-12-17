namespace SIS
{
    partial class FrmBasicSetting
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBasicSetting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoADShort = new System.Windows.Forms.RadioButton();
            this.rdoAD = new System.Windows.Forms.RadioButton();
            this.rdoROC = new System.Windows.Forms.RadioButton();
            this.txtDateShow = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPWD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComputeOrIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtShipTaxRate = new System.Windows.Forms.TextBox();
            this.txtStockTaxRate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboReceiptPoint = new System.Windows.Forms.ComboBox();
            this.cboItemPoint = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnDefault);
            this.groupBox1.Location = new System.Drawing.Point(28, 337);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(641, 70);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "執行功能區";
            // 
            // btnExit
            // 
            this.btnExit.Image = global::SIS.Properties.Resources.Exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.Location = new System.Drawing.Point(383, 21);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 43);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "離開";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::SIS.Properties.Resources.Save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(16, 21);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 43);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "儲存";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Image = global::SIS.Properties.Resources.clear;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.Location = new System.Drawing.Point(116, 21);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 43);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "清除";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Image = global::SIS.Properties.Resources.Default;
            this.btnDefault.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDefault.Location = new System.Drawing.Point(220, 21);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(140, 43);
            this.btnDefault.TabIndex = 2;
            this.btnDefault.Text = "恢復原廠設定值";
            this.btnDefault.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoADShort);
            this.groupBox2.Controls.Add(this.rdoAD);
            this.groupBox2.Controls.Add(this.rdoROC);
            this.groupBox2.Controls.Add(this.txtDateShow);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtDate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(28, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(534, 87);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "日期格式";
            // 
            // rdoADShort
            // 
            this.rdoADShort.AutoSize = true;
            this.rdoADShort.Location = new System.Drawing.Point(200, 17);
            this.rdoADShort.Name = "rdoADShort";
            this.rdoADShort.Size = new System.Drawing.Size(35, 16);
            this.rdoADShort.TabIndex = 7;
            this.rdoADShort.Text = "14";
            this.rdoADShort.UseVisualStyleBackColor = true;
            this.rdoADShort.CheckedChanged += new System.EventHandler(this.rdoADShort_CheckedChanged);
            // 
            // rdoAD
            // 
            this.rdoAD.AutoSize = true;
            this.rdoAD.Checked = true;
            this.rdoAD.Location = new System.Drawing.Point(136, 17);
            this.rdoAD.Name = "rdoAD";
            this.rdoAD.Size = new System.Drawing.Size(47, 16);
            this.rdoAD.TabIndex = 6;
            this.rdoAD.TabStop = true;
            this.rdoAD.Text = "2014";
            this.rdoAD.UseVisualStyleBackColor = true;
            this.rdoAD.CheckedChanged += new System.EventHandler(this.rdoAD_CheckedChanged);
            // 
            // rdoROC
            // 
            this.rdoROC.AutoSize = true;
            this.rdoROC.Location = new System.Drawing.Point(76, 17);
            this.rdoROC.Name = "rdoROC";
            this.rdoROC.Size = new System.Drawing.Size(41, 16);
            this.rdoROC.TabIndex = 5;
            this.rdoROC.Text = "103";
            this.rdoROC.UseVisualStyleBackColor = true;
            this.rdoROC.CheckedChanged += new System.EventHandler(this.rdoROC_CheckedChanged);
            // 
            // txtDateShow
            // 
            this.txtDateShow.Location = new System.Drawing.Point(338, 47);
            this.txtDateShow.Name = "txtDateShow";
            this.txtDateShow.Size = new System.Drawing.Size(173, 22);
            this.txtDateShow.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "顯示範例";
            // 
            // txtDate
            // 
            this.txtDate.Enabled = false;
            this.txtDate.Location = new System.Drawing.Point(76, 47);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(145, 22);
            this.txtDate.TabIndex = 2;
            this.txtDate.Text = "yyyy年MM月dd日";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "日期格式";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "年份格式";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPWD);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtID);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtComputeOrIP);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(28, 117);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(641, 100);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "資料庫參數設定";
            // 
            // txtPWD
            // 
            this.txtPWD.Location = new System.Drawing.Point(359, 54);
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.PasswordChar = '*';
            this.txtPWD.Size = new System.Drawing.Size(148, 22);
            this.txtPWD.TabIndex = 5;
            this.txtPWD.Text = "12345";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(290, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "登入密碼";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(106, 54);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(129, 22);
            this.txtID.TabIndex = 3;
            this.txtID.Text = "sa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "登入帳號";
            // 
            // txtComputeOrIP
            // 
            this.txtComputeOrIP.Location = new System.Drawing.Point(106, 19);
            this.txtComputeOrIP.Name = "txtComputeOrIP";
            this.txtComputeOrIP.Size = new System.Drawing.Size(129, 22);
            this.txtComputeOrIP.TabIndex = 1;
            this.txtComputeOrIP.Text = "localhost";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "電腦名稱或IP";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtShipTaxRate);
            this.groupBox4.Controls.Add(this.txtStockTaxRate);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(28, 235);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(266, 84);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "營業稅率設定";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(168, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 12);
            this.label10.TabIndex = 7;
            this.label10.Text = "%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(168, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "%";
            // 
            // txtShipTaxRate
            // 
            this.txtShipTaxRate.Location = new System.Drawing.Point(106, 48);
            this.txtShipTaxRate.MaxLength = 3;
            this.txtShipTaxRate.Name = "txtShipTaxRate";
            this.txtShipTaxRate.Size = new System.Drawing.Size(56, 22);
            this.txtShipTaxRate.TabIndex = 3;
            this.txtShipTaxRate.Text = "5";
            // 
            // txtStockTaxRate
            // 
            this.txtStockTaxRate.Location = new System.Drawing.Point(106, 20);
            this.txtStockTaxRate.MaxLength = 3;
            this.txtStockTaxRate.Name = "txtStockTaxRate";
            this.txtStockTaxRate.Size = new System.Drawing.Size(56, 22);
            this.txtStockTaxRate.TabIndex = 2;
            this.txtStockTaxRate.Text = "5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "銷貨稅率";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "進貨稅率";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cboReceiptPoint);
            this.groupBox5.Controls.Add(this.cboItemPoint);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Location = new System.Drawing.Point(320, 235);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(349, 84);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "小數點位數設定";
            // 
            // cboReceiptPoint
            // 
            this.cboReceiptPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReceiptPoint.FormattingEnabled = true;
            this.cboReceiptPoint.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.cboReceiptPoint.Location = new System.Drawing.Point(141, 48);
            this.cboReceiptPoint.Name = "cboReceiptPoint";
            this.cboReceiptPoint.Size = new System.Drawing.Size(59, 20);
            this.cboReceiptPoint.TabIndex = 3;
            // 
            // cboItemPoint
            // 
            this.cboItemPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItemPoint.FormattingEnabled = true;
            this.cboItemPoint.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.cboItemPoint.Location = new System.Drawing.Point(141, 18);
            this.cboItemPoint.Name = "cboItemPoint";
            this.cboItemPoint.Size = new System.Drawing.Size(59, 20);
            this.cboItemPoint.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "單據金額小數位數";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "商品金額小數位數";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Location = new System.Drawing.Point(577, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(92, 58);
            this.groupBox6.TabIndex = 20;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "快速鍵";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "F2-清除輸入";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "F1-關閉表單";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmBasicSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 419);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBasicSetting";
            this.Text = "系統基本設定";
            this.Load += new System.EventHandler(this.FrmBasicSetting_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBasicSetting_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoADShort;
        private System.Windows.Forms.RadioButton rdoAD;
        private System.Windows.Forms.RadioButton rdoROC;
        private System.Windows.Forms.TextBox txtDateShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPWD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtComputeOrIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtShipTaxRate;
        private System.Windows.Forms.TextBox txtStockTaxRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cboReceiptPoint;
        private System.Windows.Forms.ComboBox cboItemPoint;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}