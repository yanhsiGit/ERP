namespace SIS
{
    partial class FrmItemsMaintain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItemsMaintain));
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddNew = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvItemsInfo = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslDataCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxAutoNumber = new System.Windows.Forms.CheckBox();
            this.mtbSafeInventory = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.mtbInventory = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboManufacturer = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mtbMSRP = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mtbCostPrice = new System.Windows.Forms.MaskedTextBox();
            this.mtbSellingPrice = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboItemsUnit = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboItemsType = new System.Windows.Forms.ComboBox();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.Label30 = new System.Windows.Forms.Label();
            this.txtSpecifications = new System.Windows.Forms.TextBox();
            this.Label33 = new System.Windows.Forms.Label();
            this.txtNAME = new System.Windows.Forms.TextBox();
            this.txtItemsID = new System.Windows.Forms.TextBox();
            this.Label37 = new System.Windows.Forms.Label();
            this.Label38 = new System.Windows.Forms.Label();
            this.Label39 = new System.Windows.Forms.Label();
            this.Label40 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ToolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsInfo)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.GroupBox3.SuspendLayout();
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
            this.ToolStrip1.Size = new System.Drawing.Size(1008, 39);
            this.ToolStrip1.TabIndex = 4;
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
            this.groupBox1.Location = new System.Drawing.Point(824, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 53);
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
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.dgvItemsInfo);
            this.GroupBox4.Location = new System.Drawing.Point(22, 328);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(940, 238);
            this.GroupBox4.TabIndex = 23;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "商品資料顯示區";
            // 
            // dgvItemsInfo
            // 
            this.dgvItemsInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItemsInfo.Location = new System.Drawing.Point(3, 18);
            this.dgvItemsInfo.Name = "dgvItemsInfo";
            this.dgvItemsInfo.RowTemplate.Height = 24;
            this.dgvItemsInfo.Size = new System.Drawing.Size(934, 217);
            this.dgvItemsInfo.TabIndex = 0;
            this.dgvItemsInfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvItemsInfo_CellFormatting);
            this.dgvItemsInfo.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvItemsInfo_RowHeaderMouseClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslDataCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 581);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 24;
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
            this.panel1.Location = new System.Drawing.Point(22, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 246);
            this.panel1.TabIndex = 25;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.cbxAutoNumber);
            this.GroupBox3.Controls.Add(this.mtbSafeInventory);
            this.GroupBox3.Controls.Add(this.label8);
            this.GroupBox3.Controls.Add(this.mtbInventory);
            this.GroupBox3.Controls.Add(this.label7);
            this.GroupBox3.Controls.Add(this.cboManufacturer);
            this.GroupBox3.Controls.Add(this.label6);
            this.GroupBox3.Controls.Add(this.mtbMSRP);
            this.GroupBox3.Controls.Add(this.label5);
            this.GroupBox3.Controls.Add(this.mtbCostPrice);
            this.GroupBox3.Controls.Add(this.mtbSellingPrice);
            this.GroupBox3.Controls.Add(this.label2);
            this.GroupBox3.Controls.Add(this.cboItemsUnit);
            this.GroupBox3.Controls.Add(this.label1);
            this.GroupBox3.Controls.Add(this.cboItemsType);
            this.GroupBox3.Controls.Add(this.rtbNotes);
            this.GroupBox3.Controls.Add(this.Label30);
            this.GroupBox3.Controls.Add(this.txtSpecifications);
            this.GroupBox3.Controls.Add(this.Label33);
            this.GroupBox3.Controls.Add(this.txtNAME);
            this.GroupBox3.Controls.Add(this.txtItemsID);
            this.GroupBox3.Controls.Add(this.Label37);
            this.GroupBox3.Controls.Add(this.Label38);
            this.GroupBox3.Controls.Add(this.Label39);
            this.GroupBox3.Controls.Add(this.Label40);
            this.GroupBox3.Location = new System.Drawing.Point(24, 16);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(931, 465);
            this.GroupBox3.TabIndex = 3;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "商品資料填寫區";
            // 
            // cbxAutoNumber
            // 
            this.cbxAutoNumber.AutoSize = true;
            this.cbxAutoNumber.Location = new System.Drawing.Point(261, 17);
            this.cbxAutoNumber.Name = "cbxAutoNumber";
            this.cbxAutoNumber.Size = new System.Drawing.Size(96, 16);
            this.cbxAutoNumber.TabIndex = 66;
            this.cbxAutoNumber.Text = "自動產生編號";
            this.cbxAutoNumber.UseVisualStyleBackColor = true;
            this.cbxAutoNumber.CheckedChanged += new System.EventHandler(this.cbxAutoNumber_CheckedChanged);
            // 
            // mtbSafeInventory
            // 
            this.mtbSafeInventory.Location = new System.Drawing.Point(306, 268);
            this.mtbSafeInventory.Mask = "#####";
            this.mtbSafeInventory.Name = "mtbSafeInventory";
            this.mtbSafeInventory.Size = new System.Drawing.Size(100, 22);
            this.mtbSafeInventory.TabIndex = 65;
            this.mtbSafeInventory.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(235, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 64;
            this.label8.Text = "安全庫存量";
            // 
            // mtbInventory
            // 
            this.mtbInventory.Location = new System.Drawing.Point(306, 234);
            this.mtbInventory.Mask = "#####";
            this.mtbInventory.Name = "mtbInventory";
            this.mtbInventory.Size = new System.Drawing.Size(100, 22);
            this.mtbInventory.TabIndex = 63;
            this.mtbInventory.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(259, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 62;
            this.label7.Text = "庫存量";
            // 
            // cboManufacturer
            // 
            this.cboManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboManufacturer.FormattingEnabled = true;
            this.cboManufacturer.Location = new System.Drawing.Point(306, 198);
            this.cboManufacturer.Name = "cboManufacturer";
            this.cboManufacturer.Size = new System.Drawing.Size(410, 20);
            this.cboManufacturer.TabIndex = 61;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 60;
            this.label6.Text = "進貨廠商";
            // 
            // mtbMSRP
            // 
            this.mtbMSRP.Location = new System.Drawing.Point(83, 304);
            this.mtbMSRP.Mask = "#########";
            this.mtbMSRP.Name = "mtbMSRP";
            this.mtbMSRP.Size = new System.Drawing.Size(100, 22);
            this.mtbMSRP.TabIndex = 59;
            this.mtbMSRP.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 58;
            this.label5.Text = "建議售價";
            // 
            // mtbCostPrice
            // 
            this.mtbCostPrice.Location = new System.Drawing.Point(83, 271);
            this.mtbCostPrice.Mask = "#########";
            this.mtbCostPrice.Name = "mtbCostPrice";
            this.mtbCostPrice.Size = new System.Drawing.Size(100, 22);
            this.mtbCostPrice.TabIndex = 57;
            this.mtbCostPrice.Text = "0";
            // 
            // mtbSellingPrice
            // 
            this.mtbSellingPrice.Location = new System.Drawing.Point(83, 237);
            this.mtbSellingPrice.Mask = "#########";
            this.mtbSellingPrice.Name = "mtbSellingPrice";
            this.mtbSellingPrice.Size = new System.Drawing.Size(100, 22);
            this.mtbSellingPrice.TabIndex = 56;
            this.mtbSellingPrice.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 55;
            this.label2.Text = "出貨價格";
            // 
            // cboItemsUnit
            // 
            this.cboItemsUnit.FormattingEnabled = true;
            this.cboItemsUnit.Items.AddRange(new object[] {
            "個",
            "台",
            "支",
            "隻",
            "張",
            "本",
            "片",
            "箱",
            "對",
            "瓶"});
            this.cboItemsUnit.Location = new System.Drawing.Point(82, 201);
            this.cboItemsUnit.Name = "cboItemsUnit";
            this.cboItemsUnit.Size = new System.Drawing.Size(64, 20);
            this.cboItemsUnit.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 53;
            this.label1.Text = "基本單位";
            // 
            // cboItemsType
            // 
            this.cboItemsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItemsType.FormattingEnabled = true;
            this.cboItemsType.Location = new System.Drawing.Point(83, 81);
            this.cboItemsType.Name = "cboItemsType";
            this.cboItemsType.Size = new System.Drawing.Size(150, 20);
            this.cboItemsType.TabIndex = 52;
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(82, 346);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(624, 104);
            this.rtbNotes.TabIndex = 50;
            this.rtbNotes.Text = "";
            // 
            // Label30
            // 
            this.Label30.AutoSize = true;
            this.Label30.Location = new System.Drawing.Point(41, 339);
            this.Label30.Name = "Label30";
            this.Label30.Size = new System.Drawing.Size(29, 12);
            this.Label30.TabIndex = 26;
            this.Label30.Text = "備註";
            // 
            // txtSpecifications
            // 
            this.txtSpecifications.Location = new System.Drawing.Point(83, 114);
            this.txtSpecifications.MaxLength = 10000;
            this.txtSpecifications.Multiline = true;
            this.txtSpecifications.Name = "txtSpecifications";
            this.txtSpecifications.Size = new System.Drawing.Size(633, 78);
            this.txtSpecifications.TabIndex = 21;
            // 
            // Label33
            // 
            this.Label33.AutoSize = true;
            this.Label33.Location = new System.Drawing.Point(22, 117);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(53, 12);
            this.Label33.TabIndex = 20;
            this.Label33.Text = "商品規格";
            // 
            // txtNAME
            // 
            this.txtNAME.Location = new System.Drawing.Point(82, 46);
            this.txtNAME.MaxLength = 100;
            this.txtNAME.Name = "txtNAME";
            this.txtNAME.Size = new System.Drawing.Size(634, 22);
            this.txtNAME.TabIndex = 8;
            // 
            // txtItemsID
            // 
            this.txtItemsID.Location = new System.Drawing.Point(82, 17);
            this.txtItemsID.MaxLength = 20;
            this.txtItemsID.Name = "txtItemsID";
            this.txtItemsID.Size = new System.Drawing.Size(151, 22);
            this.txtItemsID.TabIndex = 7;
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Location = new System.Drawing.Point(22, 271);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(53, 12);
            this.Label37.TabIndex = 3;
            this.Label37.Text = "進貨價格";
            // 
            // Label38
            // 
            this.Label38.AutoSize = true;
            this.Label38.Location = new System.Drawing.Point(22, 81);
            this.Label38.Name = "Label38";
            this.Label38.Size = new System.Drawing.Size(53, 12);
            this.Label38.TabIndex = 2;
            this.Label38.Text = "商品類別";
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
            this.Label40.Text = "商品編號";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Copy.ico");
            this.imageList1.Images.SetKeyName(1, "Cut.ico");
            this.imageList1.Images.SetKeyName(2, "Paste.ico");
            // 
            // FrmItemsMaintain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 603);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmItemsMaintain";
            this.Text = "商品資料";
            this.Load += new System.EventHandler(this.FrmItemsMaintain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmItemsMaintain_KeyDown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsInfo)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
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
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.DataGridView dgvItemsInfo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslDataCount;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.RichTextBox rtbNotes;
        internal System.Windows.Forms.Label Label30;
        internal System.Windows.Forms.TextBox txtSpecifications;
        internal System.Windows.Forms.Label Label33;
        internal System.Windows.Forms.TextBox txtNAME;
        internal System.Windows.Forms.TextBox txtItemsID;
        internal System.Windows.Forms.Label Label37;
        internal System.Windows.Forms.Label Label38;
        internal System.Windows.Forms.Label Label39;
        internal System.Windows.Forms.Label Label40;
        private System.Windows.Forms.MaskedTextBox mtbSafeInventory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox mtbInventory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboManufacturer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mtbMSRP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox mtbCostPrice;
        private System.Windows.Forms.MaskedTextBox mtbSellingPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboItemsUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboItemsType;
        private System.Windows.Forms.CheckBox cbxAutoNumber;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ImageList imageList1;
    }
}