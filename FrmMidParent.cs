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
    public partial class FrmMidParent : Form
    {
        public FrmMidParent()
        {
            InitializeComponent();
        }

        private void FrmMidParent_Load(object sender, EventArgs e)
        {
            FrmSplashScreen FSS = new FrmSplashScreen();
            FSS.ShowDialog();

            this.WindowState = FormWindowState.Maximized;
            timer1.Enabled = true;
            timer1.Interval = 1000;
            tSSL_DbType.Text = My.MyGlobal.DbType;
            tSSL_DbName.Text = My.MyGlobal.DbName;
            LoadDefaultValue();
            RegistryProcess();
            LoadSystemINI();

            //delegate
            this.tSB_Login.Click += new System.EventHandler(this.TSMI_Login_Click);
            this.tSB_Logout.Click += new System.EventHandler(this.TSMI_Logout_Click);
            this.tSB_ChangePwd.Click += new System.EventHandler(this.TSMI_ChangePwd_Click);
            this.tSB_ExitSystem.Click += new System.EventHandler(this.TSMI_ExitSystem_Click);

            //將開啟的子視窗直接附加在[視窗]下的子項目
            menuStrip1.MdiWindowListItem = TSMI_windowsMenu;
        }

        /// <summary>
        /// 載入表單預設值
        /// </summary>
        public void LoadDefaultValue()
        {
            tSB_Logout.Enabled = false;
            tSB_ChangePwd.Enabled = false;
            TSMI_F1.Enabled = false;
            TSMI_F2.Enabled = false;
            TSMI_F3.Enabled = false;
            TSMI_F4.Enabled = false;
            TSMI_F5.Enabled = false;
            TSMI_windowsMenu.Enabled = false;
            My.MyGlobal.GlobalUserID = "";
            My.MyGlobal.GlobalPassword = "";
            My.MyGlobal.GlobalLoginErrorCounter = 0;
        }

        #region "載入系統INI設定參數"

        public void LoadSystemINI()
        {

            string filePath = Application.StartupPath + "\\System.ini";
            if (My.MyFileIO.FileExists(filePath))
            {
                My.MyINI myINI = new My.MyINI(filePath);
                My.MyGlobal.INISystemName = myINI.getKeyValue("System", "Name");
                My.MyGlobal.INISystemVersion = myINI.getKeyValue("System", "Version");
                My.MyGlobal.INISystemLocale = myINI.getKeyValue("System", "Locale");
                My.MyGlobal.INISystemCreator = myINI.getKeyValue("System", "Creator");
                My.MyGlobal.INICompanyName = myINI.getKeyValue("Company", "Name");
                My.MyGlobal.INICompanyAddress = myINI.getKeyValue("Company", "Address");
                My.MyGlobal.INICompanyTelephone = myINI.getKeyValue("Company", "Telephone");
                My.MyGlobal.INIDateFormatYearSet = myINI.getKeyValue("DateFormat", "YearSet");
                My.MyGlobal.INIDateFormatDateSet = myINI.getKeyValue("DateFormat", "DateSet");
                My.MyGlobal.INIDatabaseComputeOrIP = myINI.getKeyValue("Database", "ComputeOrIP");
                My.MyGlobal.INIDatabaseID = myINI.getKeyValue("Database", "ID");
                My.MyGlobal.INIDatabasePassword = myINI.getKeyValue("Database", "Password");
                My.MyGlobal.INIBusinessTaxStockTaxRate = myINI.getKeyValue("BusinessTax", "StockTaxRate");
                My.MyGlobal.INIBusinessTaxShipTaxRate = myINI.getKeyValue("BusinessTax", "ShipTaxRate");
                My.MyGlobal.INIPointSettingItemPoint = myINI.getKeyValue("PointSetting", "ItemPoint");
                My.MyGlobal.INIPointSettingReceiptPoint = myINI.getKeyValue("PointSetting", "ReceiptPoint");
            }
            else
            {
                MessageBox.Show("系統設定檔案System.INI載入失敗，請洽系統維護人員。", "警告",   MessageBoxButtons.OK ,  MessageBoxIcon.Warning);
            }

        }

        #endregion


        #region "登錄檔處理"

        /// <summary>
        /// 登錄檔處理
        /// </summary>
        public void RegistryProcess()
        {

            //SysProfile系統設定檔變數宣告========================================
            bool IsStart;          //記錄系統是否啟動過
            int SystemUseCount = 0;  //記錄系統使用次數
            string SetupDate;      //記錄系統安裝日期
            string PreUser = "";     //記錄系統上次使用者
            string PreUseSysTime;  //紀錄上次使用系統時間
            string SystemName;     //記錄系統名稱
            string CurrentVersion; //記錄系統目前版本
            string SystemTitle;    //記錄系統標題名稱
            string DefaultLocale;  //記錄系統預設語系
            string DefaultLanguage;//記錄系統使用何種程式語言開發
            string NowDateTime;


            NowDateTime = DateTime.Now.ToString("yyyy年MM月dd日 hh:mm:ss");
            SetupDate = NowDateTime;
            PreUser = "anonymous";
            PreUseSysTime = NowDateTime;
            SystemName = My.MyGlobal.GlobalSystemName;
            CurrentVersion = My.MyGlobal.GlobalSystemVersion;
            SystemTitle = My.MyGlobal.GlobalSystemTitle;
            DefaultLocale = My.MyGlobal.GlobalUseLocale;
            DefaultLanguage = My.MyGlobal.GlobalDefaultLanguage;

            IsStart = Convert.ToBoolean(My.MyWinAPI.GetSubKeyValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "SysProfile", "IsStart"));

            //IsStart = (IsStartString == "true") ? true : false;


            if (IsStart) //若IsStart=True表示已經有將基本資料寫入到登錄檔!
            {
                //MessageBox.Show(this, "已經有將基本資料寫入到登錄檔!!", "訊息提示");
                SystemUseCount = Convert.ToInt16(My.MyWinAPI.GetSubKeyValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "SysProfile", "SystemUseCount"));
                My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "SysProfile", "SystemUseCount", SystemUseCount + 1);
                My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "SysProfile", "PreUseSysTime", PreUseSysTime);

            }
            else //若IsStart=False表示第一次啟動系統
            {
                MessageBox.Show(this, "第一次啟動系統,執行登錄檔作業!!", "訊息提示");
                My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "SysProfile", "IsStart", 1);
                My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "SysProfile", "SystemUseCount", 1);
                My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "SysProfile", "SetupDate", SetupDate);
                My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "SysProfile", "PreUser", PreUser);
                My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "SysProfile", "PreUseSysTime", PreUseSysTime);
                My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "SysProfile", "SystemName", SystemName);
                My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "SysProfile", "CurrentVersion", CurrentVersion);
                My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "SysProfile", "SystemTitle", SystemTitle);
                My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "SysProfile", "DefaultLocale", DefaultLocale);
                My.MyWinAPI.CreateSubKeyAndSetValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "SysProfile", "DefaultLanguage", DefaultLanguage);

            }

            //登錄檔讀取註冊訊息==================================================Start
            string sn = "";
            string username = "";


            sn = Convert.ToString(My.MyWinAPI.GetSubKeyValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "Registration", "RegisterCode"));
            username = Convert.ToString(My.MyWinAPI.GetSubKeyValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "Registration", "RegisterUser"));

            //將驗證序號類別My.MySNAuthority實體化
            My.MySNAuthority SNAuth = new My.MySNAuthority();
            //檢查登錄檔中的序號資料是否正確,若是正確序號則顯示為中文專業版,若是序號錯誤則顯示30天試用版
            if (SNAuth.checkSN(username, sn))
            {
                this.Text = "超級進銷存系統(SIS) V1.0 - (中文旗艦版)";
            }
            else
            {
                this.Text = "超級進銷存系統(SIS) V1.0 - (30天試用版)";
                TrySystemIsTimeOut(); //若尚未註冊則判斷還能試用多久時間
            }
            //登錄檔讀取註冊訊息==================================================End


        }

        #endregion


        #region "判斷試用時間是否過期"

        /// <summary>
        /// 判斷試用時間是否過期
        /// </summary>
        public void TrySystemIsTimeOut()
        {

            string SetupDate = "";

            SetupDate = Convert.ToString(My.MyWinAPI.GetSubKeyValue("CurrentUser", My.MyGlobal.GlobalSysRegDefaultPath + "SysProfile", "SetupDate"));
            DateTime dt1 = Convert.ToDateTime(SetupDate);
            DateTime dt2 = dt1.AddDays(30);
            Int32 i = My.MyMethod.DateTimeDiff(dt2.ToString()); //i為可試用日期與目前時間的秒數差
            if (i > 0)
            {
                MessageBox.Show(this, "系統試用時間還剩 [" + My.MyMethod.SecToDay(i) + "]", "試用版訊息提示");
            }
            else
            {
                MessageBox.Show(this, "系統試用時間已到,系統所有功能將關閉!!", "試用版訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                My.MyGlobal.GlobalSystemShutdown = true;
                Application.Exit();
            }
        }

        #endregion



        private void FrmMidParent_Resize(object sender, EventArgs e)
        {
            this.BackgroundImage = null;
        }

        private void FrmMidParent_SizeChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = global::SIS.Properties.Resources.bg02;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tSSL_Now.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
        }

        #region "判斷子表單是否已經存在"

        /// <summary>
        /// 判斷子表單是否已經存在
        /// </summary>
        /// <param name="MdiFormName">輸入子表單名稱</param>
        /// <returns></returns>
        public bool IsShowChildForm(string MdiFormName)
        {
            foreach (Form var in MdiChildren)
            {
                if (MdiFormName == var.Name)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        #endregion

        #region "說明"


        private void TSMI_ProductRegister_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmProductRegistration"))
            {
                FrmProductRegistration FPR = new FrmProductRegistration();
                FPR.MdiParent = this;
                FPR.StartPosition = FormStartPosition.CenterScreen;
                FPR.Show();
            }
        }

        private void TSMI_CheckUpdate_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmCheckUpdate"))
            {
                FrmCheckUpdate FCU = new FrmCheckUpdate();
                FCU.MdiParent = this;
                FCU.StartPosition = FormStartPosition.CenterScreen;
                FCU.Show();
            }
        }

        private void TSMI_About_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("AboutBox1"))
            {
                AboutBox1 AB = new AboutBox1();
                AB.MdiParent = this;
                AB.StartPosition = FormStartPosition.CenterScreen;
                AB.Show();
            }
        }

        #endregion

        #region "共同功能"


        private void TSMI_Login_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmLogin"))
            {
                FrmLogin FL = new FrmLogin();
                FL.MdiParent = this;
                FL.StartPosition = FormStartPosition.CenterScreen;
                FL.Show();
            }
        }

        //登出
        private void TSMI_Logout_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }

            SIS.DBClass.DBClsWinAPEvents WAE = new SIS.DBClass.DBClsWinAPEvents();

            //將登入結果寫入事件資料庫中
            WAE.AddEventData(My.MyGlobal.GlobalUserID, "資訊", "登出", "使用者登出成功");

            LoadDefaultValue();

            MessageBox.Show(this, "您已經成功登出系統!!", "訊息提示");
        }

        private void TSMI_ChangePwd_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmChangePassword"))
            {
                FrmChangePassword FCP = new FrmChangePassword();
                FCP.MdiParent = this;
                FCP.StartPosition = FormStartPosition.CenterScreen;
                FCP.Show();
            }
        }

        private void TSMI_ExitSystem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
        
        #region "系統設定與管理"


        private void TSMI_BasicSetting_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmBasicSetting"))
            {
                FrmBasicSetting FBS = new FrmBasicSetting();
                FBS.MdiParent = this;
                FBS.StartPosition = FormStartPosition.CenterScreen;
                FBS.Show();
            }
        }

        //事件管理
        private void TSMI_EventManage_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmEventManage"))
            {
                FrmEventManage FEM = new FrmEventManage();
                FEM.MdiParent = this;
                FEM.StartPosition = FormStartPosition.CenterScreen;
                FEM.Show();
            }
        }

        //使用者註冊
        private void TSMI_UserRegister_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmUserRegistration"))
            {
                FrmUserRegistration FUR = new FrmUserRegistration();
                FUR.MdiParent = this;
                FUR.StartPosition = FormStartPosition.CenterScreen;
                FUR.Show();
            }
        }

        //權限管理
        private void TSMI_Authority_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("Form_AuthoritySetup"))
            {
                FrmAuthoritySetup FAS = new FrmAuthoritySetup();
                FAS.MdiParent = this;
                FAS.StartPosition = FormStartPosition.CenterScreen;
                FAS.Show();
            }
        }

        #endregion

        #region "視窗"

        //[視窗]*****************************************************************Start

        //重疊顯示(&C)
        private void TSMI_Cascade_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
        //垂直並排(&V)
        private void TSMI_TileVerticle_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        //水平並排(&H)
        private void TSMI_TileHorizontal_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        //全部關閉(&L)
        private void TSMI_CloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        //排列圖示(&A)
        private void TSMI_ArrangeIcons_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        //當要關閉應用程式時,做最後一次確認,防止不小心按到[X]鈕而將整個應用關閉
        private void FrmMidParent_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!My.MyGlobal.GlobalSystemShutdown)
            {
                DialogResult result;
                result = MessageBox.Show(this, "您確定要離開這裡嗎?不多停留一會兒?", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }



        //[視窗]*****************************************************************End
        #endregion

        //公司
        private void TSMI_Company_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmCompanyMaintain"))
            {
                FrmCompanyMaintain FCM = new FrmCompanyMaintain();
                FCM.MdiParent = this;
                FCM.StartPosition = FormStartPosition.CenterScreen;
                FCM.Show();
            }
        }
        //廠商
        private void TSMI_Manufacturer_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmManufacturerMaintain"))
            {
                FrmManufacturerMaintain FMM = new FrmManufacturerMaintain();
                FMM.MdiParent = this;
                FMM.StartPosition = FormStartPosition.CenterScreen;
                FMM.Show();
            }
        }
        //商品
        private void TSMI_Items_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmItemsMaintain"))
            {
                FrmItemsMaintain FIM = new FrmItemsMaintain();
                FIM.MdiParent = this;
                FIM.StartPosition = FormStartPosition.CenterScreen;
                FIM.Show();
            }
        }
        //客戶
        private void TSMI_Customer_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmCustomerMaintain"))
            {
                FrmCustomerMaintain FCM = new FrmCustomerMaintain();
                FCM.MdiParent = this;
                FCM.StartPosition = FormStartPosition.CenterScreen;
                FCM.Show();
            }
        }
        //員工
        private void TSMI_Employee_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmEmployeeMaintain"))
            {
                FrmEmployeeMaintain FEM = new FrmEmployeeMaintain();
                FEM.MdiParent = this;
                FEM.StartPosition = FormStartPosition.CenterScreen;
                FEM.Show();
            }
        }
        //採購
        private void TSMI_Purchase_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmSISPurchase"))
            {
                FrmSISPurchase FSP = new FrmSISPurchase();
                FSP.MdiParent = this;
                FSP.StartPosition = FormStartPosition.CenterScreen;
                FSP.Show();
            }
        }
        //進貨
        private void TSMI_Stock_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmSISStock"))
            {
                FrmSISStock FSS = new FrmSISStock();
                FSS.MdiParent = this;
                FSS.StartPosition = FormStartPosition.CenterScreen;
                FSS.Show();
            }
        }
        //出貨
        private void TSMI_Ship_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmSISShip"))
            {
                FrmSISShip FSS = new FrmSISShip();
                FSS.MdiParent = this;
                FSS.StartPosition = FormStartPosition.CenterScreen;
                FSS.Show();
            }
        }
        //退貨
        private void TSMI_RMA_Click(object sender, EventArgs e)
        {
            //if (IsShowChildForm("FrmSISRMA"))
            //{
                //實作獨體模式
                FrmSISRMA.Instance.MdiParent = this;
                FrmSISRMA.Instance.StartPosition = FormStartPosition.CenterScreen; ;
                FrmSISRMA.Instance.Show();
                //FrmSISRMA FSR = new FrmSISRMA();
                //FSR.MdiParent = this;
                //FSR.StartPosition = FormStartPosition.CenterScreen;
                //FSR.Show();
            //}
        }

        //盤點
        private void TSMI_TakeStock_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmSISTakeStock"))
            {
                FrmSISTakeStock FSTS = new FrmSISTakeStock();
                FSTS.MdiParent = this;
                FSTS.StartPosition = FormStartPosition.CenterScreen;
                FSTS.Show();
            }
        }

        //沖銷
        private void TSMI_Reversal_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmSISReversal"))
            {
                FrmSISReversal FSR = new FrmSISReversal();
                FSR.MdiParent = this;
                FSR.StartPosition = FormStartPosition.CenterScreen;
                FSR.Show();
            }
        }

        //客戶明細表
        private void TSMI_CustomerReport_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmReportForCustomer"))
            {
                FrmReportForCustomer FRFC = new FrmReportForCustomer();
                FRFC.MdiParent = this;
                FRFC.StartPosition = FormStartPosition.CenterScreen;
                FRFC.Show();
            }
        }
        //廠商明細表
        private void TSMI_ManufacturerReport_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmReportForManufacturer"))
            {
                FrmReportForManufacturer FRFM = new FrmReportForManufacturer();
                FRFM.MdiParent = this;
                FRFM.StartPosition = FormStartPosition.CenterScreen;
                FRFM.Show();
            }
        }
        //商品明細表
        private void TSMI_ItemsReport_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmReportForItems"))
            {
                FrmReportForItems FRFI = new FrmReportForItems();
                FRFI.MdiParent = this;
                FRFI.StartPosition = FormStartPosition.CenterScreen;
                FRFI.Show();
            }
        }

        //應付帳款明細表
        private void TSMI_AccountsPayableReport_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmReportForAccountsPayable"))
            {
                FrmReportForAccountsPayable FRFAP = new FrmReportForAccountsPayable();
                FRFAP.MdiParent = this;
                FRFAP.StartPosition = FormStartPosition.CenterScreen;
                FRFAP.Show();
            }
        }
        //應收帳款明細表
        private void TSMI_AccountsReceivableReport_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmReportForAccountsReceivable"))
            {
                FrmReportForAccountsReceivable FRFAR = new FrmReportForAccountsReceivable();
                FRFAR.MdiParent = this;
                FRFAR.StartPosition = FormStartPosition.CenterScreen;
                FRFAR.Show();
            }
        }
        //銷售訂單明細表
        private void TSMI_SaleOrdersReport_Click(object sender, EventArgs e)
        {
            if (IsShowChildForm("FrmReportForSaleOrders"))
            {
                FrmReportForSaleOrders FRFSO = new FrmReportForSaleOrders();
                FRFSO.MdiParent = this;
                FRFSO.StartPosition = FormStartPosition.CenterScreen;
                FRFSO.Show();
            }
        }

 

        

       

        

       


    }
}
