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
    class DBClsSysUserAuthority
    {
        public string TableName = "SysUserAuthority";
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


        #region "驗證使用者權限-適用於單一功能驗證"

        /// <summary>
        /// 驗證使用者權限-適用於單一功能驗證
        /// </summary>
        /// <param name="UserID">使用者帳號</param>
        /// <param name="FuncId">功能編號</param>
        /// <returns>回傳True表示可以使用該功能,回傳False表示該功能無法使用</returns>
        public bool VerifyAuthority(string UserID, string FuncId)
        {
            InitDB();
            string selectCmd;
            bool result;

            selectCmd = "Select * From " + TableName + " Where UserID='" + UserID + "' And FuncId='" + FuncId + "'";

            try
            {
                cmd = new SqlCommand(selectCmd, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    result = Convert.ToBoolean(dr["AuthStatus"]);
                    conn.Close();
                    return result;
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


        #region "獲取SysUserAuthority的DataTable"

        /// <summary>
        /// 獲取SysUserAuthority的DataTable
        /// </summary>
        /// <param name="UserId">使用者帳號</param>
        /// <returns></returns>
        public DataTable GetSysUserAuthorityDataTable(string UserId)
        {
            string selectCmd = "select * from SysUserAuthority Where UserId='" + UserId + "'";

            InitDB();

            da = new SqlDataAdapter(selectCmd, conn);
            DataTable DT = new DataTable();
            da.Fill(DT);

            da.Dispose();
            conn.Close();

            return DT;
        }

        #endregion


        #region "驗證使用者權限-此法效率較佳-可以減少資料庫開啟動作"

        /// <summary> 驗證使用者權限-此法效率較佳-可以減少資料庫開啟動作
        /// </summary>
        /// <param name="UserID">使用者編號</param>
        /// <param name="FuncId">功能編號</param>
        /// <param name="DT">傳入DataTable</param>
        /// <returns></returns>
        public bool VerifyAuthorityPerformance(string UserID, string FuncId, DataTable DT)
        {

            string bufstring = "";
            foreach (DataRow Rows in DT.Rows)
            {

                if (FuncId.IndexOf(Rows["FuncId"].ToString()) != -1)
                {
                    bufstring = Rows["AuthStatus"].ToString();
                    if (bufstring == "True")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


            }

            return false;


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

            insertCmd = "Insert Into " + TableName + " (UserID,FuncId,AuthStatus";

            insertCmd = insertCmd + ") Values(";
            insertCmd = insertCmd + "'" + ArrField[0] + "',";  //使用者編號
            insertCmd = insertCmd + "'" + ArrField[1] + "',";  //功能編號
            insertCmd = insertCmd + "" + ArrField[2] + " ";  //使用權限True/False
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

        public bool InsertData(string UserID, string FuncId, bool AuthStatus)
        {
            InitDB();

            string insertCmd;
            int intAuthStatus = Convert.ToInt32(AuthStatus);

            insertCmd = "Insert Into " + TableName + " (UserID,FuncId,AuthStatus";

            insertCmd = insertCmd + ") Values(";
            insertCmd = insertCmd + "'" + UserID + "',";  //使用者編號
            insertCmd = insertCmd + "'" + FuncId + "',";  //功能編號
            insertCmd = insertCmd + "" + intAuthStatus.ToString() + " ";  //使用權限True/False
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


        #region "更新使用權限"

        /// <summary>
        /// 更新使用權限
        /// </summary>
        /// <param name="UserId">使用者帳號</param>
        /// <param name="FuncId">功能編號</param>
        /// <param name="AuthStatus">授權狀態</param>
        /// <returns></returns>
        public bool UpdateAuthStatus(string UserId, string FuncId, bool AuthStatus)
        {

            InitDB();

            string updateCmd;
            int i = 0;
            int intAuthStatus = Convert.ToInt32(AuthStatus);

            updateCmd = "UPDATE " + TableName + " SET AuthStatus = " + intAuthStatus.ToString() + " ";
            updateCmd = updateCmd + " WHERE UserId='" + UserId + "' And FuncId='" + FuncId + "'";

            try
            {
                cmd = new SqlCommand(updateCmd, conn);
                i = cmd.ExecuteNonQuery();//若沒有任何異動則回傳0
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


        #region "刪除單一使用者所有權限資料"

        /// <summary>
        /// 刪除單一使用者所有權限資料
        /// </summary>
        /// <param name="UserId">使用者帳號</param>
        /// <returns></returns>
        public bool DeleteUserData(string UserId)
        {
            InitDB();
            string delCmd;
            int i = 0;


            delCmd = "Delete From " + TableName + " Where UserId='" + UserId + "'";

            try
            {
                cmd = new SqlCommand(delCmd, conn);
                i = cmd.ExecuteNonQuery(); //若沒有任何資料進行異動,則會回傳0
                conn.Close();
                if (i >= 1)
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
