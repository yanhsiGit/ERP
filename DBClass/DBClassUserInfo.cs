using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //新增命名空間 for SQL Server
using System.Collections;
using System.Data; //for DataTable

namespace SIS.DBClass
{
    class DBClassUserInfo
    {
        public string TableName = "UserInfo";
        string errorMsg;
        string ConnString;

        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        #region "資料庫初始化"

        //資料庫初始化
        public void InitDB()
        {


            ConnString = My.MyGlobal.SQLConnectionString;

            conn = new SqlConnection(ConnString);
            conn.Open();
        }

        #endregion


        #region "新增一筆資料"

        /// <summary>
        /// 新增一筆資料
        /// </summary>
        /// <param name="ArrField">傳入存放新增資料的ArrayList</param>
        /// <returns></returns>
        public bool InsertData(System.Collections.ArrayList ArrField)
        {
            InitDB();

            string insertCmd;

            insertCmd = "Insert Into " + TableName + " (UserId,CNAME,ENAME,Sex,Birthday,BooldType,ID,PresentAddress,Phone";

            insertCmd = insertCmd + ") Values(";
            insertCmd = insertCmd + "'" + ArrField[0] + "',";  //使用者帳號
            insertCmd = insertCmd + "'" + ArrField[1] + "',";  //中文名稱
            insertCmd = insertCmd + "'" + ArrField[2] + "',";  //英文名稱
            insertCmd = insertCmd + "'" + ArrField[3] + "',";  //性別
            insertCmd = insertCmd + "'" + ArrField[4] + "',";  //生日
            insertCmd = insertCmd + "'" + ArrField[5] + "',";  //血型
            insertCmd = insertCmd + "'" + ArrField[6] + "',";  //身份證字號
            insertCmd = insertCmd + "'" + ArrField[7] + "',";  //通訊地址
            insertCmd = insertCmd + "'" + ArrField[8] + "'";   //電話
            insertCmd = insertCmd + ")";

            try
            {
                cmd = new SqlCommand(insertCmd, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;

            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                conn.Close();
                return false;
            }

        }

        #endregion


        #region "更新一筆資料"

        /// <summary>
        /// 更新一筆資料
        /// </summary>
        /// <param name="ArrField">傳入存放更新資料的ArrayList</param>
        /// <returns></returns>
        public bool Update(System.Collections.ArrayList ArrField)
        {
            InitDB();

            string updateCmd;

            updateCmd = "UPDATE " + TableName + " SET UserId='" + ArrField[0] + "',";//使用者帳號
            updateCmd = updateCmd + " CNAME='" + ArrField[1] + "',";　　　　　　　 //中文名稱
            updateCmd = updateCmd + " ENAME='" + ArrField[2] + "',";　　　　　　　 //英文名稱
            updateCmd = updateCmd + " Sex='" + ArrField[3] + "',";                   //性別
            updateCmd = updateCmd + " Birthday='" + ArrField[4] + "',";　　　　　　//生日
            updateCmd = updateCmd + " BooldType='" + ArrField[5] + "',";　　　　　 //血型
            updateCmd = updateCmd + " ID='" + ArrField[6] + "',";                   //身份證字號
            updateCmd = updateCmd + " PresentAddress='" + ArrField[7] + "',";　　　//通訊地址
            updateCmd = updateCmd + " Phone='" + ArrField[8] + "'";　　　　　　　 //電話
            updateCmd = updateCmd + " WHERE UserId='" + ArrField[0] + "'";

            try
            {
                cmd = new SqlCommand(updateCmd, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;

            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                conn.Close();
                return false;
            }

        }

        #endregion


        #region "刪除一筆資料"

        /// <summary>
        /// 刪除一筆資料
        /// </summary>
        /// <param name="PKval">傳入欲刪除資料的主鍵值</param>
        /// <returns></returns>
        public bool DeleteOneData(string PKval)
        {
            InitDB();
            string delCmd;
            int i = 0;


            delCmd = "Delete From " + TableName + " Where UserId='" + PKval + "'";

            try
            {
                cmd = new SqlCommand(delCmd, conn);
                i = cmd.ExecuteNonQuery();//若沒有任何資料進行異動,則會回傳0
                conn.Close();
                if (i == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                conn.Close();
                return false;
            }

        }

        #endregion


    }
}
