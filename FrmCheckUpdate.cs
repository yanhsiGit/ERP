using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;//新增命名空間
using System.IO;
using System.Net;

namespace SIS
{
    public partial class FrmCheckUpdate : Form
    {
        public FrmCheckUpdate()
        {
            InitializeComponent();
        }

        bool IsNeedUpgrade = false; //是否需要更新程式
        SIS.Configuration.ClsOnlineUpgradeSetting COUS;
        SaveFileDialog sfd = new SaveFileDialog();
        private void FrmCheckUpdate_Load(object sender, EventArgs e)
        {
            txtNowVersion.Text = My.Application.Info.Version.ToString();
            sfd.AddExtension = true;
            sfd.CheckFileExists = false; //若為true則儲存的檔案必須存在
            sfd.Filter = "RAR類別|*.rar|所有檔案|*.*";
            sfd.FilterIndex = 1;//過濾條件預設為［C#類別］
            sfd.FileName = "SIS.RAR";
            sfd.InitialDirectory = Application.StartupPath + "\\Downloads";
            sfd.OverwritePrompt = true;
            sfd.RestoreDirectory = true;
            sfd.Title = "請您選擇要儲存檔案的路徑和輸入檔名";
            sfd.FileOk += new CancelEventHandler(sfd_FileOk);
        }

        private void sfd_FileOk(object sender, CancelEventArgs e)
        {
            string msg = "";
            msg = msg + "您選擇儲存的檔案路徑:\n" + sfd.FileName;
            MessageBox.Show(msg, "SaveFileDialog");
        }

        //立即檢查新版本
        private void btnNowCheck_Click(object sender, EventArgs e)
        {
            LoadInternetSetting();
            if (COUS != null)
            {
                txtLatestVersion.Text = COUS.Version;
                rtbNews.Text  = COUS.Message;
                if (IsNeedUpgrade)
                {
                    rtbCheckResult.Text = "您的系統版本不是最新版本:V" + txtLatestVersion.Text + " 需下載系統安裝檔案進行系統安裝更新!!";
                }
                else
                {
                    rtbCheckResult.Text = "您的系統版本已經是最新版本:V" + txtLatestVersion.Text + " 不需執行更新!!(記得定期檢查更新，以確保系統穩定性!!)";
                }
            }
        }

        //立即下載最新版本
        private async void btnNowDownloadLatestVersion_Click(object sender, EventArgs e)
        {
            DialogResult dr = sfd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                try
                {
                    await DownloadFileAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("錯誤訊息:" + ex.Message.ToString(), "發生例外");
                }

            }
        }

        /// <summary>
        /// 使用非同步從Internet下載檔案
        /// </summary>
        /// <returns></returns>
        private async Task DownloadFileAsync()
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            await webClient.DownloadFileTaskAsync(new Uri("http://localhost/SIS.rar"), sfd.FileName);
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            tsslProgress.Text = toolStripProgressBar1.Value.ToString() + "%";
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("安裝檔案[" + sfd.FileName +  "]下載完成!!", "Download Completed!");
            rtbCheckResult.Text = "安裝檔案[" + sfd.FileName + "]下載完成!!";
        }


        private void llabWebSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process myProcess = new Process();
            myProcess = Process.Start("IExplore.exe", "www.drmaster.com.tw");
        }

        //確定
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 載入網際網路設定值
        /// </summary>
        private void LoadInternetSetting()
        {

                try
                {
                    string getSettingString = My.MyInternet.getFileData("http://localhost/SIS.Setting"); //由於MIME類型預設沒有支援.Setting副檔名，須至IIS新增此副檔名且MIME類型為text/plain，注意SIS.Setting檔案須為Unicode編碼
                    //使用StringReader讀行方式來去除InternetSettingString字串的\r\n
                    StringReader sr = new StringReader(getSettingString);
                    string[] aLine = new string[6];
                    string temp = "";
                    int i = 0;
                    COUS = new Configuration.ClsOnlineUpgradeSetting();

                    while (true)
                    {
                        temp = sr.ReadLine();
                        if (temp == null)
                        {
                            break;
                        }
                        else
                        {
                            aLine[i] = temp;
                            i = i + 1;
                        }
                    }
                    COUS.Name = aLine[0].Split('=')[1];
                    COUS.Version = aLine[1].Split('=')[1];
                    COUS.Locale = aLine[2].Split('=')[1];
                    COUS.Creator = aLine[3].Split('=')[1];
                    COUS.Code = aLine[4].Split('=')[1];
                    COUS.Message = aLine[5].Split('=')[1];

                    //判斷是否有新版本
                    if (COUS.Version.CompareTo(txtNowVersion.Text) == 1)
                    {
                        IsNeedUpgrade = true;
                    }
                     
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    COUS = null;
                }

        }




    }
}
