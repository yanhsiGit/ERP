using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNGenerateKey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenSN_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length <= 2)
            {
                MessageBox.Show("使用者名稱長度至少為3");
                return;
            }
            if (txtEnvironmentCode.Text.Length != 10)
            {
                MessageBox.Show("環境代碼長度為10");
                return;
            }

            My.MySNAuthority SNA = new My.MySNAuthority();
            txtSN.Text = SNA.GenerateKey(txtUserName.Text, txtEnvironmentCode.Text);
        }
        //序號驗證
        private void btnVerifySN_Click(object sender, EventArgs e)
        {
            My.MySNAuthority SNA = new My.MySNAuthority();
            if (SNA.checkSN(txtUserName.Text, txtSN.Text))
            {
                MessageBox.Show("序號正確!!");
            }
            else
            {
                MessageBox.Show("序號錯誤!!");
            }
        }
        //清除
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtEnvironmentCode.Text = "";
            txtSN.Text = "";
        }
        //關閉
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //檢查環境代碼
        private void btnCheckEnvironmentCode_Click(object sender, EventArgs e)
        {
            if (txtEnvironmentCode.Text =="")
            {
                MessageBox.Show("請輸入環境代碼!!", "檢查環境代碼");
                return;
            }
            My.MySNAuthority CSNA = new My.MySNAuthority();

            string OSName = CSNA.QryOSName(txtEnvironmentCode.Text.Substring(0, 5));
            string NICName = CSNA.QryNICName(txtEnvironmentCode.Text.Substring(5, 5));
            string msg = "";

            if (OSName != "Error" && NICName != "Error")
            {
                msg = "環境代碼正確!!\n";
                msg = msg + "您的作業系統為:" + OSName + "\n";
                msg = msg + "您的網路介面卡為:" + NICName + "\n";
                MessageBox.Show(this, msg, "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxOS.SelectedItem = OSName;
                cbxNIC.SelectedItem = NICName;
            }
            else
            {
                msg = "環境代碼錯誤!!\n";
                msg = msg + "您的作業系統為:" + OSName + "\n";
                msg = msg + "您的網路介面卡為:" + NICName + "\n";
                MessageBox.Show(this, msg, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //產生環境代碼
        private void btnGenEnviornmentCode_Click(object sender, EventArgs e)
        {
            if (cbxOS.Text == "")
            {
                MessageBox.Show("請選取作業系統!!");
                cbxOS.Focus();
                return;
            }
            if (cbxNIC.Text == "")
            {
                MessageBox.Show("請選取網路卡廠商!!");
                cbxNIC.Focus();
                return;
            }
            My.MySNAuthority SNA = new My.MySNAuthority();
            txtEnvironmentCode.Text = SNA.GetOSCode(cbxOS.Text, true) + SNA.GetNICCode(cbxNIC.Text, true);
        }
        //驗證產生環境代碼序號
        private void btnEnvironmentCodeSN_Click(object sender, EventArgs e)
        {
            if (txtEnvironmentCode.Text.Length != 10)
            {
                MessageBox.Show("請先產生環境代碼!!");
                return;
            }

            My.MySNAuthority SNA = new My.MySNAuthority();
            if (SNA.checkSN(txtUserName.Text, txtSN.Text, txtEnvironmentCode.Text))
            {
                MessageBox.Show("序號正確!!");
            }
            else
            {
                MessageBox.Show("序號錯誤!!");
            }
        }
    }
}
