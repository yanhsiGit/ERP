namespace SIS
{
    partial class FrmAuthoritySetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAuthoritySetup));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSBSureChange = new System.Windows.Forms.ToolStripButton();
            this.tSBRefresh = new System.Windows.Forms.ToolStripButton();
            this.tSBQuery = new System.Windows.Forms.ToolStripButton();
            this.tSBClose = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tSSL_TreeViewPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSL_UserId = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.treeViewUsers = new System.Windows.Forms.TreeView();
            this.btnCloseQuery = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.imgListForTreeView = new System.Windows.Forms.ImageList(this.components);
            this.imgListForTreeView2 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoBtn6 = new System.Windows.Forms.RadioButton();
            this.rdoBtn3 = new System.Windows.Forms.RadioButton();
            this.rdoBtn5 = new System.Windows.Forms.RadioButton();
            this.rdoBtn2 = new System.Windows.Forms.RadioButton();
            this.rdoBtn4 = new System.Windows.Forms.RadioButton();
            this.rdoBtn1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeViewAuthority = new System.Windows.Forms.TreeView();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSBSureChange,
            this.tSBRefresh,
            this.tSBQuery,
            this.tSBClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(815, 54);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSBSureChange
            // 
            this.tSBSureChange.Image = global::SIS.Properties.Resources.OK;
            this.tSBSureChange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBSureChange.Name = "tSBSureChange";
            this.tSBSureChange.Size = new System.Drawing.Size(59, 51);
            this.tSBSureChange.Text = "確定變更";
            this.tSBSureChange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tSBSureChange.ToolTipText = "按一下[確定更改]鈕,以便進行變更使用者權限相關資料";
            this.tSBSureChange.Click += new System.EventHandler(this.tSBSureChange_Click);
            // 
            // tSBRefresh
            // 
            this.tSBRefresh.Image = global::SIS.Properties.Resources.Refresh;
            this.tSBRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBRefresh.Name = "tSBRefresh";
            this.tSBRefresh.Size = new System.Drawing.Size(59, 51);
            this.tSBRefresh.Text = "重新整理";
            this.tSBRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tSBRefresh.ToolTipText = "重新整理資料庫內容與相關控制項";
            this.tSBRefresh.Click += new System.EventHandler(this.tSBRefresh_Click);
            // 
            // tSBQuery
            // 
            this.tSBQuery.Image = global::SIS.Properties.Resources.Search;
            this.tSBQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBQuery.Name = "tSBQuery";
            this.tSBQuery.Size = new System.Drawing.Size(59, 51);
            this.tSBQuery.Text = "人員查詢";
            this.tSBQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tSBQuery.ToolTipText = "輸入使用者帳號,以查詢該使用者是否存在";
            this.tSBQuery.Click += new System.EventHandler(this.tSBQuery_Click);
            // 
            // tSBClose
            // 
            this.tSBClose.Image = global::SIS.Properties.Resources.Exit;
            this.tSBClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBClose.Name = "tSBClose";
            this.tSBClose.Size = new System.Drawing.Size(59, 51);
            this.tSBClose.Text = "關閉表單";
            this.tSBClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tSBClose.ToolTipText = "按一下[關閉表單]鈕,以進行關閉本表單";
            this.tSBClose.Click += new System.EventHandler(this.tSBClose_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSL_TreeViewPath,
            this.toolStripStatusLabel1,
            this.tSSL_UserId});
            this.statusStrip1.Location = new System.Drawing.Point(0, 494);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(815, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tSSL_TreeViewPath
            // 
            this.tSSL_TreeViewPath.ForeColor = System.Drawing.Color.Blue;
            this.tSSL_TreeViewPath.Name = "tSSL_TreeViewPath";
            this.tSSL_TreeViewPath.Size = new System.Drawing.Size(128, 17);
            this.tSSL_TreeViewPath.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(28, 17);
            this.toolStripStatusLabel1.Text = "       ";
            // 
            // tSSL_UserId
            // 
            this.tSSL_UserId.ForeColor = System.Drawing.Color.Red;
            this.tSSL_UserId.Name = "tSSL_UserId";
            this.tSSL_UserId.Size = new System.Drawing.Size(128, 17);
            this.tSSL_UserId.Text = "toolStripStatusLabel1";
            // 
            // treeViewUsers
            // 
            this.treeViewUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewUsers.Location = new System.Drawing.Point(3, 18);
            this.treeViewUsers.Name = "treeViewUsers";
            this.treeViewUsers.Size = new System.Drawing.Size(332, 391);
            this.treeViewUsers.TabIndex = 1;
            this.toolTip1.SetToolTip(this.treeViewUsers, "人員顯示區,角色根據分類來顯示系統所有使用者");
            this.treeViewUsers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewUsers_AfterSelect);
            // 
            // btnCloseQuery
            // 
            this.btnCloseQuery.Location = new System.Drawing.Point(137, 77);
            this.btnCloseQuery.Name = "btnCloseQuery";
            this.btnCloseQuery.Size = new System.Drawing.Size(75, 39);
            this.btnCloseQuery.TabIndex = 7;
            this.btnCloseQuery.Text = "關閉查詢";
            this.toolTip1.SetToolTip(this.btnCloseQuery, "按下[關閉查詢]鈕,此功能表單將會關閉.");
            this.btnCloseQuery.UseVisualStyleBackColor = true;
            this.btnCloseQuery.Click += new System.EventHandler(this.btnCloseQuery_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(45, 77);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 39);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "查詢";
            this.toolTip1.SetToolTip(this.btnQuery, "當您輸入使用者帳號時,按下[查詢]鈕,便會顯示是否有找到該人員,以便進行權限變更動作");
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnApply
            // 
            this.btnApply.ForeColor = System.Drawing.Color.Black;
            this.btnApply.Location = new System.Drawing.Point(280, 35);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(83, 89);
            this.btnApply.TabIndex = 13;
            this.btnApply.Text = "權限套用";
            this.toolTip1.SetToolTip(this.btnApply, "按下[權限套用]鈕,將會與權限設定區變更成對應的權限內容,但是要注意需按下[確定變更]鈕,才能完成真正的權限變更");
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // imgListForTreeView
            // 
            this.imgListForTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListForTreeView.ImageStream")));
            this.imgListForTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListForTreeView.Images.SetKeyName(0, "People.ico");
            this.imgListForTreeView.Images.SetKeyName(1, "peopleType.gif");
            this.imgListForTreeView.Images.SetKeyName(2, "onPeople.gif");
            this.imgListForTreeView.Images.SetKeyName(3, "offPeople.gif");
            // 
            // imgListForTreeView2
            // 
            this.imgListForTreeView2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListForTreeView2.ImageStream")));
            this.imgListForTreeView2.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListForTreeView2.Images.SetKeyName(0, "application.gif");
            this.imgListForTreeView2.Images.SetKeyName(1, "programs01.ico");
            this.imgListForTreeView2.Images.SetKeyName(2, "programs.gif");
            this.imgListForTreeView2.Images.SetKeyName(3, "programs02.ico");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeViewUsers);
            this.groupBox1.Location = new System.Drawing.Point(14, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 412);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "人員顯示區";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox4.Controls.Add(this.btnCloseQuery);
            this.groupBox4.Controls.Add(this.btnQuery);
            this.groupBox4.Controls.Add(this.txtUserId);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(3, 21);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(407, 154);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "查詢功能";
            // 
            // txtUserId
            // 
            this.txtUserId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtUserId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtUserId.Location = new System.Drawing.Point(114, 33);
            this.txtUserId.MaxLength = 20;
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(171, 22);
            this.txtUserId.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "使用者帳號";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnApply);
            this.groupBox3.Controls.Add(this.rdoBtn6);
            this.groupBox3.Controls.Add(this.rdoBtn3);
            this.groupBox3.Controls.Add(this.rdoBtn5);
            this.groupBox3.Controls.Add(this.rdoBtn2);
            this.groupBox3.Controls.Add(this.rdoBtn4);
            this.groupBox3.Controls.Add(this.rdoBtn1);
            this.groupBox3.Location = new System.Drawing.Point(375, 331);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(407, 144);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "群組設定區";
            // 
            // rdoBtn6
            // 
            this.rdoBtn6.AutoSize = true;
            this.rdoBtn6.Location = new System.Drawing.Point(144, 107);
            this.rdoBtn6.Name = "rdoBtn6";
            this.rdoBtn6.Size = new System.Drawing.Size(95, 16);
            this.rdoBtn6.TabIndex = 12;
            this.rdoBtn6.Tag = "All";
            this.rdoBtn6.Text = "選取所有權限";
            this.rdoBtn6.UseVisualStyleBackColor = true;
            // 
            // rdoBtn3
            // 
            this.rdoBtn3.AutoSize = true;
            this.rdoBtn3.Location = new System.Drawing.Point(23, 108);
            this.rdoBtn3.Name = "rdoBtn3";
            this.rdoBtn3.Size = new System.Drawing.Size(107, 16);
            this.rdoBtn3.TabIndex = 11;
            this.rdoBtn3.Tag = "Users";
            this.rdoBtn3.Text = "一般使用者權限";
            this.rdoBtn3.UseVisualStyleBackColor = true;
            // 
            // rdoBtn5
            // 
            this.rdoBtn5.AutoSize = true;
            this.rdoBtn5.Location = new System.Drawing.Point(144, 70);
            this.rdoBtn5.Name = "rdoBtn5";
            this.rdoBtn5.Size = new System.Drawing.Size(107, 16);
            this.rdoBtn5.TabIndex = 10;
            this.rdoBtn5.Tag = "Admin";
            this.rdoBtn5.Text = "系統管理者權限";
            this.rdoBtn5.UseVisualStyleBackColor = true;
            // 
            // rdoBtn2
            // 
            this.rdoBtn2.AutoSize = true;
            this.rdoBtn2.Location = new System.Drawing.Point(23, 70);
            this.rdoBtn2.Name = "rdoBtn2";
            this.rdoBtn2.Size = new System.Drawing.Size(107, 16);
            this.rdoBtn2.TabIndex = 9;
            this.rdoBtn2.Tag = "Guest";
            this.rdoBtn2.Text = "匿名參觀者權限";
            this.rdoBtn2.UseVisualStyleBackColor = true;
            // 
            // rdoBtn4
            // 
            this.rdoBtn4.AutoSize = true;
            this.rdoBtn4.Location = new System.Drawing.Point(144, 33);
            this.rdoBtn4.Name = "rdoBtn4";
            this.rdoBtn4.Size = new System.Drawing.Size(119, 16);
            this.rdoBtn4.TabIndex = 8;
            this.rdoBtn4.Tag = "Management";
            this.rdoBtn4.Text = "進銷存管理者權限";
            this.rdoBtn4.UseVisualStyleBackColor = true;
            // 
            // rdoBtn1
            // 
            this.rdoBtn1.AutoSize = true;
            this.rdoBtn1.Checked = true;
            this.rdoBtn1.Location = new System.Drawing.Point(23, 33);
            this.rdoBtn1.Name = "rdoBtn1";
            this.rdoBtn1.Size = new System.Drawing.Size(95, 16);
            this.rdoBtn1.TabIndex = 7;
            this.rdoBtn1.TabStop = true;
            this.rdoBtn1.Tag = "None";
            this.rdoBtn1.Text = "取消所有權限";
            this.rdoBtn1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.treeViewAuthority);
            this.groupBox2.Location = new System.Drawing.Point(372, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 259);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "權限設定區";
            // 
            // treeViewAuthority
            // 
            this.treeViewAuthority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewAuthority.Location = new System.Drawing.Point(3, 18);
            this.treeViewAuthority.Name = "treeViewAuthority";
            this.treeViewAuthority.Size = new System.Drawing.Size(407, 238);
            this.treeViewAuthority.TabIndex = 1;
            // 
            // FrmAuthoritySetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 516);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmAuthoritySetup";
            this.Text = "權限設定";
            this.Load += new System.EventHandler(this.FrmAuthoritySetup_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSBSureChange;
        private System.Windows.Forms.ToolStripButton tSBRefresh;
        private System.Windows.Forms.ToolStripButton tSBQuery;
        private System.Windows.Forms.ToolStripButton tSBClose;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tSSL_TreeViewPath;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tSSL_UserId;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ImageList imgListForTreeView;
        private System.Windows.Forms.ImageList imgListForTreeView2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeViewUsers;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCloseQuery;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.RadioButton rdoBtn6;
        private System.Windows.Forms.RadioButton rdoBtn3;
        private System.Windows.Forms.RadioButton rdoBtn5;
        private System.Windows.Forms.RadioButton rdoBtn2;
        private System.Windows.Forms.RadioButton rdoBtn4;
        private System.Windows.Forms.RadioButton rdoBtn1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treeViewAuthority;
    }
}