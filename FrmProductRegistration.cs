using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIS
{
    public partial class FrmProductRegistration : Form
    {
        public FrmProductRegistration()
        {
            InitializeComponent();
        }

        private void FrmProductRegistration_Load(object sender, EventArgs e)
        {
            My.MySNAuthority SNA = new My.MySNAuthority();
            txtEnvironmentCode.Text = SNA.GenEnvironmentCode();
            txtEnvironmentCode.Enabled = false;
        }

        //確定
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cbxAgreement.Checked == false)
            {
                MessageBox.Show("請勾選同意五大條款規範", "訊息");
                return;
            }
            if (txtUserName.Text == "" || txtUserName.Text.Length < 3)
            {
                MessageBox.Show("使用者名稱不得為空白且長度需大於等於3", "訊息");
                return;
            }
            if (txtSN.Text == "")
            {
                MessageBox.Show("序號不得為空白!!", "訊息");
                return;
            }

            My.MySNAuthority SNAuth = new My.MySNAuthority();
            if (SNAuth.checkSN(txtUserName.Text, txtSN.Text))
            {
                My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "Registration", "RegisterCode", txtSN.Text);
                My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "Registration", "RegisterEnvironmentCode", txtEnvironmentCode.Text);
                My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "Registration", "RegisterUser", txtUserName.Text);
                My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "Registration", "IsRegister", 1);
                MessageBox.Show("序號正確,恭喜您已經註冊成功!", "註冊結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MdiParent.Text = "超級進銷存系統(SIS) V1.0 - (中文旗艦版)";
                this.Close();
            }
            else
            {
                MessageBox.Show("序號錯誤", "註冊結果",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //說明
        private void btnExplain_Click(object sender, EventArgs e)
        {
            string MessageString = "";
            MessageString = "請您務必要完成註冊手續,"
                + Environment.NewLine + "否則程式有部分功能將無法使用.";
            MessageBox.Show(this, MessageString, "說明");
        }

        private void txtSN_TextChanged(object sender, EventArgs e)
        {
            string[] code = txtSN.Text.Split('-');

            My.MySNAuthority SNAuth = new My.MySNAuthority();

            if (code.Length == 5 && txtSN.Text.Length >= 29 && txtUserName.Text.Length >= 3)
            {
                if (SNAuth.checkSN(txtUserName.Text, txtSN.Text))
                {
                    this.PicBox_ok.Visible = true;
                }
                else
                {
                    this.PicBox_ok.Visible = false;
                }
            }
            else
            {
                this.PicBox_ok.Visible = false;
            }
        }

        private void txtEnvironmentCode_TextChanged(object sender, EventArgs e)
        {
            My.MySNAuthority SNA = new My.MySNAuthority();
            txtEnvironmentCode.Text = SNA.GenEnvironmentCode();
        }

      
    }
}
