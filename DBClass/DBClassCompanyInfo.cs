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
    class DBClassCompanyInfo
    {
        public string TableName = "CompanyInfo";
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
        /// <param name="CCC">傳入存放更新資料的SIS.Configuration.ClsCompanyConfig</param>
        /// <returns></returns>
        public bool InsertData(SIS.Configuration.ClsCompanyConfig CCC)
        {
            InitDB();

            string insertCmd;

            insertCmd = "Insert Into " + TableName + " (CompanyID,CNAME,ENAME,UnifiedBusinessNo,CompanyType,Owner,Contact,Phone,MobilePhone,Fax,Address,WebSite,Notes";

            insertCmd = insertCmd + ") Values(";
            insertCmd = insertCmd + "'" + CCC.CompanyID  + "',";  
            insertCmd = insertCmd + "'" + CCC.CNAME  + "',"; 
            insertCmd = insertCmd + "'" + CCC.ENAME  + "',";  
            insertCmd = insertCmd + "'" + CCC.UnifiedBusinessNo  + "',";  
            insertCmd = insertCmd + "'" + CCC.CompanyType  + "',";  
            insertCmd = insertCmd + "'" + CCC.Owner  + "',";  
            insertCmd = insertCmd + "'" + CCC.Contact  + "',";  
            insertCmd = insertCmd + "'" + CCC.Phone  + "',";  
            insertCmd = insertCmd + "'" + CCC.MobilePhone  + "',";  
            insertCmd = insertCmd + "'" + CCC.Fax  + "',";  
            insertCmd = insertCmd + "'" + CCC.Address  + "',";  
            insertCmd = insertCmd + "'" + CCC.WebSite  + "',";  
            insertCmd = insertCmd + "'" + CCC.Notes  + "'";  
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
        /// <param name="CCC">傳入存放更新資料的SIS.Configuration.ClsCompanyConfig</param>
        /// <returns></returns>
        public bool Update(SIS.Configuration.ClsCompanyConfig CCC)
        {
            InitDB();

            string updateCmd;

            updateCmd = "UPDATE " + TableName + " SET ";
            updateCmd = updateCmd + " CompanyID='" + CCC.CompanyID + "',";　　　　　　　 
            updateCmd = updateCmd + " CNAME='" + CCC.CNAME + "',";　　　　　　　
            updateCmd = updateCmd + " ENAME='" + CCC.ENAME  + "',";
            updateCmd = updateCmd + " UnifiedBusinessNo='" + CCC.UnifiedBusinessNo  + "',";
            updateCmd = updateCmd + " CompanyType='" + CCC.CompanyType  + "',";
            updateCmd = updateCmd + " Owner='" + CCC.Owner  + "',";
            updateCmd = updateCmd + " Contact='" + CCC.Contact + "',";
            updateCmd = updateCmd + " Phone='" + CCC.Phone  + "',";
            updateCmd = updateCmd + " MobilePhone='" + CCC.MobilePhone  + "',";
            updateCmd = updateCmd + " Fax='" + CCC.Fax  + "',";
            updateCmd = updateCmd + " Address='" + CCC.Address  + "',";
            updateCmd = updateCmd + " WebSite='" + CCC.WebSite  + "',";
            updateCmd = updateCmd + " Notes='" + CCC.Notes  + "'";
            updateCmd = updateCmd + " WHERE CompanyID='" + CCC.CompanyID + "'";

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


            delCmd = "Delete From " + TableName + " Where CompanyID='" + PKval + "'";

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
