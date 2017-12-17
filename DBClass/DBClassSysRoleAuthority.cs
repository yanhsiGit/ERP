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
    class DBClassSysRoleAuthority
    {
        public string TableName = "SysRoleAuthority";
        string errorMsg;
        string ConnString;

        SqlConnection conn;
        //SqlCommand cmd;
        //SqlDataReader dr;
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


        #region "將SysRoleAuthority資料表的內容以DataTable方式回傳"

        /// <summary>
        /// 將SysRoleAuthority資料表的內容以DataTable方式回傳
        /// </summary>
        /// <param name="ASCorDESC">ASC遞增排序,DESC遞減排序</param>
        /// <returns></returns>
        public DataTable GetSysRoleAuthorityDataTable(string ASCorDESC)
        {
            try
            {
                string selectCmd = "select * from SysRoleAuthority Order By FuncId " + ASCorDESC;

                InitDB();

                da = new SqlDataAdapter(selectCmd, conn);
                DataTable DT = new DataTable();
                da.Fill(DT);

                da.Dispose();
                conn.Close();
                return DT;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return null;
            }


        }

        #endregion


    }
}
