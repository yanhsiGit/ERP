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
    class DBClassManufacturerInfo
    {

        public string TableName = "ManufacturerInfo";
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
        /// <param name="CMC">傳入存放更新資料的SIS.Configuration.ClsManufacturerConfig</param>
        /// <returns></returns>
        public bool InsertData(SIS.Configuration.ClsManufacturerConfig CMC)
        {
            InitDB();

            string insertCmd;

            insertCmd = "Insert Into " + TableName + " (ManufacturerID,CNAME,ENAME,UnifiedBusinessNo,Owner,Contact,Phone,MobilePhone,Fax,Address,WebSite,Notes";

            insertCmd = insertCmd + ") Values(";
            insertCmd = insertCmd + "'" + CMC.ManufacturerID + "',";
            insertCmd = insertCmd + "'" + CMC.CNAME + "',";
            insertCmd = insertCmd + "'" + CMC.ENAME + "',";
            insertCmd = insertCmd + "'" + CMC.UnifiedBusinessNo + "',";
            insertCmd = insertCmd + "'" + CMC.Owner + "',";
            insertCmd = insertCmd + "'" + CMC.Contact + "',";
            insertCmd = insertCmd + "'" + CMC.Phone + "',";
            insertCmd = insertCmd + "'" + CMC.MobilePhone + "',";
            insertCmd = insertCmd + "'" + CMC.Fax + "',";
            insertCmd = insertCmd + "'" + CMC.Address + "',";
            insertCmd = insertCmd + "'" + CMC.WebSite + "',";
            insertCmd = insertCmd + "'" + CMC.Notes + "'";
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
        /// <param name="CMC">傳入存放更新資料的SIS.Configuration.ClsManufacturerConfig</param>
        /// <returns></returns>
        public bool Update(SIS.Configuration.ClsManufacturerConfig CMC)
        {
            InitDB();

            string updateCmd;

            updateCmd = "UPDATE " + TableName + " SET ";
            updateCmd = updateCmd + " ManufacturerID='" + CMC.ManufacturerID + "',";
            updateCmd = updateCmd + " CNAME='" + CMC.CNAME + "',";
            updateCmd = updateCmd + " ENAME='" + CMC.ENAME + "',";
            updateCmd = updateCmd + " UnifiedBusinessNo='" + CMC.UnifiedBusinessNo + "',";
            updateCmd = updateCmd + " Owner='" + CMC.Owner + "',";
            updateCmd = updateCmd + " Contact='" + CMC.Contact + "',";
            updateCmd = updateCmd + " Phone='" + CMC.Phone + "',";
            updateCmd = updateCmd + " MobilePhone='" + CMC.MobilePhone + "',";
            updateCmd = updateCmd + " Fax='" + CMC.Fax + "',";
            updateCmd = updateCmd + " Address='" + CMC.Address + "',";
            updateCmd = updateCmd + " WebSite='" + CMC.WebSite + "',";
            updateCmd = updateCmd + " Notes='" + CMC.Notes + "'";
            updateCmd = updateCmd + " WHERE ManufacturerID='" + CMC.ManufacturerID + "'";

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


            delCmd = "Delete From " + TableName + " Where ManufacturerID='" + PKval + "'";

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


        public string QueryData(string ManufacturerID, string GetFieldName)
        {
            InitDB();
            string selectCmd;
            string result = "";

            selectCmd = "Select " + GetFieldName + " From " + TableName + " Where ManufacturerID='" + ManufacturerID + "'";

            try
            {
                cmd = new SqlCommand(selectCmd, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    result = dr[GetFieldName].ToString();
                    conn.Close();
                    return result;
                }
                else
                {
                    conn.Close();
                    return result;
                }

            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                conn.Close();
                return result;
            }
        }


    }
}
