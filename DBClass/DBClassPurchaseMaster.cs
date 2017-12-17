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
    class DBClassPurchaseMaster
    {
        public string TableName = "PurchaseMaster";
        public string TableName2 = "PurchaseDetails";
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
        /// <param name="CPC">傳入存放更新資料的SIS.Configuration.ClsPurchaseConfig</param>
        /// <returns></returns>
        public bool InsertData(SIS.Configuration.ClsPurchaseConfig CPC)
        {
            InitDB();

            string insertCmd , insertCmd2;

            insertCmd = "Insert Into " + TableName + " (PurchaseID,PurchaseDate ,DeliveryDate ,ManufacturerID ,PurchaseStaff ," + 
                "PurchasePhone , DeliveryAddress ,PaymentType ,BusinessTaxStockTaxRate ,TotalPreTax, Tax,TotalAfterTax ,Notes";

            insertCmd = insertCmd + ") Values(";
            insertCmd = insertCmd + "'" +CPC.PurchaseID + "',";
            insertCmd = insertCmd + "'" + CPC.PurchaseDate + "',";
            insertCmd = insertCmd + "'" + CPC.DeliveryDate  + "',";
            insertCmd = insertCmd + "'" + CPC.ManufacturerID + "',";
            insertCmd = insertCmd + "'" + CPC.PurchaseStaff + "',";
            insertCmd = insertCmd + "'" + CPC.PurchasePhone + "',";
            insertCmd = insertCmd + "'" + CPC.DeliveryAddress + "',";
            insertCmd = insertCmd + "'" + CPC.PaymentType  + "',";
            insertCmd = insertCmd + "" + CPC.BusinessTaxStockTaxRate + ",";
            insertCmd = insertCmd + "" + CPC.TotalPreTax  + ",";
            insertCmd = insertCmd + "" + CPC.Tax + ",";
            insertCmd = insertCmd + "" + CPC.TotalAfterTax + ",";
            insertCmd = insertCmd + "'" + CPC.Notes + "'";
            insertCmd = insertCmd + ")";

            transaction = conn.BeginTransaction("MyInsertTransaction");

            try
            {
                cmd = conn.CreateCommand(); // new SqlCommand(insertCmd, conn);
                cmd.CommandText = insertCmd;
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();

                for(int i=0;i< CPC.PurchaseItems.Length ;i++)
                {
                    insertCmd2 = "Insert Into " + TableName2 + " (PurchaseID,ItemsID ,NAME ,Quantity ,ItemsUnit ," +
                   "CostPrice , Totals ,Notes";

                    insertCmd2 = insertCmd2 + ") Values(";
                    insertCmd2 = insertCmd2 + "'" + CPC.PurchaseID + "',";
                    insertCmd2=  insertCmd2 + "'" + CPC.PurchaseItems[i].ItemsID + "',";
                    insertCmd2 = insertCmd2 + "'" + CPC.PurchaseItems[i].NAME + "',";
                    insertCmd2 = insertCmd2 + "" + CPC.PurchaseItems[i].Quantity + ",";
                    insertCmd2 = insertCmd2 + "'" + CPC.PurchaseItems[i].ItemsUnit + "',";
                    insertCmd2 = insertCmd2 + "" + CPC.PurchaseItems[i].Price + ",";
                    insertCmd2 = insertCmd2 + "" + CPC.PurchaseItems[i].Totals + ",";
                    insertCmd2 = insertCmd2 + "'" + CPC.PurchaseItems[i].Notes + "'";
                    insertCmd2 = insertCmd2 + ")";

                    cmd.CommandText = insertCmd2 ;//new SqlCommand(insertCmd2, conn);
                    cmd.ExecuteNonQuery();
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
        /// <param name="CPC">傳入存放更新資料的SIS.Configuration.ClsPurchaseConfig CPC</param>
        /// <returns></returns>
        public bool Update(SIS.Configuration.ClsPurchaseConfig CPC)
        {
            InitDB();

            string updateCmd, updateCmd2;

            updateCmd = "UPDATE " + TableName + " SET ";
            updateCmd = updateCmd + " PurchaseID='" + CPC.PurchaseID + "',";
            updateCmd = updateCmd + " PurchaseDate='" + CPC.PurchaseDate + "',";
            updateCmd = updateCmd + " DeliveryDate='" + CPC.DeliveryDate + "',";
            updateCmd = updateCmd + " ManufacturerID='" + CPC.ManufacturerID + "',";
            updateCmd = updateCmd + " PurchaseStaff='" + CPC.PurchaseStaff + "',";
            updateCmd = updateCmd + " PurchasePhone='" + CPC.PurchasePhone + "',";
            updateCmd = updateCmd + " DeliveryAddress='" + CPC.DeliveryAddress + "',";
            updateCmd = updateCmd + " PaymentType='" + CPC.PaymentType + "',";
            updateCmd = updateCmd + " BusinessTaxStockTaxRate=" + CPC.BusinessTaxStockTaxRate + ",";
            updateCmd = updateCmd + " TotalPreTax=" + CPC.TotalPreTax + ",";
            updateCmd = updateCmd + " Tax=" + CPC.Tax + ",";
            updateCmd = updateCmd + " TotalAfterTax=" + CPC.TotalAfterTax + ",";
            updateCmd = updateCmd + " Notes='" + CPC.Notes + "'";
            updateCmd = updateCmd + " WHERE PurchaseID='" + CPC.PurchaseID + "'";

            transaction = conn.BeginTransaction("MyUpdateTransaction");

            try
            {
                cmd = conn.CreateCommand(); // new SqlCommand(updateCmd, conn);
                cmd.CommandText = updateCmd;
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();


                for (int i = 0; i < CPC.PurchaseItems.Length; i++)
                {

                    updateCmd2 = "UPDATE " + TableName2 + " SET ";
                    updateCmd2 = updateCmd2 + " PurchaseID='" + CPC.PurchaseID + "',";
                    updateCmd2 = updateCmd2 + " ItemsID='" + CPC.PurchaseItems[i].ItemsID + "',";
                    updateCmd2 = updateCmd2 + " NAME='" + CPC.PurchaseItems[i].NAME + "',";
                    updateCmd2 = updateCmd2 + " Quantity=" + CPC.PurchaseItems[i].Quantity + ",";
                    updateCmd2 = updateCmd2 + " ItemsUnit='" + CPC.PurchaseItems[i].ItemsUnit + "',";
                    updateCmd2 = updateCmd2 + " CostPrice=" + CPC.PurchaseItems[i].Price + ",";
                    updateCmd2 = updateCmd2 + " Totals=" + CPC.PurchaseItems[i].Totals + ",";
                    updateCmd2 = updateCmd2 + " Notes='" + CPC.PurchaseItems[i].Notes + "'";
                    updateCmd2 = updateCmd2 + " WHERE PurchaseID='" + CPC.PurchaseID + "' And ItemsID='" + CPC.PurchaseItems[i].ItemsID +"'";

                    cmd.CommandText = updateCmd2;
                    cmd.ExecuteNonQuery();
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
            string delCmd ;
            int i = 0;

            delCmd = "Delete From " + TableName + " Where PurchaseID='" + PKval + "'";

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
        /// <returns></returns>
        public bool DeleteMasterDetailsData(string PKval)
        {
            InitDB();
            string delCmd , delCmd2;
            int i = 0;


            delCmd = "Delete From " + TableName + " Where PurchaseID='" + PKval + "'";

            transaction = conn.BeginTransaction("MyDeleteTransaction");

            try
            {
                cmd = conn.CreateCommand(); // new SqlCommand(updateCmd, conn);
                cmd.CommandText = delCmd;
                cmd.Transaction = transaction;
                i = cmd.ExecuteNonQuery();//若沒有任何資料進行異動,則會回傳0

                delCmd2 = "Delete From " + TableName2 + " Where PurchaseID='" + PKval + "'";
                cmd.CommandText = delCmd2;
                i = i + cmd.ExecuteNonQuery();//若沒有任何資料進行異動,則會回傳0


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

        #region "查詢採購單相關資料"

 /// <summary>
        /// 查詢採購單相關資料
 /// </summary>
 /// <param name="PurchaseID">傳入採購單編號</param>
        /// <param name="CPC">傳入存放查詢結果資料的SIS.Configuration.ClsPurchaseConfig CPC</param>
 /// <returns></returns>
        public bool QueryData(string PurchaseID, SIS.Configuration.ClsPurchaseConfig CPC)
        {
            InitDB();
            string selectCmd ;

            selectCmd = "Select * From " + TableName + " Where PurchaseID='" + PurchaseID + "'";

            try
            {
                cmd = new SqlCommand(selectCmd, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    CPC.PurchaseID = PurchaseID;
                    CPC.PurchaseDate = dr["PurchaseDate"].ToString();
                    CPC.DeliveryDate = dr["DeliveryDate"].ToString();
                    CPC.ManufacturerID = dr["ManufacturerID"].ToString();
                    CPC.PurchaseStaff = dr["PurchaseStaff"].ToString();
                    CPC.PurchasePhone = dr["PurchasePhone"].ToString();
                    CPC.DeliveryAddress = dr["DeliveryAddress"].ToString();
                    CPC.PaymentType = dr["PaymentType"].ToString();
                    CPC.BusinessTaxStockTaxRate = int.Parse(dr["BusinessTaxStockTaxRate"].ToString());
                    CPC.TotalPreTax = int.Parse(dr["TotalPreTax"].ToString());
                    CPC.Tax = int.Parse(dr["Tax"].ToString());
                    CPC.TotalAfterTax = int.Parse(dr["TotalAfterTax"].ToString());
                    CPC.Notes = dr["Notes"].ToString();
                    conn.Close();
                 
                    SIS.DBClass.DBClassPurchaseDetails DBPD = new DBClassPurchaseDetails();

                    CPC.PurchaseItems = DBPD.QueryData(PurchaseID);
                    if (CPC.PurchaseItems ==null)
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

        public bool QueryData(string PurchaseID)
        {
            InitDB();
            string selectCmd;

            selectCmd = "Select * From " + TableName + " Where PurchaseID='" + PurchaseID + "'";

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
