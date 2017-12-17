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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //顯示[?]鈕必須要將最大化與最小化按鈕關閉
            this.HelpButton = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            this.helpProvider1.SetHelpString(txtUserID, "請輸入使用者[帳號]!");
            this.helpProvider1.SetHelpString(txtPwd, "請輸入[密碼]!");
            this.helpProvider1.SetHelpString(btnSure, "按下[確定]鈕,以進行系統身份驗證動作!");
            this.helpProvider1.SetHelpString(btnCancel, "按下[取消]鈕,以取消系統登入動作!");
            this.KeyPreview = true;


            txtUserID.MaxLength = 20;
            txtUserID.Font = new Font(txtUserID.Font.Name, 12, FontStyle.Bold);
            txtPwd.Font = new Font(txtPwd.Font.Name, 12, FontStyle.Bold);
            txtPwd.MaxLength = 20;
            txtPwd.UseSystemPasswordChar = true;

            toolTip1.SetToolTip(txtUserID, "請輸入使用者[帳號]!");
            toolTip1.SetToolTip(txtPwd, "請輸入[密碼]!");
            toolTip1.SetToolTip(btnSure, "按下[確定]鈕,以進行系統身份驗證動作!");
            toolTip1.SetToolTip(btnCancel, "按下[取消]鈕,以取消系統登入動作!");

            errorProvider1.BlinkRate = 200;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            btnSure.FlatStyle = FlatStyle.Popup;
            btnCancel.FlatStyle = FlatStyle.Popup;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (RunLogin())
            {
                this.Close();//關閉登入表單
            }
        }


        #region "執行登入動作"

        /// <summary>
        /// 執行登入動作
        /// </summary>
        /// <returns>登入成功回傳True,否則回傳False</returns>
        public bool RunLogin()
        {

            if (CheckField())
            {
                string UserID;
                string HashPwd;
                string encryptFormat;//加密格式設定
                string RoleName = "";

                encryptFormat = "SHA1";
                UserID = txtUserID.Text;
                HashPwd = My.MyMethod.HashEncryption(encryptFormat, txtPwd.Text);

                SIS.DBClass.DBClsLogin DbLogin = new SIS.DBClass.DBClsLogin();
                SIS.DBClass.DBClsWinAPEvents WAE = new SIS.DBClass.DBClsWinAPEvents();
                bool VerifyResult = false;
                try
                {
                    VerifyResult = DbLogin.VerifyPWD(UserID, HashPwd);
                    if (VerifyResult ==false )
                    {
                        My.ErrorType errType = new My.ErrorType( My.MainErrorType.LoginError);
                        errType.loginError = new My.LoginError();
                        errType.loginError.AccountOrPasswordError = true;
                        throw new My.MyExceptionHandler(errType);
                    }
                }
                catch (My.MyExceptionHandler ex)
                {
                    MessageBox.Show(ex.Message, "MyExceptionHandler");
                    return false ;
                }

                if (VerifyResult)
                {
                    //MessageBox.Show("驗證成功");

                    //將登入結果寫入事件資料庫中
                    WAE.AddEventData(UserID, "資訊", "登入", "身分驗證成功");
                    RoleName = DbLogin.RoleIdToRoleName(UserID);

                    My.MyGlobal.GlobalUserID = UserID;
                    My.MyGlobal.GlobalPassword = txtPwd.Text;
                    My.MyGlobal.GlobalHashPassword = HashPwd;
                    My.MyGlobal.GlobalRoleName = RoleName;

                    //執行登錄檔處理
                    if (RegistryProcess(UserID, RoleName))
                    {
                        //執行使用者授權動作
                        if (AuthorityProcess(UserID, RoleName))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                    else
                    {
                        MessageBox.Show("登錄檔作業失敗!!", "Registry作業", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }


                }
                else
                {
                    //MessageBox.Show("驗證失敗");

                    My.MyGlobal.GlobalLoginErrorCounter += 1;

                    if (My.MyGlobal.GlobalLoginErrorCounter >= 3)
                    {
                        MessageBox.Show("[帳號]和[密碼]輸入錯誤超過三次!!,系統將強制關閉", "登入失敗", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        My.MyGlobal.GlobalSystemShutdown = true;
                        MdiParent.Close();
                        this.Close();
                    }


                    //將登入失敗的結果寫入事件資料庫中
                    WAE.AddEventData(UserID, "警告", "登入", "身分驗證失敗");

                    MessageBox.Show("[帳號]和[密碼]錯誤!!", "登入失敗", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        #endregion



        #region "欄位檢查"

        /// <summary>
        /// 欄位檢查
        /// </summary>
        /// <returns></returns>
        public bool CheckField()
        {
            errorProvider1.Clear();
            if (txtUserID.Text == "" || txtUserID.Text.Length == 0)
            {
                MessageBox.Show(this, "帳號不得為空白", "欄位檢查");
                txtUserID.Focus();
                errorProvider1.SetError(txtUserID, "帳號不得為空白");
                return false;
            }

            if (Microsoft.VisualBasic.Information.IsNumeric(txtUserID.Text))
            {
                MessageBox.Show(this, "帳號不得為數字型態", "欄位檢查");
                txtUserID.Focus();
                errorProvider1.SetError(txtUserID, "帳號不得為數字型態");
                return false;
            }

            if (txtPwd.Text.Length <= 3)
            {
                MessageBox.Show(this, "密碼長度必須4個以上", "欄位檢查");
                txtPwd.Focus();
                errorProvider1.SetError(txtPwd, "密碼長度必須4個以上");
                return false;
            }
            return true;

        }

        #endregion


        #region "登錄檔處理(Registry)"

        /// <summary>
        /// 登錄檔處理(Registry)
        /// </summary>
        /// <param name="UserID">使用者帳號</param>
        /// <param name="RoleName">角色名稱</param>
        /// <returns>處理成功回傳true,若失敗回傳false</returns>
        public bool RegistryProcess(string UserID, string RoleName)
        {

            bool LoginStart = false;
            string PreLoginTime = "";//存放使用者上次登入時間
            int LoginCount = 0;

            try
            {
                LoginStart = Convert.ToBoolean(My.MyWinAPI.GetSubKeyValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "UserProfile\\" + UserID, "LoginStart"));

                if (LoginStart)　//LoginStart為True表示登入系統超過一次
                {
                    //從登錄檔中讀取資料
                    PreLoginTime = (string)(My.MyWinAPI.GetSubKeyValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "UserProfile\\" + UserID, "PreLoginTime"));
                    LoginCount = Convert.ToInt16(My.MyWinAPI.GetSubKeyValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "UserProfile\\" + UserID, "LoginCount"));


                    //將設定資料寫入登錄檔
                    My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "UserProfile\\" + UserID, "LoginCount", LoginCount + 1);
                    MessageBox.Show(this, UserID + "您好!!,[帳號]與[密碼]正確!!,您是第" +
                        (LoginCount + 1) + "次登入系統." + Environment.NewLine +
                        "上次登入時間為:" + PreLoginTime, "登入成功");
                    My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "UserProfile\\" + UserID, "PreLoginTime", DateTime.Now.ToString("yyyy年MM月dd日 hh:mm:ss"));
                }
                else　//LoginStart為False表示第一次登入系統
                {
                    MessageBox.Show(this, UserID + "您好!!,您是第一次登入系統,[帳號]與[密碼]正確!!", "登入成功");
                    My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "UserProfile\\" + UserID, "LoginStart", 1); //1轉換成bool變成True
                    My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "UserProfile\\" + UserID, "LoginCount", 1);
                    My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "UserProfile\\" + UserID, "Role", RoleName);
                    My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "UserProfile\\" + UserID, "PreLoginTime", DateTime.Now.ToString("yyyy年MM月dd日 hh:mm:ss"));
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "登錄檔處理(Registry)例外產生");
                return false;
            }


        }

        #endregion


        #region "權限處理"

        /// <summary>
        /// 權限處理
        /// </summary>
        /// <param name="UserID">使用者帳號</param>
        /// <param name="RoleName">角色名稱</param>
        /// <returns>處理成功回傳true,若失敗回傳false</returns>
        public bool AuthorityProcess(string UserID, string RoleName)
        {
            int i = 0;
            SIS.DBClass.DBClsSysUserAuthority SUA = new SIS.DBClass.DBClsSysUserAuthority();
            DataTable DT = SUA.GetSysUserAuthorityDataTable(UserID);

            foreach (object var in this.MdiParent.Controls)
            {

                //Start..設定MenuStrip權限
                if (var.GetType().ToString() == "System.Windows.Forms.MenuStrip")
                {

                    MenuStrip MS = (MenuStrip)var;

                    foreach (object MenuStripBuf in MS.Items)
                    {
                        ToolStripMenuItem TSMI = (ToolStripMenuItem)MenuStripBuf;

                        //TSMI.Enabled = SUA.VerifyAuthority(UserID, TSMI.Tag.ToString());
                        TSMI.Enabled = SUA.VerifyAuthorityPerformance(UserID, TSMI.Tag.ToString(), DT);

                        for (i = 0; i < TSMI.DropDownItems.Count; i++)
                        {
                            if (TSMI.DropDownItems[i].Tag != null)
                            {

                                //TSMI.DropDownItems[i].Enabled = SUA.VerifyAuthority(UserID, TSMI.DropDownItems[i].Tag.ToString());
                                TSMI.DropDownItems[i].Enabled = SUA.VerifyAuthorityPerformance(UserID, TSMI.DropDownItems[i].Tag.ToString(), DT);
                            }
                        }

                    }
                }
                //End ..設定MenuStrip權限


                //Start..設定ToolStrip權限
                if (var.GetType().ToString() == "System.Windows.Forms.ToolStrip")
                {
                    ToolStrip TS = (ToolStrip)var;

                    for (i = 0; i < TS.Items.Count; i++)
                    {
                        if (TS.Items[i].Tag != null)
                        {
                            //TS.Items[i].Enabled = SUA.VerifyAuthority(UserID, TS.Items[i].Tag.ToString());
                            TS.Items[i].Enabled = SUA.VerifyAuthorityPerformance(UserID, TS.Items[i].Tag.ToString(), DT);
                        }
                    }

                }
                //End..設定ToolStrip權限

                //Start..設定StatusStrip權限
                if (var.GetType().ToString() == "System.Windows.Forms.StatusStrip")
                {
                    StatusStrip SS = (StatusStrip)var;

                    for (i = 0; i < SS.Items.Count; i++)
                    {
                        if (SS.Items[i].Name == "tSSL_UserId")
                        {
                            SS.Items[i].Text = UserID;
                            SS.Items[i].BackColor = Color.Navy;
                            SS.Items[i].ForeColor = Color.White;
                        }

                        if (SS.Items[i].Name == "tSSL_SysRole")
                        {
                            SS.Items[i].Text = RoleName;
                            SS.Items[i].BackColor = Color.Crimson;
                            SS.Items[i].ForeColor = Color.White;
                        }

                    }

                }
                //End..設定StatusStrip權限


            }

            return true;
        }

        #endregion



        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region "快速鍵"

        private void FrmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //當按下[Enter]鍵時執行登入動作
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                //MessageBox.Show("按下Enter", "訊息提示", MessageBoxButtons.OK);
                if (RunLogin())
                {
                    this.Close();//關閉登入表單
                }
            }
           
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                e.Handled = true;
                this.Close();
            }
            else if (e.KeyCode == Keys.F2)
            {
                //btnCancel_Click(sender, e);
                txtUserID.Text = "";
                txtPwd.Text = "";
            }
        }

        #endregion

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {
            txtUserID.Text = txtUserID.Text.ToUpper();
            My.Computer.Keyboard.SendKeys("{End}");
        }

    }
}
