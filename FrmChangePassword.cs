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
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            //顯示[?]鈕必須要將最大化與最小化按鈕關閉
            this.HelpButton = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            this.helpProvider1.SetHelpString(txtOldPwd, "請輸入目前使用[密碼]!");
            this.helpProvider1.SetHelpString(txtNewPwd, "請輸入欲變更的[新密碼]!");
            this.helpProvider1.SetHelpString(txtCheckNewPwd, "請重新輸入一次[新密碼]!");
            this.helpProvider1.SetHelpString(btnSure, "按下[確認變更]鈕,以進行密碼變更動作!");
            this.helpProvider1.SetHelpString(btnCancel, "按下[取消]鈕,以關閉本表單!");
            this.helpProvider1.SetHelpString(btnClear, "按下[清除輸入]鈕,會將所有輸入的密碼內容文字清除!");
            this.KeyPreview = true;

        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (CheckField()) //檢查爛位是否無誤
            {

                SIS.DBClass.DBClsLogin Login = new SIS.DBClass.DBClsLogin();
                SIS.DBClass.DBClsWinAPEvents WAE = new SIS.DBClass.DBClsWinAPEvents();

                string UserID = "";
                string OldPwd = "";
                string NewPwd = "";
                string encryptFormat;//加密格式設定


                UserID = My.MyGlobal.GlobalUserID;

                encryptFormat = "SHA1";
                OldPwd = My.MyMethod.HashEncryption(encryptFormat, txtOldPwd.Text);
                NewPwd = My.MyMethod.HashEncryption(encryptFormat, txtNewPwd.Text);

                if (Login.UpdatePassword(UserID, OldPwd, NewPwd))
                {
                    MessageBox.Show(this, "密碼變更成功!!", "密碼變更");
                    clearField();

                    WAE.AddEventData(UserID, "資訊", "密碼變更", "密碼變更成功");
                    //btn_OK.Click += new System.EventHandler(btn_ClearField_Click);
                }
                else
                {
                    MessageBox.Show(this, "密碼變更失敗!!", "密碼變更");
                    WAE.AddEventData(UserID, "警告", "密碼變更", "密碼變更失敗");
                }

            }
        }
        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //清除輸入內容
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();
        }

        #region "清除欄位"

        /// <summary>
        /// 清除欄位
        /// </summary>
        public void clearField()
        {
            txtCheckNewPwd.Text = "";
            txtNewPwd.Text = "";
            txtOldPwd.Text = "";
        }

        #endregion


        #region "欄位驗證"

        /// <summary>
        /// 欄位驗證
        /// </summary>
        /// <returns></returns>
        private bool CheckField()
        {
            if (txtNewPwd.Text == "")
            {
                MessageBox.Show(this, "[密碼]不得為空白;", "欄位檢查");
                txtNewPwd.Focus();
                return false;
            }


            if (txtNewPwd.Text.Trim().Length <= 3)
            {
                MessageBox.Show(this, "[密碼]長度須四個以上的字元長度;", "欄位檢查");
                txtNewPwd.Focus();
                return false;
            }


            if (txtNewPwd.Text != txtCheckNewPwd.Text)
            {
                MessageBox.Show(this, "[新密碼]與[確認密碼]必須一樣;", "欄位檢查");
                txtNewPwd.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region "快速鍵"

        private void FrmChangePassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                e.Handled = true;
                this.Close();
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnClear_Click(sender, e);
             }
        }

        private void FrmChangePassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            //當按下[Enter]鍵時執行登入動作
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSure_Click(sender, e);
            }
        }


        #endregion


    }
}
