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
    class DBClassItemsInfo
    {

        public string TableName = "ItemsInfo";
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
        /// <param name="CIC">傳入存放更新資料的SIS.Configuration.ClsItemsConfig</param>
        /// <returns></returns>
        public bool InsertData(SIS.Configuration.ClsItemsConfig CIC)
        {
            InitDB();

            string insertCmd;

            insertCmd = "Insert Into " + TableName + " (ItemsID,NAME,ItemsType,Specifications,ItemsUnit,SellingPrice,CostPrice,MSRP,ManufacturerID,Inventory,SafeInventory,Notes";

            insertCmd = insertCmd + ") Values(";
            insertCmd = insertCmd + "'" + CIC.ItemsID + "',";
            insertCmd = insertCmd + "'" + CIC.NAME + "',";
            insertCmd = insertCmd + "'" + CIC.ItemsType + "',";
            insertCmd = insertCmd + "'" + CIC.Specifications + "',";
            insertCmd = insertCmd + "'" + CIC.ItemsUnit + "',";
            insertCmd = insertCmd + "" + CIC.SellingPrice + ",";
            insertCmd = insertCmd + "" + CIC.CostPrice + ",";
            insertCmd = insertCmd + "" + CIC.MSRP + ",";
            insertCmd = insertCmd + "'" + CIC.ManufacturerID + "',";
            insertCmd = insertCmd + "" + CIC.Inventory + ",";
            insertCmd = insertCmd + "" + CIC.SafeInventory + ",";
            insertCmd = insertCmd + "'" + CIC.Notes + "'";
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
        /// <param name="CIC">傳入存放更新資料的SIS.Configuration.ClsItemsConfig CIC</param>
        /// <returns></returns>
        public bool Update(SIS.Configuration.ClsItemsConfig CIC)
        {
            InitDB();

            string updateCmd;

            updateCmd = "UPDATE " + TableName + " SET ";
            updateCmd = updateCmd + " ItemsID='" + CIC.ItemsID + "',";
            updateCmd = updateCmd + " NAME='" + CIC.NAME + "',";
            updateCmd = updateCmd + " ItemsType='" + CIC.ItemsType + "',";
            updateCmd = updateCmd + " Specifications='" + CIC.Specifications + "',";
            updateCmd = updateCmd + " ItemsUnit='" + CIC.ItemsUnit + "',";
            updateCmd = updateCmd + " SellingPrice=" + CIC.SellingPrice + ",";
            updateCmd = updateCmd + " CostPrice=" + CIC.CostPrice + ",";
            updateCmd = updateCmd + " MSRP=" + CIC.MSRP + ",";
            updateCmd = updateCmd + " ManufacturerID='" + CIC.ManufacturerID + "',";
            updateCmd = updateCmd + " Inventory=" + CIC.Inventory + ",";
            updateCmd = updateCmd + " SafeInventory=" + CIC.SafeInventory + ",";
            updateCmd = updateCmd + " Notes='" + CIC.Notes + "'";
            updateCmd = updateCmd + " WHERE ItemsID='" + CIC.ItemsID + "'";

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


            delCmd = "Delete From " + TableName + " Where ItemsID='" + PKval + "'";

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


        #region "更新商品庫存量"

        /// <summary>
        /// 更新商品庫存量
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="ItemsCount">商品數</param>
        /// <returns></returns>
         public bool UpdateInventory(string ItemID , int ItemsCount)
        {
            int Inventory = QueryItemInventory(ItemID);
            if (Inventory == -1)
            {
                conn.Close();
                return false;
            }
             //避免更新庫存造成小於零的狀況
            int SetInventory = Inventory + ItemsCount;
             if (SetInventory < 0)
             {
                 conn.Close();
                 return false;
             }
             else
             {
                 InitDB();

                 string updateCmd;

                 updateCmd = "UPDATE " + TableName + " SET ";
                 updateCmd = updateCmd + " Inventory=" + SetInventory + "";
                 updateCmd = updateCmd + " WHERE ItemsID='" + ItemID + "'";

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

        }

        #endregion

         #region "查詢商品目前的庫存量"

         /// <summary>
        /// 查詢商品目前的庫存量
        /// </summary>
        /// <param name="ItemsID">傳入商品編號</param>
        /// <returns></returns>
         public int QueryItemInventory(string ItemsID)
         {
             InitDB();
             string selectCmd;
             int Inventory=0;
             selectCmd = "Select Inventory From " + TableName + " With(nolock) Where ItemsID='" + ItemsID + "'";

             try
             {
                 cmd = new SqlCommand(selectCmd, conn);
                 dr = cmd.ExecuteReader();
                 if (dr.Read())
                 {
                     Inventory = int.Parse(dr["Inventory"].ToString());
                     conn.Close();
                     return Inventory;
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

         #endregion

         #region "查詢所有商品項目"

         /// <summary>
        ///  查詢所有商品項目
        /// </summary>
        /// <param name="CTSC">傳入SIS.Configuration.ClsTakeStockConfig CTSC</param>
        /// <returns></returns>
         public bool QueryAllItems(SIS.Configuration.ClsTakeStockConfig CTSC)
         {
             int MAX = QueryItemsCount();//先算出商品總數
             InitDB();
             string selectCmd;

             selectCmd = "Select * From " + TableName + " Order by ItemsID";

             try
             {
                 cmd = new SqlCommand(selectCmd, conn);
                 dr = cmd.ExecuteReader();
                 int i = 0;


                 SIS.Configuration.TakeStockItem[] takeStockItems = new Configuration.TakeStockItem[MAX];
                 SIS.Configuration.TakeStockItem takeStockItem;

                 while (dr.Read())
                 {
                     takeStockItem = new Configuration.TakeStockItem();
                     takeStockItem.ItemsID = dr["ItemsID"].ToString();
                     takeStockItem.NAME = dr["NAME"].ToString();
                     takeStockItem.Inventory = int.Parse(dr["Inventory"].ToString());
                     takeStockItem.TakeStockInventory = takeStockItem.Inventory; //預設盤點數量 = 庫存數量
                     takeStockItem.GainLossInventory = takeStockItem.Inventory - takeStockItem.TakeStockInventory;
                     takeStockItem.IsTakeStock = false;
                     takeStockItem.ItemsUnit = dr["ItemsUnit"].ToString();
                     takeStockItem.Price = int.Parse(dr["CostPrice"].ToString());
                     takeStockItem.Totals = takeStockItem.TakeStockInventory * takeStockItem.Price;
                     takeStockItem.Notes = "";
                     takeStockItems[i] = takeStockItem;

                     i = i + 1;
                 }
                 CTSC.TakeStockItems = takeStockItems;
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

         public int QueryItemsCount()
         {
             InitDB();
             string selectCmd;
             int ItemsCount = 0;
             selectCmd = "Select Count(*) as count From " + TableName + " With(nolock)";

             try
             {
                 cmd = new SqlCommand(selectCmd, conn);
                 dr = cmd.ExecuteReader();
                 if (dr.Read())
                 {
                     ItemsCount = int.Parse(dr["count"].ToString());
                     conn.Close();
                     return ItemsCount;
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
