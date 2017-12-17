using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //新增命名空間 for SQL Server
using System.IO;
using System.Windows.Forms;
using System.Configuration;//

namespace My
{
    public class MyGlobal
    {

        public static string GlobalUserID;      //記錄登入使用者帳號
        public static string GlobalPassword;    //記錄登入使用者密碼
        public static string GlobalHashPassword;//記錄登入使用者加密過後的密碼
        public static string GlobalRoleName;    //記錄登入使用者角色名稱

        public static int GlobalLoginErrorCounter; //記錄登入錯誤次數
        public static bool GlobalSystemShutdown = false;  //此變數主要用來判斷是試用版時間到要關閉系統　還是　正常使用下關閉系統
        public static string GlobalSysRegDefaultPath = @"Software\SIS\V1.0\"; //登錄檔軟體註冊路徑

        //public static string DefaultMultiLanguage = "zh-tw";

        #region ***SQL Server 2012 ***

        //***SQL Server 2012 ***
        public const string DbType = "SQL Server 2012";        //預設使用資料庫
        public const string DbName = "SIS";                    //使用資料庫名稱
        public const string SQLUserID = "sa";                  //SQL Server使用者ID
        public const string SQLUserPwd = "12345";                //SQL Server使用者密碼
        public const string DBServer = "RyuPC";                //資料庫伺服器名稱 也是 電腦名稱
        public const string WorkStationID = "RyuPC";           //電腦名稱
        public const string ServerIP = "127.0.0.1";            //本機所設定的IP
        public const string ServerDNS = "localhost";           //領域伺服器名稱
        public const string DataSource = ".\\SQLEXPRESS";


        private static string ConnString;
        public static string SQLConnectionString
        {
            get
            {
                //使用應用程式組態檔連線方式,需加入參考[System.configuration.dll]
                ConnectionStringSettings settings;
                settings = ConfigurationManager.ConnectionStrings["SQLConnectionString"];

                //若要直接讀取檔案則使用以下語法
                //settings = ConfigurationManager.ConnectionStrings["SQLConnectionString2"];
                //ConnString = settings.ConnectionString;
                //ConnString = ConnString.Replace("|DataDirectory|", System.Windows.Forms.Application.StartupPath);

                ConnString = settings.ConnectionString;
                return ConnString;
            }
        }

        #endregion



        #region ***系統開發環境設定

        //***系統開發環境設定
        public int MininumPasswordLength = 3;             //最小密碼長度
        public int MaxUserNameLength = 20;                //最大使用者名稱長度

        public const string GlobalSystemName = "SIS";
        public const string GlobalSystemTitle = "超級進銷存系統 Super Invoicing System";
        public const string GlobalSystemVersion = "V1.0";
        public const string GlobalUseLocale = "zh-tw";//預設語系      
        public const string GlobalDefaultLanguage = "C Sharp .NET 5.0"; //記錄系統使用何種程式語言開發



        #endregion


        #region ***系統開發環境設定
        public static string INISystemName;
        public static string INISystemVersion;
        public static string INISystemLocale;
        public static string INISystemCreator;

        public static string INICompanyName;
        public static string INICompanyAddress;
        public static string INICompanyTelephone;

        public static string INIDateFormatYearSet;
        public static string INIDateFormatDateSet;

        public static string INIDatabaseComputeOrIP;
        public static string INIDatabaseID;
        public static string INIDatabasePassword;

        public static string INIBusinessTaxStockTaxRate;
        public static string INIBusinessTaxShipTaxRate;

        public static string INIPointSettingItemPoint;
        public static string INIPointSettingReceiptPoint;

        #endregion



        #region 資料庫連線設定

        /// <summary>
        /// 資料庫連線設定
        /// </summary>
        /// <param name="AppPath">應用程式的資料庫所在位置</param>
        /// <param name="DBType">資料庫類型：可分為Access或SQLServer</param>
        /// <returns>回傳連線字串值</returns>
        public string DBConnectionString(string AppPath, string DBType)
        {
            if (DBType == "SQL Server 2012")
            {
                //Builder["data Source"] = "192.168.12.185";
                //Builder["initial catalog"] = "company";
                //Builder["user id"] = "sa";
                //Builder["Password"] = "123";
                return "";
            }
            else //SQL Server 2012 Express
            {
                SqlConnectionStringBuilder Builder = new SqlConnectionStringBuilder();

                //Builder["data Source"] = "192.168.12.185";
                //Builder["initial catalog"] = "company";
                //Builder["user id"] = "sa";
                //Builder["Password"] = "123";
                Builder.DataSource = "192.168.0.1";
                Builder.InitialCatalog = "IPQC";
                Builder.UserID = "sa";
                Builder.Password = "123";
                return Builder.ConnectionString;


            }

        }

        #endregion


        #region 水晶報表資料庫連線設定

        /// <summary>
        /// 水晶報表資料庫連線設定
        /// </summary>
        /// <param name="AppPath">應用程式的資料庫所在位置</param>
        /// <param name="DBType">資料庫類型：可分為Access或SQLServer</param>
        /// <returns>回傳連線字串值</returns>
        public string CRDBConnString(string AppPath, string DBType)
        {
            if (DBType == "SQL Server 2012")
            {
                //Builder["data Source"] = "192.168.12.185";
                //Builder["initial catalog"] = "company";
                //Builder["user id"] = "sa";
                //Builder["Password"] = "123";
                return "";
            }
            else //SQL Server 2012 Express
            {
                SqlConnectionStringBuilder Builder = new SqlConnectionStringBuilder();

                Builder.DataSource = "192.168.0.1";
                Builder.InitialCatalog = "IPQC";
                Builder.UserID = "sa";
                Builder.Password = "123";
                return Builder.ConnectionString;


            }

        }

        #endregion




    }
}
