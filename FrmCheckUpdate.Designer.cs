namespace SIS
{
    partial class FrmCheckUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNowVersion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLatestVersion = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbNews = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbCheckResult = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.llabWebSite = new System.Windows.Forms.LinkLabel();
            this.btnOK = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnNowDownloadLatestVersion = new System.Windows.Forms.Button();
            this.btnNowCheck = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "您目前的系統版本為：";
            // 
            // txtNowVersion
            // 
            this.txtNowVersion.Enabled = false;
            this.txtNowVersion.Location = new System.Drawing.Point(178, 23);
            this.txtNowVersion.Name = "txtNowVersion";
            this.txtNowVersion.Size = new System.Drawing.Size(91, 22);
            this.txtNowVersion.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "產品最新版本為：";
            // 
            // txtLatestVersion
            // 
            this.txtLatestVersion.Enabled = false;
            this.txtLatestVersion.Location = new System.Drawing.Point(178, 57);
            this.txtLatestVersion.Name = "txtLatestVersion";
            this.txtLatestVersion.Size = new System.Drawing.Size(91, 22);
            this.txtLatestVersion.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbNews);
            this.groupBox1.Location = new System.Drawing.Point(28, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 123);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "公司最新消息";
            // 
            // rtbNews
            // 
            this.rtbNews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbNews.Location = new System.Drawing.Point(3, 18);
            this.rtbNews.Name = "rtbNews";
            this.rtbNews.Size = new System.Drawing.Size(535, 102);
            this.rtbNews.TabIndex = 0;
            this.rtbNews.Text = "狂賀[Visual C# 2013程式設計實例演練與系統開發]和[Visual Basic 2013程式設計實例演練與系統開發]二本書受到讀者熱烈搶購，目前正加刷" +
    "列印中，尚未入手的讀者請加快腳步，以免向隅。";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtbCheckResult);
            this.groupBox2.Location = new System.Drawing.Point(28, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(535, 76);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "執行結果";
            // 
            // rtbCheckResult
            // 
            this.rtbCheckResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbCheckResult.Location = new System.Drawing.Point(3, 18);
            this.rtbCheckResult.Name = "rtbCheckResult";
            this.rtbCheckResult.Size = new System.Drawing.Size(529, 55);
            this.rtbCheckResult.TabIndex = 0;
            this.rtbCheckResult.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "造訪公司網站：";
            // 
            // llabWebSite
            // 
            this.llabWebSite.AutoSize = true;
            this.llabWebSite.Location = new System.Drawing.Point(124, 306);
            this.llabWebSite.Name = "llabWebSite";
            this.llabWebSite.Size = new System.Drawing.Size(139, 12);
            this.llabWebSite.TabIndex = 9;
            this.llabWebSite.TabStop = true;
            this.llabWebSite.Text = "http://www.drmaster.com.tw/";
            this.llabWebSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llabWebSite_LinkClicked);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(488, 306);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "確定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.tsslProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 332);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(595, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // tsslProgress
            // 
            this.tsslProgress.ForeColor = System.Drawing.Color.Red;
            this.tsslProgress.Name = "tsslProgress";
            this.tsslProgress.Size = new System.Drawing.Size(25, 17);
            this.tsslProgress.Text = "0%";
            // 
            // btnNowDownloadLatestVersion
            // 
            this.btnNowDownloadLatestVersion.Image = global::SIS.Properties.Resources.Download;
            this.btnNowDownloadLatestVersion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNowDownloadLatestVersion.Location = new System.Drawing.Point(448, 23);
            this.btnNowDownloadLatestVersion.Name = "btnNowDownloadLatestVersion";
            this.btnNowDownloadLatestVersion.Size = new System.Drawing.Size(121, 53);
            this.btnNowDownloadLatestVersion.TabIndex = 7;
            this.btnNowDownloadLatestVersion.Text = "立即下載最新版本";
            this.btnNowDownloadLatestVersion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNowDownloadLatestVersion.UseVisualStyleBackColor = true;
            this.btnNowDownloadLatestVersion.Click += new System.EventHandler(this.btnNowDownloadLatestVersion_Click);
            // 
            // btnNowCheck
            // 
            this.btnNowCheck.Image = global::SIS.Properties.Resources.Check;
            this.btnNowCheck.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNowCheck.Location = new System.Drawing.Point(296, 23);
            this.btnNowCheck.Name = "btnNowCheck";
            this.btnNowCheck.Size = new System.Drawing.Size(129, 53);
            this.btnNowCheck.TabIndex = 4;
            this.btnNowCheck.Text = "立即檢查新版本";
            this.btnNowCheck.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNowCheck.UseVisualStyleBackColor = true;
            this.btnNowCheck.Click += new System.EventHandler(this.btnNowCheck_Click);
            // 
            // FrmCheckUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 354);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.llabWebSite);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnNowDownloadLatestVersion);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNowCheck);
            this.Controls.Add(this.txtLatestVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNowVersion);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCheckUpdate";
            this.Text = "檢查更新";
            this.Load += new System.EventHandler(this.FrmCheckUpdate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNowVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLatestVersion;
        private System.Windows.Forms.Button btnNowCheck;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbNews;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNowDownloadLatestVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel llabWebSite;
        private System.Windows.Forms.RichTextBox rtbCheckResult;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel tsslProgress;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}