using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;//新增命名空間
using System.Net; //for IPHostEntry
using System.Net.NetworkInformation; // for IPGlobalProperties
using Microsoft.Win32; //for RegistryKey
using System.Management;//for ManagementClass

namespace My
{
    public class MySNAuthority
    {
        /// <summary>
        /// 產生註冊序號
        /// </summary>
        /// <param name="UserName">傳入使用者名稱</param>
        /// <returns>回傳字串序號</returns>
        public string GenerateKey(string UserName, string EnvironmentCode)
        {
            string CodeA, CodeB, CodeC, CodeD, CodeE;

            if (UserName.Length < 3)
            {
                return "序號產生失敗,使用者名稱長度不可小於3";
            }
            else
            {
                CodeA = "IN" + AutoGenerateWord(3);
                CodeB = QryOSCode(EnvironmentCode.Substring(0, 5));//GetOSCode(My.Computer.Info.OSFullName, false);
                CodeC = UserNameCode(UserName);
                //string[] networkcard = GetAdapter();
                CodeD = QryNICCode(EnvironmentCode.Substring(5, 5)); //GetNICCode(networkcard[0], false);
                CodeE = CheckCode(CodeA, CodeB, CodeC, CodeD);

                return CodeA + "-" + CodeB + "-" + CodeC + "-" + CodeD + "-" + CodeE;
            }

        }

        public string GenEnvironmentCode()
        {
            string[] networkcard = GetAdapter();
            string result = GetOSCode(My.Computer.Info.OSFullName, true) + GetNICCode(networkcard[0], true);
            return result;
        }

        /// <summary>
        /// 獲取網路卡裝置名稱
        /// </summary>
        /// <returns></returns>
        public string[] GetAdapter()
        {
            string[] adapters = new string[20];
            //得到 MAC的註冊表鍵
            RegistryKey macRegistry = Registry.LocalMachine.OpenSubKey("SYSTEM").OpenSubKey("CurrentControlSet").OpenSubKey("Control")
                .OpenSubKey("Class").OpenSubKey("{4D36E972-E325-11CE-BFC1-08002bE10318}");

            IList<string> list = macRegistry.GetSubKeyNames().ToList();

            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            int n = 0;
            for (int i = 0; i < nics.Length; i++)
            {
                if (nics[i].Name.IndexOf("區域連線") != -1 || nics[i].Name.IndexOf("無線網路連線") != -1 || nics[i].Name.IndexOf("乙太網路") != -1)
                {
                    adapters[n] = nics[i].Description;
                    n = n + 1;
                }
            }
            if (n==0)
            {
                return null;
            }
            else
            {
                Array.Resize(ref adapters, n);
                return adapters;
            }

            //var adapter = nics.First(o => o.Name == txtLanInterface.Text); //"區域連線"
            //if (adapter == null)
            //    return null;
            //return adapter.Description;
        }


        /// <summary>
        /// 產生n個字元(0~9或a~z或A~Z)
        /// </summary>
        /// <param name="WordLen">字串長度</param>
        /// <returns></returns>
        public string AutoGenerateWord(int WordLen)
        {
            int RanValue = 0;
            string bufstr = "";

            Random rnd = new Random(DateTime.Now.Millisecond);


            for (int i = 0; i < WordLen; i++)
            {
                while (bufstr.Length != WordLen)
                {
                    RanValue = (int)rnd.Next(48, 122);
                    if ((RanValue >= 48 && RanValue <= 57) || (RanValue >= 65 && RanValue <= 90) || (RanValue >= 97 && RanValue <= 122))
                    {
                        bufstr = bufstr + Strings.Chr(RanValue);

                    }

                }

            }
            return bufstr;

        }

        /// <summary>
        /// 獲取作業系統代碼
        /// </summary>
        /// <param name="OperatingSystem">傳入作業系統名稱</param>
        /// <param name="IsEnviornmentCode">傳入布林值為true表示為環境編碼，若為false表示為註冊碼</param>
        /// <returns></returns>
        public string GetOSCode(string OperatingSystem, bool IsEnviornmentCode)
        {
            string result = "";

            if (OperatingSystem.IndexOf("Windows 8.1") != -1)
            {
                result = (IsEnviornmentCode) ? "99981" : "NEWED";
            }
            else if (OperatingSystem.IndexOf("Windows 8") != -1)
            {
                result = (IsEnviornmentCode) ? "66680" : "B8EDX";
            }
            else if (OperatingSystem.IndexOf("Windows 7") != -1)
            {
                result = (IsEnviornmentCode) ? "73842" : "AZEDY";
            }
            else if (OperatingSystem.IndexOf("Vista") != -1)
            {
                result = (IsEnviornmentCode) ? "75387" : "BCHGF";
            }
            else if (OperatingSystem.IndexOf("XP") != -1)
            {
                result = (IsEnviornmentCode) ? "54978" : "B39D3";
            }
            else if (OperatingSystem.IndexOf("2003") != -1)
            {
                result = (IsEnviornmentCode) ? "98722" : "GFCW4";
            }
            else if (OperatingSystem.IndexOf("2000") != -1)
            {
                result = (IsEnviornmentCode) ? "32144" : "CCW67";
            }
            else
            {
                result = (IsEnviornmentCode) ? "12984" : "DAPZE";
            }


            return result;

        }

        public string QryOSCode(string osEnvorinmentCode)
        {
            string result = "";
            switch (osEnvorinmentCode)
            {
                case "99981":
                    result = "NEWED";
                    break;
                case "66680":
                    result = "B8EDX";
                    break;
                case "73842":
                    result = "AZEDY";
                    break;
                case "75387":
                    result = "BCHGF";
                    break;
                case "54978":
                    result = "B39D3";
                    break;
                case "98722":
                    result = "GFCW4";
                    break;
                case "32144":
                    result = "CCW67";
                    break;
                case "12984":
                    result = "DAPZE";
                    break;
            }

            return result;
        }

        public string QryOSName(string osEnvorinmentCode)
        {
            string result = "";
            switch (osEnvorinmentCode)
            {
                case "99981":
                    result = "Windows 8.1";
                    break;
                case "66680":
                    result = "Windows 8";
                    break;
                case "73842":
                    result = "Windows 7";
                    break;
                case "75387":
                    result = "Windows Vista";
                    break;
                case "54978":
                    result = "Windows XP";
                    break;
                case "98722":
                    result = "Windows 2003";
                    break;
                case "32144":
                    result = "Windows 2000";
                    break;
                case "12984":
                    result = "Other OS";
                    break;
                default:
                    result = "Error";
                    break;
            }

            return result;
        }


        public string GetNICCode(string NIC, bool IsEnviornmentCode)
        {
            string result = "";

            if (NIC.IndexOf("D-Link") != -1)
            {
                result = (IsEnviornmentCode) ? "21148" : "N1EDY";
            }
            else if (NIC.IndexOf("Intel") != -1)
            {
                result = (IsEnviornmentCode) ? "57028" : "LTNIE";
            }
            else if (NIC.IndexOf("3Com") != -1)
            {
                result = (IsEnviornmentCode) ? "39002" : "N2HGF";
            }
            else if (NIC.IndexOf("Realtek") != -1)
            {
                result = (IsEnviornmentCode) ? "25366" : "N39D3";
            }
            else if (NIC.IndexOf("Broadcom") != -1)
            {
                result = (IsEnviornmentCode) ? "87115" : "N4CW4";
            }
            else if (NIC.IndexOf("ASUS") != -1)
            {
                result = (IsEnviornmentCode) ? "10023" : "N5W67";
            }
            else if (NIC.IndexOf("Corega") != -1)
            {
                result = (IsEnviornmentCode) ? "57736" : "N6F68";
            }
            else if (NIC.IndexOf("Atheros") != -1)
            {
                result = (IsEnviornmentCode) ? "09302" : "N7E69";
            }
            else
            {
                result = (IsEnviornmentCode) ? "66431" : "N1EZE";
            }


            return result;

        }


        public string QryNICCode(string nicEnvorinmentCode)
        {
            string result = "";
            switch (nicEnvorinmentCode)
            {
                case "21148":
                    result = "N1EDY";
                    break;
                case "57028":
                    result = "LTNIE";
                    break;
                case "39002":
                    result = "N2HGF";
                    break;
                case "25366":
                    result = "N39D3";
                    break;
                case "87115":
                    result = "N4CW4";
                    break;
                case "10023":
                    result = "N5W67";
                    break;
                case "57736":
                    result = "N6F68";
                    break;
                case "09302":
                    result = "N7E69";
                    break;
                case "66431":
                    result = "N1EZE";
                    break;
            }

            return result;
        }

        public string QryNICName(string nicEnvorinmentCode)
        {
            string result = "";
            switch (nicEnvorinmentCode)
            {
                case "21148":
                    result = "D-Link";
                    break;
                case "57028":
                    result = "Intel";
                    break;
                case "39002":
                    result = "3Com";
                    break;
                case "25366":
                    result = "Realtek";
                    break;
                case "87115":
                    result = "Broadcom";
                    break;
                case "10023":
                    result = "ASUS";
                    break;
                case "57736":
                    result = "Corega";
                    break;
                case "09302":
                    result = "Atheros";
                    break;
                case "66431":
                    result = "Other NIC";
                    break;
                default:
                    result = "Error";
                    break;
            }

            return result;
        }



        #region "檢查ＳＮ序號"

        /// <summary>
        /// 檢查ＳＮ序號
        /// </summary>
        /// <param name="RegUserName">註冊的使用者名稱</param>
        /// <param name="SerialNumber">序號</param>
        /// <returns></returns>
        public bool checkSN(string RegUserName, string SerialNumber)
        {

            string[] bufcode = SerialNumber.Split('-');

            if (bufcode.Length != 5)
            {
                return false;
            }


            //step 1
            if (bufcode[0].Substring(0, 2) != "IN")
            {
                return false;
            }



            //step 2
            Microsoft.VisualBasic.Devices.ComputerInfo ComputerInfo = new Microsoft.VisualBasic.Devices.ComputerInfo();
            string OS = GetOSCode(ComputerInfo.OSFullName.ToString(), false);
            if (OS != bufcode[1])
            {
                return false;
            }


            //step 3

            if (UserNameCode(RegUserName) != bufcode[2])
            {
                return false;
            }

            //step 4
            string NIC;
            string[] networkcard = GetAdapter();
            if (networkcard  !=  null)
            {
                 NIC = GetNICCode(networkcard[0], false);
            }
            else
            {
                NIC = GetNICCode("Other NIC", false); ;
            }

            if (NIC != bufcode[3])
            {
                return false;
            }

            //step 5
            if (CheckCode(bufcode[0], bufcode[1], bufcode[2], bufcode[3]) != bufcode[4])
            {
                return false;
            }

            return true; //若全部都符合則傳回True

        }

        #endregion

        #region "檢查環境代碼ＳＮ序號"

        /// <summary>
        /// 檢查環境代碼ＳＮ序號
        /// </summary>
        /// <param name="RegUserName">註冊的使用者名稱</param>
        /// <param name="SerialNumber">序號</param>
        /// <param name="EnvironmentCode">環境代碼</param>
        /// <returns></returns>
        public bool checkSN(string RegUserName, string SerialNumber, string EnvironmentCode)
        {

            string[] bufcode = SerialNumber.Split('-');

            if (bufcode.Length != 5)
            {
                return false;
            }


            //step 1
            if (bufcode[0].Substring(0, 2) != "UH")
            {
                return false;
            }

            //step 2
            string OS = QryOSCode(EnvironmentCode.Substring(0, 5));
            if (OS != bufcode[1])
            {
                return false;
            }


            //step 3

            if (UserNameCode(RegUserName) != bufcode[2])
            {
                return false;
            }

            //step 4
            string NIC = QryNICCode(EnvironmentCode.Substring(5, 5));

            if (NIC != bufcode[3])
            {
                return false;
            }

            //step 5
            if (CheckCode(bufcode[0], bufcode[1], bufcode[2], bufcode[3]) != bufcode[4])
            {
                return false;
            }

            return true; //若全部都符合則傳回True

        }

        #endregion



        #region "將傳入的使用者名稱進行編碼動作"

        /// <summary>
        /// 將傳入的使用者名稱進行編碼動作
        /// 使用者名稱UserName至少長度為5,最多為15
        /// </summary>
        /// <param name="UserName">使用者名稱</param>
        /// <returns></returns>
        public string UserNameCode(string UserName)
        {
            int[] bufarr = new int[15];
            int[] encode = new int[5];
            string NewCode = "";
            string NewUserName = UserName.ToUpper();


            for (int i = 0; i < UserName.Length; i++)
            {
                bufarr[i] = Strings.Asc(NewUserName.Substring(i, 1));

                encode[i % 5] = encode[i % 5] + bufarr[i];
                //MessageBox.Show(bufarr[i].ToString());
            }

            if (UserName.Length == 3)
            {
                encode[3] = encode[0] + encode[1];
                encode[4] = encode[2] + encode[3];
            }

            if (UserName.Length == 4)
            {
                encode[4] = encode[0] + encode[1] + encode[2] + encode[3];
            }


            for (int j = 0; j < 5; j++)
            {


                switch (j)
                {
                    case 0:
                        encode[j] = encode[j] + 1;
                        break;
                    case 1:
                        encode[j] = encode[j] + 3;
                        break;
                    case 2:
                        encode[j] = encode[j] + 5;
                        break;
                    case 3:
                        encode[j] = encode[j] + 2;
                        break;
                    case 4:
                        encode[j] = encode[j] + 4;
                        break;
                    default:
                        break;
                }

                //轉換成大寫字母範圍

                encode[j] = (encode[j] % 26) + 65;

                NewCode = NewCode + Strings.Chr(encode[j]);

            }

            return NewCode;

        }

        #endregion


        #region "檢查碼驗證"

        /// <summary>
        /// 檢查碼驗證
        /// </summary>
        /// <param name="PID">產品編號</param>
        /// <param name="OS">作業系統編號</param>
        /// <param name="UNC">使用者名稱編號</param>
        /// <param name="NIC">網路卡編號</param>
        /// <returns></returns>
        public string CheckCode(string PID, string OS, string UNC, string NIC)
        {
            int i = 0;

            int[] chkcode = new int[5];

            string bufstring = "";

            for (i = 0; i < 5; i++)
            {
                //將PID第n個字元與OS第n個字元與UNC第n個字元的ASCII碼相加
                chkcode[i] = Strings.Asc(PID.Substring(i, 1)) +
                             Strings.Asc(OS.Substring(i, 1)) +
                             Strings.Asc(UNC.Substring(i, 1)) +
                             Strings.Asc(NIC.Substring(i, 1));

                //轉換成大寫字母範圍
                chkcode[i] = (chkcode[i] % 26) + 65;

                bufstring = bufstring + Strings.Chr(chkcode[i]);
            }
            return bufstring;

        }

        #endregion

    }
}
