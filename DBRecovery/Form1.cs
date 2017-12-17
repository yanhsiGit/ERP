using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace DBRecovery
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialog1.SelectedPath = @"C:\";
            folderBrowserDialog1.ShowNewFolderButton = true;
            btnBackup.Enabled = false;
            btnRestore.Enabled = false;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (txtComputerName.Text =="" || txtDBName.Text =="" || txtPath.Text =="")
            {
                MessageBox.Show(this, "輸入區欄位內容均不得為空白!!", "欄位驗證");
                return;
            }
            string MessageString = "";
            string Caption = "";
            MessageBoxButtons Buttons;
            MessageBoxIcon Icons;
            DialogResult DR;

            MessageString = "是否要進行資料庫備份作業?";
            Caption = "資料備份";
            Buttons = MessageBoxButtons.YesNo;
            Icons = MessageBoxIcon.Information;
            DR = MessageBox.Show(MessageString, Caption, Buttons, Icons);

            if (DR == DialogResult.Yes)
            {
                string extension = ".bak"; //備份資料庫副檔名
                string dbName = txtDBName.Text;
                if (txtPath.Text.Substring(txtPath.Text.Length - 1, 1) != @"\")
                {
                    dbName = @"\" + dbName;
                }
                string argument = string.Format(@"-E -S {0} -Q  ""BACKUP DATABASE {1} TO DISK='{2}{3}{4}'""" ,
    txtComputerName.Text, txtDBName.Text, txtPath.Text, dbName, extension);
                // append user/password if not use integrated security
                // argument += string.Format(" -U {0} -P {1}", User, Password);
                var process = Process.Start("sqlcmd.exe", argument);
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                while (true)
                {
                    // wait for the process exits. The WaitForExit() method doesn't work
                    if (process.HasExited)
                        break;
                        System.Threading.Thread.Sleep(500);
                }
                string msg = "資料庫[" + txtDBName.Text + "]備份成功!" + "\r\n";
                msg = msg + "備份路徑為:" + txtPath.Text+ dbName+ extension;
                MessageBox.Show(this,msg , "資訊");
             }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (txtComputerName.Text == "" || txtDBName.Text == "" || txtPath.Text == "")
            {
                MessageBox.Show(this, "輸入區欄位內容均不得為空白!!", "欄位驗證");
                return;
            }
            string MessageString = "";
            string Caption = "";
            MessageBoxButtons Buttons;
            MessageBoxIcon Icons;
            DialogResult DR;

            MessageString = "是否要進行資料庫還原作業?";
            Caption = "資料還原";
            Buttons = MessageBoxButtons.YesNo;
            Icons = MessageBoxIcon.Information;
            DR = MessageBox.Show(MessageString, Caption, Buttons, Icons);

            if (DR == DialogResult.Yes)
            {
                string extension = ".bak"; //備份資料庫副檔名
                string dbName = txtDBName.Text;
                if (txtPath.Text.Substring(txtPath.Text.Length - 1, 1) != @"\")
                {
                    dbName = @"\" + dbName;
                }
                string DbPath = txtPath.Text + dbName + extension;
                if (File.Exists(DbPath) == false)
                {
                    MessageBox.Show(DbPath + "資料庫檔案不存在!!無法進行還原!!", "警告");
                    return;
                }

                string argument = string.Format(@"-E -S {0} -Q  ""RESTORE DATABASE {1} FROM DISK='{2}'""",
                 txtComputerName.Text, txtDBName.Text, DbPath);
                var process = Process.Start("sqlcmd.exe", argument);
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                while (true)
                {
                    // Wait for the process exits. The WaitForExit() method doesn't work
                    if (process.HasExited)
                        break;
                    System.Threading.Thread.Sleep(500);
                }
                string msg = "資料庫[" + txtDBName.Text + "]還原成功!" + "\r\n";
                msg = msg + "還原路徑為:" + txtPath.Text + dbName + extension;
                MessageBox.Show(this, msg, "資訊");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtPath.Text = folderBrowserDialog1.SelectedPath;
            if (txtPath.Text != "")
            {
                btnBackup.Enabled = true;
                btnRestore.Enabled = true;
            }
        }
    }
}
