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
    class DBClassShipMaster
    {
        public string TableName = "ShipMaster";
        public string TableName2 = "ShipDetails";
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
        /// <param name="CSC">傳入存放更新資料的SIS.Configuration.ClsShipConfig CSC</param>
        /// <returns></returns>
        public bool InsertData(SIS.Configuration.ClsShipConfig CSC)
        {
            InitDB();

            string insertCmd, insertCmd2;

            insertCmd = "Insert Into " + TableName + " (ShipID,ShipDate ,TotalPreTax, Tax,TotalAfterTax,CustomerID ,BusinessTaxShipTaxRate ," +
                "AmountPaid ,UnpaidAmount ,ShipStaff , PaymentType ,Notes";

            insertCmd = insertCmd + ") Values(";
            insertCmd = insertCmd + "'" + CSC.ShipID + "',";
            insertCmd = insertCmd + "'" + CSC.ShipDate + "',";
            insertCmd = insertCmd + "" + CSC.TotalPreTax + ",";
            insertCmd = insertCmd + "" + CSC.Tax + ",";
            insertCmd = insertCmd + "" + CSC.TotalAfterTax + ",";
            insertCmd = insertCmd + "'" + CSC.CustomerID + "',";
            insertCmd = insertCmd + "" + CSC.BusinessTaxShipTaxRate + ",";
            insertCmd = insertCmd + "" + CSC.AmountPaid + ",";
            insertCmd = insertCmd + "" + CSC.UnpaidAmount + ",";
            insertCmd = insertCmd + "'" + CSC.ShipStaff + "',";
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

                for (int i = 0; i < CSC.ShipItems.Length; i++)
                {
                    insertCmd2 = "Insert Into " + TableName2 + " (ShipID ,ItemsID ,NAME ,Quantity ,ItemsUnit ," +
                   "SellingPrice ,Totals ,Notes";

                    insertCmd2 = insertCmd2 + ") Values(";
                    insertCmd2 = insertCmd2 + "'" + CSC.ShipID + "',";
                    insertCmd2 = insertCmd2 + "'" + CSC.ShipItems[i].ItemsID + "',";
                    insertCmd2 = insertCmd2 + "'" + CSC.ShipItems[i].NAME + "',";
                    insertCmd2 = insertCmd2 + "" + CSC.ShipItems[i].Quantity + ",";
                    insertCmd2 = insertCmd2 + "'" + CSC.ShipItems[i].ItemsUnit + "',";
                    insertCmd2 = insertCmd2 + "" + CSC.ShipItems[i].Price + ",";
                    insertCmd2 = insertCmd2 + "" + CSC.ShipItems[i].Totals + ",";
                    insertCmd2 = insertCmd2 + "'" + CSC.ShipItems[i].Notes + "'";
                    insertCmd2 = insertCmd2 + ")";

                    cmd.CommandText = insertCmd2;//new SqlCommand(insertCmd2, conn);
                    cmd.ExecuteNonQuery();
                    DBCItemsInfo.UpdateInventory(CSC.ShipItems[i].ItemsID, -(CSC.ShipItems[i].Quantity)); //更新商品庫存量
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
        /// <param name="CSC">傳入存放更新資料的SIS.Configuration.ClsShipConfig</param>
        /// <param name="OLDItems">傳入更新前的商品集合</param>
        /// <returns></returns>
        public bool Update(SIS.Configuration.ClsShipConfig CSC, SIS.Configuration.Items[] OLDItems)
        {
            InitDB();

            string updateCmd, updateCmd2;

            updateCmd = "UPDATE " + TableName + " SET ";
            updateCmd = updateCmd + " ShipID='" + CSC.ShipID + "',";
            updateCmd = updateCmd + " ShipDate='" + CSC.ShipDate + "',";
            updateCmd = updateCmd + " TotalPreTax=" + CSC.TotalPreTax + ",";
            updateCmd = updateCmd + " Tax=" + CSC.Tax + ",";
            updateCmd = updateCmd + " TotalAfterTax=" + CSC.TotalAfterTax + ",";
            updateCmd = updateCmd + " CustomerID='" + CSC.CustomerID + "',";
            updateCmd = updateCmd + " BusinessTaxShipTaxRate=" + CSC.BusinessTaxShipTaxRate + ",";
            updateCmd = updateCmd + " AmountPaid=" + CSC.AmountPaid + ",";
            updateCmd = updateCmd + " UnpaidAmount=" + CSC.UnpaidAmount + ",";
            updateCmd = updateCmd + " ShipStaff='" + CSC.ShipStaff + "',";
            updateCmd = updateCmd + " PaymentType='" + CSC.PaymentType + "',";
            updateCmd = updateCmd + " Notes='" + CSC.Notes + "'";
            updateCmd = updateCmd + " WHERE ShipID='" + CSC.ShipID + "'";

            transaction = conn.BeginTransaction("MyUpdateTransaction");

            try
            {
                cmd = conn.CreateCommand(); // new SqlCommand(updateCmd, conn);
                cmd.CommandText = updateCmd;
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();

                DBClass.DBClassItemsInfo DBCItemsInfo = new DBClassItemsInfo();
                DBClass.DBClassShipDetails DBCSD = new DBClassShipDetails();

                for (int i = 0; i < CSC.ShipItems.Length; i++)
                {

                    updateCmd2 = "UPDATE " + TableName2 + " SET ";
                    updateCmd2 = updateCmd2 + " ShipID='" + CSC.ShipID + "',";
                    updateCmd2 = updateCmd2 + " ItemsID='" + CSC.ShipItems[i].ItemsID + "',";
                    updateCmd2 = updateCmd2 + " NAME='" + CSC.ShipItems[i].NAME + "',";
                    updateCmd2 = updateCmd2 + " Quantity=" + CSC.ShipItems[i].Quantity + ",";
                    updateCmd2 = updateCmd2 + " ItemsUnit='" + CSC.ShipItems[i].ItemsUnit + "',";
                    updateCmd2 = updateCmd2 + " SellingPrice=" + CSC.ShipItems[i].Price + ",";
                    updateCmd2 = updateCmd2 + " Totals=" + CSC.ShipItems[i].Totals + ",";
                    updateCmd2 = updateCmd2 + " Notes='" + CSC.ShipItems[i].Notes + "'";
                    updateCmd2 = updateCmd2 + " WHERE ShipID='" + CSC.ShipID + "' And ItemsID='" + CSC.ShipItems[i].ItemsID + "'";

                    cmd.CommandText = updateCmd2;
                    cmd.ExecuteNonQuery();

                    int nowQuantity = OLDItems[i].Quantity;
                    if (nowQuantity < CSC.ShipItems[i].Quantity)
                    {
                        DBCItemsInfo.UpdateInventory(CSC.ShipItems[i].ItemsID, -(CSC.ShipItems[i].Quantity - nowQuantity)); //更新商品庫存量
                    }
                    else if (nowQuantity > CSC.ShipItems[i].Quantity)
                    {
                        DBCItemsInfo.UpdateInventory(CSC.ShipItems[i].ItemsID, -(CSC.ShipItems[i].Quantity - nowQuantity)); //更新商品庫存量
                    }
                    else if (nowQuantity == CSC.ShipItems[i].Quantity)
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
        public bool DeleteMasterDetailsData(string PKval , SIS.Configuration.Items[] OLDItems)
        {
            InitDB();
            string delCmd, delCmd2;
            int i = 0;


            delCmd = "Delete From " + TableName + " Where ShipID='" + PKval + "'";

            transaction = conn.BeginTransaction("MyDeleteTransaction");

            try
            {
                cmd = conn.CreateCommand(); // new SqlCommand(updateCmd, conn);
                cmd.CommandText = delCmd;
                cmd.Transaction = transaction;
                i = cmd.ExecuteNonQuery();//若沒有任何資料進行異動,則會回傳0

                delCmd2 = "Delete From " + TableName2 + " Where ShipID='" + PKval + "'";
                cmd.CommandText = delCmd2;
                i = i + cmd.ExecuteNonQuery();//若沒有任何資料進行異動,則會回傳0

                DBClass.DBClassItemsInfo DBCItemsInfo = new DBClassItemsInfo();

                for (int j = 0; j < OLDItems.Length; j++)
                {
                    DBCItemsInfo.UpdateInventory(OLDItems[j].ItemsID, (OLDItems[j].Quantity)); //更新商品庫存量
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

        #region "查詢出貨單單相關資料"

        /// <summary>
        /// 查詢出貨單相關資料
        /// </summary>
        /// <param name="ShipID">傳入出貨單編號</param>
        /// <param name="CSC">傳入存放查詢結果資料的SIS.Configuration.ClsShipConfig CSC</param>
        /// <returns></returns>
        public bool QueryData(string ShipID, SIS.Configuration.ClsShipConfig CSC)
        {
            InitDB();
            string selectCmd;

            selectCmd = "Select * From " + TableName + " Where ShipID='" + ShipID + "'";

            try
            {
                cmd = new SqlCommand(selectCmd, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    CSC.ShipID = ShipID;
                    CSC.ShipDate = dr["ShipDate"].ToString();
                    CSC.TotalPreTax = int.Parse(dr["TotalPreTax"].ToString());
                    CSC.Tax = int.Parse(dr["Tax"].ToString());
                    CSC.TotalAfterTax = int.Parse(dr["TotalAfterTax"].ToString());
                    CSC.CustomerID = dr["CustomerID"].ToString();
                    CSC.BusinessTaxShipTaxRate = int.Parse(dr["BusinessTaxShipTaxRate"].ToString());
                    CSC.AmountPaid = int.Parse(dr["AmountPaid"].ToString());
                    CSC.UnpaidAmount = int.Parse(dr["UnpaidAmount"].ToString());
                    CSC.ShipStaff = dr["ShipStaff"].ToString();
                    CSC.PaymentType = dr["PaymentType"].ToString();
                    CSC.Notes = dr["Notes"].ToString();
                    conn.Close();

                    SIS.DBClass.DBClassShipDetails DBSD = new DBClassShipDetails();

                    CSC.ShipItems = DBSD.QueryData(ShipID);
                    if (CSC.ShipItems == null)
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

        public bool QueryData(string ShipID)
        {
            InitDB();
            string selectCmd;

            selectCmd = "Select * From " + TableName + " Where ShipID='" + ShipID + "'";

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
