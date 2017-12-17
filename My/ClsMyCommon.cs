using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//
using System.Data;//
using System.Data.SqlClient; //SQL Server使用必要引入Namespace

namespace My
{
    public class MyCommon
    {
        #region "test"

        #endregion




        #region 判斷傳入的字串是否為空值

        /// <summary>
        /// 判斷傳入的字串是否為空值
        /// </summary>
        /// <param name="bufstr">傳入字串</param>
        /// <returns>回傳字串值</returns>
        public static bool IsNullString(string bufstr)
        {
            if (bufstr == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion


        #region 判斷是否為布林值

        /// <summary>
        /// 判斷是否為布林值
        /// </summary>
        /// <param name="objbuf"></param>
        /// <returns>回傳布林值</returns>
        public static bool IsBoolean(object objbuf)
        {
            string bufstr = (string)objbuf;
            bufstr = Microsoft.VisualBasic.Strings.LCase(bufstr);

            if (bufstr == "false" || bufstr == "true")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion


        #region 將傳入的日期轉成對應的日期

        /// <summary>
        /// 將傳入的日期轉成對應的日期
        /// </summary>
        /// <param name="bufnum">整數型態,
        /// 1 為星期一 , 2為星期二...7為星期日..以此類推
        /// </param>
        /// <returns></returns>
        public static string numToWeek(int bufnum)
        {
            switch (bufnum)
            {
                case 1:
                    return "星期一";
                //break;
                case 2:
                    return "星期二";
                //break;
                case 3:
                    return "星期三";
                //break;
                case 4:
                    return "星期四";
                //break;
                case 5:
                    return "星期五";
                //break;
                case 6:
                    return "星期六";
                //break;
                case 7:
                    return "星期日";
                //break;
                default:
                    return "傳入參數有誤";
                //break;
            }
        }

        #endregion


        #region 絕對值的計算

        /// <summary>
        /// 絕對值的計算
        /// </summary>
        /// <param name="InputNum"></param>
        /// <returns>回傳整數值</returns>
        public static int CustomAbs(int InputNum)
        {
            int result;
            result = (InputNum >= 0) ? InputNum : -InputNum;
            return result;
        }

        #endregion


        #region 將資料庫對應的值加到ComboBox清單內

        /// <summary>
        /// 將資料庫對應的值加到ComboBox清單內
        /// </summary>
        /// <param name="objCom">ComboBox物件</param>
        /// <param name="DefaultUseDB">使用資料庫種類</param>
        /// <param name="TableName">表格名稱</param>
        /// <param name="FieldID">過濾欄位名稱</param>
        /// <param name="FieldName">要填入的欄位名稱</param>
        /// <param name="WhereValue">過濾條件值</param>
        public static void GetComboBox(System.Windows.Forms.ComboBox objCom, string DefaultUseDB, string TableName, string FieldID, string FieldName, string WhereValue)
        {
            //cc.GetComboBox(DDL_Department, "SQLServer", "FactoryDept", "FactoryName", "Department", DDL_FactoryClass.SelectedItem.Text);
            string errorMsg = "";
            string selectCmd = "";
            int i;

            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader dr;

            objCom.Items.Clear();

            switch (TableName)
            {
                case "TableSchmea":
                    selectCmd = "SELECT Distinct " + FieldID + "," + FieldName + " FROM " + TableName + " Where " + FieldID + "='" + WhereValue + "' And IsValid=True  order by " + FieldID;
                    break;
                case "Code":
                    selectCmd = "SELECT Distinct " + FieldID + "," + FieldName + " FROM " + TableName + " Where " + FieldID + "='" + WhereValue + "' order by " + FieldID;
                    break;
                case "Membership":
                    if (WhereValue == "%")
                    {
                        selectCmd = "SELECT Distinct " + FieldID + "," + FieldName + " FROM " + TableName + " Where " + FieldID + " Like'" + WhereValue + "' order by " + FieldName;
                    }
                    break;
                case "SysRole":
                    if (WhereValue == "%")
                    {
                        selectCmd = "SELECT Distinct " + FieldID + "," + FieldName + " FROM " + TableName + " Where " + FieldID + " Like'" + WhereValue + "' order by " + FieldID;
                    }
                    break;
                case "ManufacMan":
                    if (WhereValue == "%")
                    {
                        selectCmd = "SELECT Distinct *  FROM " + TableName + " Where " + FieldID + " Like'" + WhereValue + "' And IsValid=True order by " + FieldID;
                    }
                    break;
                default:
                    break;
            }

            i = 0;

            try
            {

                string ConnString;
                ConnString = My.MyGlobal.SQLConnectionString;
                conn = new SqlConnection(ConnString);
                conn.Open();
                cmd = new SqlCommand(selectCmd, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objCom.Items.Add(dr[FieldName].ToString());
                    //objCom.Items[i].Value = Srd[FieldName].ToString();
                    i = i + 1;
                }
                conn.Close();
                dr.Close();
                cmd.Dispose();

            }
            catch (Exception ex)
            {

                errorMsg = ex.Message;
            }
        }

        #endregion
    }
}
