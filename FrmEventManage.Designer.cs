namespace SIS
{
    partial class FrmEventManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEventManage));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSBDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tSCBQueryItem = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tSCBKeyword = new System.Windows.Forms.ToolStripComboBox();
            this.tSBQuery = new System.Windows.Forms.ToolStripButton();
            this.tSBExit = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSL_DataCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSBDelete,
            this.toolStripLabel1,
            this.tSCBQueryItem,
            this.toolStripLabel2,
            this.tSCBKeyword,
            this.tSBQuery,
            this.tSBExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(739, 54);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSBDelete
            // 
            this.tSBDelete.Image = global::SIS.Properties.Resources.Remove;
            this.tSBDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBDelete.Name = "tSBDelete";
            this.tSBDelete.Size = new System.Drawing.Size(36, 51);
            this.tSBDelete.Text = "刪除";
            this.tSBDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tSBDelete.Click += new System.EventHandler(this.tSBDelete_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Purple;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 51);
            this.toolStripLabel1.Text = "查詢項目";
            // 
            // tSCBQueryItem
            // 
            this.tSCBQueryItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tSCBQueryItem.Items.AddRange(new object[] {
            "事件類型",
            "使用者編號",
            "執行動作"});
            this.tSCBQueryItem.Name = "tSCBQueryItem";
            this.tSCBQueryItem.Size = new System.Drawing.Size(121, 54);
            this.tSCBQueryItem.SelectedIndexChanged += new System.EventHandler(this.tSCBQueryItem_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(67, 51);
            this.toolStripLabel2.Text = "查詢關鍵字";
            // 
            // tSCBKeyword
            // 
            this.tSCBKeyword.Name = "tSCBKeyword";
            this.tSCBKeyword.Size = new System.Drawing.Size(121, 54);
            // 
            // tSBQuery
            // 
            this.tSBQuery.Image = global::SIS.Properties.Resources.Search;
            this.tSBQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBQuery.Name = "tSBQuery";
            this.tSBQuery.Size = new System.Drawing.Size(36, 51);
            this.tSBQuery.Text = "查詢";
            this.tSBQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tSBQuery.ToolTipText = "執行[查詢]前先選擇[查詢項目然後輸入或選擇[查詢關鍵字]]";
            this.tSBQuery.Click += new System.EventHandler(this.tSBQuery_Click);
            // 
            // tSBExit
            // 
            this.tSBExit.Image = global::SIS.Properties.Resources.Exit;
            this.tSBExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBExit.Name = "tSBExit";
            this.tSBExit.Size = new System.Drawing.Size(36, 51);
            this.tSBExit.Text = "離開";
            this.tSBExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tSBExit.Click += new System.EventHandler(this.tSBExit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(739, 297);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tSSL_DataCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 329);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(739, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(91, 17);
            this.toolStripStatusLabel1.Text = "目前資料筆數：";
            // 
            // tSSL_DataCount
            // 
            this.tSSL_DataCount.ForeColor = System.Drawing.Color.Blue;
            this.tSSL_DataCount.Name = "tSSL_DataCount";
            this.tSSL_DataCount.Size = new System.Drawing.Size(17, 17);
            this.tSSL_DataCount.Text = "N";
            // 
            // FrmEventManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 351);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEventManage";
            this.Text = "事件管理";
            this.Load += new System.EventHandler(this.FrmEventManage_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSBDelete;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tSCBQueryItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox tSCBKeyword;
        private System.Windows.Forms.ToolStripButton tSBQuery;
        private System.Windows.Forms.ToolStripButton tSBExit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tSSL_DataCount;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}