using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//MessageBox.Show
using Microsoft.Win32; //for RegistryKey

///機碼中的所有數值的總計大小不能超過64K
///二進位值 REG_BINARY 原始的二進位資料,可對照ASCII表用byte存放以寫入
///DWORD值　REG_DWORD 以4個位元組長度來表示資料(數值型態)
///字串值 REG_SZ 固定長度的文字串

namespace My
{
    public class MyWinAPI
    {
        static RegistryKey rkCR = Registry.ClassesRoot;
        static RegistryKey rkCC = Registry.CurrentConfig;
        static RegistryKey rkCU = Registry.CurrentUser;
        static RegistryKey rkLM = Registry.LocalMachine;
        static RegistryKey rkUsers = Registry.Users;
        static RegistryKey rk;

        #region "根據[群機碼]類型 建立新的[子機碼] 並設定其值"

        /// <summary>
        /// 根據[群機碼]類型 建立新的[子機碼] 並設定其值
        /// </summary>
        /// <param name="RegistryType">群機碼類型包含：ClassesRoot,CurrentConfig,CurrentUser,LocalMachine,Users</param>
        /// <param name="AppName">機碼名稱</param>
        /// <param name="KeyName">數值名稱</param>
        /// <param name="KeyVal">數值資料</param>
        public static bool CreateSubKeyAndSetValue(string RegistryType, string AppName, string KeyName, object KeyVal)
        {
            //用法
            //CreateSubKeyAndSetValue("CurrentUser", @"eCRAM System\Login", "LoginCount", 2);
            //CreateSubKeyAndSetValue("CurrentUser", @"eCRAM System\Login", "LoginUser", "kevin");
            bool result = false;

            try
            {
                switch (RegistryType)
                {
                    case "ClassesRoot"://定義文件類型以及這些相關聯的屬性
                        rkCR.CreateSubKey(AppName);
                        rkCR.OpenSubKey(AppName, true).SetValue(KeyName, KeyVal);
                        rkCR.Close();
                        result = true;
                        break;
                    case "CurrentConfig"://包含目前電腦軟硬體相關組態設定
                        rkCC.CreateSubKey(AppName);
                        rkCC.OpenSubKey(AppName, true).SetValue(KeyName, KeyVal);
                        rkCC.Close();
                        result = true;
                        break;
                    case "CurrentUser"://包含目前使用者個人偏好相關設定資訊(此部分最常使用)
                        rkCU.CreateSubKey(AppName);
                        rkCU.OpenSubKey(AppName, true).SetValue(KeyName, KeyVal);
                        rkCU.Close();
                        result = true;
                        break;
                    case "LocalMachine"://與電腦相關的設定資訊,包含作業系統與硬體結構資料,用來存放本機電腦組態資料五個子機碼(Hardware,SAM,Security,Software,System)
                        rkLM.CreateSubKey(AppName);
                        rkLM.OpenSubKey(AppName, true).SetValue(KeyName, KeyVal);
                        rkLM.Close();
                        result = true;
                        break;
                    case "Users"://包含所有使用者在電腦上所有自動載入的使用者設定檔
                        rkUsers.CreateSubKey(AppName);
                        rkUsers.OpenSubKey(AppName, true).SetValue(KeyName, KeyVal);
                        rkUsers.Close();
                        result = true;
                        break;
                    default:
                        result = false;
                        break;
                }
                return result;
            }

            catch (Exception ex)
            {
                MessageBox.Show("建立子機碼與設定其值失敗,錯誤訊息為:" + ex.Message, "Registry作業");
                return false;
            }


        }

        #endregion


        #region "獲取子機碼內容值"

        /// <summary>
        /// 獲取子機碼內容值
        /// </summary>
        /// <param name="RegistryType">群機碼類型包含：ClassesRoot,CurrentConfig,CurrentUser,LocalMachine,Users</param>
        /// <param name="AppName">機碼名稱</param>
        /// <param name="KeyName">數值名稱</param>
        /// <returns></returns>
        public static object GetSubKeyValue(string RegistryType, string AppName, string KeyName)
        {

            //用法(string)GetSubKeyValue("CurrentUser", @"eCRAM System\Login", "LoginUser")
            object result;

            string ErrorMessageString = "";

            try
            {
                switch (RegistryType)
                {
                    case "ClassesRoot"://定義文件類型以及這些相關聯的屬性
                        result = rkCR.OpenSubKey(AppName, true).GetValue(KeyName, false); //若機碼內容值不存在則會回傳false
                        rkCR.Close();
                        break;
                    case "CurrentConfig"://包含目前電腦軟硬體相關組態設定
                        result = rkCC.OpenSubKey(AppName, true).GetValue(KeyName, false);
                        rkCC.Close();
                        break;
                    case "CurrentUser"://包含目前使用者個人偏好相關設定資訊(此部分最常使用)
                        result = rkCU.OpenSubKey(AppName, true).GetValue(KeyName, false);
                        rkCU.Close();
                        break;
                    case "LocalMachine"://與電腦相關的設定資訊,包含作業系統與硬體結構資料,用來存放本機電腦組態資料五個子機碼(Hardware,SAM,Security,Software,System)
                        result = rkLM.OpenSubKey(AppName, true).GetValue(KeyName, false);
                        rkLM.Close();
                        break;
                    case "Users"://包含所有使用者在電腦上所有自動載入的使用者設定檔
                        result = rkUsers.OpenSubKey(AppName, true).GetValue(KeyName, false);
                        rkUsers.Close();
                        break;
                    default:
                        result = false;
                        break;
                }
                return result;
            }

            catch (Exception ex)
            {
                //MessageBox.Show("獲取子機碼內容值失敗,錯誤訊息為:" + ex.Message, "Registry作業");
                ErrorMessageString = "獲取子機碼內容值失敗,錯誤訊息為:" + ex.Message;
                return false;
            }

        }

        #endregion


        #region "判斷子機碼是否存在"

        /// <summary>
        /// 判斷子機碼是否存在
        /// </summary>
        /// <param name="RegistryType">群機碼類型包含：ClassesRoot,CurrentConfig,CurrentUser,LocalMachine,Users</param>
        /// <param name="AppName">機碼名稱</param>
        /// <returns>回傳布林值</returns>
        public static bool SubKeyExist(string RegistryType, string AppName)
        {
            //用法
            //SubKeyExist("CurrentUser", @"eCRAM System\Login");

            try
            {
                switch (RegistryType)
                {
                    case "ClassesRoot"://定義文件類型以及這些相關聯的屬性
                        rk = rkCR.OpenSubKey(AppName, true);
                        rkCR.Close();
                        break;
                    case "CurrentConfig"://包含目前電腦軟硬體相關組態設定
                        rk = rkCC.OpenSubKey(AppName, true);
                        rkCC.Close();
                        break;
                    case "CurrentUser"://包含目前使用者個人偏好相關設定資訊(此部分最常使用)
                        rk = rkCU.OpenSubKey(AppName, true);
                        rkCU.Close();
                        break;
                    case "LocalMachine"://與電腦相關的設定資訊,包含作業系統與硬體結構資料,用來存放本機電腦組態資料五個子機碼(Hardware,SAM,Security,Software,System)
                        rk = rkLM.OpenSubKey(AppName, true);
                        rkLM.Close();
                        break;
                    case "Users"://包含所有使用者在電腦上所有自動載入的使用者設定檔
                        rk = rkUsers.OpenSubKey(AppName, true);
                        rkUsers.Close();
                        break;
                    default:
                        break;
                }

                if (rk == null)
                {
                    rk.Close();
                    return false;
                }
                else
                {
                    rk.Close();
                    return true;
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show("判斷子機碼是否存在失敗,錯誤訊息為:" + ex.Message, "Registry作業");
                return false;
            }


        }

        #endregion


        #region "刪除指定子機碼"

        /// <summary>
        /// 刪除指定子機碼
        /// </summary>
        /// <param name="RegistryType">群機碼類型包含：ClassesRoot,CurrentConfig,CurrentUser,LocalMachine,Users</param>
        /// <param name="AppName">機碼名稱</param>
        /// <param name="KeyName">數值名稱</param>
        /// <returns></returns>
        public static object DeleteSpecSubKey(string RegistryType, string AppName, string KeyName)
        {

            //用法bool result = (bool)DeleteSpecSubKey("CurrentUser", "eCRAM System", "Login");
            object result;

            try
            {
                switch (RegistryType)
                {
                    case "ClassesRoot"://定義文件類型以及這些相關聯的屬性
                        RegistryKey rk1 = rkCR.OpenSubKey(AppName, true);
                        rk1.DeleteSubKey(KeyName);
                        rk1.Close();
                        rkCR.Close();
                        result = true;
                        break;
                    case "CurrentConfig"://包含目前電腦軟硬體相關組態設定
                        RegistryKey rk2 = rkCC.OpenSubKey(AppName, true);
                        rk2.DeleteSubKey(KeyName);
                        rk2.Close();
                        rkCC.Close();
                        result = true;
                        break;
                    case "CurrentUser"://包含目前使用者個人偏好相關設定資訊(此部分最常使用)
                        RegistryKey rk3 = rkCU.OpenSubKey(AppName, true);
                        rk3.DeleteSubKey(KeyName);
                        rk3.Close();
                        rkCU.Close();
                        result = true;
                        break;
                    case "LocalMachine"://與電腦相關的設定資訊,包含作業系統與硬體結構資料,用來存放本機電腦組態資料五個子機碼(Hardware,SAM,Security,Software,System)
                        RegistryKey rk4 = rkLM.OpenSubKey(AppName, true);
                        rk4.DeleteSubKey(KeyName);
                        rk4.Close();
                        rkLM.Close();
                        result = true;
                        break;
                    case "Users"://包含所有使用者在電腦上所有自動載入的使用者設定檔
                        RegistryKey rk5 = rkUsers.OpenSubKey(AppName, true);
                        rk5.DeleteSubKey(KeyName);
                        rk5.Close();
                        rkUsers.Close();
                        result = true;
                        break;
                    default:
                        result = false;
                        break;
                }
                return result;
            }

            catch (Exception ex)
            {
                MessageBox.Show("刪除子機碼內容值失敗,錯誤訊息為:" + ex.Message, "Registry作業");
                return false;
            }

        }

        #endregion


        #region "刪除所有子機碼"
        /// <summary>
        /// 刪除所有子機碼
        /// </summary>
        /// <param name="RegistryType">群機碼類型包含：ClassesRoot,CurrentConfig,CurrentUser,LocalMachine,Users</param>
        /// <param name="AppName">機碼名稱</param>
        /// <returns></returns>
        public static object DeleteALLSubKey(string RegistryType, string AppName)
        {

            //用法bool result = (bool) DeleteALLSubKey("CurrentUser", @"eCRAM System\Login", "LoginUser");
            object result;

            try
            {
                switch (RegistryType)
                {
                    case "ClassesRoot"://定義文件類型以及這些相關聯的屬性
                        rkCR.DeleteSubKeyTree(AppName);
                        rkCR.Close();
                        result = true;
                        break;
                    case "CurrentConfig"://包含目前電腦軟硬體相關組態設定
                        rkCC.DeleteSubKeyTree(AppName);
                        rkCC.Close();
                        result = true;
                        break;
                    case "CurrentUser"://包含目前使用者個人偏好相關設定資訊(此部分最常使用)
                        rkCU.DeleteSubKeyTree(AppName);
                        rkCU.Close();
                        result = true;
                        break;
                    case "LocalMachine"://與電腦相關的設定資訊,包含作業系統與硬體結構資料,用來存放本機電腦組態資料五個子機碼(Hardware,SAM,Security,Software,System)
                        rkLM.DeleteSubKeyTree(AppName);
                        rkLM.Close();
                        result = true;
                        break;
                    case "Users"://包含所有使用者在電腦上所有自動載入的使用者設定檔
                        rkUsers.DeleteSubKeyTree(AppName);
                        rkUsers.Close();
                        result = true;
                        break;
                    default:
                        result = false;
                        break;
                }
                return result;
            }

            catch (Exception ex)
            {
                MessageBox.Show("刪除子機碼的任何子機碼失敗,錯誤訊息為:" + ex.Message, "Registry作業");
                return false;
            }

        }

        #endregion


        #region "刪除子機碼的數值名稱內容值"

        /// <summary>
        /// 刪除子機碼的數值名稱內容值
        /// </summary>
        /// <param name="RegistryType">群機碼類型包含：ClassesRoot,CurrentConfig,CurrentUser,LocalMachine,Users</param>
        /// <param name="AppName">機碼名稱</param>
        /// <param name="ValueName">數值名稱</param>
        /// <returns></returns>
        public static bool DeleteSubKeyValue(string RegistryType, string AppName, string ValueName)
        {

            bool result = false;
            //用法bool result = (bool)DeleteSubKeyValue("CurrentUser", @"eCRAM System\Login", "LoginUser");
            try
            {
                switch (RegistryType)
                {
                    case "ClassesRoot"://定義文件類型以及這些相關聯的屬性
                        RegistryKey rk1 = rkCR.OpenSubKey(AppName, true);
                        rk1.DeleteValue(ValueName);
                        rk1.Close();
                        rkCR.Close();
                        result = true;
                        break;
                    case "CurrentConfig"://包含目前電腦軟硬體相關組態設定
                        RegistryKey rk2 = rkCC.OpenSubKey(AppName, true);
                        rk2.DeleteValue(ValueName);
                        rk2.Close();
                        rkCC.Close();
                        result = true;
                        break;
                    case "CurrentUser"://包含目前使用者個人偏好相關設定資訊(此部分最常使用)
                        RegistryKey rk3 = rkCU.OpenSubKey(AppName, true);
                        rk3.DeleteValue(ValueName);
                        rk3.Close();
                        rkCU.Close();
                        result = true;
                        break;
                    case "LocalMachine"://與電腦相關的設定資訊,包含作業系統與硬體結構資料,用來存放本機電腦組態資料五個子機碼(Hardware,SAM,Security,Software,System)
                        RegistryKey rk4 = rkLM.OpenSubKey(AppName, true);
                        rk4.DeleteValue(ValueName);
                        rk4.Close();
                        rkLM.Close();
                        result = true;
                        break;
                    case "Users"://包含所有使用者在電腦上所有自動載入的使用者設定檔
                        RegistryKey rk5 = rkUsers.OpenSubKey(AppName, true);
                        rk5.DeleteValue(ValueName);
                        rk5.Close();
                        rkUsers.Close();
                        result = true;
                        break;
                    default:
                        result = false;
                        break;
                }
                return result;
            }

            catch (Exception ex)
            {
                MessageBox.Show("刪除數值名稱內容值失敗,錯誤訊息為:" + ex.Message, "Registry作業");
                return false;
            }
        }

        #endregion



        #region "獲取作業系統版本資訊"

        /// <summary>
        /// 獲取作業系統版本資訊
        /// </summary>
        /// <param name="KeyName">數值名稱
        /// 包含:ProductName , 如: Microsoft Windows XP
        ///      CSDVersion , 如: Service Pack 2
        ///      CurrentBuild , 如: 1.511.1 () (Obsolete data - do not use)
        ///      CurrentVersion , 如: 5.1
        ///      RegisteredOrganization , 如:mis
        ///      RegisteredOwner , 如:kevin
        /// </param>
        /// <returns></returns>
        public static string GetWindowsXPProfessionalInfo(string KeyName)
        {
            string result = "";

            result = (string)GetSubKeyValue("LocalMachine", @"Software\Microsoft\Windows NT\CurrentVersion", KeyName);
            return result;

        }

        #endregion


        #region "獲取指定機碼下的所有子機碼名稱"

        /// <summary>
        /// 獲取指定機碼下的所有子機碼名稱
        /// </summary>
        /// <param name="RegistryType">群機碼類型包含：ClassesRoot,CurrentConfig,CurrentUser,LocalMachine,Users</param>
        /// <param name="AppName">指定機碼名稱</param>
        /// <returns></returns>
        public static string[] GetAllSubKeyNames(string RegistryType, string AppName)
        {

            //用法string[] test = GetAllSubKeyNames("CurrentUser", "eCRAM System");
            string[] result = new string[1000];
            try
            {
                switch (RegistryType)
                {
                    case "ClassesRoot"://定義文件類型以及這些相關聯的屬性
                        RegistryKey rk1 = rkCR.OpenSubKey(AppName, true);
                        result = rk1.GetSubKeyNames();
                        rk1.Close();
                        rkCR.Close();
                        break;
                    case "CurrentConfig"://包含目前電腦軟硬體相關組態設定
                        RegistryKey rk2 = rkCC.OpenSubKey(AppName, true);
                        result = rk2.GetSubKeyNames();
                        rk2.Close();
                        rkCC.Close();
                        break;
                    case "CurrentUser"://包含目前使用者個人偏好相關設定資訊(此部分最常使用)
                        RegistryKey rk3 = rkCU.OpenSubKey(AppName, true);
                        result = rk3.GetSubKeyNames();
                        rk3.Close();
                        rkCU.Close();
                        break;
                    case "LocalMachine"://與電腦相關的設定資訊,包含作業系統與硬體結構資料,用來存放本機電腦組態資料五個子機碼(Hardware,SAM,Security,Software,System)
                        RegistryKey rk4 = rkLM.OpenSubKey(AppName, true);
                        result = rk4.GetSubKeyNames();
                        rk4.Close();
                        rkLM.Close();
                        break;
                    case "Users"://包含所有使用者在電腦上所有自動載入的使用者設定檔
                        RegistryKey rk5 = rkUsers.OpenSubKey(AppName, true);
                        result = rk5.GetSubKeyNames();
                        rk5.Close();
                        rkUsers.Close();
                        break;
                    default:
                        break;
                }
                return result;
            }

            catch (Exception ex)
            {
                MessageBox.Show("獲取指定機碼下的所有子機碼名稱失敗,錯誤訊息為:" + ex.Message, "Registry作業");
                return result;
            }
        }

        #endregion


        #region "獲取所有子機碼下的數值名稱"

        /// <summary>
        /// 獲取所有子機碼下的數值名稱
        /// </summary>
        /// <param name="RegistryType">群機碼類型包含：ClassesRoot,CurrentConfig,CurrentUser,LocalMachine,Users</param>
        /// <param name="AppName">機碼名稱</param>
        /// <returns></returns>
        public static string[] GetAllValueNames(string RegistryType, string AppName)
        {

            //用法string[] test = GetAllValueNames("CurrentUser", @"eCRAM System\Login");
            string[] result = new string[1000];
            try
            {
                switch (RegistryType)
                {
                    case "ClassesRoot"://定義文件類型以及這些相關聯的屬性
                        RegistryKey rk1 = rkCR.OpenSubKey(AppName, true);
                        result = rk1.GetValueNames();
                        rk1.Close();
                        rkCR.Close();
                        break;
                    case "CurrentConfig"://包含目前電腦軟硬體相關組態設定
                        RegistryKey rk2 = rkCC.OpenSubKey(AppName, true);
                        result = rk2.GetValueNames();
                        rk2.Close();
                        rkCC.Close();
                        break;
                    case "CurrentUser"://包含目前使用者個人偏好相關設定資訊(此部分最常使用)
                        RegistryKey rk3 = rkCU.OpenSubKey(AppName, true);
                        result = rk3.GetValueNames();
                        rk3.Close();
                        rkCU.Close();
                        break;
                    case "LocalMachine"://與電腦相關的設定資訊,包含作業系統與硬體結構資料,用來存放本機電腦組態資料五個子機碼(Hardware,SAM,Security,Software,System)
                        RegistryKey rk4 = rkLM.OpenSubKey(AppName, true);
                        result = rk4.GetValueNames();
                        rk4.Close();
                        rkLM.Close();
                        break;
                    case "Users"://包含所有使用者在電腦上所有自動載入的使用者設定檔
                        RegistryKey rk5 = rkUsers.OpenSubKey(AppName, true);
                        result = rk5.GetValueNames();
                        rk5.Close();
                        rkUsers.Close();
                        break;
                    default:
                        break;
                }
                return result;
            }

            catch (Exception ex)
            {
                MessageBox.Show("獲取所有子機碼下的數值名稱失敗,錯誤訊息為:" + ex.Message, "Registry作業");
                return result;
            }

        }

        #endregion


    }
}
