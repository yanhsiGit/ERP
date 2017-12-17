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
    class DBClassCustomerInfo
    {
        public string TableName = "CustomerInfo";
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



        /// <summary>
        /// 新增一筆資料-新增圖片用
        /// </summary>
        /// <param name="ClsCustomerConfig"></param>
        /// <returns></returns>
        public bool ParameterInsertData(SIS.Configuration.ClsCustomerConfig CCC)
        {

            InitDB();

            string insertCmd = null;

            insertCmd = "INSERT INTO " + TableName + " (CustomerID,CNAME,ENAME,Photos,Birthday,CustomerType,Phone,MobilePhone,Fax,Address,Notes) VALUES (@CustomerID,@CNAME,@ENAME,@Photos,@Birthday,@CustomerType,@Phone,@MobilePhone,@Fax,@Address,@Notes)";


            try
            {
                cmd = new SqlCommand(insertCmd, conn);
                cmd.Parameters.Add(new SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 20));
                cmd.Parameters.Add(new SqlParameter("@CNAME", System.Data.SqlDbType.NVarChar, 10));
                cmd.Parameters.Add(new SqlParameter("@ENAME", System.Data.SqlDbType.NVarChar, 30));
                cmd.Parameters.Add(new SqlParameter("@Photos", System.Data.SqlDbType.Image));
                cmd.Parameters.Add(new SqlParameter("@Birthday", System.Data.SqlDbType.NVarChar, 12));
                cmd.Parameters.Add(new SqlParameter("@CustomerType", System.Data.SqlDbType.NVarChar, 5));
                cmd.Parameters.Add(new SqlParameter("@Phone", System.Data.SqlDbType.NVarChar, 10));
                cmd.Parameters.Add(new SqlParameter("@MobilePhone", System.Data.SqlDbType.NVarChar, 10));
                cmd.Parameters.Add(new SqlParameter("@Fax", System.Data.SqlDbType.NVarChar, 10));
                cmd.Parameters.Add(new SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@Notes", System.Data.SqlDbType.NVarChar, -1)); //Size set -1 eqal Max

                cmd.Parameters["@CustomerID"].Value = CCC.CustomerID;
                cmd.Parameters["@CNAME"].Value = CCC.CNAME;
                cmd.Parameters["@ENAME"].Value = CCC.ENAME;
                cmd.Parameters["@Photos"].Value = CCC.Photos;
                cmd.Parameters["@Birthday"].Value = CCC.Birthday;
                cmd.Parameters["@CustomerType"].Value = CCC.CustomerType;
                cmd.Parameters["@Phone"].Value = CCC.Phone;
                cmd.Parameters["@MobilePhone"].Value = CCC.MobilePhone;
                cmd.Parameters["@Fax"].Value = CCC.Fax;
                cmd.Parameters["@Address"].Value = CCC.Address;
                cmd.Parameters["@Notes"].Value = CCC.Notes;
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


        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="CCC">傳入SIS.Configuration.ClsCustomerConfig</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool ParameterUpdateData(SIS.Configuration.ClsCustomerConfig CCC)
        {

            InitDB();

            string updateCmd = null;
            int i = 0;

            updateCmd = "UPDATE " + TableName + " SET CustomerID=@CustomerID ," + 
                "CNAME=@CNAME , " + 
                "ENAME = @ENAME , " + 
                "Photos = @Photos , " + 
                "Birthday = @Birthday ," + 
                "CustomerType = @CustomerType ," +
                "Phone=@Phone , " +
                "MobilePhone = @MobilePhone ," +
                "Fax = @Fax ," +
                "Address=@Address , " +
                "Notes = @Notes " +
                " WHERE (CustomerID =" + " @Original_CustomerID)";

            try
            {


                cmd = new SqlCommand(updateCmd, conn);
                cmd.Parameters.Add(new SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 0, "CustomerID"));
                cmd.Parameters.Add(new SqlParameter("@CNAME", System.Data.SqlDbType.NVarChar, 0, "CNAME"));
                cmd.Parameters.Add(new SqlParameter("@ENAME", System.Data.SqlDbType.NVarChar, 0, "ENAME"));
                cmd.Parameters.Add(new SqlParameter("@Photos", System.Data.SqlDbType.Image, 0, "Photos"));
                cmd.Parameters.Add(new SqlParameter("@Birthday", System.Data.SqlDbType.NVarChar, 0, "Birthday"));
                cmd.Parameters.Add(new SqlParameter("@CustomerType", System.Data.SqlDbType.NVarChar, 0, "CustomerType"));
                cmd.Parameters.Add(new SqlParameter("@Phone", System.Data.SqlDbType.NVarChar, 0, "Phone"));
                cmd.Parameters.Add(new SqlParameter("@MobilePhone", System.Data.SqlDbType.NVarChar, 0, "MobilePhone"));
                cmd.Parameters.Add(new SqlParameter("@Fax", System.Data.SqlDbType.NVarChar, 0, "Fax"));
                cmd.Parameters.Add(new SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 0, "Address"));
                cmd.Parameters.Add(new SqlParameter("@Notes", System.Data.SqlDbType.NVarChar, 0, "Notes"));
                cmd.Parameters.Add(new SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 0, "CustomerID"));
                cmd.Parameters["@Original_CustomerID"].SourceVersion = DataRowVersion.Original;

                cmd.Parameters["@CustomerID"].Value = CCC.CustomerID;
                cmd.Parameters["@CNAME"].Value = CCC.CNAME;
                cmd.Parameters["@ENAME"].Value = CCC.ENAME;
                cmd.Parameters["@Photos"].Value = CCC.Photos;
                cmd.Parameters["@Birthday"].Value = CCC.Birthday;
                cmd.Parameters["@CustomerType"].Value = CCC.CustomerType;
                cmd.Parameters["@Phone"].Value = CCC.Phone;
                cmd.Parameters["@MobilePhone"].Value = CCC.MobilePhone;
                cmd.Parameters["@Fax"].Value = CCC.Fax;
                cmd.Parameters["@Address"].Value = CCC.Address;
                cmd.Parameters["@Notes"].Value = CCC.Notes;
                cmd.Parameters["@Original_CustomerID"].Value = CCC.CustomerID;
                i = cmd.ExecuteNonQuery();
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
                conn.Close();
                errorMsg = ex.Message;
                return false;

            }


        }




        /// <summary>
        /// 參數方式更新資料for Photo二進位格式專用
        /// </summary>
        /// <param name="ArrField">傳入ArrayList</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool ParameterUpdateData(ArrayList ArrField)
        {

            InitDB();

            string updateCmd = null;
            int i = 0;
            updateCmd = "UPDATE " + TableName + " SET CustomerID=@CustomerID , Photos = @Photos" + " WHERE (CustomerID =" + " @Original_CustomerID)";

            try
            {
                cmd = new SqlCommand(updateCmd, conn);
                cmd.Parameters.Add(new SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 0, "CustomerID"));
                cmd.Parameters.Add(new SqlParameter("@Photos", System.Data.SqlDbType.Image, 0, "Photos"));
                cmd.Parameters.Add(new SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 0, "CustomerID"));
                cmd.Parameters["@Original_CustomerID"].SourceVersion = DataRowVersion.Original;
                cmd.Parameters["@CustomerID"].Value = ArrField[0];
                cmd.Parameters["@Photos"].Value = ArrField[1];
                cmd.Parameters["@Original_CustomerID"].Value = ArrField[0];
                i = cmd.ExecuteNonQuery();
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
                conn.Close();
                errorMsg = ex.Message;
                return false;
            }
        }


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


            delCmd = "Delete From " + TableName + " Where CustomerID='" + PKval + "'";

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


        public string QueryData(string CustomerID, string GetFieldName)
        {
            InitDB();
            string selectCmd;
            string result = "";

            selectCmd = "Select " + GetFieldName + " From " + TableName + " Where CustomerID='" + CustomerID + "'";

            try
            {
                cmd = new SqlCommand(selectCmd, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    result = dr[GetFieldName].ToString();
                    conn.Close();
                    return result;
                }
                else
                {
                    conn.Close();
                    return result;
                }

            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                conn.Close();
                return result;
            }
        }


    }
}
