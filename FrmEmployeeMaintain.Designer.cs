namespace SIS
{
    partial class FrmEmployeeMaintain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmployeeMaintain));
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddNew = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.Label41 = new System.Windows.Forms.Label();
            this.PicPhotos = new System.Windows.Forms.PictureBox();
            this.Label27 = new System.Windows.Forms.Label();
            this.mtbPhone = new System.Windows.Forms.MaskedTextBox();
            this.Label28 = new System.Windows.Forms.Label();
            this.txtBackground = new System.Windows.Forms.TextBox();
            this.Label29 = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.Label30 = new System.Windows.Forms.Label();
            this.dtpHireDate = new System.Windows.Forms.DateTimePicker();
            this.Label31 = new System.Windows.Forms.Label();
            this.txtProfessional = new System.Windows.Forms.TextBox();
            this.Label32 = new System.Windows.Forms.Label();
            this.txtPresentAddress = new System.Windows.Forms.TextBox();
            this.Label33 = new System.Windows.Forms.Label();
            this.mtbID = new System.Windows.Forms.MaskedTextBox();
            this.cboBooldType = new System.Windows.Forms.ComboBox();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.txtENAME = new System.Windows.Forms.TextBox();
            this.txtCNAME = new System.Windows.Forms.TextBox();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.Label34 = new System.Windows.Forms.Label();
            this.Label35 = new System.Windows.Forms.Label();
            this.Label36 = new System.Windows.Forms.Label();
            this.Label37 = new System.Windows.Forms.Label();
            this.Label38 = new System.Windows.Forms.Label();
            this.Label39 = new System.Windows.Forms.Label();
            this.Label40 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvEmployeeInfo = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslDataCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ToolStrip1.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPhotos)).BeginInit();
            this.panel1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeInfo)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.ToolStrip1.Size = new System.Drawing.Size(778, 39);
            this.ToolStrip1.TabIndex = 2;
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
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.cboStatus);
            this.GroupBox3.Controls.Add(this.Label41);
            this.GroupBox3.Controls.Add(this.PicPhotos);
            this.GroupBox3.Controls.Add(this.Label27);
            this.GroupBox3.Controls.Add(this.mtbPhone);
            this.GroupBox3.Controls.Add(this.Label28);
            this.GroupBox3.Controls.Add(this.txtBackground);
            this.GroupBox3.Controls.Add(this.Label29);
            this.GroupBox3.Controls.Add(this.txtPosition);
            this.GroupBox3.Controls.Add(this.Label30);
            this.GroupBox3.Controls.Add(this.dtpHireDate);
            this.GroupBox3.Controls.Add(this.Label31);
            this.GroupBox3.Controls.Add(this.txtProfessional);
            this.GroupBox3.Controls.Add(this.Label32);
            this.GroupBox3.Controls.Add(this.txtPresentAddress);
            this.GroupBox3.Controls.Add(this.Label33);
            this.GroupBox3.Controls.Add(this.mtbID);
            this.GroupBox3.Controls.Add(this.cboBooldType);
            this.GroupBox3.Controls.Add(this.dtpBirthday);
            this.GroupBox3.Controls.Add(this.cboSex);
            this.GroupBox3.Controls.Add(this.txtENAME);
            this.GroupBox3.Controls.Add(this.txtCNAME);
            this.GroupBox3.Controls.Add(this.txtEmployeeID);
            this.GroupBox3.Controls.Add(this.Label34);
            this.GroupBox3.Controls.Add(this.Label35);
            this.GroupBox3.Controls.Add(this.Label36);
            this.GroupBox3.Controls.Add(this.Label37);
            this.GroupBox3.Controls.Add(this.Label38);
            this.GroupBox3.Controls.Add(this.Label39);
            this.GroupBox3.Controls.Add(this.Label40);
            this.GroupBox3.Location = new System.Drawing.Point(24, 16);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(660, 357);
            this.GroupBox3.TabIndex = 3;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "職員資料填寫區";
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "在職",
            "留職",
            "離職"});
            this.cboStatus.Location = new System.Drawing.Point(82, 324);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(80, 20);
            this.cboStatus.TabIndex = 37;
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
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.Location = new System.Drawing.Point(23, 327);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(53, 12);
            this.Label27.TabIndex = 32;
            this.Label27.Text = "就職狀態";
            // 
            // mtbPhone
            // 
            this.mtbPhone.Location = new System.Drawing.Point(423, 237);
            this.mtbPhone.Mask = "0000000000";
            this.mtbPhone.Name = "mtbPhone";
            this.mtbPhone.Size = new System.Drawing.Size(100, 22);
            this.mtbPhone.TabIndex = 31;
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.Location = new System.Drawing.Point(388, 244);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(29, 12);
            this.Label28.TabIndex = 30;
            this.Label28.Text = "電話";
            // 
            // txtBackground
            // 
            this.txtBackground.Location = new System.Drawing.Point(423, 298);
            this.txtBackground.MaxLength = 100;
            this.txtBackground.Name = "txtBackground";
            this.txtBackground.Size = new System.Drawing.Size(137, 22);
            this.txtBackground.TabIndex = 29;
            // 
            // Label29
            // 
            this.Label29.AutoSize = true;
            this.Label29.Location = new System.Drawing.Point(364, 303);
            this.Label29.Name = "Label29";
            this.Label29.Size = new System.Drawing.Size(53, 12);
            this.Label29.TabIndex = 28;
            this.Label29.Text = "最高學歷";
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(423, 265);
            this.txtPosition.MaxLength = 20;
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(137, 22);
            this.txtPosition.TabIndex = 27;
            // 
            // Label30
            // 
            this.Label30.AutoSize = true;
            this.Label30.Location = new System.Drawing.Point(388, 268);
            this.Label30.Name = "Label30";
            this.Label30.Size = new System.Drawing.Size(29, 12);
            this.Label30.TabIndex = 26;
            this.Label30.Text = "職稱";
            // 
            // dtpHireDate
            // 
            this.dtpHireDate.Location = new System.Drawing.Point(82, 293);
            this.dtpHireDate.Name = "dtpHireDate";
            this.dtpHireDate.Size = new System.Drawing.Size(200, 22);
            this.dtpHireDate.TabIndex = 25;
            // 
            // Label31
            // 
            this.Label31.AutoSize = true;
            this.Label31.Location = new System.Drawing.Point(18, 298);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(53, 12);
            this.Label31.TabIndex = 24;
            this.Label31.Text = "到職日期";
            // 
            // txtProfessional
            // 
            this.txtProfessional.Location = new System.Drawing.Point(82, 265);
            this.txtProfessional.MaxLength = 30;
            this.txtProfessional.Name = "txtProfessional";
            this.txtProfessional.Size = new System.Drawing.Size(200, 22);
            this.txtProfessional.TabIndex = 23;
            // 
            // Label32
            // 
            this.Label32.AutoSize = true;
            this.Label32.Location = new System.Drawing.Point(42, 268);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(29, 12);
            this.Label32.TabIndex = 22;
            this.Label32.Text = "專長";
            // 
            // txtPresentAddress
            // 
            this.txtPresentAddress.Location = new System.Drawing.Point(82, 237);
            this.txtPresentAddress.MaxLength = 100;
            this.txtPresentAddress.Name = "txtPresentAddress";
            this.txtPresentAddress.Size = new System.Drawing.Size(274, 22);
            this.txtPresentAddress.TabIndex = 21;
            // 
            // Label33
            // 
            this.Label33.AutoSize = true;
            this.Label33.Location = new System.Drawing.Point(18, 240);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(53, 12);
            this.Label33.TabIndex = 20;
            this.Label33.Text = "通訊地址";
            // 
            // mtbID
            // 
            this.mtbID.Location = new System.Drawing.Point(82, 198);
            this.mtbID.Mask = "L000000000";
            this.mtbID.Name = "mtbID";
            this.mtbID.Size = new System.Drawing.Size(100, 22);
            this.mtbID.TabIndex = 19;
            // 
            // cboBooldType
            // 
            this.cboBooldType.FormattingEnabled = true;
            this.cboBooldType.Items.AddRange(new object[] {
            "A",
            "B",
            "O",
            "AB"});
            this.cboBooldType.Location = new System.Drawing.Point(82, 167);
            this.cboBooldType.Name = "cboBooldType";
            this.cboBooldType.Size = new System.Drawing.Size(100, 20);
            this.cboBooldType.TabIndex = 18;
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Location = new System.Drawing.Point(82, 134);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(128, 22);
            this.dtpBirthday.TabIndex = 17;
            // 
            // cboSex
            // 
            this.cboSex.FormattingEnabled = true;
            this.cboSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cboSex.Location = new System.Drawing.Point(82, 107);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(100, 20);
            this.cboSex.TabIndex = 16;
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
            this.txtCNAME.MaxLength = 10;
            this.txtCNAME.Name = "txtCNAME";
            this.txtCNAME.Size = new System.Drawing.Size(100, 22);
            this.txtCNAME.TabIndex = 8;
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Location = new System.Drawing.Point(82, 17);
            this.txtEmployeeID.MaxLength = 20;
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(100, 22);
            this.txtEmployeeID.TabIndex = 7;
            // 
            // Label34
            // 
            this.Label34.AutoSize = true;
            this.Label34.Location = new System.Drawing.Point(6, 208);
            this.Label34.Name = "Label34";
            this.Label34.Size = new System.Drawing.Size(65, 12);
            this.Label34.TabIndex = 6;
            this.Label34.Text = "身份證字號";
            // 
            // Label35
            // 
            this.Label35.AutoSize = true;
            this.Label35.Location = new System.Drawing.Point(44, 175);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(29, 12);
            this.Label35.TabIndex = 5;
            this.Label35.Text = "血型";
            // 
            // Label36
            // 
            this.Label36.AutoSize = true;
            this.Label36.Location = new System.Drawing.Point(44, 145);
            this.Label36.Name = "Label36";
            this.Label36.Size = new System.Drawing.Size(29, 12);
            this.Label36.TabIndex = 4;
            this.Label36.Text = "生日";
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Location = new System.Drawing.Point(44, 115);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(29, 12);
            this.Label37.TabIndex = 3;
            this.Label37.Text = "性別";
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
            this.Label40.Text = "職員編號";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.GroupBox3);
            this.panel1.Location = new System.Drawing.Point(44, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 246);
            this.panel1.TabIndex = 4;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.dgvEmployeeInfo);
            this.GroupBox4.Location = new System.Drawing.Point(44, 336);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(678, 236);
            this.GroupBox4.TabIndex = 5;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "職員資料顯示區";
            // 
            // dgvEmployeeInfo
            // 
            this.dgvEmployeeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmployeeInfo.Location = new System.Drawing.Point(3, 18);
            this.dgvEmployeeInfo.Name = "dgvEmployeeInfo";
            this.dgvEmployeeInfo.RowTemplate.Height = 24;
            this.dgvEmployeeInfo.Size = new System.Drawing.Size(672, 215);
            this.dgvEmployeeInfo.TabIndex = 0;
            this.dgvEmployeeInfo.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEmployeeInfo_RowHeaderMouseClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslDataCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 585);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(778, 22);
            this.statusStrip1.TabIndex = 6;
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(594, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 53);
            this.groupBox1.TabIndex = 19;
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
            // FrmEmployeeMaintain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 607);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEmployeeMaintain";
            this.Text = "員工資料";
            this.Load += new System.EventHandler(this.FrmEmployeeMaintain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEmployeeMaintain_KeyDown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPhotos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.GroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeInfo)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label Label41;
        internal System.Windows.Forms.PictureBox PicPhotos;
        internal System.Windows.Forms.Label Label27;
        internal System.Windows.Forms.MaskedTextBox mtbPhone;
        internal System.Windows.Forms.Label Label28;
        internal System.Windows.Forms.TextBox txtBackground;
        internal System.Windows.Forms.Label Label29;
        internal System.Windows.Forms.TextBox txtPosition;
        internal System.Windows.Forms.Label Label30;
        internal System.Windows.Forms.DateTimePicker dtpHireDate;
        internal System.Windows.Forms.Label Label31;
        internal System.Windows.Forms.TextBox txtProfessional;
        internal System.Windows.Forms.Label Label32;
        internal System.Windows.Forms.TextBox txtPresentAddress;
        internal System.Windows.Forms.Label Label33;
        internal System.Windows.Forms.MaskedTextBox mtbID;
        internal System.Windows.Forms.ComboBox cboBooldType;
        internal System.Windows.Forms.DateTimePicker dtpBirthday;
        internal System.Windows.Forms.ComboBox cboSex;
        internal System.Windows.Forms.TextBox txtENAME;
        internal System.Windows.Forms.TextBox txtCNAME;
        internal System.Windows.Forms.TextBox txtEmployeeID;
        internal System.Windows.Forms.Label Label34;
        internal System.Windows.Forms.Label Label35;
        internal System.Windows.Forms.Label Label36;
        internal System.Windows.Forms.Label Label37;
        internal System.Windows.Forms.Label Label38;
        internal System.Windows.Forms.Label Label39;
        internal System.Windows.Forms.Label Label40;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.DataGridView dgvEmployeeInfo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslDataCount;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}