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
    class DBClassStockMaster
    {

        public string TableName = "StockMaster";
        public string TableName2 = "StockDetails";
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

        #region "新增一筆資料"

        /// <summary>
        /// 新增一筆資料
        /// </summary>
        /// <param name="CSC">傳入存放更新資料的SIS.Configuration.ClsStockConfig CSC</param>
        /// <returns></returns>
        public bool InsertData(SIS.Configuration.ClsStockConfig CSC)
        {
            InitDB();

            string insertCmd, insertCmd2;

            insertCmd = "Insert Into " + TableName + " (StockID,StockDate ,TotalPreTax, Tax,TotalAfterTax,ManufacturerID ,BusinessTaxStockTaxRate ," +
                "AmountPaid ,UnpaidAmount ,StockStaff , PaymentType ,Notes";

            insertCmd = insertCmd + ") Values(";
            insertCmd = insertCmd + "'" + CSC.StockID  + "',";
            insertCmd = insertCmd + "'" +CSC.StockDate + "',";
            insertCmd = insertCmd + "" + CSC.TotalPreTax + ",";
            insertCmd = insertCmd + "" + CSC.Tax + ",";
            insertCmd = insertCmd + "" + CSC.TotalAfterTax + ",";
            insertCmd = insertCmd + "'" + CSC.ManufacturerID + "',";
            insertCmd = insertCmd + "" + CSC.BusinessTaxStockTaxRate + ",";
            insertCmd = insertCmd + "" + CSC.AmountPaid + ",";
            insertCmd = insertCmd + "" + CSC.UnpaidAmount + ",";
            insertCmd = insertCmd + "'" + CSC.StockStaff + "',";
            insertCmd = insertCmd + "'" + CSC.PaymentType + "',";
            insertCmd = insertCmd + "'" + CSC.Notes + "'";
            insertCmd = insertCmd + ")";

            transaction = conn.BeginTransaction("MyInsertTransaction");

            try
            {
                cmd = conn.CreateCommand(); // new SqlCommand(insertCmd, conn);
                cmd.CommandText = insertCmd;
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();

                DBClass.DBClassItemsInfo DBCItemsInfo = new DBClassItemsInfo();

                for (int i = 0; i < CSC.StockItems.Length; i++)
                {
                    insertCmd2 = "Insert Into " + TableName2 + " (StockID ,ItemsID ,NAME ,Quantity ,ItemsUnit ," +
                   "CostPrice ,Totals ,Notes";

                    insertCmd2 = insertCmd2 + ") Values(";
                    insertCmd2 = insertCmd2 + "'" + CSC.StockID + "',";
                    insertCmd2 = insertCmd2 + "'" + CSC.StockItems[i].ItemsID + "',";
                    insertCmd2 = insertCmd2 + "'" + CSC.StockItems[i].NAME + "',";
                    insertCmd2 = insertCmd2 + "" + CSC.StockItems[i].Quantity + ",";
                    insertCmd2 = insertCmd2 + "'" + CSC.StockItems[i].ItemsUnit + "',";
                    insertCmd2 = insertCmd2 + "" + CSC.StockItems[i].Price + ",";
                    insertCmd2 = insertCmd2 + "" + CSC.StockItems[i].Totals + ",";
                    insertCmd2 = insertCmd2 + "'" + CSC.StockItems[i].Notes + "'";
                    insertCmd2 = insertCmd2 + ")";

                    cmd.CommandText = insertCmd2;//new SqlCommand(insertCmd2, conn);
                    cmd.ExecuteNonQuery();
                    DBCItemsInfo.UpdateInventory(CSC.StockItems[i].ItemsID, CSC.StockItems[i].Quantity); //更新商品庫存量
                }

                transaction.Commit(); //try to Commit above sql command

                conn.Close();
                return true;

            }
            catch (Exception ex)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    errorMsg = ex2.Message;
                }
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
        /// <param name="CSC">傳入存放更新資料的SIS.Configuration.ClsStockConfig</param>
   /// <param name="OLDItems">傳入更新前的商品集合</param>
   /// <returns></returns>
        public bool Update(SIS.Configuration.ClsStockConfig CSC , SIS.Configuration.Items[] OLDItems)
        {
            InitDB();

            string updateCmd, updateCmd2;

            updateCmd = "UPDATE " + TableName + " SET ";
            updateCmd = updateCmd + " StockID='" + CSC.StockID + "',";
            updateCmd = updateCmd + " StockDate='" + CSC.StockDate + "',";
            updateCmd = updateCmd + " TotalPreTax=" + CSC.TotalPreTax + ",";
            updateCmd = updateCmd + " Tax=" + CSC.Tax + ",";
            updateCmd = updateCmd + " TotalAfterTax=" + CSC.TotalAfterTax + ",";
            updateCmd = updateCmd + " ManufacturerID='" + CSC.ManufacturerID + "',";
            updateCmd = updateCmd + " BusinessTaxStockTaxRate=" + CSC.BusinessTaxStockTaxRate + ",";
            updateCmd = updateCmd + " AmountPaid=" + CSC.AmountPaid + ",";
            updateCmd = updateCmd + " UnpaidAmount=" + CSC.UnpaidAmount + ",";
            updateCmd = updateCmd + " StockStaff='" + CSC.StockStaff + "',";
            updateCmd = updateCmd + " PaymentType='" + CSC.PaymentType + "',";
            updateCmd = updateCmd + " Notes='" + CSC.Notes + "'";
            updateCmd = updateCmd + " WHERE StockID='" + CSC.StockID + "'";

            transaction = conn.BeginTransaction("MyUpdateTransaction");

            try
            {
                cmd = conn.CreateCommand(); // new SqlCommand(updateCmd, conn);
                cmd.CommandText = updateCmd;
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();

                DBClass.DBClassItemsInfo DBCItemsInfo = new DBClassItemsInfo();

                for (int i = 0; i < CSC.StockItems.Length; i++)
                {

                    updateCmd2 = "UPDATE " + TableName2 + " SET ";
                    updateCmd2 = updateCmd2 + " StockID='" + CSC.StockID + "',";
                    updateCmd2 = updateCmd2 + " ItemsID='" + CSC.StockItems[i].ItemsID + "',";
                    updateCmd2 = updateCmd2 + " NAME='" + CSC.StockItems[i].NAME + "',";
                    updateCmd2 = updateCmd2 + " Quantity=" + CSC.StockItems[i].Quantity + ",";
                    updateCmd2 = updateCmd2 + " ItemsUnit='" + CSC.StockItems[i].ItemsUnit + "',";
                    updateCmd2 = updateCmd2 + " CostPrice=" + CSC.StockItems[i].Price + ",";
                    updateCmd2 = updateCmd2 + " Totals=" + CSC.StockItems[i].Totals + ",";
                    updateCmd2 = updateCmd2 + " Notes='" + CSC.StockItems[i].Notes + "'";
                    updateCmd2 = updateCmd2 + " WHERE StockID='" + CSC.StockID + "' And ItemsID='" + CSC.StockItems[i].ItemsID + "'";

                    cmd.CommandText = updateCmd2;
                    cmd.ExecuteNonQuery();
                    int nowQuantity = OLDItems[i].Quantity;
                    if (nowQuantity < CSC.StockItems[i].Quantity)
                    {
                        DBCItemsInfo.UpdateInventory(CSC.StockItems[i].ItemsID, (CSC.StockItems[i].Quantity - nowQuantity)); //更新商品庫存量
                    }
                    else if (nowQuantity > CSC.StockItems[i].Quantity)
                    {
                        DBCItemsInfo.UpdateInventory(CSC.StockItems[i].ItemsID, (CSC.StockItems[i].Quantity - nowQuantity)); //更新商品庫存量
                    }
                    else if (nowQuantity == CSC.StockItems[i].Quantity)
                    {
                        //數量一樣不用更新庫存
                    }

                }

                transaction.Commit(); //try to Commit above sql command

                conn.Close();
                return true;

            }
            catch (Exception ex)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    errorMsg = ex2.Message;
                    return false;
                }
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

            delCmd = "Delete From " + TableName + " Where StockID='" + PKval + "'";

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

        #region "刪除主表和明細資料"

        /// <summary>
        /// 刪除主表和明細資料
       /// </summary>
       /// <param name="PKval">傳入欲刪除資料的主鍵值</param>
      /// <param name="OLDItems">傳入刪除前的商品集合</param>
      /// <returns></returns>
        public bool DeleteMasterDetailsData(string PKval, SIS.Configuration.Items[] OLDItems)
        {
            InitDB();
            string delCmd, delCmd2;
            int i = 0;


            delCmd = "Delete From " + TableName + " Where StockID='" + PKval + "'";

            transaction = conn.BeginTransaction("MyDeleteTransaction");

            try
            {
                cmd = conn.CreateCommand(); // new SqlCommand(updateCmd, conn);
                cmd.CommandText = delCmd;
                cmd.Transaction = transaction;
                i = cmd.ExecuteNonQuery();//若沒有任何資料進行異動,則會回傳0

                delCmd2 = "Delete From " + TableName2 + " Where StockID='" + PKval + "'";
                cmd.CommandText = delCmd2;
                i = i + cmd.ExecuteNonQuery();//若沒有任何資料進行異動,則會回傳0

                DBClass.DBClassItemsInfo DBCItemsInfo = new DBClassItemsInfo();

                for (int j = 0; j < OLDItems.Length; j++)
                {
                    DBCItemsInfo.UpdateInventory(OLDItems[j].ItemsID, -(OLDItems[j].Quantity)); //更新商品庫存量
                }

                transaction.Commit(); //try to Commit above sql command
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    errorMsg = ex2.Message;
                    return false;
                }
                errorMsg = ex.Message;
                conn.Close();
                return false;
            }

        }

        #endregion

        #region "查詢進貨單相關資料"

        /// <summary>
        /// 查詢進貨單相關資料
        /// </summary>
        /// <param name="StockID">傳入進貨單編號</param>
        /// <param name="CSC">傳入存放查詢結果資料的SIS.Configuration.ClsStockConfig CSC</param>
        /// <returns></returns>
        public bool QueryData(string StockID, SIS.Configuration.ClsStockConfig CSC)
        {
            InitDB();
            string selectCmd;

            selectCmd = "Select * From " + TableName + " Where StockID='" + StockID + "'";

            try
            {
                cmd = new SqlCommand(selectCmd, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    CSC.StockID = StockID;
                    CSC.StockDate = dr["StockDate"].ToString();
                    CSC.TotalPreTax = int.Parse(dr["TotalPreTax"].ToString());
                    CSC.Tax = int.Parse(dr["Tax"].ToString());
                    CSC.TotalAfterTax = int.Parse(dr["TotalAfterTax"].ToString());
                    CSC.ManufacturerID = dr["ManufacturerID"].ToString();
                    CSC.BusinessTaxStockTaxRate = int.Parse(dr["BusinessTaxStockTaxRate"].ToString());
                    CSC.AmountPaid = int.Parse(dr["AmountPaid"].ToString());
                    CSC.UnpaidAmount = int.Parse(dr["UnpaidAmount"].ToString());
                    CSC.StockStaff = dr["StockStaff"].ToString();
                    CSC.PaymentType = dr["PaymentType"].ToString();
                    CSC.Notes = dr["Notes"].ToString();
                    conn.Close();

                    SIS.DBClass.DBClassStockDetails DBSD = new DBClassStockDetails();

                    CSC.StockItems = DBSD.QueryData(StockID);
                    if (CSC.StockItems == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }

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

        public bool QueryData(string StockID)
        {
            InitDB();
            string selectCmd;

            selectCmd = "Select * From " + TableName + " Where StockID='" + StockID + "'";

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
                return false;
            }
        }

        #endregion

    }
}
