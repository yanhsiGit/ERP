namespace SIS
{
    partial class FrmSISRMA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSISRMA));
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRemoveItems = new System.Windows.Forms.Button();
            this.dgvRMADetails = new System.Windows.Forms.DataGridView();
            this.ItemsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RMAQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemsUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Totals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mtbRMAAmount = new System.Windows.Forms.MaskedTextBox();
            this.btnLoadItems = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdoRMAShip = new System.Windows.Forms.RadioButton();
            this.rdoRMAStock = new System.Windows.Forms.RadioButton();
            this.txtStockIDOrShipID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.cboPaymentType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTotalPreTax = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.mtbAmountPaid = new System.Windows.Forms.MaskedTextBox();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboStaff = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUnpaidAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalAfterTax = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBusinessTax = new System.Windows.Forms.TextBox();
            this.lblBusinessTax = new System.Windows.Forms.Label();
            this.dtpRMADate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAutoNumber = new System.Windows.Forms.Button();
            this.txtRMAID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ToolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRMADetails)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.ToolStrip1.Size = new System.Drawing.Size(1003, 39);
            this.ToolStrip1.TabIndex = 8;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 678);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1003, 22);
            this.statusStrip1.TabIndex = 28;
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(821, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 53);
            this.groupBox1.TabIndex = 29;
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
            this.groupBox3.Controls.Add(this.dgvRMADetails);
            this.groupBox3.Location = new System.Drawing.Point(15, 285);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(962, 373);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "退貨明細區";
            // 
            // btnRemoveItems
            // 
            this.btnRemoveItems.Image = global::SIS.Properties.Resources.RemoveAll;
            this.btnRemoveItems.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemoveItems.Location = new System.Drawing.Point(844, 30);
            this.btnRemoveItems.Name = "btnRemoveItems";
            this.btnRemoveItems.Size = new System.Drawing.Size(103, 52);
            this.btnRemoveItems.TabIndex = 3;
            this.btnRemoveItems.Text = "移除所有商品";
            this.btnRemoveItems.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemoveItems.UseVisualStyleBackColor = true;
            this.btnRemoveItems.Click += new System.EventHandler(this.btnRemoveItems_Click);
            // 
            // dgvRMADetails
            // 
            this.dgvRMADetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRMADetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemsID,
            this.NAME,
            this.Quantity,
            this.RMAQuantity,
            this.ItemsUnit,
            this.Price,
            this.Totals,
            this.Notes,
            this.Delete});
            this.dgvRMADetails.Location = new System.Drawing.Point(20, 30);
            this.dgvRMADetails.Name = "dgvRMADetails";
            this.dgvRMADetails.RowTemplate.Height = 24;
            this.dgvRMADetails.Size = new System.Drawing.Size(807, 331);
            this.dgvRMADetails.TabIndex = 0;
            this.dgvRMADetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRMADetails_CellClick);
            this.dgvRMADetails.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRMADetails_CellFormatting);
            this.dgvRMADetails.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRMADetails_CellValueChanged);
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
            this.Quantity.HeaderText = "購買數量";
            this.Quantity.Name = "Quantity";
            // 
            // RMAQuantity
            // 
            this.RMAQuantity.HeaderText = "退貨數量";
            this.RMAQuantity.Name = "RMAQuantity";
            // 
            // ItemsUnit
            // 
            this.ItemsUnit.HeaderText = "基本單位";
            this.ItemsUnit.Name = "ItemsUnit";
            // 
            // Price
            // 
            this.Price.HeaderText = "單價";
            this.Price.Name = "Price";
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
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.mtbRMAAmount);
            this.groupBox2.Controls.Add(this.btnLoadItems);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.txtStockIDOrShipID);
            this.groupBox2.Controls.Add(this.lblID);
            this.groupBox2.Controls.Add(this.cboPaymentType);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtTax);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtTotalPreTax);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.mtbAmountPaid);
            this.groupBox2.Controls.Add(this.rtbNotes);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.cboStaff);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtUnpaidAmount);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtTotalAfterTax);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtBusinessTax);
            this.groupBox2.Controls.Add(this.lblBusinessTax);
            this.groupBox2.Controls.Add(this.dtpRMADate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnAutoNumber);
            this.groupBox2.Controls.Add(this.txtRMAID);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(15, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(961, 208);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "出貨主表區";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(671, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 71;
            this.label2.Text = "已付金額";
            // 
            // mtbRMAAmount
            // 
            this.mtbRMAAmount.Enabled = false;
            this.mtbRMAAmount.Location = new System.Drawing.Point(740, 115);
            this.mtbRMAAmount.Mask = "9999999999";
            this.mtbRMAAmount.Name = "mtbRMAAmount";
            this.mtbRMAAmount.Size = new System.Drawing.Size(118, 22);
            this.mtbRMAAmount.TabIndex = 70;
            this.mtbRMAAmount.Text = "0";
            // 
            // btnLoadItems
            // 
            this.btnLoadItems.Location = new System.Drawing.Point(308, 109);
            this.btnLoadItems.Name = "btnLoadItems";
            this.btnLoadItems.Size = new System.Drawing.Size(88, 37);
            this.btnLoadItems.TabIndex = 69;
            this.btnLoadItems.Text = "載入商品資料";
            this.btnLoadItems.UseVisualStyleBackColor = true;
            this.btnLoadItems.Click += new System.EventHandler(this.btnLoadItems_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdoRMAShip);
            this.groupBox4.Controls.Add(this.rdoRMAStock);
            this.groupBox4.Location = new System.Drawing.Point(20, 51);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(281, 55);
            this.groupBox4.TabIndex = 68;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "退貨類型";
            // 
            // rdoRMAShip
            // 
            this.rdoRMAShip.AutoSize = true;
            this.rdoRMAShip.Location = new System.Drawing.Point(135, 22);
            this.rdoRMAShip.Name = "rdoRMAShip";
            this.rdoRMAShip.Size = new System.Drawing.Size(103, 16);
            this.rdoRMAShip.TabIndex = 1;
            this.rdoRMAShip.Text = "出貨退貨(客戶)";
            this.rdoRMAShip.UseVisualStyleBackColor = true;
            // 
            // rdoRMAStock
            // 
            this.rdoRMAStock.AutoSize = true;
            this.rdoRMAStock.Location = new System.Drawing.Point(25, 22);
            this.rdoRMAStock.Name = "rdoRMAStock";
            this.rdoRMAStock.Size = new System.Drawing.Size(103, 16);
            this.rdoRMAStock.TabIndex = 0;
            this.rdoRMAStock.Text = "進貨退貨(廠商)";
            this.rdoRMAStock.UseVisualStyleBackColor = true;
            this.rdoRMAStock.CheckedChanged += new System.EventHandler(this.rdoRMAStock_CheckedChanged);
            // 
            // txtStockIDOrShipID
            // 
            this.txtStockIDOrShipID.Location = new System.Drawing.Point(78, 118);
            this.txtStockIDOrShipID.MaxLength = 30;
            this.txtStockIDOrShipID.Name = "txtStockIDOrShipID";
            this.txtStockIDOrShipID.Size = new System.Drawing.Size(223, 22);
            this.txtStockIDOrShipID.TabIndex = 66;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(21, 122);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(53, 12);
            this.lblID.TabIndex = 65;
            this.lblID.Text = "出貨單號";
            // 
            // cboPaymentType
            // 
            this.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentType.FormattingEnabled = true;
            this.cboPaymentType.Location = new System.Drawing.Point(740, 175);
            this.cboPaymentType.Name = "cboPaymentType";
            this.cboPaymentType.Size = new System.Drawing.Size(186, 20);
            this.cboPaymentType.TabIndex = 62;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(670, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 61;
            this.label10.Text = "付款方式";
            // 
            // txtTax
            // 
            this.txtTax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTax.Enabled = false;
            this.txtTax.Location = new System.Drawing.Point(489, 118);
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(100, 22);
            this.txtTax.TabIndex = 60;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(430, 121);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 59;
            this.label14.Text = "稅金金額";
            // 
            // txtTotalPreTax
            // 
            this.txtTotalPreTax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTotalPreTax.Enabled = false;
            this.txtTotalPreTax.Location = new System.Drawing.Point(489, 85);
            this.txtTotalPreTax.Name = "txtTotalPreTax";
            this.txtTotalPreTax.Size = new System.Drawing.Size(100, 22);
            this.txtTotalPreTax.TabIndex = 58;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(430, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 57;
            this.label13.Text = "稅前總計";
            // 
            // mtbAmountPaid
            // 
            this.mtbAmountPaid.Enabled = false;
            this.mtbAmountPaid.Location = new System.Drawing.Point(740, 53);
            this.mtbAmountPaid.Mask = "9999999999";
            this.mtbAmountPaid.Name = "mtbAmountPaid";
            this.mtbAmountPaid.Size = new System.Drawing.Size(118, 22);
            this.mtbAmountPaid.TabIndex = 56;
            this.mtbAmountPaid.Text = "0";
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
            // cboStaff
            // 
            this.cboStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStaff.FormattingEnabled = true;
            this.cboStaff.Location = new System.Drawing.Point(740, 146);
            this.cboStaff.Name = "cboStaff";
            this.cboStaff.Size = new System.Drawing.Size(187, 20);
            this.cboStaff.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(671, 152);
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
            this.label7.Location = new System.Drawing.Point(671, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 48;
            this.label7.Text = "退貨金額";
            // 
            // txtTotalAfterTax
            // 
            this.txtTotalAfterTax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTotalAfterTax.Enabled = false;
            this.txtTotalAfterTax.Location = new System.Drawing.Point(740, 20);
            this.txtTotalAfterTax.Name = "txtTotalAfterTax";
            this.txtTotalAfterTax.Size = new System.Drawing.Size(118, 22);
            this.txtTotalAfterTax.TabIndex = 47;
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
            // txtBusinessTax
            // 
            this.txtBusinessTax.Location = new System.Drawing.Point(489, 50);
            this.txtBusinessTax.MaxLength = 3;
            this.txtBusinessTax.Name = "txtBusinessTax";
            this.txtBusinessTax.Size = new System.Drawing.Size(48, 22);
            this.txtBusinessTax.TabIndex = 40;
            // 
            // lblBusinessTax
            // 
            this.lblBusinessTax.AutoSize = true;
            this.lblBusinessTax.Location = new System.Drawing.Point(430, 55);
            this.lblBusinessTax.Name = "lblBusinessTax";
            this.lblBusinessTax.Size = new System.Drawing.Size(53, 12);
            this.lblBusinessTax.TabIndex = 12;
            this.lblBusinessTax.Text = "出貨稅率";
            // 
            // dtpRMADate
            // 
            this.dtpRMADate.Location = new System.Drawing.Point(488, 17);
            this.dtpRMADate.Name = "dtpRMADate";
            this.dtpRMADate.Size = new System.Drawing.Size(145, 22);
            this.dtpRMADate.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(430, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "退貨日期";
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
            // txtRMAID
            // 
            this.txtRMAID.Location = new System.Drawing.Point(78, 19);
            this.txtRMAID.MaxLength = 20;
            this.txtRMAID.Name = "txtRMAID";
            this.txtRMAID.Size = new System.Drawing.Size(218, 22);
            this.txtRMAID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "退貨單號";
            // 
            // FrmSISRMA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 700);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSISRMA";
            this.Text = "退貨作業";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSISRMA_FormClosing);
            this.Load += new System.EventHandler(this.FrmSISRMA_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSISRMA_KeyDown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRMADetails)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRemoveItems;
        private System.Windows.Forms.DataGridView dgvRMADetails;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtStockIDOrShipID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ComboBox cboPaymentType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTotalPreTax;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox mtbAmountPaid;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboStaff;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUnpaidAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalAfterTax;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBusinessTax;
        private System.Windows.Forms.Label lblBusinessTax;
        private System.Windows.Forms.DateTimePicker dtpRMADate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAutoNumber;
        private System.Windows.Forms.TextBox txtRMAID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdoRMAShip;
        private System.Windows.Forms.RadioButton rdoRMAStock;
        private System.Windows.Forms.Button btnLoadItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn RMAQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemsUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Totals;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtbRMAAmount;
    }
}