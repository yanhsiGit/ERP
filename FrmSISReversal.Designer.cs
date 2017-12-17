namespace SIS
{
    partial class FrmSISReversal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSISReversal));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddNew = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tsbQuery = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslDataCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvAccountsReceivable = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvAccountsPayable = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mtbReversalAmount = new System.Windows.Forms.MaskedTextBox();
            this.cbxIsReversal = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPaymentAmount = new System.Windows.Forms.TextBox();
            this.lblPaymentAmount = new System.Windows.Forms.Label();
            this.txtCustomerOrManufacturer = new System.Windows.Forms.TextBox();
            this.txtStockIDOrShipID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblCustomerOrManufacturer = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdoReversalShip = new System.Windows.Forms.RadioButton();
            this.rdoReversalStock = new System.Windows.Forms.RadioButton();
            this.cboPaymentType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboReversalStaff = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpReversalDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAutoNumber = new System.Windows.Forms.Button();
            this.txtReversalID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountsReceivable)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountsPayable)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(833, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 53);
            this.groupBox1.TabIndex = 32;
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
            // ToolStrip1
            // 
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddNew,
            this.tsbUpdate,
            this.tsbDelete,
            this.tsbClear,
            this.tsbQuery,
            this.tsbPrint,
            this.tsbExit});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(1010, 39);
            this.ToolStrip1.TabIndex = 31;
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
            // tsbQuery
            // 
            this.tsbQuery.Image = global::SIS.Properties.Resources.Query;
            this.tsbQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQuery.Name = "tsbQuery";
            this.tsbQuery.Size = new System.Drawing.Size(67, 36);
            this.tsbQuery.Text = "查詢";
            this.tsbQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsbQuery.Click += new System.EventHandler(this.tsbQuery_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.Image = global::SIS.Properties.Resources.print;
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(67, 36);
            this.tsbPrint.Text = "列印";
            this.tsbPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslDataCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 551);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1010, 22);
            this.statusStrip1.TabIndex = 33;
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
            // dgvAccountsReceivable
            // 
            this.dgvAccountsReceivable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountsReceivable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccountsReceivable.Location = new System.Drawing.Point(3, 3);
            this.dgvAccountsReceivable.Name = "dgvAccountsReceivable";
            this.dgvAccountsReceivable.RowTemplate.Height = 24;
            this.dgvAccountsReceivable.Size = new System.Drawing.Size(956, 249);
            this.dgvAccountsReceivable.TabIndex = 0;
            this.dgvAccountsReceivable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAccountsReceivable_CellFormatting);
            this.dgvAccountsReceivable.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAccountsReceivable_RowHeaderMouseClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(18, 261);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(970, 281);
            this.tabControl1.TabIndex = 35;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvAccountsReceivable);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(962, 255);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "應收沖銷";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvAccountsPayable);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(962, 255);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "應付沖銷";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvAccountsPayable
            // 
            this.dgvAccountsPayable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountsPayable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccountsPayable.Location = new System.Drawing.Point(3, 3);
            this.dgvAccountsPayable.Name = "dgvAccountsPayable";
            this.dgvAccountsPayable.RowTemplate.Height = 24;
            this.dgvAccountsPayable.Size = new System.Drawing.Size(956, 249);
            this.dgvAccountsPayable.TabIndex = 1;
            this.dgvAccountsPayable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAccountsPayable_CellFormatting);
            this.dgvAccountsPayable.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAccountsPayable_RowHeaderMouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mtbReversalAmount);
            this.groupBox2.Controls.Add(this.cbxIsReversal);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtPaymentAmount);
            this.groupBox2.Controls.Add(this.lblPaymentAmount);
            this.groupBox2.Controls.Add(this.txtCustomerOrManufacturer);
            this.groupBox2.Controls.Add(this.txtStockIDOrShipID);
            this.groupBox2.Controls.Add(this.lblID);
            this.groupBox2.Controls.Add(this.lblCustomerOrManufacturer);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.cboPaymentType);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.rtbNotes);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.cboReversalStaff);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.dtpReversalDate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnAutoNumber);
            this.groupBox2.Controls.Add(this.txtReversalID);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(18, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(970, 192);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "沖銷主表區";
            // 
            // mtbReversalAmount
            // 
            this.mtbReversalAmount.Location = new System.Drawing.Point(478, 82);
            this.mtbReversalAmount.Mask = "999999999999";
            this.mtbReversalAmount.Name = "mtbReversalAmount";
            this.mtbReversalAmount.Size = new System.Drawing.Size(142, 22);
            this.mtbReversalAmount.TabIndex = 79;
            // 
            // cbxIsReversal
            // 
            this.cbxIsReversal.AutoSize = true;
            this.cbxIsReversal.Location = new System.Drawing.Point(626, 85);
            this.cbxIsReversal.Name = "cbxIsReversal";
            this.cbxIsReversal.Size = new System.Drawing.Size(72, 16);
            this.cbxIsReversal.TabIndex = 78;
            this.cbxIsReversal.Text = "是否沖銷";
            this.cbxIsReversal.UseVisualStyleBackColor = true;
            this.cbxIsReversal.CheckedChanged += new System.EventHandler(this.cbxIsReversal_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(419, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 76;
            this.label8.Text = "沖銷金額";
            // 
            // txtPaymentAmount
            // 
            this.txtPaymentAmount.Enabled = false;
            this.txtPaymentAmount.Location = new System.Drawing.Point(477, 51);
            this.txtPaymentAmount.Name = "txtPaymentAmount";
            this.txtPaymentAmount.Size = new System.Drawing.Size(143, 22);
            this.txtPaymentAmount.TabIndex = 75;
            // 
            // lblPaymentAmount
            // 
            this.lblPaymentAmount.AutoSize = true;
            this.lblPaymentAmount.Location = new System.Drawing.Point(417, 57);
            this.lblPaymentAmount.Name = "lblPaymentAmount";
            this.lblPaymentAmount.Size = new System.Drawing.Size(53, 12);
            this.lblPaymentAmount.TabIndex = 74;
            this.lblPaymentAmount.Text = "應收金額";
            // 
            // txtCustomerOrManufacturer
            // 
            this.txtCustomerOrManufacturer.Location = new System.Drawing.Point(88, 121);
            this.txtCustomerOrManufacturer.Name = "txtCustomerOrManufacturer";
            this.txtCustomerOrManufacturer.Size = new System.Drawing.Size(289, 22);
            this.txtCustomerOrManufacturer.TabIndex = 73;
            // 
            // txtStockIDOrShipID
            // 
            this.txtStockIDOrShipID.Location = new System.Drawing.Point(88, 152);
            this.txtStockIDOrShipID.Name = "txtStockIDOrShipID";
            this.txtStockIDOrShipID.Size = new System.Drawing.Size(213, 22);
            this.txtStockIDOrShipID.TabIndex = 72;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(18, 155);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(53, 12);
            this.lblID.TabIndex = 71;
            this.lblID.Text = "出貨單號";
            // 
            // lblCustomerOrManufacturer
            // 
            this.lblCustomerOrManufacturer.AutoSize = true;
            this.lblCustomerOrManufacturer.Location = new System.Drawing.Point(19, 124);
            this.lblCustomerOrManufacturer.Name = "lblCustomerOrManufacturer";
            this.lblCustomerOrManufacturer.Size = new System.Drawing.Size(53, 12);
            this.lblCustomerOrManufacturer.TabIndex = 69;
            this.lblCustomerOrManufacturer.Text = "客戶名稱";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdoReversalShip);
            this.groupBox4.Controls.Add(this.rdoReversalStock);
            this.groupBox4.Location = new System.Drawing.Point(20, 51);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(281, 55);
            this.groupBox4.TabIndex = 68;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "沖銷類型";
            // 
            // rdoReversalShip
            // 
            this.rdoReversalShip.AutoSize = true;
            this.rdoReversalShip.Location = new System.Drawing.Point(135, 22);
            this.rdoReversalShip.Name = "rdoReversalShip";
            this.rdoReversalShip.Size = new System.Drawing.Size(103, 16);
            this.rdoReversalShip.TabIndex = 1;
            this.rdoReversalShip.Text = "應收沖銷(客戶)";
            this.rdoReversalShip.UseVisualStyleBackColor = true;
            this.rdoReversalShip.CheckedChanged += new System.EventHandler(this.rdoReversalShip_CheckedChanged);
            // 
            // rdoReversalStock
            // 
            this.rdoReversalStock.AutoSize = true;
            this.rdoReversalStock.Location = new System.Drawing.Point(25, 22);
            this.rdoReversalStock.Name = "rdoReversalStock";
            this.rdoReversalStock.Size = new System.Drawing.Size(103, 16);
            this.rdoReversalStock.TabIndex = 0;
            this.rdoReversalStock.Text = "應付沖銷(廠商)";
            this.rdoReversalStock.UseVisualStyleBackColor = true;
            // 
            // cboPaymentType
            // 
            this.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentType.FormattingEnabled = true;
            this.cboPaymentType.Location = new System.Drawing.Point(746, 42);
            this.cboPaymentType.Name = "cboPaymentType";
            this.cboPaymentType.Size = new System.Drawing.Size(201, 20);
            this.cboPaymentType.TabIndex = 62;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(676, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 61;
            this.label10.Text = "付款方式";
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(477, 124);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(470, 62);
            this.rtbNotes.TabIndex = 55;
            this.rtbNotes.Text = "";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(441, 144);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 54;
            this.label16.Text = "備註";
            // 
            // cboReversalStaff
            // 
            this.cboReversalStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReversalStaff.FormattingEnabled = true;
            this.cboReversalStaff.Location = new System.Drawing.Point(746, 13);
            this.cboReversalStaff.Name = "cboReversalStaff";
            this.cboReversalStaff.Size = new System.Drawing.Size(201, 20);
            this.cboReversalStaff.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(677, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 52;
            this.label9.Text = "沖銷人員";
            // 
            // dtpReversalDate
            // 
            this.dtpReversalDate.Location = new System.Drawing.Point(475, 17);
            this.dtpReversalDate.Name = "dtpReversalDate";
            this.dtpReversalDate.Size = new System.Drawing.Size(145, 22);
            this.dtpReversalDate.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(417, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "沖銷日期";
            // 
            // btnAutoNumber
            // 
            this.btnAutoNumber.Location = new System.Drawing.Point(302, 19);
            this.btnAutoNumber.Name = "btnAutoNumber";
            this.btnAutoNumber.Size = new System.Drawing.Size(75, 23);
            this.btnAutoNumber.TabIndex = 7;
            this.btnAutoNumber.Text = "自動產生";
            this.btnAutoNumber.UseVisualStyleBackColor = true;
            this.btnAutoNumber.Click += new System.EventHandler(this.btnAutoNumber_Click);
            // 
            // txtReversalID
            // 
            this.txtReversalID.Location = new System.Drawing.Point(78, 19);
            this.txtReversalID.MaxLength = 20;
            this.txtReversalID.Name = "txtReversalID";
            this.txtReversalID.Size = new System.Drawing.Size(218, 22);
            this.txtReversalID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "沖銷單號";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmSISReversal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 573);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ToolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSISReversal";
            this.Text = "沖銷作業";
            this.Load += new System.EventHandler(this.FrmSISReversal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSISReversal_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountsReceivable)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountsPayable)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton tsbAddNew;
        internal System.Windows.Forms.ToolStripButton tsbUpdate;
        internal System.Windows.Forms.ToolStripButton tsbDelete;
        internal System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripButton tsbQuery;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        internal System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslDataCount;
        private System.Windows.Forms.DataGridView dgvAccountsReceivable;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvAccountsPayable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbxIsReversal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPaymentAmount;
        private System.Windows.Forms.Label lblPaymentAmount;
        private System.Windows.Forms.TextBox txtCustomerOrManufacturer;
        private System.Windows.Forms.TextBox txtStockIDOrShipID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblCustomerOrManufacturer;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdoReversalShip;
        private System.Windows.Forms.RadioButton rdoReversalStock;
        private System.Windows.Forms.ComboBox cboPaymentType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboReversalStaff;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpReversalDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAutoNumber;
        private System.Windows.Forms.TextBox txtReversalID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtbReversalAmount;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}