using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//
using System.Data.SqlClient;//for SQL Server 2005
using System.Collections; // for ArrayList

namespace SIS.DBClass
{
    class DBClassSysFunction
    {
        public string TableName = "SysFunction";
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


        #region "將SysFunction資料表的內容以DataTable方式回傳"

        /// <summary>
        /// 將SysFunction資料表的內容以DataTable方式回傳
        /// </summary>
        /// <param name="ASCorDESC">ASC遞增排序,DESC遞減排序</param>
        /// <returns></returns>
        public DataTable GetSysFunctionDataTable(string ASCorDESC)
        {
            string selectCmd = "select * from SysFunction Order By FuncId " + ASCorDESC;

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
