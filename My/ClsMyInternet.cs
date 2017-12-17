using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; //for IPHostEntry
using System.Runtime.InteropServices; //for DllImport
using Microsoft.Win32; // for Registry

namespace My
{
    public class MyInternet
    {
        /// <summary>
        /// 檢查是否為URL網址格式
        /// </summary>
        /// <param name="url">傳入網址字串訊息</param>
        /// <returns>若是URL則回傳true,否則回傳false</returns>
        public static bool IsURL(string url)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
            return result;
        }

        /// <summary>
        /// 判斷URL是否存在-Internet須為連線狀態
        /// </summary>
        /// <param name="URL">傳入URL字串網址</param>
        /// <returns>若網址存在則回傳true,否則會傳false</returns>
        public static bool UrlExist(string URL)
        {
            bool Result = true;
            Uri urlCheck = new Uri(URL);
            WebRequest request = WebRequest.Create(urlCheck);
            request.Timeout = 15000;

            WebResponse response;
            try
            {
                response = request.GetResponse();
            }
            catch (Exception)
            {
                return false; //url does not exist
            }

            return Result;

        }

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(ref uint lpdwFlags, uint dwReserved);
        //連線的Flag
        //      lpdwFlags：Long 本機電腦的連線旗標

        //值 說明 
        //INTERNET_CONNECTION_CONFIGURED：0x40 本機電腦有一個合法的連線，但目前可能尚未連線 
        //INTERNET_CONNECTION_LAN：0x02 本機電腦是透過區域網路方式連至網際網路 
        //INTERNET_CONNECTION_MODEM：0x01 本機電腦是使用數據機方式連至網際網路 
        //INTERNET_CONNECTION_MODEM_BUSY：0x08 數據機忙線中無法使用 
        //INTERNET_CONNECTION_OFFLINE：0x20 本機電腦目前處於離線狀態 
        //INTERNET_CONNECTION_PROXY：0x04 本機電腦透過代理伺服器方式連至網際網路 
        static uint  flags = 0x0;
        static bool rtvl;

        /// <summary>
        /// 是否能連接上Internet
        /// </summary>
        /// <returns></returns>
        public static bool IsConnectedToInternet()
        {
            //取得本機電腦目前的連線狀態
            rtvl = InternetGetConnectedState(ref flags, 0);
            return rtvl;
        }

        public static string getFileData(string URL)
        {
            if (IsConnectedToInternet())
            {
                try
                {
                    //建立WebClient類別的執行個體
                    WebClient myWebClient = new WebClient();
                    byte[] myDatabuffer;
                    string InternetSettingString = "";
                    //UpHitsRate.Setting要用Unicode方式儲存
                    myDatabuffer = myWebClient.DownloadData(URL);
                    InternetSettingString = Encoding.Unicode.GetString(myDatabuffer);
                    return InternetSettingString;
                }
                catch (Exception ex)
                {
                    string error = ex.Message.Replace(URL, "*");
                    bool result = My.MyFileIO.WriteEventLog("錯誤", " LoadInternetSetting()", "執行載入Internet設定值時發生錯誤!!=>" + error);
                    return null; // read file error
                }
            }
            else
            {
                return null;// "Connect Internet error";
            }
        }

    }
}
