namespace SIS
{
    partial class FrmManufacturerMaintain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManufacturerMaintain));
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
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.mtbFax = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mtbMobilePhone = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mtbPhone = new System.Windows.Forms.MaskedTextBox();
            this.Label28 = new System.Windows.Forms.Label();
            this.txtWebSite = new System.Windows.Forms.TextBox();
            this.Label30 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.Label33 = new System.Windows.Forms.Label();
            this.mtbUnifiedBusinessNo = new System.Windows.Forms.MaskedTextBox();
            this.txtENAME = new System.Windows.Forms.TextBox();
            this.txtCNAME = new System.Windows.Forms.TextBox();
            this.txtManufacturerID = new System.Windows.Forms.TextBox();
            this.Label37 = new System.Windows.Forms.Label();
            this.Label38 = new System.Windows.Forms.Label();
            this.Label39 = new System.Windows.Forms.Label();
            this.Label40 = new System.Windows.Forms.Label();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvManufacturerInfo = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ToolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManufacturerInfo)).BeginInit();
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
            this.ToolStrip1.Size = new System.Drawing.Size(849, 39);
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
            this.groupBox1.Location = new System.Drawing.Point(682, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 53);
            this.groupBox1.TabIndex = 21;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 606);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(849, 22);
            this.statusStrip1.TabIndex = 22;
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
            this.panel1.Size = new System.Drawing.Size(777, 246);
            this.panel1.TabIndex = 24;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.label10);
            this.GroupBox3.Controls.Add(this.label9);
            this.GroupBox3.Controls.Add(this.rtbNotes);
            this.GroupBox3.Controls.Add(this.mtbFax);
            this.GroupBox3.Controls.Add(this.label7);
            this.GroupBox3.Controls.Add(this.mtbMobilePhone);
            this.GroupBox3.Controls.Add(this.label6);
            this.GroupBox3.Controls.Add(this.txtContact);
            this.GroupBox3.Controls.Add(this.label5);
            this.GroupBox3.Controls.Add(this.txtOwner);
            this.GroupBox3.Controls.Add(this.label2);
            this.GroupBox3.Controls.Add(this.label1);
            this.GroupBox3.Controls.Add(this.mtbPhone);
            this.GroupBox3.Controls.Add(this.Label28);
            this.GroupBox3.Controls.Add(this.txtWebSite);
            this.GroupBox3.Controls.Add(this.Label30);
            this.GroupBox3.Controls.Add(this.txtAddress);
            this.GroupBox3.Controls.Add(this.Label33);
            this.GroupBox3.Controls.Add(this.mtbUnifiedBusinessNo);
            this.GroupBox3.Controls.Add(this.txtENAME);
            this.GroupBox3.Controls.Add(this.txtCNAME);
            this.GroupBox3.Controls.Add(this.txtManufacturerID);
            this.GroupBox3.Controls.Add(this.Label37);
            this.GroupBox3.Controls.Add(this.Label38);
            this.GroupBox3.Controls.Add(this.Label39);
            this.GroupBox3.Controls.Add(this.Label40);
            this.GroupBox3.Location = new System.Drawing.Point(24, 16);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(764, 357);
            this.GroupBox3.TabIndex = 3;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "廠商資料填寫區";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(444, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 12);
            this.label10.TabIndex = 52;
            this.label10.Text = "(例如:0987654321)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(444, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 12);
            this.label9.TabIndex = 51;
            this.label9.Text = "(例如:077654321)";
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(83, 262);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(624, 89);
            this.rtbNotes.TabIndex = 50;
            this.rtbNotes.Text = "";
            // 
            // mtbFax
            // 
            this.mtbFax.Location = new System.Drawing.Point(337, 104);
            this.mtbFax.Mask = "0000000000";
            this.mtbFax.Name = "mtbFax";
            this.mtbFax.Size = new System.Drawing.Size(100, 22);
            this.mtbFax.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(262, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 46;
            this.label7.Text = "廠商傳真";
            // 
            // mtbMobilePhone
            // 
            this.mtbMobilePhone.Location = new System.Drawing.Point(337, 76);
            this.mtbMobilePhone.Mask = "0000000000";
            this.mtbMobilePhone.Name = "mtbMobilePhone";
            this.mtbMobilePhone.Size = new System.Drawing.Size(100, 22);
            this.mtbMobilePhone.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(250, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 44;
            this.label6.Text = "聯絡人手機";
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(337, 19);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(100, 22);
            this.txtContact.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 42;
            this.label5.Text = "聯絡人";
            // 
            // txtOwner
            // 
            this.txtOwner.Location = new System.Drawing.Point(83, 145);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(100, 22);
            this.txtOwner.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 40;
            this.label2.Text = "負責人";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(22, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "統一編號";
            // 
            // mtbPhone
            // 
            this.mtbPhone.Location = new System.Drawing.Point(337, 47);
            this.mtbPhone.Mask = "0000000000";
            this.mtbPhone.Name = "mtbPhone";
            this.mtbPhone.Size = new System.Drawing.Size(100, 22);
            this.mtbPhone.TabIndex = 31;
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.Location = new System.Drawing.Point(262, 51);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(53, 12);
            this.Label28.TabIndex = 30;
            this.Label28.Text = "廠商電話";
            // 
            // txtWebSite
            // 
            this.txtWebSite.Location = new System.Drawing.Point(83, 216);
            this.txtWebSite.MaxLength = 100;
            this.txtWebSite.Name = "txtWebSite";
            this.txtWebSite.Size = new System.Drawing.Size(354, 22);
            this.txtWebSite.TabIndex = 27;
            // 
            // Label30
            // 
            this.Label30.AutoSize = true;
            this.Label30.Location = new System.Drawing.Point(42, 255);
            this.Label30.Name = "Label30";
            this.Label30.Size = new System.Drawing.Size(29, 12);
            this.Label30.TabIndex = 26;
            this.Label30.Text = "備註";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(82, 177);
            this.txtAddress.MaxLength = 100;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(355, 22);
            this.txtAddress.TabIndex = 21;
            // 
            // Label33
            // 
            this.Label33.AutoSize = true;
            this.Label33.Location = new System.Drawing.Point(21, 180);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(53, 12);
            this.Label33.TabIndex = 20;
            this.Label33.Text = "公司地址";
            // 
            // mtbUnifiedBusinessNo
            // 
            this.mtbUnifiedBusinessNo.Location = new System.Drawing.Point(82, 109);
            this.mtbUnifiedBusinessNo.Mask = "00000000";
            this.mtbUnifiedBusinessNo.Name = "mtbUnifiedBusinessNo";
            this.mtbUnifiedBusinessNo.Size = new System.Drawing.Size(100, 22);
            this.mtbUnifiedBusinessNo.TabIndex = 19;
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
            this.txtCNAME.MaxLength = 30;
            this.txtCNAME.Name = "txtCNAME";
            this.txtCNAME.Size = new System.Drawing.Size(149, 22);
            this.txtCNAME.TabIndex = 8;
            // 
            // txtManufacturerID
            // 
            this.txtManufacturerID.Location = new System.Drawing.Point(82, 17);
            this.txtManufacturerID.MaxLength = 20;
            this.txtManufacturerID.Name = "txtManufacturerID";
            this.txtManufacturerID.Size = new System.Drawing.Size(100, 22);
            this.txtManufacturerID.TabIndex = 7;
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Location = new System.Drawing.Point(42, 219);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(29, 12);
            this.Label37.TabIndex = 3;
            this.Label37.Text = "網站";
            // 
            // Label38
            // 
            this.Label38.AutoSize = true;
            this.Label38.Location = new System.Drawing.Point(22, 81);
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
            this.Label40.Text = "廠商編號";
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.dgvManufacturerInfo);
            this.GroupBox4.Location = new System.Drawing.Point(27, 349);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(780, 243);
            this.GroupBox4.TabIndex = 25;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "廠商資料顯示區";
            // 
            // dgvManufacturerInfo
            // 
            this.dgvManufacturerInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManufacturerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvManufacturerInfo.Location = new System.Drawing.Point(3, 18);
            this.dgvManufacturerInfo.Name = "dgvManufacturerInfo";
            this.dgvManufacturerInfo.RowTemplate.Height = 24;
            this.dgvManufacturerInfo.Size = new System.Drawing.Size(774, 222);
            this.dgvManufacturerInfo.TabIndex = 0;
            this.dgvManufacturerInfo.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvManufacturerInfo_RowHeaderMouseClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmManufacturerMaintain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 628);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmManufacturerMaintain";
            this.Text = "廠商資料";
            this.Load += new System.EventHandler(this.FrmManufacturerMaintain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmManufacturerMaintain_KeyDown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManufacturerInfo)).EndInit();
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox rtbNotes;
        internal System.Windows.Forms.MaskedTextBox mtbFax;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.MaskedTextBox mtbMobilePhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.MaskedTextBox mtbPhone;
        internal System.Windows.Forms.Label Label28;
        internal System.Windows.Forms.TextBox txtWebSite;
        internal System.Windows.Forms.Label Label30;
        internal System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.Label Label33;
        internal System.Windows.Forms.MaskedTextBox mtbUnifiedBusinessNo;
        internal System.Windows.Forms.TextBox txtENAME;
        internal System.Windows.Forms.TextBox txtCNAME;
        internal System.Windows.Forms.TextBox txtManufacturerID;
        internal System.Windows.Forms.Label Label37;
        internal System.Windows.Forms.Label Label38;
        internal System.Windows.Forms.Label Label39;
        internal System.Windows.Forms.Label Label40;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.DataGridView dgvManufacturerInfo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}