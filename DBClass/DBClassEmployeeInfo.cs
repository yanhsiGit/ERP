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
    class DBClassEmployeeInfo
    {

        public string TableName = "EmployeeInfo";
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
/// <param name="ClsEmployeeConfig"></param>
/// <returns></returns>
        public bool ParameterInsertData(SIS.Configuration.ClsEmployeeConfig CEC)
        {

            InitDB();

            string insertCmd = null;

            insertCmd = "INSERT INTO " + TableName + " (EmployeeID,CNAME,ENAME,Photos,Sex,Birthday,BooldType,ID,PresentAddress,Professional,HireDate,Positions,Background,Phone,Status) VALUES (@EmployeeID,@CNAME,@ENAME,@Photos,@Sex,@Birthday,@BooldType,@ID,@PresentAddress,@Professional,@HireDate,@Positions,@Background,@Phone,@Status)";


            try
            {
                    cmd = new SqlCommand(insertCmd, conn);
                    cmd.Parameters.Add(new SqlParameter("@EmployeeID", System.Data.SqlDbType.NVarChar, 20));
                    cmd.Parameters.Add(new SqlParameter("@CNAME", System.Data.SqlDbType.NVarChar, 10));
                    cmd.Parameters.Add(new SqlParameter("@ENAME", System.Data.SqlDbType.NVarChar, 30));
                    cmd.Parameters.Add(new SqlParameter("@Photos", System.Data.SqlDbType.Image));
                    cmd.Parameters.Add(new SqlParameter("@Sex", System.Data.SqlDbType.NVarChar, 2));
                    cmd.Parameters.Add(new SqlParameter("@Birthday", System.Data.SqlDbType.NVarChar, 12));
                    cmd.Parameters.Add(new SqlParameter("@BooldType", System.Data.SqlDbType.NVarChar, 5));
                    cmd.Parameters.Add(new SqlParameter("@ID", System.Data.SqlDbType.NVarChar, 10));
                    cmd.Parameters.Add(new SqlParameter("@PresentAddress", System.Data.SqlDbType.NVarChar, 100));
                    cmd.Parameters.Add(new SqlParameter("@Professional", System.Data.SqlDbType.NVarChar, 30));
                    cmd.Parameters.Add(new SqlParameter("@HireDate", System.Data.SqlDbType.NVarChar, 12));
                    cmd.Parameters.Add(new SqlParameter("@Positions", System.Data.SqlDbType.NVarChar, 20));
                    cmd.Parameters.Add(new SqlParameter("@Background", System.Data.SqlDbType.NVarChar, 100));
                    cmd.Parameters.Add(new SqlParameter("@Phone", System.Data.SqlDbType.NVarChar, 20));
                    cmd.Parameters.Add(new SqlParameter("@Status", System.Data.SqlDbType.NVarChar, 2));

                    cmd.Parameters["@EmployeeID"].Value = CEC.EmployeeID;
                    cmd.Parameters["@CNAME"].Value = CEC.CNAME;
                    cmd.Parameters["@ENAME"].Value = CEC.ENAME;
                    cmd.Parameters["@Photos"].Value = CEC.Photos;
                    cmd.Parameters["@Sex"].Value = CEC.Sex;
                    cmd.Parameters["@Birthday"].Value = CEC.Birthday;
                    cmd.Parameters["@BooldType"].Value = CEC.BooldType;
                    cmd.Parameters["@ID"].Value = CEC.ID;
                    cmd.Parameters["@PresentAddress"].Value = CEC.PresentAddress;
                    cmd.Parameters["@Professional"].Value = CEC.Professional;
                    cmd.Parameters["@HireDate"].Value = CEC.HireDate;
                    cmd.Parameters["@Positions"].Value = CEC.Positions;
                    cmd.Parameters["@Background"].Value = CEC.Background;
                    cmd.Parameters["@Phone"].Value = CEC.Phone;
                    cmd.Parameters["@Status"].Value = CEC.Status;
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
        /// <param name="CEC">傳入SIS.Configuration.ClsEmployeeConfig</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool ParameterUpdateData(SIS.Configuration.ClsEmployeeConfig CEC)
        {

            InitDB();

            string updateCmd = null;
            int i = 0;

            updateCmd = "UPDATE EmployeeInfo SET EmployeeID=@EmployeeID , CNAME=@CNAME , " + "ENAME = @ENAME , Photos = @Photos , Sex=@Sex , " + 
                "Birthday = @Birthday , BooldType = @BooldType , ID=@ID , " + "PresentAddress = @PresentAddress , Professional = @Professional , HireDate=@HireDate , " + 
                "Positions = @Positions , Background = @Background , Phone=@Phone , " + "Status = @Status " + " WHERE (EmployeeID =" + " @Original_EmployeeID)";

            try
            {


                    cmd = new SqlCommand(updateCmd, conn);
                    cmd.Parameters.Add(new SqlParameter("@EmployeeID", System.Data.SqlDbType.NVarChar, 0, "EmployeeID"));
                    cmd.Parameters.Add(new SqlParameter("@CNAME", System.Data.SqlDbType.NVarChar, 0, "CNAME"));
                    cmd.Parameters.Add(new SqlParameter("@ENAME", System.Data.SqlDbType.NVarChar, 0, "ENAME"));
                    cmd.Parameters.Add(new SqlParameter("@Photos", System.Data.SqlDbType.Image, 0, "Photos"));
                    cmd.Parameters.Add(new SqlParameter("@Sex", System.Data.SqlDbType.NVarChar, 0, "Sex"));
                    cmd.Parameters.Add(new SqlParameter("@Birthday", System.Data.SqlDbType.NVarChar, 0, "Birthday"));
                    cmd.Parameters.Add(new SqlParameter("@BooldType", System.Data.SqlDbType.NVarChar, 0, "BooldType"));
                    cmd.Parameters.Add(new SqlParameter("@ID", System.Data.SqlDbType.NVarChar, 0, "ID"));
                    cmd.Parameters.Add(new SqlParameter("@PresentAddress", System.Data.SqlDbType.NVarChar, 0, "PresentAddress"));
                    cmd.Parameters.Add(new SqlParameter("@Professional", System.Data.SqlDbType.NVarChar, 0, "Professional"));
                    cmd.Parameters.Add(new SqlParameter("@HireDate", System.Data.SqlDbType.NVarChar, 0, "HireDate"));
                    cmd.Parameters.Add(new SqlParameter("@Positions", System.Data.SqlDbType.NVarChar, 0, "Positions"));
                    cmd.Parameters.Add(new SqlParameter("@Background", System.Data.SqlDbType.NVarChar, 0, "Background"));
                    cmd.Parameters.Add(new SqlParameter("@Phone", System.Data.SqlDbType.NVarChar, 0, "Phone"));
                    cmd.Parameters.Add(new SqlParameter("@Status", System.Data.SqlDbType.NVarChar, 0, "Status"));
                    cmd.Parameters.Add(new SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.NVarChar, 0, "EmployeeID"));
                    cmd.Parameters["@Original_EmployeeID"].SourceVersion = DataRowVersion.Original;

                    cmd.Parameters["@EmployeeID"].Value = CEC.EmployeeID;
                    cmd.Parameters["@CNAME"].Value = CEC.CNAME;
                    cmd.Parameters["@ENAME"].Value = CEC.ENAME;
                    cmd.Parameters["@Photos"].Value = CEC.Photos;
                    cmd.Parameters["@Sex"].Value = CEC.Sex;
                    cmd.Parameters["@Birthday"].Value = CEC.Birthday;
                    cmd.Parameters["@BooldType"].Value = CEC.BooldType;
                    cmd.Parameters["@ID"].Value = CEC.ID;
                    cmd.Parameters["@PresentAddress"].Value = CEC.PresentAddress;
                    cmd.Parameters["@Professional"].Value = CEC.Professional;
                    cmd.Parameters["@HireDate"].Value = CEC.HireDate;
                    cmd.Parameters["@Positions"].Value = CEC.Positions;
                    cmd.Parameters["@Background"].Value = CEC.Background;
                    cmd.Parameters["@Phone"].Value = CEC.Phone;
                    cmd.Parameters["@Status"].Value = CEC.Status;
                    cmd.Parameters["@Original_EmployeeID"].Value = CEC.EmployeeID;
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
            updateCmd = "UPDATE " + TableName +" SET EmployeeID=@EmployeeID , Photos = @Photos" + " WHERE (EmployeeID =" + " @Original_EmployeeID)";

            try
            {
                cmd = new SqlCommand(updateCmd, conn);
                cmd.Parameters.Add(new SqlParameter("@EmployeeID", System.Data.SqlDbType.NVarChar, 0, "EmployeeID"));
                cmd.Parameters.Add(new SqlParameter("@Photos", System.Data.SqlDbType.Image, 0, "Photos"));
                cmd.Parameters.Add(new SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.NVarChar, 0, "EmployeeID"));
                cmd.Parameters["@Original_EmployeeID"].SourceVersion = DataRowVersion.Original;
                cmd.Parameters["@EmployeeID"].Value = ArrField[0];
                cmd.Parameters["@Photos"].Value = ArrField[1];
                cmd.Parameters["@Original_EmployeeID"].Value = ArrField[0];
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


            delCmd = "Delete From " + TableName + " Where EmployeeID='" + PKval + "'";

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


    }
}
