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
    class DBClassReversal
    {
        public string TableName = "Reversal";
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
        /// <param name="CRC">傳入存放更新資料的SIS.Configuration.ClsReversalConfig</param>
        /// <returns></returns>
        public bool InsertData(SIS.Configuration.ClsReversalConfig  CRC)
        {
            InitDB();

            string insertCmd;

            insertCmd = "Insert Into " + TableName + " (ReversalID,ReversalDate,ReversalStaff,ReversalType,CustomerOrManufacturer,StockIDOrShipID,PaymentAmount,ReversalAmount,IsReversal,PaymentType,Notes";

            insertCmd = insertCmd + ") Values(";
            insertCmd = insertCmd + "'" + CRC.ReversalID  + "',";
            insertCmd = insertCmd + "'" + CRC.ReversalDate + "',";
            insertCmd = insertCmd + "'" + CRC.ReversalStaff + "',";
            insertCmd = insertCmd + "'" + CRC.ReversalType + "',";
            insertCmd = insertCmd + "'" + CRC.CustomerOrManufacturer + "',";
            insertCmd = insertCmd + "'" + CRC.StockIDOrShipID + "',";
            insertCmd = insertCmd + "" + CRC.PaymentAmount + ",";
            insertCmd = insertCmd + "" + CRC.ReversalAmount + ",";
            insertCmd = insertCmd + "'" + CRC.IsReversal + "',";
            insertCmd = insertCmd + "'" + CRC.PaymentType + "',";
            insertCmd = insertCmd + "'" + CRC.Notes + "'";
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
        /// <param name="CRC">傳入存放更新資料的SIS.Configuration.ClsCompanyConfig</param>
        /// <returns></returns>
        public bool Update(SIS.Configuration.ClsReversalConfig CRC)
        {
            InitDB();

            string updateCmd;

            updateCmd = "UPDATE " + TableName + " SET ";
            updateCmd = updateCmd + " ReversalID='" + CRC.ReversalID + "',";
            updateCmd = updateCmd + " ReversalDate='" + CRC.ReversalDate + "',";
            updateCmd = updateCmd + " ReversalStaff='" + CRC.ReversalStaff + "',";
            updateCmd = updateCmd + " ReversalType='" + CRC.ReversalType + "',";
            updateCmd = updateCmd + " CustomerOrManufacturer='" + CRC.CustomerOrManufacturer + "',";
            updateCmd = updateCmd + " StockIDOrShipID='" + CRC.StockIDOrShipID + "',";
            updateCmd = updateCmd + " PaymentAmount=" + CRC.PaymentAmount + ",";
            updateCmd = updateCmd + " ReversalAmount=" + CRC.ReversalAmount + ",";
            updateCmd = updateCmd + " IsReversal='" + CRC.IsReversal + "',";
            updateCmd = updateCmd + " PaymentType='" + CRC.PaymentType + "',";
            updateCmd = updateCmd + " Notes='" + CRC.Notes + "'";
            updateCmd = updateCmd + " WHERE ReversalID='" + CRC.ReversalID + "'";

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


            delCmd = "Delete From " + TableName + " Where ReversalID='" + PKval + "'";

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


        #region "查詢沖銷單相關資料"

        public bool QueryData(string ReversalID, SIS.Configuration.ClsReversalConfig CRC)
        {
            InitDB();
            string selectCmd;

            selectCmd = "Select * From " + TableName + " Where ReversalID='" + ReversalID + "'";

            try
            {
                cmd = new SqlCommand(selectCmd, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    CRC.ReversalID = ReversalID;
                    CRC.ReversalDate = dr["ReversalDate"].ToString();
                    CRC.ReversalStaff = dr["ReversalStaff"].ToString();
                    CRC.ReversalType = dr["ReversalType"].ToString();
                    CRC.CustomerOrManufacturer = dr["CustomerOrManufacturer"].ToString();
                    CRC.StockIDOrShipID = dr["StockIDOrShipID"].ToString();
                    CRC.PaymentAmount = int.Parse(dr["PaymentAmount"].ToString());
                    CRC.ReversalAmount = int.Parse(dr["ReversalAmount"].ToString());
                    CRC.IsReversal = bool.Parse(dr["IsReversal"].ToString());
                    CRC.PaymentType = dr["PaymentType"].ToString();
                    CRC.Notes = dr["Notes"].ToString();
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

        public bool QueryData(string ReversalID)
        {
            InitDB();
            string selectCmd;

            selectCmd = "Select * From " + TableName + " Where ReversalID='" + ReversalID + "'";

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
