namespace SIS
{
    partial class FrmSISShip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSISShip));
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRemoveItems = new System.Windows.Forms.Button();
            this.btnAddItems = new System.Windows.Forms.Button();
            this.dgvShipDetails = new System.Windows.Forms.DataGridView();
            this.ItemsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemsUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Totals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxPayOff = new System.Windows.Forms.CheckBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.mtbPhone = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboPaymentType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTotalPreTax = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.mtbAmountPaid = new System.Windows.Forms.MaskedTextBox();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboShipStaff = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUnpaidAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalAfterTax = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBusinessTaxShipTaxRate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpShipDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAutoNumber = new System.Windows.Forms.Button();
            this.txtShipID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ToolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipDetails)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            this.tsbQuery,
            this.tsbPrint,
            this.tsbExit});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(994, 39);
            this.ToolStrip1.TabIndex = 7;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 663);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(994, 22);
            this.statusStrip1.TabIndex = 27;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(91, 17);
            this.toolStripStatusLabel1.Text = "商品資料筆數：";
            // 
            // tsslDataCount
            // 
            this.tsslDataCount.ForeColor = System.Drawing.Color.Blue;
            this.tsslDataCount.Name = "tsslDataCount";
            this.tsslDataCount.Size = new System.Drawing.Size(17, 17);
            this.tsslDataCount.Text = "N";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(819, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 53);
            this.groupBox1.TabIndex = 28;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRemoveItems);
            this.groupBox3.Controls.Add(this.btnAddItems);
            this.groupBox3.Controls.Add(this.dgvShipDetails);
            this.groupBox3.Location = new System.Drawing.Point(12, 280);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(962, 373);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "出貨明細區";
            // 
            // btnRemoveItems
            // 
            this.btnRemoveItems.Image = global::SIS.Properties.Resources.RemoveAll;
            this.btnRemoveItems.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemoveItems.Location = new System.Drawing.Point(844, 100);
            this.btnRemoveItems.Name = "btnRemoveItems";
            this.btnRemoveItems.Size = new System.Drawing.Size(103, 52);
            this.btnRemoveItems.TabIndex = 3;
            this.btnRemoveItems.Text = "移除所有商品";
            this.btnRemoveItems.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemoveItems.UseVisualStyleBackColor = true;
            this.btnRemoveItems.Click += new System.EventHandler(this.btnRemoveItems_Click);
            // 
            // btnAddItems
            // 
            this.btnAddItems.Image = global::SIS.Properties.Resources.Add;
            this.btnAddItems.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddItems.Location = new System.Drawing.Point(844, 30);
            this.btnAddItems.Name = "btnAddItems";
            this.btnAddItems.Size = new System.Drawing.Size(103, 51);
            this.btnAddItems.TabIndex = 1;
            this.btnAddItems.Text = "加入商品";
            this.btnAddItems.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddItems.UseVisualStyleBackColor = true;
            this.btnAddItems.Click += new System.EventHandler(this.btnAddItems_Click);
            // 
            // dgvShipDetails
            // 
            this.dgvShipDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShipDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemsID,
            this.NAME,
            this.Quantity,
            this.ItemsUnit,
            this.SellingPrice,
            this.Totals,
            this.Notes,
            this.Delete});
            this.dgvShipDetails.Location = new System.Drawing.Point(20, 30);
            this.dgvShipDetails.Name = "dgvShipDetails";
            this.dgvShipDetails.RowTemplate.Height = 24;
            this.dgvShipDetails.Size = new System.Drawing.Size(807, 331);
            this.dgvShipDetails.TabIndex = 0;
            this.dgvShipDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShipDetails_CellClick);
            this.dgvShipDetails.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvShipDetails_CellFormatting);
            this.dgvShipDetails.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShipDetails_CellValueChanged);
            // 
            // ItemsID
            // 
            this.ItemsID.Frozen = true;
            this.ItemsID.HeaderText = "商品編號";
            this.ItemsID.Name = "ItemsID";
            // 
            // NAME
            // 
            this.NAME.Frozen = true;
            this.NAME.HeaderText = "商品名稱";
            this.NAME.Name = "NAME";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "數量";
            this.Quantity.Name = "Quantity";
            // 
            // ItemsUnit
            // 
            this.ItemsUnit.HeaderText = "基本單位";
            this.ItemsUnit.Name = "ItemsUnit";
            // 
            // SellingPrice
            // 
            this.SellingPrice.HeaderText = "單價";
            this.SellingPrice.Name = "SellingPrice";
            // 
            // Totals
            // 
            this.Totals.HeaderText = "合計";
            this.Totals.Name = "Totals";
            // 
            // Notes
            // 
            this.Notes.HeaderText = "備註";
            this.Notes.Name = "Notes";
            // 
            // Delete
            // 
            this.Delete.HeaderText = "刪除";
            this.Delete.Name = "Delete";
            this.Delete.Text = "刪除";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxPayOff);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.mtbPhone);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cboPaymentType);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtTax);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtTotalPreTax);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.mtbAmountPaid);
            this.groupBox2.Controls.Add(this.rtbNotes);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.cboShipStaff);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtUnpaidAmount);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtTotalAfterTax);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtBusinessTaxShipTaxRate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtpShipDate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboCustomer);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnAutoNumber);
            this.groupBox2.Controls.Add(this.txtShipID);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(961, 208);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "出貨主表區";
            // 
            // cbxPayOff
            // 
            this.cbxPayOff.AutoSize = true;
            this.cbxPayOff.Location = new System.Drawing.Point(869, 55);
            this.cbxPayOff.Name = "cbxPayOff";
            this.cbxPayOff.Size = new System.Drawing.Size(48, 16);
            this.cbxPayOff.TabIndex = 67;
            this.cbxPayOff.Text = "付清";
            this.cbxPayOff.UseVisualStyleBackColor = true;
            this.cbxPayOff.CheckedChanged += new System.EventHandler(this.cbxPayOff_CheckedChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(78, 123);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(333, 22);
            this.txtAddress.TabIndex = 66;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(21, 127);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 65;
            this.label17.Text = "送貨地址";
            // 
            // mtbPhone
            // 
            this.mtbPhone.Location = new System.Drawing.Point(78, 86);
            this.mtbPhone.Mask = "0000000000";
            this.mtbPhone.Name = "mtbPhone";
            this.mtbPhone.Size = new System.Drawing.Size(147, 22);
            this.mtbPhone.TabIndex = 64;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 63;
            this.label11.Text = "客戶電話";
            // 
            // cboPaymentType
            // 
            this.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentType.FormattingEnabled = true;
            this.cboPaymentType.Location = new System.Drawing.Point(740, 147);
            this.cboPaymentType.Name = "cboPaymentType";
            this.cboPaymentType.Size = new System.Drawing.Size(186, 20);
            this.cboPaymentType.TabIndex = 62;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(670, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 61;
            this.label10.Text = "付款方式";
            // 
            // txtTax
            // 
            this.txtTax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTax.Enabled = false;
            this.txtTax.Location = new System.Drawing.Point(489, 124);
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(100, 22);
            this.txtTax.TabIndex = 60;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(430, 127);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 59;
            this.label14.Text = "稅金金額";
            // 
            // txtTotalPreTax
            // 
            this.txtTotalPreTax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTotalPreTax.Enabled = false;
            this.txtTotalPreTax.Location = new System.Drawing.Point(489, 91);
            this.txtTotalPreTax.Name = "txtTotalPreTax";
            this.txtTotalPreTax.Size = new System.Drawing.Size(100, 22);
            this.txtTotalPreTax.TabIndex = 58;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(430, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 57;
            this.label13.Text = "稅前總計";
            // 
            // mtbAmountPaid
            // 
            this.mtbAmountPaid.Location = new System.Drawing.Point(740, 53);
            this.mtbAmountPaid.Mask = "9999999999";
            this.mtbAmountPaid.Name = "mtbAmountPaid";
            this.mtbAmountPaid.Size = new System.Drawing.Size(118, 22);
            this.mtbAmountPaid.TabIndex = 56;
            this.mtbAmountPaid.Text = "0";
            this.mtbAmountPaid.TextChanged += new System.EventHandler(this.mtbAmountPaid_TextChanged);
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(78, 152);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(555, 42);
            this.rtbNotes.TabIndex = 55;
            this.rtbNotes.Text = "";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(43, 155);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 54;
            this.label16.Text = "備註";
            // 
            // cboShipStaff
            // 
            this.cboShipStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShipStaff.FormattingEnabled = true;
            this.cboShipStaff.Location = new System.Drawing.Point(740, 118);
            this.cboShipStaff.Name = "cboShipStaff";
            this.cboShipStaff.Size = new System.Drawing.Size(187, 20);
            this.cboShipStaff.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(671, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 52;
            this.label9.Text = "經辦人員";
            // 
            // txtUnpaidAmount
            // 
            this.txtUnpaidAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtUnpaidAmount.Enabled = false;
            this.txtUnpaidAmount.Location = new System.Drawing.Point(740, 86);
            this.txtUnpaidAmount.Name = "txtUnpaidAmount";
            this.txtUnpaidAmount.Size = new System.Drawing.Size(118, 22);
            this.txtUnpaidAmount.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(671, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 50;
            this.label8.Text = "未付金額";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(669, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 48;
            this.label7.Text = "已付金額";
            // 
            // txtTotalAfterTax
            // 
            this.txtTotalAfterTax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTotalAfterTax.Enabled = false;
            this.txtTotalAfterTax.Location = new System.Drawing.Point(740, 20);
            this.txtTotalAfterTax.Name = "txtTotalAfterTax";
            this.txtTotalAfterTax.Size = new System.Drawing.Size(118, 22);
            this.txtTotalAfterTax.TabIndex = 47;
            this.txtTotalAfterTax.TextChanged += new System.EventHandler(this.txtTotalAfterTax_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(669, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 46;
            this.label15.Text = "稅後金額";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(542, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 12);
            this.label12.TabIndex = 41;
            this.label12.Text = "%";
            // 
            // txtBusinessTaxShipTaxRate
            // 
            this.txtBusinessTaxShipTaxRate.Location = new System.Drawing.Point(489, 50);
            this.txtBusinessTaxShipTaxRate.MaxLength = 3;
            this.txtBusinessTaxShipTaxRate.Name = "txtBusinessTaxShipTaxRate";
            this.txtBusinessTaxShipTaxRate.Size = new System.Drawing.Size(48, 22);
            this.txtBusinessTaxShipTaxRate.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(430, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "出貨稅率";
            // 
            // dtpShipDate
            // 
            this.dtpShipDate.Location = new System.Drawing.Point(488, 17);
            this.dtpShipDate.Name = "dtpShipDate";
            this.dtpShipDate.Size = new System.Drawing.Size(145, 22);
            this.dtpShipDate.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(430, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "出貨日期";
            // 
            // cboCustomer
            // 
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(78, 54);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(299, 20);
            this.cboCustomer.TabIndex = 9;
            this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.cboCustomer_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "客戶名稱";
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
            // txtShipID
            // 
            this.txtShipID.Location = new System.Drawing.Point(78, 19);
            this.txtShipID.MaxLength = 20;
            this.txtShipID.Name = "txtShipID";
            this.txtShipID.Size = new System.Drawing.Size(218, 22);
            this.txtShipID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "出貨單號";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmSISShip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 685);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSISShip";
            this.Text = "出貨作業(銷貨作業)";
            this.Load += new System.EventHandler(this.FrmSISShip_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSISShip_KeyDown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipDetails)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton tsbQuery;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        internal System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslDataCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRemoveItems;
        private System.Windows.Forms.Button btnAddItems;
        private System.Windows.Forms.DataGridView dgvShipDetails;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboPaymentType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTotalPreTax;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox mtbAmountPaid;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboShipStaff;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUnpaidAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalAfterTax;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBusinessTaxShipTaxRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpShipDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAutoNumber;
        private System.Windows.Forms.TextBox txtShipID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label17;
        internal System.Windows.Forms.MaskedTextBox mtbPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.CheckBox cbxPayOff;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemsUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellingPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Totals;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}