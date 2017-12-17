using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //新增命名空間 for SQL Server
using System.Collections;//
using System.Data;//

namespace SIS.DBClass
{
    class DBClsWinAPEvents
    {
        public string TableName = "WinApEvents";
        string errorMsg;
        string ConnString;

        SqlConnection conn;
        SqlCommand cmd;
        //SqlDataReader dr;
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
        /// <param name="ArrField">傳入存放新增資料的ArrayList</param>
        /// <returns></returns>
        public bool InsertData(System.Collections.ArrayList ArrField)
        {
            InitDB();

            string insertCmd;

            //注意欄位名稱不可為Action
            insertCmd = "Insert Into " + TableName + " (EventId,EventTime,EventType,UserId,Action,Details";

            insertCmd = insertCmd + ") Values(";
            insertCmd = insertCmd + "'" + ArrField[0] + "',";  //事件編號
            insertCmd = insertCmd + "'" + ArrField[1] + "',";  //事件觸發時間
            insertCmd = insertCmd + "'" + ArrField[2] + "',";  //事件類型
            insertCmd = insertCmd + "'" + ArrField[3] + "',";  //使用者編號
            insertCmd = insertCmd + "'" + ArrField[4] + "',";  //執行動作
            insertCmd = insertCmd + "'" + ArrField[5] + "' ";  //細節說明
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


        #region "加入事件資料於資料庫中"

        /// <summary>
        /// 加入事件資料於資料庫中
        /// </summary>
        /// <param name="UserId">使用者編號</param>
        /// <param name="EventType">事件類型,包含:資訊,錯誤,警告,危險等四種</param>
        /// <param name="Action">對系統所執行動作</param>
        /// <param name="Details">動作詳細描述</param>
        public bool AddEventData(string UserId, string EventType, string Actions, string Details)
        {

            ArrayList arrList = new ArrayList();

            string EventId;        //事件編號
            string EventTime;      //事件觸發時間


            bool IsInsertOK = false; //用來存放bool值,作為判斷新增資料是否成功


            EventId = My.MyMethod.RunID("EV");
            EventTime = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");


            arrList.Clear();
            arrList.Insert(0, EventId);
            arrList.Insert(1, EventTime);
            arrList.Insert(2, EventType);
            arrList.Insert(3, UserId);
            arrList.Insert(4, Actions);
            arrList.Insert(5, Details);

            My.MyDatabase MyDB = new My.MyDatabase();

            //檢查要插入的資料其主鍵值(Primary Key)是否有重複,若有重複則會回傳True
            if (MyDB.AuthPK(EventId, "EventId", "WinApEvents"))
            {
                //MessageBox.Show("資料已經存在,請重新送出填寫表單!!", "主鍵值驗證失敗");
                return false;
            }
            else
            {
                IsInsertOK = InsertData(arrList); //呼叫InsertData方法來進行資料新增動作


                if (IsInsertOK)
                {
                    //MessageBox.Show("資料新增成功!!", "資料新增");
                    return true;
                }
                else
                {
                    //MessageBox.Show("資料新增失敗!!", "資料新增");
                    return false;
                }
            }

        }

        #endregion


        #region "刪除一筆資料"

        /// <summary>
        /// 刪除一筆資料
        /// </summary>
        /// <param name="PKval">傳入欲刪除資料的主鍵值</param>
        /// <returns></returns>
        public bool DeleteOneData(string PKval1)
        {
            InitDB();
            string delCmd;
            int i = 0;


            delCmd = "Delete From " + TableName + " Where EventId='" + PKval1 + "'";

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


        #region "刪除多筆資料"

        /// <summary>
        /// 刪除多筆資料
        /// </summary>
        /// <param name="Alist">傳入一個ArrayList,其陣列元素存放主鍵值</param>
        /// <returns></returns>
        public bool MultiDelete(ArrayList Alist)
        {
            try
            {
                if (Alist.Count <= 0)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < Alist.Count; i++)
                    {
                        DeleteOneData(Alist[i].ToString());
                    }
                    return true;

                }
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }



        }

        #endregion


        #region "執行SQL語法並將結果以DataView回傳"

        public DataView RunQueryToDataView(string QueryFieldName, string QueryKeyword)
        {

            try
            {

                InitDB();
                DataSet ds = new DataSet();
                string SQLCmd = "";

                if (QueryFieldName == "")
                {
                    SQLCmd = "Select * From " + TableName + "Order by EventTime DESC";
                }
                else
                {
                    SQLCmd = "Select * From " + TableName + " Where " + QueryFieldName + " Like '%" + QueryKeyword + "%' " + "Order by EventTime DESC";
                }


                da = new SqlDataAdapter(SQLCmd, conn);
                da.Fill(ds, TableName);
                conn.Close();
                return ds.Tables[TableName].DefaultView;


            }
            catch (Exception ex)
            {

                errorMsg = ex.Message;
                return null;
            }

        }

        #endregion

        

    }
}
