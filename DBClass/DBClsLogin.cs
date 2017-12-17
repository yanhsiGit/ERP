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
    class DBClsLogin
    {
        public string TableName = "Login";
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


        #region "驗證帳號與密碼"

        /// <summary>
        /// 驗證帳號與密碼
        /// </summary>
        /// <param name="UserID">使用者帳號</param>
        /// <param name="Password">密碼</param>
        /// <returns></returns>
        public bool VerifyPWD(string UserID, string Password)
        {
            InitDB();
            string selectCmd;

            selectCmd = "Select * From " + TableName + " Where UserID='"
                + UserID + "' And Pwd='" + Password + "' And IsValid=1";
            //注意：欄位名稱不可為Password

            try
            {
                cmd = new SqlCommand(selectCmd, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }

            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                conn.Close();
                //throw new Exception(ex.Message.ToString());
                return false;
            }

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

            insertCmd = "Insert Into " + TableName + " (UserID,Pwd,RoleId,CreateDate,IsValid";

            insertCmd = insertCmd + ") Values(";
            insertCmd = insertCmd + "'" + ArrField[0] + "',";  //使用者編號
            insertCmd = insertCmd + "'" + ArrField[1] + "',";  //密碼
            insertCmd = insertCmd + "'" + ArrField[2] + "',";  //角色編號
            insertCmd = insertCmd + "'" + ArrField[3] + "',";  //建立日期
            insertCmd = insertCmd + "'" + ArrField[4] + "' ";  //備註
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

         public bool InsertData(SIS.Configuration.ClsLoginConfig Login)
        {
            InitDB();

            string insertCmd;

            insertCmd = "Insert Into " + TableName + " (UserID,Pwd,RoleId,CreateDate,IsValid";

            insertCmd = insertCmd + ") Values(";
            insertCmd = insertCmd + "'" + Login.UserId  + "',";  //使用者編號
            insertCmd = insertCmd + "'" + Login.Pwd  + "',";  //密碼
            insertCmd = insertCmd + "'" + Login.RoleId  + "',";  //角色編號
            insertCmd = insertCmd + "'" + Login.CreateDate  + "',";  //建立日期
            insertCmd = insertCmd + "" +  Login.IsValid + "";  //是否有效
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

            updateCmd = "UPDATE " + TableName + " SET UserId='" + ArrField[0] + "',";//使用者編號
            updateCmd = updateCmd + " Pwd='" + ArrField[1] + "',";　　　　　　　　　　//密碼
            updateCmd = updateCmd + " RoleId='" + ArrField[2] + "',";　　　　　　　　//角色編號
            updateCmd = updateCmd + " CreateDate='" + ArrField[3] + "',";　　　　　　//建立日期
            updateCmd = updateCmd + " IsValid=" + ArrField[4] + "";　　　　　　　　　//備註
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


        #region "更新密碼"

        /// <summary>
        /// 更新密碼
        /// </summary>
        /// <param name="UserId">使用者帳號</param>
        /// <param name="OldPassword">舊密碼</param>
        /// <param name="NewPassword">新密碼</param>
        /// <returns></returns>
        public bool UpdatePassword(string UserId, string OldPassword, string NewPassword)
        {

            if (VerifyPWD(UserId, OldPassword))
            {
                InitDB();

                string updateCmd;
                int i = 0;

                updateCmd = "UPDATE " + TableName + " SET UserId='" + UserId + "',";
                updateCmd = updateCmd + " Pwd='" + NewPassword + "'";
                updateCmd = updateCmd + " WHERE UserId='" + UserId + "'";

                try
                {
                    cmd = new SqlCommand(updateCmd, conn);
                    i = cmd.ExecuteNonQuery(); //若沒有任何異動則回傳0
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
            else
            {
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


        #region "查詢帳號相關資料"

        /// <summary>
        /// 查詢帳號相關資料
        /// </summary>
        /// <param name="UserId">使用者帳號</param>
        /// <param name="BufArrList">傳入要接收查詢結果的ArrayList</param>
        /// <returns></returns>
        public bool QueryData(string UserId, System.Collections.ArrayList BufArrList)
        {
            InitDB();
            string selectCmd;

            selectCmd = "Select * From " + TableName + " Where UserId='" + UserId + "'";

            try
            {
                cmd = new SqlCommand(selectCmd, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    BufArrList.Insert(0, dr["UserId"].ToString());
                    BufArrList.Insert(1, dr["Pwd"].ToString());
                    BufArrList.Insert(2, dr["RoleId"].ToString());
                    BufArrList.Insert(3, dr["CreateDate"].ToString());
                    BufArrList.Insert(4, dr["IsValid"].ToString());

                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
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


        #region "查詢帳號相關資料"

        /// <summary>
        /// 查詢帳號相關資料
        /// </summary>
        /// <param name="UserId">使用者帳號</param>
        /// <returns></returns>
        public DataTable QueryDataForLike(string UserId)
        {
            InitDB();
            string selectCmd;
            DataTable DT = new DataTable();

            selectCmd = "Select * From " + TableName + " Where UserId Like '%" + UserId + "%'";

            try
            {

                da = new SqlDataAdapter(selectCmd, conn);
                da.Fill(DT);

                da.Dispose();
                conn.Close();

                return DT;

            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                da.Dispose();
                conn.Close();
                return DT;
            }
        }

        #endregion


        #region "將角色編號轉換成角色名稱"

        /// <summary>
        /// 將角色編號轉換成角色名稱
        /// </summary>
        /// <param name="UserId">使用者帳號</param>
        /// <returns></returns>
        public string RoleIdToRoleName(string UserId)
        {
            InitDB();
            string selectCmd;
            string RoleId = "";

            selectCmd = "Select * From " + TableName + " Where UserId='" + UserId + "'";

            try
            {
                cmd = new SqlCommand(selectCmd, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    RoleId = dr["RoleId"].ToString();
                    conn.Close();
                    My.MyDatabase MyDB = new My.MyDatabase();

                    return MyDB.GetTableFieldData("SysRole", "RoleId", RoleId, "RoleName");

                }
                else
                {
                    conn.Close();
                    return "error";
                }

            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                conn.Close();
                return ex.Message.ToString();
            }
        }

        #endregion


        #region "將Login資料表的內容以DataTable方式回傳"

        /// <summary>
        /// 將Login資料表的內容以DataTable方式回傳
        /// </summary>
        /// <param name="OrderByColumn">要排序的欄位</param>
        /// <param name="ASCorDESC">ASC遞增,DESC遞減</param>
        /// <returns></returns>
        public DataTable GetLoginDataTable(string OrderByColumn, string ASCorDESC)
        {
            string selectCmd = "select * from Login Order By " + OrderByColumn + " " + ASCorDESC;

            InitDB();

            da = new SqlDataAdapter(selectCmd, conn);
            DataTable DT = new DataTable();
            da.Fill(DT);

            da.Dispose();
            conn.Close();
            return DT;
        }

        #endregion

    }
}
