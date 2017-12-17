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
    class DBClassTakeStockMaster
    {
        public string TableName = "TakeStockMaster";
        public string TableName2 = "TakeStockDetails";
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
        /// <param name="CTSC">傳入存放更新資料的SIS.Configuration.ClsTakeStockConfig CTSC</param>
        /// <returns></returns>
        public bool InsertData(SIS.Configuration.ClsTakeStockConfig  CTSC)
        {
            InitDB();

            string insertCmd, insertCmd2;

            insertCmd = "Insert Into " + TableName + " (TakeStockID,TakeStockDate,TakeStockStaff ,Notes";

            insertCmd = insertCmd + ") Values(";
            insertCmd = insertCmd + "'" + CTSC.TakeStockID + "',";
            insertCmd = insertCmd + "'" + CTSC.TakeStockDate + "',";
            insertCmd = insertCmd + "'" + CTSC.TakeStockStaff  + "',";
            insertCmd = insertCmd + "'" + CTSC.Notes + "'";
            insertCmd = insertCmd + ")";

            transaction = conn.BeginTransaction("MyInsertTransaction");

            try
            {
                cmd = conn.CreateCommand(); // new SqlCommand(insertCmd, conn);
                cmd.CommandText = insertCmd;
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();


                for (int i = 0; i < CTSC.TakeStockItems.Length; i++)
                {
                    insertCmd2 = "Insert Into " + TableName2 + " (TakeStockID ,ItemsID ,NAME ,Inventory ,TakeStockInventory ,GainLossInventory ," +
                    "IsTakeStock,ItemsUnit ,Price ,Totals ,Notes";

                    insertCmd2 = insertCmd2 + ") Values(";
                    insertCmd2 = insertCmd2 + "'" + CTSC.TakeStockID + "',";
                    insertCmd2 = insertCmd2 + "'" + CTSC.TakeStockItems[i].ItemsID + "',";
                    insertCmd2 = insertCmd2 + "'" + CTSC.TakeStockItems[i].NAME + "',";
                    insertCmd2 = insertCmd2 + "" + CTSC.TakeStockItems[i].Inventory + ",";
                    insertCmd2 = insertCmd2 + "" + CTSC.TakeStockItems[i].TakeStockInventory  + ",";
                    insertCmd2 = insertCmd2 + "" + CTSC.TakeStockItems[i].GainLossInventory + ",";
                    insertCmd2 = insertCmd2 + "'" + CTSC.TakeStockItems[i].IsTakeStock + "',";
                    insertCmd2 = insertCmd2 + "'" + CTSC.TakeStockItems[i].ItemsUnit + "',";
                    insertCmd2 = insertCmd2 + "" + CTSC.TakeStockItems[i].Price + ",";
                    insertCmd2 = insertCmd2 + "" + CTSC.TakeStockItems[i].Totals + ",";
                    insertCmd2 = insertCmd2 + "'" + CTSC.TakeStockItems[i].Notes + "'";
                    insertCmd2 = insertCmd2 + ")";

                    cmd.CommandText = insertCmd2;//new SqlCommand(insertCmd2, conn);
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
        /// <param name="CTSC">傳入存放更新資料的SIS.Configuration.ClsTakeStockConfig  CTSC</param>
        /// <returns></returns>
        public bool Update(SIS.Configuration.ClsTakeStockConfig CTSC)
        {
            InitDB();

            string updateCmd, updateCmd2;

            updateCmd = "UPDATE " + TableName + " SET ";
            updateCmd = updateCmd + " TakeStockID='" + CTSC.TakeStockID + "',";
            updateCmd = updateCmd + " TakeStockDate='" + CTSC.TakeStockDate + "',";
            updateCmd = updateCmd + " TakeStockStaff='" + CTSC.TakeStockStaff + "',";
            updateCmd = updateCmd + " Notes='" + CTSC.Notes + "'";
            updateCmd = updateCmd + " WHERE TakeStockID='" + CTSC.TakeStockID + "'";

            transaction = conn.BeginTransaction("MyUpdateTransaction");

            try
            {
                cmd = conn.CreateCommand(); // new SqlCommand(updateCmd, conn);
                cmd.CommandText = updateCmd;
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();


                for (int i = 0; i < CTSC.TakeStockItems.Length; i++)
                {

                    updateCmd2 = "UPDATE " + TableName2 + " SET ";
                    updateCmd2 = updateCmd2 + " TakeStockID='" + CTSC.TakeStockID + "',";
                    updateCmd2 = updateCmd2 + " ItemsID='" + CTSC.TakeStockItems[i].ItemsID + "',";
                    updateCmd2 = updateCmd2 + " NAME='" + CTSC.TakeStockItems[i].NAME + "',";
                    updateCmd2 = updateCmd2 + " Inventory=" + CTSC.TakeStockItems[i].Inventory + ",";
                    updateCmd2 = updateCmd2 + " TakeStockInventory=" + CTSC.TakeStockItems[i].TakeStockInventory + ",";
                    updateCmd2 = updateCmd2 + " GainLossInventory=" + CTSC.TakeStockItems[i].GainLossInventory + ",";
                    updateCmd2 = updateCmd2 + " IsTakeStock='" + CTSC.TakeStockItems[i].IsTakeStock + "',";
                    updateCmd2 = updateCmd2 + " ItemsUnit='" + CTSC.TakeStockItems[i].ItemsUnit + "',";
                    updateCmd2 = updateCmd2 + " Price=" + CTSC.TakeStockItems[i].Price + ",";
                    updateCmd2 = updateCmd2 + " Totals=" + CTSC.TakeStockItems[i].Totals + ",";
                    updateCmd2 = updateCmd2 + " Notes='" + CTSC.TakeStockItems[i].Notes + "'";
                    updateCmd2 = updateCmd2 + " WHERE TakeStockID='" + CTSC.TakeStockID + "' And ItemsID='" + CTSC.TakeStockItems[i].ItemsID + "'";

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
            string delCmd;
            int i = 0;

            delCmd = "Delete From " + TableName + " Where TakeStockID='" + PKval + "'";

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
            string delCmd, delCmd2;
            int i = 0;


            delCmd = "Delete From " + TableName + " Where TakeStockID='" + PKval + "'";

            transaction = conn.BeginTransaction("MyDeleteTransaction");

            try
            {
                cmd = conn.CreateCommand(); // new SqlCommand(updateCmd, conn);
                cmd.CommandText = delCmd;
                cmd.Transaction = transaction;
                i = cmd.ExecuteNonQuery();//若沒有任何資料進行異動,則會回傳0

                delCmd2 = "Delete From " + TableName2 + " Where TakeStockID='" + PKval + "'";
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

        #region "查詢盤點單單相關資料"

        /// <summary>
        /// 查詢盤點單相關資料
        /// </summary>
        /// <param name="TakeStockID">傳入盤點單編號</param>
        /// <param name="CTSC">SIS.Configuration.ClsTakeStockConfig CTSC</param>
        /// <returns></returns>
        public bool QueryData(string TakeStockID, SIS.Configuration.ClsTakeStockConfig CTSC)
        {
            InitDB();
            string selectCmd;

            selectCmd = "Select * From " + TableName + " Where TakeStockID='" + TakeStockID + "'";

            try
            {
                cmd = new SqlCommand(selectCmd, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    CTSC.TakeStockID = TakeStockID;
                    CTSC.TakeStockDate = dr["TakeStockDate"].ToString();
                    CTSC.TakeStockStaff = dr["TakeStockStaff"].ToString();
                    CTSC.Notes = dr["Notes"].ToString();
                    conn.Close();

                    SIS.DBClass.DBClassTakeStockDetails DBTSD = new DBClassTakeStockDetails();

                    CTSC.TakeStockItems = DBTSD.QueryData(TakeStockID);
                    if (CTSC.TakeStockItems == null)
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


        public bool QueryData(string TakeStockID)
        {
            InitDB();
            string selectCmd;

            selectCmd = "Select * From " + TableName + " Where TakeStockID='" + TakeStockID + "'";

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
