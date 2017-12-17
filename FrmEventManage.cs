using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;//for ArrayList

namespace SIS
{
    public partial class FrmEventManage : Form
    {
        public FrmEventManage()
        {
            InitializeComponent();
        }

        private void FrmEventManage_Load(object sender, EventArgs e)
        {
            LoadDefaultValue();
        }

        #region "載入表單控制項相關預設值"

        /// <summary>
        /// 載入表單控制項相關預設值
        /// </summary>
        public void LoadDefaultValue()
        {
            string SQLCommand = "Select TOP 100 * from WinApEvents order by EventTime DESC";
            My.MyDatabase MyDb = new My.MyDatabase();

            DataView DV = MyDb.CreateDataView(SQLCommand, "WinApEvents");
            this.dataGridView1.DataSource = DV;

            //dataGridView表頭名稱中文化
            dataGridView1.Columns[0].HeaderText = "事件編號";
            dataGridView1.Columns[1].HeaderText = "事件觸發時間";
            dataGridView1.Columns[2].HeaderText = "事件類型";
            dataGridView1.Columns[3].HeaderText = "使用者帳號";
            dataGridView1.Columns[4].HeaderText = "執行動作";
            dataGridView1.Columns[5].HeaderText = "細節說明";

            tSSL_DataCount.Text = DV.Count.ToString();


            //設定點選任一儲存格變選取所屬資料列的所有資料
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //替代資料列樣式 
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Ivory;

            //自動調整資料列與資料行的高度與寬度
            this.dataGridView1.AutoResizeColumns();
            this.dataGridView1.AutoResizeRows();

            //防止在 DataGridView 控制項中新增和刪除資料列 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
        }

        #endregion

        private void tSCBQueryItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            tSCBKeyword.Items.Clear();

            switch (tSCBQueryItem.Text)
            {
                case "事件類型":
                    tSCBKeyword.Items.Add("資訊");
                    tSCBKeyword.Items.Add("警告");
                    tSCBKeyword.Items.Add("錯誤");
                    tSCBKeyword.Items.Add("危險");
                    break;
                case "使用者編號":
                    break;
                case "執行動作":
                    break;
                default:
                    break;
            }
        }

        //刪除
        private void tSBDelete_Click(object sender, EventArgs e)
        {
            //注意DataGridView的SelectMode只能為　選取欄位　或　選取資料列　不能二者同時存在
            //獲取選取資料列(ROW)的總數
            int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            ArrayList AList = new ArrayList();
            string EventId = "";
            DialogResult DR = new DialogResult();

            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                AList.Clear();
                for (int i = 0; i < selectedRowCount; i++)
                {
                    EventId = dataGridView1.SelectedRows[i].Cells["EventId"].Value.ToString();
                    sb.Append("第 ");
                    sb.Append(dataGridView1.SelectedRows[i].Index.ToString() + "列");
                    sb.Append(" " + EventId);
                    sb.Append(Environment.NewLine);
                    AList.Add(EventId);
                }

                sb.Append("被選取的資料列總數: " + selectedRowCount.ToString() + Environment.NewLine + "是否要刪除上述事件編號資料?");

                DR = MessageBox.Show(this, sb.ToString(), "刪除事件資料", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (DR == DialogResult.Yes)
                {
                    SIS.DBClass.DBClsWinAPEvents WAE = new SIS.DBClass.DBClsWinAPEvents();

                    if (WAE.MultiDelete(AList))
                    {
                        MessageBox.Show("完成刪除動作,共刪除" + selectedRowCount.ToString() +
                            "筆資料.", "刪除資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show(this, "刪除事件失敗!!", "刪除訊息", MessageBoxButtons.OK);
                    }
                }


            }
        }

        //查詢
        private void tSBQuery_Click(object sender, EventArgs e)
        {
            string FieldName = "";
            string Keyword = "";
            SIS.DBClass.DBClsWinAPEvents WAE = new SIS.DBClass.DBClsWinAPEvents();

            switch (tSCBQueryItem.Text)
            {
                case "事件類型":
                    FieldName = "EventType";
                    break;
                case "使用者編號":
                    FieldName = "UserId";
                    break;
                case "執行動作":
                    FieldName = "Action";
                    break;
                default:
                    FieldName = "";
                    break;
            }


            Keyword = this.tSCBKeyword.Text;

            DataView DV = WAE.RunQueryToDataView(FieldName, Keyword);

            if (DV.Count == 0)
            {
                MessageBox.Show("搜尋條件並未找到任何符合資料", "搜尋結果", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tSSL_DataCount.Text = DV.Count.ToString();
            }
            else
            {
                MessageBox.Show("共找到資料筆數" + DV.Count.ToString(), "搜尋結果");
                tSSL_DataCount.Text = DV.Count.ToString();
            }

            this.dataGridView1.DataSource = DV;
        }

        //離開
        private void tSBExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string EventId = this.dataGridView1[0, e.RowIndex].Value.ToString();
                string EventTime = this.dataGridView1[1, e.RowIndex].Value.ToString();
                string EventType = this.dataGridView1[2, e.RowIndex].Value.ToString();
                string UserId = this.dataGridView1[3, e.RowIndex].Value.ToString();
                string Action = this.dataGridView1[4, e.RowIndex].Value.ToString();
                string Details = this.dataGridView1[5, e.RowIndex].Value.ToString();

                string Msg = "";
                Msg = Msg + "事件編號:" + EventId + "\r\n";
                Msg = Msg + "事件觸發類型:" + EventTime + "\r\n";
                Msg = Msg + "事件類型:" + EventType + "\r\n";
                Msg = Msg + "使用者編號:" + UserId + "\r\n";
                Msg = Msg + "執行動作:" + Action + "\r\n";
                Msg = Msg + "細節說明:" + Details;

                MessageBox.Show(Msg, "事件內容");
            }
        }
      
    }
}
