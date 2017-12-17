namespace SIS
{
    partial class FrmCustomerMaintain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerMaintain));
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddNew = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslDataCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.Label36 = new System.Windows.Forms.Label();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.mtbFax = new System.Windows.Forms.MaskedTextBox();
            this.mtbMobilePhone = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Label41 = new System.Windows.Forms.Label();
            this.PicPhotos = new System.Windows.Forms.PictureBox();
            this.mtbPhone = new System.Windows.Forms.MaskedTextBox();
            this.Label28 = new System.Windows.Forms.Label();
            this.Label30 = new System.Windows.Forms.Label();
            this.Label32 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.Label33 = new System.Windows.Forms.Label();
            this.cboCustomerType = new System.Windows.Forms.ComboBox();
            this.txtENAME = new System.Windows.Forms.TextBox();
            this.txtCNAME = new System.Windows.Forms.TextBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.Label37 = new System.Windows.Forms.Label();
            this.Label38 = new System.Windows.Forms.Label();
            this.Label39 = new System.Windows.Forms.Label();
            this.Label40 = new System.Windows.Forms.Label();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvCustomerInfo = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ToolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPhotos)).BeginInit();
            this.GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddNew,
            this.tsbUpdate,
            this.tsbDelete,
            this.tsbClear,
            this.tsbExit});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(759, 39);
            this.ToolStrip1.TabIndex = 3;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // tsbAddNew
            // 
            this.tsbAddNew.Image = global::SIS.Properties.Resources.New;
            this.tsbAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddNew.Name = "tsbAddNew";
            this.tsbAddNew.Size = new System.Drawing.Size(67, 36);
            this.tsbAddNew.Text = "新增";
            this.tsbAddNew.Click += new System.EventHandler(this.tsbAddNew_Click);
            // 
            // tsbUpdate
            // 
            this.tsbUpdate.Image = global::SIS.Properties.Resources.Modify;
            this.tsbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdate.Name = "tsbUpdate";
            this.tsbUpdate.Size = new System.Drawing.Size(67, 36);
            this.tsbUpdate.Text = "更改";
            this.tsbUpdate.Click += new System.EventHandler(this.tsbUpdate_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::SIS.Properties.Resources.Remove;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(67, 36);
            this.tsbDelete.Text = "刪除";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbClear
            // 
            this.tsbClear.Image = global::SIS.Properties.Resources.clear;
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(67, 36);
            this.tsbClear.Text = "清除";
            this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = global::SIS.Properties.Resources.Exit;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(67, 36);
            this.tsbExit.Text = "離開";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(614, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(103, 53);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "快速鍵";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "F2-清除輸入";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "F1-關閉表單";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslDataCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 588);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(759, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel1.Text = "資料筆數：";
            // 
            // tsslDataCount
            // 
            this.tsslDataCount.ForeColor = System.Drawing.Color.Blue;
            this.tsslDataCount.Name = "tsslDataCount";
            this.tsslDataCount.Size = new System.Drawing.Size(17, 17);
            this.tsslDataCount.Text = "N";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.GroupBox3);
            this.panel1.Location = new System.Drawing.Point(25, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 236);
            this.panel1.TabIndex = 22;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.dtpBirthday);
            this.GroupBox3.Controls.Add(this.Label36);
            this.GroupBox3.Controls.Add(this.rtbNotes);
            this.GroupBox3.Controls.Add(this.mtbFax);
            this.GroupBox3.Controls.Add(this.mtbMobilePhone);
            this.GroupBox3.Controls.Add(this.label1);
            this.GroupBox3.Controls.Add(this.Label41);
            this.GroupBox3.Controls.Add(this.PicPhotos);
            this.GroupBox3.Controls.Add(this.mtbPhone);
            this.GroupBox3.Controls.Add(this.Label28);
            this.GroupBox3.Controls.Add(this.Label30);
            this.GroupBox3.Controls.Add(this.Label32);
            this.GroupBox3.Controls.Add(this.txtAddress);
            this.GroupBox3.Controls.Add(this.Label33);
            this.GroupBox3.Controls.Add(this.cboCustomerType);
            this.GroupBox3.Controls.Add(this.txtENAME);
            this.GroupBox3.Controls.Add(this.txtCNAME);
            this.GroupBox3.Controls.Add(this.txtCustomerID);
            this.GroupBox3.Controls.Add(this.Label37);
            this.GroupBox3.Controls.Add(this.Label38);
            this.GroupBox3.Controls.Add(this.Label39);
            this.GroupBox3.Controls.Add(this.Label40);
            this.GroupBox3.Location = new System.Drawing.Point(18, 18);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(684, 465);
            this.GroupBox3.TabIndex = 3;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "客戶資料填寫區";
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Location = new System.Drawing.Point(82, 112);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(128, 22);
            this.dtpBirthday.TabIndex = 53;
            // 
            // Label36
            // 
            this.Label36.AutoSize = true;
            this.Label36.Location = new System.Drawing.Point(21, 119);
            this.Label36.Name = "Label36";
            this.Label36.Size = new System.Drawing.Size(53, 12);
            this.Label36.TabIndex = 52;
            this.Label36.Text = "客戶生日";
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(22, 331);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(624, 117);
            this.rtbNotes.TabIndex = 51;
            this.rtbNotes.Text = "";
            // 
            // mtbFax
            // 
            this.mtbFax.Location = new System.Drawing.Point(82, 242);
            this.mtbFax.Mask = "0000000000";
            this.mtbFax.Name = "mtbFax";
            this.mtbFax.Size = new System.Drawing.Size(100, 22);
            this.mtbFax.TabIndex = 40;
            // 
            // mtbMobilePhone
            // 
            this.mtbMobilePhone.Location = new System.Drawing.Point(82, 209);
            this.mtbMobilePhone.Mask = "0000000000";
            this.mtbMobilePhone.Name = "mtbMobilePhone";
            this.mtbMobilePhone.Size = new System.Drawing.Size(100, 22);
            this.mtbMobilePhone.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "客戶手機";
            // 
            // Label41
            // 
            this.Label41.AutoSize = true;
            this.Label41.Location = new System.Drawing.Point(313, 56);
            this.Label41.Name = "Label41";
            this.Label41.Size = new System.Drawing.Size(29, 12);
            this.Label41.TabIndex = 35;
            this.Label41.Text = "相片";
            // 
            // PicPhotos
            // 
            this.PicPhotos.Image = global::SIS.Properties.Resources.NoPicture;
            this.PicPhotos.Location = new System.Drawing.Point(360, 17);
            this.PicPhotos.Name = "PicPhotos";
            this.PicPhotos.Size = new System.Drawing.Size(150, 150);
            this.PicPhotos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicPhotos.TabIndex = 34;
            this.PicPhotos.TabStop = false;
            this.PicPhotos.Click += new System.EventHandler(this.PicPhotos_Click);
            // 
            // mtbPhone
            // 
            this.mtbPhone.Location = new System.Drawing.Point(82, 178);
            this.mtbPhone.Mask = "0000000000";
            this.mtbPhone.Name = "mtbPhone";
            this.mtbPhone.Size = new System.Drawing.Size(100, 22);
            this.mtbPhone.TabIndex = 31;
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.Location = new System.Drawing.Point(23, 178);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(53, 12);
            this.Label28.TabIndex = 30;
            this.Label28.Text = "客戶電話";
            // 
            // Label30
            // 
            this.Label30.AutoSize = true;
            this.Label30.Location = new System.Drawing.Point(23, 242);
            this.Label30.Name = "Label30";
            this.Label30.Size = new System.Drawing.Size(53, 12);
            this.Label30.TabIndex = 26;
            this.Label30.Text = "客戶傳真";
            // 
            // Label32
            // 
            this.Label32.AutoSize = true;
            this.Label32.Location = new System.Drawing.Point(44, 307);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(29, 12);
            this.Label32.TabIndex = 22;
            this.Label32.Text = "備註";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(82, 273);
            this.txtAddress.MaxLength = 100;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(449, 22);
            this.txtAddress.TabIndex = 21;
            // 
            // Label33
            // 
            this.Label33.AutoSize = true;
            this.Label33.Location = new System.Drawing.Point(23, 276);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(53, 12);
            this.Label33.TabIndex = 20;
            this.Label33.Text = "客戶地址";
            // 
            // cboCustomerType
            // 
            this.cboCustomerType.FormattingEnabled = true;
            this.cboCustomerType.Items.AddRange(new object[] {
            "金卡",
            "銀卡",
            "普通"});
            this.cboCustomerType.Location = new System.Drawing.Point(82, 147);
            this.cboCustomerType.Name = "cboCustomerType";
            this.cboCustomerType.Size = new System.Drawing.Size(100, 20);
            this.cboCustomerType.TabIndex = 16;
            // 
            // txtENAME
            // 
            this.txtENAME.Location = new System.Drawing.Point(82, 75);
            this.txtENAME.MaxLength = 30;
            this.txtENAME.Name = "txtENAME";
            this.txtENAME.Size = new System.Drawing.Size(100, 22);
            this.txtENAME.TabIndex = 9;
            // 
            // txtCNAME
            // 
            this.txtCNAME.Location = new System.Drawing.Point(82, 46);
            this.txtCNAME.MaxLength = 20;
            this.txtCNAME.Name = "txtCNAME";
            this.txtCNAME.Size = new System.Drawing.Size(208, 22);
            this.txtCNAME.TabIndex = 8;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(82, 17);
            this.txtCustomerID.MaxLength = 20;
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(100, 22);
            this.txtCustomerID.TabIndex = 7;
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Location = new System.Drawing.Point(20, 150);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(53, 12);
            this.Label37.TabIndex = 3;
            this.Label37.Text = "客戶類型";
            // 
            // Label38
            // 
            this.Label38.AutoSize = true;
            this.Label38.Location = new System.Drawing.Point(22, 84);
            this.Label38.Name = "Label38";
            this.Label38.Size = new System.Drawing.Size(53, 12);
            this.Label38.TabIndex = 2;
            this.Label38.Text = "英文名稱";
            // 
            // Label39
            // 
            this.Label39.AutoSize = true;
            this.Label39.ForeColor = System.Drawing.Color.Red;
            this.Label39.Location = new System.Drawing.Point(20, 53);
            this.Label39.Name = "Label39";
            this.Label39.Size = new System.Drawing.Size(53, 12);
            this.Label39.TabIndex = 1;
            this.Label39.Text = "中文名稱";
            // 
            // Label40
            // 
            this.Label40.AutoSize = true;
            this.Label40.ForeColor = System.Drawing.Color.Red;
            this.Label40.Location = new System.Drawing.Point(20, 22);
            this.Label40.Name = "Label40";
            this.Label40.Size = new System.Drawing.Size(53, 12);
            this.Label40.TabIndex = 0;
            this.Label40.Text = "客戶編號";
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.dgvCustomerInfo);
            this.GroupBox4.Location = new System.Drawing.Point(31, 332);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(678, 236);
            this.GroupBox4.TabIndex = 23;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "客戶資料顯示區";
            // 
            // dgvCustomerInfo
            // 
            this.dgvCustomerInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomerInfo.Location = new System.Drawing.Point(3, 18);
            this.dgvCustomerInfo.Name = "dgvCustomerInfo";
            this.dgvCustomerInfo.RowTemplate.Height = 24;
            this.dgvCustomerInfo.Size = new System.Drawing.Size(672, 215);
            this.dgvCustomerInfo.TabIndex = 0;
            this.dgvCustomerInfo.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCustomerInfo_RowHeaderMouseClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmCustomerMaintain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 610);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCustomerMaintain";
            this.Text = "客戶資料";
            this.Load += new System.EventHandler(this.FrmCustomerMaintain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCustomerMaintain_KeyDown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPhotos)).EndInit();
            this.GroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton tsbAddNew;
        internal System.Windows.Forms.ToolStripButton tsbUpdate;
        internal System.Windows.Forms.ToolStripButton tsbDelete;
        internal System.Windows.Forms.ToolStripButton tsbClear;
        internal System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslDataCount;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label Label41;
        internal System.Windows.Forms.PictureBox PicPhotos;
        internal System.Windows.Forms.MaskedTextBox mtbPhone;
        internal System.Windows.Forms.Label Label28;
        internal System.Windows.Forms.Label Label30;
        internal System.Windows.Forms.Label Label32;
        internal System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.Label Label33;
        internal System.Windows.Forms.ComboBox cboCustomerType;
        internal System.Windows.Forms.TextBox txtENAME;
        internal System.Windows.Forms.TextBox txtCNAME;
        internal System.Windows.Forms.TextBox txtCustomerID;
        internal System.Windows.Forms.Label Label37;
        internal System.Windows.Forms.Label Label38;
        internal System.Windows.Forms.Label Label39;
        internal System.Windows.Forms.Label Label40;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.DataGridView dgvCustomerInfo;
        internal System.Windows.Forms.MaskedTextBox mtbFax;
        internal System.Windows.Forms.MaskedTextBox mtbMobilePhone;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.DateTimePicker dtpBirthday;
        internal System.Windows.Forms.Label Label36;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}