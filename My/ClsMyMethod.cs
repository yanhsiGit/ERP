using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;//
using System.Security.Cryptography;//使用雜湊加密所需引用的命名空間
using System.Drawing; //Need add System.Drawing.dll to reference

namespace My
{
    public class MyMethod
    {

        #region 產生流水編號

        /// <summary>
        /// 產生流水編號
        /// 例如:095 12 20 12 53 20
        /// </summary>
        /// <param name="HeadStr">流水號開頭字串</param>
        /// <returns></returns>
        public static string RunID(string HeadStr)
        {
            string IDStr;
            string NowStr;
            string YearStr;
            string MonthStr;
            string DayStr;
            string HourStr;
            string MinuteStr;
            string SecondStr;

            NowStr = DateTime.Now.ToString();
            YearStr = string.Format("{0:D3}", (int)DateTime.Now.Year - 1911); //D3表是不足三位數前面會補0
            MonthStr = string.Format("{0:D2}", (int)DateTime.Now.Month);
            DayStr = string.Format("{0:D2}", (int)DateTime.Now.Day);
            HourStr = string.Format("{0:D2}", (int)DateTime.Now.Hour);
            MinuteStr = string.Format("{0:D2}", (int)DateTime.Now.Minute);
            SecondStr = string.Format("{0:D2}", (int)DateTime.Now.Second); ;
            IDStr = HeadStr + YearStr + MonthStr + DayStr + HourStr + MinuteStr + SecondStr;
            return IDStr;
        }

        #endregion


        #region 產生認證碼

        /// <summary>
        /// 產生認證碼
        /// </summary>
        /// <param name="WordLen">決定產生亂數碼長度</param>
        /// <returns></returns>
        public static string GenerateAuthWord(int WordLen) //產生WordLen長度的一組亂數碼
        {
            int RanValue;
            string bufstr = "";
            Random rnd = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < WordLen; i++)
            {
                RanValue = (int)rnd.Next(0, 9);
                bufstr = bufstr + RanValue.ToString();
            }
            return bufstr;
        }

        #endregion


        #region 將秒數轉換成天數

        /// <summary>
        /// 將秒數轉換成天數
        /// </summary>
        /// <param name="second">秒數</param>
        /// <returns>字串值 D天H小時M分S秒</returns>
        public static string SecToDay(Int32 second)
        {
            int D, H, M, S;
            string bufstr;
            D = (int)(second / (60 * 60 * 24));
            H = (second / 3600) % 24;
            M = (int)((second % 3600) / 60);
            S = second % 60;
            bufstr = D + "天" + H + "小時" + M + "分" + S + "秒";
            return bufstr;
        }

        #endregion


        #region 單引號轉換成雙引號

        /// <summary>
        /// 單引號轉換成雙引號
        /// </summary>
        /// <param name="Inputstr">輸入可能包含單引號字串</param>
        /// <returns></returns>
        public static string quotates(string Inputstr)
        {
            string correctString = Inputstr.Replace("'", "''");
            return correctString;
        }

        #endregion


        #region 計算時間差

        /// <summary>
        /// 計算時間差
        /// 用法DateTimeDiff("2006年4月1日 18:00:00")
        /// </summary>
        /// <param name="EndDate">設定終止時間</param>
        /// <returns></returns>
        public static int DateTimeDiff(string EndDate)
        {

            DateTime dt = Convert.ToDateTime(EndDate);
            int v1;


            DateTime DT1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            DateTime DT2 = dt;// new DateTime(2005, 10, 6, 18, 0, 0);
            TimeSpan TS1 = DT2.Subtract(DT1);

            v1 = (int)TS1.TotalSeconds;
            return v1;

        }

        #endregion



        #region 將內容寫入到指定的檔案

        /// <summary>
        /// 將內容寫入到指定的檔案
        /// </summary>
        /// <param name="FileContent">要寫入的檔案內容</param>
        /// <param name="FileName">檔案名稱</param>
        public static void WriteContentToFile(string FileContent, string FileName)
        {
            FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);
            sw.WriteLine(FileContent);
            sw.Close();
        }

        #endregion



        #region 從檔案中讀取內容回傳內容字串

        /// <summary>
        /// 從檔案中讀取內容回傳內容字串
        /// </summary>
        /// <param name="FileName">檔案名稱</param>
        /// <returns></returns>
        public static string ReadFileToString(string FileName)
        {
            string bufstr = "";
            FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Unicode);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);

            while (sr.Peek() > -1)
            {
                bufstr += sr.Read().ToString();
            }
            sr.Close();
            return bufstr;

        }

        #endregion



        #region 雜湊加密,此方法需要搭配一個　位元組陣列 轉字串的方法(要自己撰寫程式碼)

        /// <summary>
        /// 雜湊加密,此方法需要搭配一個　位元組陣列 轉字串的方法(要自己撰寫程式碼)
        /// MD5 訊息摘要5(Message Digest 5 , MD5)
        /// SHA1 安全雜湊演算法(Secure Hashing Algorithm , SHA1)
        /// </summary>
        /// <param name="enCrypType">"MD5"或"SHA1"</param>
        /// <param name="bufstring">欲進行加密字串</param>
        /// <returns>回傳加密字串</returns>
        public static string HashEncryption(string enCrypType, string bufstring)
        {
            //此法也可以
            //HashAlgorithm sha = new SHA1CryptoServiceProvider(); //雜湊大小160位元
            //HashAlgorithm md5 = new MD5CryptoServiceProvider();  //雜湊大小128位元

            //完整命名空間
            //System.Security.Cryptography.HashAlgorithm
            //System.Security.Cryptography.MD5 
            //System.Security.Cryptography.MD5CryptoServiceProvider(); 

            try
            {
                if (enCrypType == "MD5")
                {
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] dataArray = Encoding.UTF8.GetBytes(bufstring);
                    byte[] result = md5.ComputeHash(dataArray);
                    return byteArrayToString(result);
                }
                else if (enCrypType == "SHA1")
                {
                    SHA1 sha1 = new SHA1CryptoServiceProvider();
                    byte[] dataArray = Encoding.UTF8.GetBytes(bufstring);
                    byte[] result = sha1.ComputeHash(dataArray);
                    return byteArrayToString(result);
                }
                else
                {
                    return "error:可能是加密型態錯誤";
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("錯誤訊息:" + ex.Message.ToString(), "發生例外");
                return ex.Message.ToString();
            }




        }

        #endregion



        #region 將位元組陣列內容轉換成文字

        /// <summary>
        /// 將位元組陣列內容轉換成文字
        /// </summary>
        /// <param name="buf">傳入位元組陣列</param>
        /// <returns>文字</returns>
        public static string byteArrayToString(byte[] buf)
        {
            string result = "";
            foreach (byte var in buf)
            {
                result = result + var.ToString();
            }
            return result;
        }

        #endregion


        #region "延遲處理"

        /// <summary>
        /// 延遲處理
        /// </summary>
        /// <param name="SecInt">傳入秒數</param>
        public static void DoSomeThing(int SecInt)
        {
            for (int i = 0; i < SecInt; i++)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }

        #endregion


        #region 計算時間差

        public enum DateInterval
        {
            Second, Minute, Hour, Day
        }


        /// <summary>
        /// 計算時間差
        /// </summary>
        /// <param name="StartDate">起始日期</param>
        /// <param name="EndDate">終止日期</param>
        /// <param name="DateInterval">指定回傳單位
        /// Second 秒
        /// Minute 分
        /// Hour 時
        /// Day 天
        /// </param>
        /// <returns></returns>
        public static int DateDiff(DateTime StartDate, DateTime EndDate, DateInterval DI)
        {

            int v1;
            TimeSpan TS1 = EndDate.Subtract(StartDate);

            switch ((int)DI)
            {
                case (int)DateInterval.Second:
                    v1 = (int)TS1.TotalSeconds;
                    break;
                case (int)DateInterval.Minute:
                    v1 = (int)TS1.TotalMinutes;
                    break;
                case (int)DateInterval.Hour:
                    v1 = (int)TS1.TotalHours;
                    break;
                case (int)DateInterval.Day:
                    v1 = (int)TS1.TotalDays;
                    break;
                default:
                    v1 = (int)TS1.TotalSeconds;
                    break;
            }


            return v1;

        }

        #endregion


        #region "字元與ASCII碼的轉換"

        public static char Chr(int N)
        {
            char C = Convert.ToChar(N);
            return C;
        }

        public static int ASC(string S)
        {
            int N = Convert.ToInt32(S[0]);
            return N;
        }

        public static int ASC(char C)
        {
            int N = Convert.ToInt32(C);
            return N;
        }

        #endregion


        #region "數值判斷"

        /// <summary>
        /// 數值判斷
        /// </summary>
        /// <param name="num">傳入數字字串</param>
        /// <returns>若為數值型態則回傳true,否則回傳false</returns>
        public static bool IsNumeric(string num)
        {
            //step 1:空字串不為數字
            if (num.Length == 0 || num == "")
            {
                return false;
            }
            char c;
            bool symbol = false;
            for (int i = 0; i < num.Length; i++)
            {
                //從字串中逐一取出字元來加以判斷
                c = Convert.ToChar(num.Substring(i, 1));
                if (char.IsNumber(c) == false) //若不是數字則進行以下判斷動作
                {   //step 2:小數點只有一個才為正確數字
                    if (c == '.')
                    {
                        if (symbol == false)
                        {
                            symbol = true;
                        }
                        else //二個以上小數點不是正確數字
                        {
                            return false;
                        }

                    }
                    else
                    {
                        //step 3:判斷第一個字元為[+]或[-]是合法
                        if (c == '+' || c == '-')
                        {
                            if (i != 0)
                            {
                                return false;
                            }
                        }
                        //step 4:其他非數字字元如@#$%均不為數字
                        else
                        {
                            return false;
                        }
                    }

                }

            }
            return true;
        }


        #endregion

        #region " 影像轉位元陣列"
        /// <summary>
        /// 影像轉位元陣列
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        #endregion

        #region "將資料庫對應的值加到ComboBox清單內"

        public static void DataIntoComboBox(ComboBox objCom, String TableName, String FieldID, String FieldName, String WhereValue)
        {
            //String errorMsg= "";      
            String selectCmd = "";
            objCom.Items.Clear();

            selectCmd = "SELECT Distinct " + FieldID + "," + FieldName + " FROM " + TableName + " Where " + FieldID + " Like'" + WhereValue + "' order by " + FieldID;

            My.MyDatabase myDB= new MyDatabase();
            System.Data.DataTable dt = myDB.OpenDataTable(selectCmd, TableName);
            //System.Data.DataRow row;

            foreach (System.Data.DataRow row in dt.Rows)
            {
                objCom.Items.Add(row[FieldID] + "-" + row[FieldName]);
            }


        }

        public static void DataIntoComboBox(ComboBox objCom, String TableName, String FieldID, String FieldName, String WhereValue , bool IsCheckEnabled)
        {
            //String errorMsg= "";      
            String selectCmd = "";
            objCom.Items.Clear();

            if (IsCheckEnabled == true)
            {
                selectCmd = "SELECT Distinct " + FieldID + "," + FieldName + " FROM " + TableName + " Where " + FieldID + " Like'" + WhereValue + "' and IsEnable=1 order by " + FieldID;
            }
            else
            {
                selectCmd = "SELECT Distinct " + FieldID + "," + FieldName + " FROM " + TableName + " Where " + FieldID + " Like'" + WhereValue + "' order by " + FieldID;
            }

            My.MyDatabase myDB = new MyDatabase();
            System.Data.DataTable dt = myDB.OpenDataTable(selectCmd, TableName);
            //System.Data.DataRow row;

            foreach (System.Data.DataRow row in dt.Rows)
            {
                objCom.Items.Add(row[FieldID] + "-" + row[FieldName]);
            }


        }

        public static void DataIntoComboBox(ComboBox objCom, String TableName, String FieldName)
        {
            //String errorMsg= "";      
            String selectCmd = "";
            objCom.Items.Clear();

                selectCmd = "SELECT Distinct " + FieldName + " FROM " + TableName;

            My.MyDatabase myDB = new MyDatabase();
            System.Data.DataTable dt = myDB.OpenDataTable(selectCmd, TableName);
            //System.Data.DataRow row;

            foreach (System.Data.DataRow row in dt.Rows)
            {
                objCom.Items.Add(row[FieldName]);
            }


        }


        #endregion


        #region "自動取得ComboBox清單內真正的選取項目值-DataIntoComboBox函數相關"

        /// <summary>
        /// 自動取得ComboBox清單內真正的選取項目值
        /// Ex: ComboBox1內選取項目為[Personal-一般個人]
        /// 若呼叫GetSeleteItem(ComboBox1,0)則回傳Personal
        /// 若呼叫GetSeleteItem(ComboBox1,1)則回傳一般個人
        /// 其他狀況回傳空字串
        /// </summary>
        /// <param name="objCom">傳入ComboBox控制項</param>
        /// <param name="index">傳入欲傳回的項目索引</param>
        /// <returns>真正的項目值</returns>
        public static string GetSeleteItem(ComboBox objCom, int index)
        {
            String[] strItemName = new String[2];
            strItemName = objCom.SelectedItem.ToString().Split('-');
            if (strItemName.Length > index)
            {
                return strItemName[index];
            }
            else
            {
                return "";
            }



        }

        #endregion


        #region "自動判斷ComboBox清單內的項目所在的索引值-DataIntoComboBox函數相關"
        public static int ItemToSeleteIndex(ComboBox objCom, String ItemName)
        {
            String[] strItemName = new string[2];
            for (int i = 0; i <= objCom.Items.Count - 1; i++)
            {
                strItemName = objCom.Items[i].ToString().Split('-');
                if (strItemName[0] == ItemName || strItemName[1] == ItemName)
                {
                    return i;
                }
            }
            return -1;
        }


        #endregion

        #region "搜尋ComboBox的Item集合找符合關鍵字的Item回傳"

        public static string SearchComboBoxItems(System.Windows.Forms.ComboBox cbo, string SearchWord)
        {
            foreach (string obj in cbo.Items)
            {
                if (obj.IndexOf(SearchWord) != -1)
                {
                    return obj;
                }
            }
            return "NotFound";
        }

        #endregion


        #region "驗證身份證字號"

        public static bool CheckID(string ID)
        {
            bool checkResult = false;
            if (ID.Length == 10) //檢查身分證字號長度
            {
                ID = ID.ToUpper();
                if (ID[0] >= 0x41 && ID[0] <= 0x5A) //檢查第一個字元是否為英文字母字母(A~Z)
                {
                    if (ID[1] != '1' && ID[1] != '2') //檢查第一個數字是否為1或2，1代表男生,2代表女生
                    {
                        return checkResult;
                    }
                    int[] n = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 34, 
                        18, 19, 20, 21, 22, 35, 23, 24, 25, 26, 27, 28, 29, 32, 30, 31, 33 };
                    int[] m = new int[11]; //因為第一個字母會拆分為二個數字，故須2+9 = 11空間來存放
                    m[1] = n[(ID[0]) - 65] % 10;               //拆解第一個字母如A = 10 , b[0] = 1 , b[1]=0 
                    int total = m[0] = n[(ID[0]) - 65] / 10;
                    for (int i = 1; i <= 9; i++)
                    {
                        m[i + 1] = ID[i] - 48;
                        total += m[i] * (10 - i);
                    }
                    if (((total % 10) + m[10]) % 10 == 0) //總計之後取餘數等於0表示身分證正確
                    {
                        checkResult = true;
                    }
                }
            }
            return checkResult;
        }

        #endregion

    }
}
