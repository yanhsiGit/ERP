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
    class DBClassRMAMaster
    {
        public string TableName = "RMAMaster";
        public string TableName2 = "RMADetails";
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
        /// <param name="CRC">傳入存放更新資料的SIS.Configuration.ClsRMAConfig CRC</param>
        /// <returns></returns>
        public bool InsertData(SIS.Configuration.ClsRMAConfig CRC)
        {
            InitDB();

            string insertCmd, insertCmd2;

            insertCmd = "Insert Into " + TableName + " (RMAID,RMADate,RMAType ,TotalPreTax, Tax,TotalAfterTax,StockIDOrShipID ,BusinessTax ," +
                "AmountPaid ,UnpaidAmount , RMAAmount , Staff , PaymentType ,Notes";

            insertCmd = insertCmd + ") Values(";
            insertCmd = insertCmd + "'" + CRC.RMAID + "',";
            insertCmd = insertCmd + "'" + CRC.RMADate + "',";
            insertCmd = insertCmd + "'" + CRC.RMAType + "',";
            insertCmd = insertCmd + "" + CRC.TotalPreTax + ",";
            insertCmd = insertCmd + "" + CRC.Tax + ",";
            insertCmd = insertCmd + "" + CRC.TotalAfterTax + ",";
            insertCmd = insertCmd + "'" + CRC.StockIDOrShipID + "',";
            insertCmd = insertCmd + "" + CRC.BusinessTax + ",";
            insertCmd = insertCmd + "" + CRC.AmountPaid + ",";
            insertCmd = insertCmd + "" + CRC.UnpaidAmount + ",";
            insertCmd = insertCmd + "" + CRC.RMAAmount  + ",";
            insertCmd = insertCmd + "'" + CRC.Staff + "',";
            insertCmd = insertCmd + "'" + CRC.PaymentType + "',";
            insertCmd = insertCmd + "'" + CRC.Notes + "'";
            insertCmd = insertCmd + ")";

            transaction = conn.BeginTransaction("MyInsertTransaction");

            try
            {
                cmd = conn.CreateCommand(); // new SqlCommand(insertCmd, conn);
                cmd.CommandText = insertCmd;
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();

                DBClass.DBClassItemsInfo DBCItemsInfo = new DBClassItemsInfo();

                for (int i = 0; i < CRC.RMAItems.Length; i++)
                {
                    insertCmd2 = "Insert Into " + TableName2 + " (RMAID ,ItemsID ,NAME ,Quantity ,ItemsUnit ," +
                   "Price ,Totals ,Notes";

                    insertCmd2 = insertCmd2 + ") Values(";
                    insertCmd2 = insertCmd2 + "'" + CRC.RMAID + "',";
                    insertCmd2 = insertCmd2 + "'" + CRC.RMAItems[i].ItemsID + "',";
                    insertCmd2 = insertCmd2 + "'" + CRC.RMAItems[i].NAME + "',";
                    insertCmd2 = insertCmd2 + "" + CRC.RMAItems[i].Quantity + ",";
                    insertCmd2 = insertCmd2 + "'" + CRC.RMAItems[i].ItemsUnit + "',";
                    insertCmd2 = insertCmd2 + "" + CRC.RMAItems[i].Price + ",";
                    insertCmd2 = insertCmd2 + "" + CRC.RMAItems[i].Totals + ",";
                    insertCmd2 = insertCmd2 + "'" + CRC.RMAItems[i].Notes + "'";
                    insertCmd2 = insertCmd2 + ")";

                    cmd.CommandText = insertCmd2;//new SqlCommand(insertCmd2, conn);
                    cmd.ExecuteNonQuery();
                    if (CRC.RMAType =="Customer")
                    {
                        DBCItemsInfo.UpdateInventory(CRC.RMAItems[i].ItemsID, (CRC.RMAItems[i].Quantity)); //更新商品庫存量
                    }
                    else
                    {
                        DBCItemsInfo.UpdateInventory(CRC.RMAItems[i].ItemsID, -(CRC.RMAItems[i].Quantity)); //更新商品庫存量
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
        /// <param name="CRC">傳入存放更新資料的SIS.Configuration.ClsRMAConfig</param>
        /// <param name="OLDItems">傳入更新前的商品集合</param>
        /// <returns></returns>
        public bool Update(SIS.Configuration.ClsRMAConfig CRC, SIS.Configuration.Items[] OLDItems)
        {
            InitDB();

            string updateCmd, updateCmd2;

            updateCmd = "UPDATE " + TableName + " SET ";
            updateCmd = updateCmd + " RMAID='" + CRC.RMAID + "',";
            updateCmd = updateCmd + " RMADate='" + CRC.RMADate + "',";
            updateCmd = updateCmd + " RMAType='" + CRC.RMAType + "',";
            updateCmd = updateCmd + " TotalPreTax=" + CRC.TotalPreTax + ",";
            updateCmd = updateCmd + " Tax=" + CRC.Tax + ",";
            updateCmd = updateCmd + " TotalAfterTax=" + CRC.TotalAfterTax + ",";
            updateCmd = updateCmd + " StockIDOrShipID='" + CRC.StockIDOrShipID + "',";
            updateCmd = updateCmd + " BusinessTax=" + CRC.BusinessTax + ",";
            updateCmd = updateCmd + " AmountPaid=" + CRC.AmountPaid + ",";
            updateCmd = updateCmd + " UnpaidAmount=" + CRC.UnpaidAmount + ",";
            updateCmd = updateCmd + " RMAAmount=" + CRC.RMAAmount + ",";
            updateCmd = updateCmd + " Staff='" + CRC.Staff + "',";
            updateCmd = updateCmd + " PaymentType='" + CRC.PaymentType + "',";
            updateCmd = updateCmd + " Notes='" + CRC.Notes + "'";
            updateCmd = updateCmd + " WHERE RMAID='" + CRC.RMAID + "'";

            transaction = conn.BeginTransaction("MyUpdateTransaction");

            try
            {
                cmd = conn.CreateCommand(); // new SqlCommand(updateCmd, conn);
                cmd.CommandText = updateCmd;
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();

                DBClass.DBClassItemsInfo DBCItemsInfo = new DBClassItemsInfo();
                DBClass.DBClassRMADetails DBCRD = new DBClassRMADetails();

                for (int i = 0; i < CRC.RMAItems.Length; i++)
                {

                    updateCmd2 = "UPDATE " + TableName2 + " SET ";
                    updateCmd2 = updateCmd2 + " RMAID='" + CRC.RMAID + "',";
                    updateCmd2 = updateCmd2 + " ItemsID='" + CRC.RMAItems[i].ItemsID + "',";
                    updateCmd2 = updateCmd2 + " NAME='" + CRC.RMAItems[i].NAME + "',";
                    updateCmd2 = updateCmd2 + " Quantity=" + CRC.RMAItems[i].Quantity + ",";
                    updateCmd2 = updateCmd2 + " ItemsUnit='" + CRC.RMAItems[i].ItemsUnit + "',";
                    updateCmd2 = updateCmd2 + " Price=" + CRC.RMAItems[i].Price + ",";
                    updateCmd2 = updateCmd2 + " Totals=" + CRC.RMAItems[i].Totals + ",";
                    updateCmd2 = updateCmd2 + " Notes='" + CRC.RMAItems[i].Notes + "'";
                    updateCmd2 = updateCmd2 + " WHERE RMAID='" + CRC.RMAID + "' And ItemsID='" + CRC.RMAItems[i].ItemsID + "'";

                    cmd.CommandText = updateCmd2;
                    cmd.ExecuteNonQuery();

                    int nowQuantity = OLDItems[i].Quantity;

                    if (CRC.RMAType == "Customer")
                    {
                        if (nowQuantity < CRC.RMAItems[i].Quantity)
                        {
                            DBCItemsInfo.UpdateInventory(CRC.RMAItems[i].ItemsID, (CRC.RMAItems[i].Quantity - nowQuantity)); //更新商品庫存量
                        }
                        else if (nowQuantity > CRC.RMAItems[i].Quantity)
                        {
                            DBCItemsInfo.UpdateInventory(CRC.RMAItems[i].ItemsID, (CRC.RMAItems[i].Quantity - nowQuantity)); //更新商品庫存量
                        }
                        else if (nowQuantity == CRC.RMAItems[i].Quantity)
                        {
                            //數量一樣不用更新庫存
                        }
                    }
                    else
                    {
                        if (nowQuantity < CRC.RMAItems[i].Quantity)
                        {
                            DBCItemsInfo.UpdateInventory(CRC.RMAItems[i].ItemsID, -(CRC.RMAItems[i].Quantity - nowQuantity)); //更新商品庫存量
                        }
                        else if (nowQuantity > CRC.RMAItems[i].Quantity)
                        {
                            DBCItemsInfo.UpdateInventory(CRC.RMAItems[i].ItemsID, -(CRC.RMAItems[i].Quantity - nowQuantity)); //更新商品庫存量
                        }
                        else if (nowQuantity == CRC.RMAItems[i].Quantity)
                        {
                            //數量一樣不用更新庫存
                        }
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

            delCmd = "Delete From " + TableName + " Where RMAID='" + PKval + "'";

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
        /// <param name="OLDItems">傳入刪除前商品集合</param>
        /// <returns></returns>
        public bool DeleteMasterDetailsData(string PKval, SIS.Configuration.ClsRMAConfig OLDCRC)
        {
            InitDB();
            string delCmd, delCmd2;
            int i = 0;


            delCmd = "Delete From " + TableName + " Where RMAID='" + PKval + "'";

            transaction = conn.BeginTransaction("MyDeleteTransaction");

            try
            {
                cmd = conn.CreateCommand(); // new SqlCommand(updateCmd, conn);
                cmd.CommandText = delCmd;
                cmd.Transaction = transaction;
                i = cmd.ExecuteNonQuery();//若沒有任何資料進行異動,則會回傳0

                delCmd2 = "Delete From " + TableName2 + " Where RMAID='" + PKval + "'";
                cmd.CommandText = delCmd2;
                i = i + cmd.ExecuteNonQuery();//若沒有任何資料進行異動,則會回傳0

                DBClass.DBClassItemsInfo DBCItemsInfo = new DBClassItemsInfo();

                for (int j = 0; j < OLDCRC.RMAItems.Length; j++)
                {
                    if (OLDCRC.RMAType =="Customer")
                    {
                        DBCItemsInfo.UpdateInventory(OLDCRC.RMAItems[j].ItemsID, -(OLDCRC.RMAItems[j].Quantity)); //更新商品庫存量
                    }
                    else
                    {
                        DBCItemsInfo.UpdateInventory(OLDCRC.RMAItems[j].ItemsID, (OLDCRC.RMAItems[j].Quantity)); //更新商品庫存量
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

        #region "查詢退貨單相關資料"

        /// <summary>
        /// 查詢退貨單相關資料
        /// </summary>
        /// <param name="RMAID">傳入退貨單編號</param>
        /// <param name="CRC">傳入存放查詢結果資料的SIS.Configuration.ClsRMAConfig CRC</param>
        /// <returns></returns>
        public bool QueryData(string RMAID, SIS.Configuration.ClsRMAConfig CRC)
        {
            InitDB();
            string selectCmd;

            selectCmd = "Select * From " + TableName + " Where RMAID='" + RMAID + "'";

            try
            {
                cmd = new SqlCommand(selectCmd, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    CRC.RMAID = RMAID;
                    CRC.RMADate = dr["RMADate"].ToString();
                    CRC.RMAType = dr["RMAType"].ToString();
                    CRC.TotalPreTax = int.Parse(dr["TotalPreTax"].ToString());
                    CRC.Tax = int.Parse(dr["Tax"].ToString());
                    CRC.TotalAfterTax = int.Parse(dr["TotalAfterTax"].ToString());
                    CRC.StockIDOrShipID = dr["StockIDOrShipID"].ToString();
                    CRC.BusinessTax = int.Parse(dr["BusinessTax"].ToString());
                    CRC.AmountPaid = int.Parse(dr["AmountPaid"].ToString());
                    CRC.UnpaidAmount = int.Parse(dr["UnpaidAmount"].ToString());
                    CRC.RMAAmount = int.Parse(dr["RMAAmount"].ToString());
                    CRC.Staff = dr["Staff"].ToString();
                    CRC.PaymentType = dr["PaymentType"].ToString();
                    CRC.Notes = dr["Notes"].ToString();
                    conn.Close();

                    SIS.DBClass.DBClassRMADetails DBRD = new DBClassRMADetails();

                    CRC.RMAItems = DBRD.QueryData(RMAID);
                    if (CRC.RMAItems == null)
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

        public bool QueryData(string RMAID)
        {
            InitDB();
            string selectCmd;

            selectCmd = "Select * From " + TableName + " Where RMAID='" + RMAID + "'";

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
