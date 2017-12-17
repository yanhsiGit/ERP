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
    class DBClassStockDetails
    {

        public string TableName = "StockDetails";
        string errorMsg;
        string ConnString;

        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        SqlTransaction transaction;

        #region "資料庫初始化"

        //資料庫初始化
        public void InitDB()
        {
            ConnString = My.MyGlobal.SQLConnectionString;

            conn = new SqlConnection(ConnString);
            conn.Open();
        }

        #endregion

        /// <summary>
        /// 查詢符合進貨單號的商品資料
        /// </summary>
        /// <param name="StockID"></param>
        /// <returns></returns>
        public SIS.Configuration.Items[] QueryData(string StockID)
        {
            InitDB();
            string selectCmd;

            selectCmd = "Select * From " + TableName + " Where StockID='" + StockID + "'";

            try
            {
                da = new SqlDataAdapter(selectCmd, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, TableName);
                if (ds.Tables[TableName].Rows.Count >= 1)
                {
                    SIS.Configuration.Items[] items = null;
                    items = new Configuration.Items[ds.Tables[TableName].Rows.Count];
                    int i = 0;
                    foreach (DataRow row in ds.Tables[TableName].Rows)
                    {
                        if (row["ItemsID"] != null)
                        {
                            SIS.Configuration.Items oneItem = new Configuration.Items();
                            oneItem.ItemsID = row["ItemsID"].ToString();
                            oneItem.NAME = row["NAME"].ToString();
                            oneItem.Quantity = int.Parse(row["Quantity"].ToString());
                            oneItem.ItemsUnit = row["ItemsUnit"].ToString();
                            oneItem.Price = int.Parse(row["CostPrice"].ToString());
                            oneItem.Totals = int.Parse(row["Totals"].ToString());
                            oneItem.Notes = row["Notes"].ToString();
                            items[i] = oneItem;
                            i = i + 1;
                        }
                    }

                    conn.Close();
                    return items;
                }
                else
                {
                    return null;
                }



            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                conn.Close();
                return null;
            }
        }

        public int QueryItemQuantity(string StockID, string ItemsID)
        {
            InitDB();
            string selectCmd;
            int Quantity = 0;
            selectCmd = "Select Quantity From " + TableName + " Where StockID='" + StockID + "' And ItemsID='" + ItemsID + "'";

            try
            {
                cmd = new SqlCommand(selectCmd, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Quantity = int.Parse(dr["Quantity"].ToString());
                    conn.Close();
                    return Quantity;
                }
                else
                {
                    conn.Close();
                    return -1;
                }

            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                conn.Close();
                return -1;
            }
        }


    }
}
