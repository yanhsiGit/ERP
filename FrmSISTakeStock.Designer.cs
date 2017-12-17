namespace SIS
{
    partial class FrmSISTakeStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSISTakeStock));
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
            this.dgvTakeStockItemsInfo = new System.Windows.Forms.DataGridView();
            this.ItemsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TakeStockInventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GainLossInventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsTakeStock = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ItemsUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Totals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboTakeStockStaff = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpTakeStockDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAutoNumber = new System.Windows.Forms.Button();
            this.txtTakeStockID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ToolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTakeStockItemsInfo)).BeginInit();
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
            this.ToolStrip1.TabIndex = 9;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 653);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(994, 22);
            this.statusStrip1.TabIndex = 29;
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
            this.groupBox1.Location = new System.Drawing.Point(827, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 53);
            this.groupBox1.TabIndex = 30;
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
            this.groupBox3.Controls.Add(this.dgvTakeStockItemsInfo);
            this.groupBox3.Location = new System.Drawing.Point(13, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(962, 417);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "商品盤點明細區";
            // 
            // dgvTakeStockItemsInfo
            // 
            this.dgvTakeStockItemsInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTakeStockItemsInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemsID,
            this.NAME,
            this.Inventory,
            this.TakeStockInventory,
            this.GainLossInventory,
            this.IsTakeStock,
            this.ItemsUnit,
            this.Price,
            this.Totals,
            this.Notes});
            this.dgvTakeStockItemsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTakeStockItemsInfo.Location = new System.Drawing.Point(3, 18);
            this.dgvTakeStockItemsInfo.Name = "dgvTakeStockItemsInfo";
            this.dgvTakeStockItemsInfo.RowTemplate.Height = 24;
            this.dgvTakeStockItemsInfo.Size = new System.Drawing.Size(956, 396);
            this.dgvTakeStockItemsInfo.TabIndex = 0;
            this.dgvTakeStockItemsInfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTakeStockItemsInfo_CellFormatting);
            this.dgvTakeStockItemsInfo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTakeStockItemsInfo_CellValueChanged);
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
            // Inventory
            // 
            this.Inventory.HeaderText = "庫存數量";
            this.Inventory.Name = "Inventory";
            // 
            // TakeStockInventory
            // 
            this.TakeStockInventory.HeaderText = "盤點數量";
            this.TakeStockInventory.Name = "TakeStockInventory";
            // 
            // GainLossInventory
            // 
            this.GainLossInventory.HeaderText = "盈虧數量";
            this.GainLossInventory.Name = "GainLossInventory";
            // 
            // IsTakeStock
            // 
            this.IsTakeStock.HeaderText = "是否盤點";
            this.IsTakeStock.Name = "IsTakeStock";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtbNotes);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.cboTakeStockStaff);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.dtpTakeStockDate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnAutoNumber);
            this.groupBox2.Controls.Add(this.txtTakeStockID);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(961, 138);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "盤點主表區";
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(78, 57);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(833, 63);
            this.rtbNotes.TabIndex = 57;
            this.rtbNotes.Text = "";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(34, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 56;
            this.label16.Text = "備註";
            // 
            // cboTakeStockStaff
            // 
            this.cboTakeStockStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTakeStockStaff.FormattingEnabled = true;
            this.cboTakeStockStaff.Location = new System.Drawing.Point(724, 14);
            this.cboTakeStockStaff.Name = "cboTakeStockStaff";
            this.cboTakeStockStaff.Size = new System.Drawing.Size(187, 20);
            this.cboTakeStockStaff.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(665, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 52;
            this.label9.Text = "盤點人員";
            // 
            // dtpTakeStockDate
            // 
            this.dtpTakeStockDate.Location = new System.Drawing.Point(488, 17);
            this.dtpTakeStockDate.Name = "dtpTakeStockDate";
            this.dtpTakeStockDate.Size = new System.Drawing.Size(145, 22);
            this.dtpTakeStockDate.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(430, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "盤點日期";
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
            // txtTakeStockID
            // 
            this.txtTakeStockID.Location = new System.Drawing.Point(78, 19);
            this.txtTakeStockID.MaxLength = 20;
            this.txtTakeStockID.Name = "txtTakeStockID";
            this.txtTakeStockID.Size = new System.Drawing.Size(218, 22);
            this.txtTakeStockID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "盤點單號";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmSISTakeStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 675);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSISTakeStock";
            this.Text = "盤點作業";
            this.Load += new System.EventHandler(this.FrmSISTakeStock_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSISTakeStock_KeyDown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTakeStockItemsInfo)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvTakeStockItemsInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboTakeStockStaff;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpTakeStockDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAutoNumber;
        private System.Windows.Forms.TextBox txtTakeStockID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn TakeStockInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn GainLossInventory;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsTakeStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemsUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Totals;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
    }
}