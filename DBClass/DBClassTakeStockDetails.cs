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
    class DBClassTakeStockDetails
    {
        public string TableName = "TakeStockDetails";
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
        /// 查詢符合盤點單號的商品資料
        /// </summary>
        /// <param name="TakeStockID"></param>
        /// <returns></returns>
        public SIS.Configuration.TakeStockItem[] QueryData(string TakeStockID)
        {
            InitDB();
            string selectCmd;

            selectCmd = "Select * From " + TableName + " Where TakeStockID='" + TakeStockID + "' Order by ItemsID ";

            try
            {
                da = new SqlDataAdapter(selectCmd, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, TableName);
                if (ds.Tables[TableName].Rows.Count >= 1)
                {
                    SIS.Configuration.TakeStockItem[] items = null;
                    items = new Configuration.TakeStockItem[ds.Tables[TableName].Rows.Count];
                    int i = 0;
                    foreach (DataRow row in ds.Tables[TableName].Rows)
                    {
                        if (row["ItemsID"] != null)
                        {
                            SIS.Configuration.TakeStockItem oneItem = new Configuration.TakeStockItem();
                            oneItem.ItemsID = row["ItemsID"].ToString();
                            oneItem.NAME = row["NAME"].ToString();
                            oneItem.Inventory = int.Parse(row["Inventory"].ToString());
                            oneItem.TakeStockInventory = int.Parse(row["TakeStockInventory"].ToString());
                            oneItem.GainLossInventory = int.Parse(row["GainLossInventory"].ToString());
                            oneItem.IsTakeStock = bool.Parse(row["IsTakeStock"].ToString());
                            oneItem.ItemsUnit = row["ItemsUnit"].ToString();
                            oneItem.Price = int.Parse(row["Price"].ToString());
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

    }
}
