using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIS
{
    public partial class FrmSISTakeStock : Form
    {
        public FrmSISTakeStock()
        {
            InitializeComponent();
        }

        private void FrmSISTakeStock_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            LoadDefaultValue(); 
            My.MyMethod.DataIntoComboBox(cboTakeStockStaff, "EmployeeInfo", "EmployeeID", "CNAME", "%");
            cboTakeStockStaff.Text = cboTakeStockStaff.Items[0].ToString();
        }

        #region "載入表單控制項相關預設值"

        /// <summary>
        /// 載入表單控制項相關預設值
        /// </summary>
        public void LoadDefaultValue()
        {
            //string SQLCommand = "Select A1.ItemsID ,A1.Name,A1.Inventory , 0, 0 , 0 , A1.ItemsUnit, A1.CostPrice, (A1.Inventory * A1.CostPrice) as totals , null as Notes  " +
            //    "from ItemsInfo A1 order by A1.ItemsID ";
            //My.MyDatabase MyDb = new My.MyDatabase();

            //DataView DV = MyDb.CreateDataView(SQLCommand, "ItemsInfo");
            //this.dgvTakeStockItemsInfo.DataSource = DV;

            //dataGridView表頭名稱中文化
            //dgvTakeStockItemsInfo.Columns[0].HeaderText = "商品編號";
            //dgvTakeStockItemsInfo.Columns[1].HeaderText = "商品名稱";
            //dgvTakeStockItemsInfo.Columns[2].HeaderText = "庫存數量";
            //dgvTakeStockItemsInfo.Columns[3].HeaderText = "盤點數量";
            //dgvTakeStockItemsInfo.Columns[4].HeaderText = "盈虧數量";
            //dgvTakeStockItemsInfo.Columns[5].HeaderText = "是否盤點";
            //dgvTakeStockItemsInfo.Columns[6].HeaderText = "基本單位";
            //dgvTakeStockItemsInfo.Columns[7].HeaderText = "單價";
            //dgvTakeStockItemsInfo.Columns[8].HeaderText = "合計";
            //dgvTakeStockItemsInfo.Columns[9].HeaderText = "備註";

            LoadTakeStockItems();

            //凍結 中文名稱 欄位
            this.dgvTakeStockItemsInfo.Columns["NAME"].Frozen = true;

            //設定點選任一儲存格變選取所屬資料列的所有資料
            this.dgvTakeStockItemsInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //替代資料列樣式 
            this.dgvTakeStockItemsInfo.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dgvTakeStockItemsInfo.AlternatingRowsDefaultCellStyle.BackColor = Color.Ivory;

            //自動調整資料列與資料行的高度與寬度
            this.dgvTakeStockItemsInfo.AutoResizeColumns();
            this.dgvTakeStockItemsInfo.AutoResizeRows();

            //防止在 DataGridView 控制項中新增和刪除資料列 
            this.dgvTakeStockItemsInfo.AllowUserToAddRows = false;
            this.dgvTakeStockItemsInfo.AllowUserToDeleteRows = false;

            //列標頭依據顯示內容自動調整大小
            this.dgvTakeStockItemsInfo.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            tsslDataCount.Text = dgvTakeStockItemsInfo.Rows.Count.ToString();

            //設定不能進行編輯的所有欄位
            dgvTakeStockItemsInfo.Columns["ItemsID"].ReadOnly = true;
            dgvTakeStockItemsInfo.Columns["Name"].ReadOnly = true;
            dgvTakeStockItemsInfo.Columns["Inventory"].ReadOnly = true;
            dgvTakeStockItemsInfo.Columns["GainLossInventory"].ReadOnly = true;
            dgvTakeStockItemsInfo.Columns["ItemsUnit"].ReadOnly = true;
            dgvTakeStockItemsInfo.Columns["Price"].ReadOnly = true;
            dgvTakeStockItemsInfo.Columns["Totals"].ReadOnly = true;

            toolTip1.SetToolTip(txtTakeStockID, "請輸入[商品編號]!");
            tsbAddNew.ToolTipText = "按下[新增]鈕,以進行盤點單新增動作!";
            tsbUpdate.ToolTipText = "按下[更改]鈕,以進行盤點單更改動作!";
            tsbDelete.ToolTipText = "按下[刪除]鈕,以進行盤點單刪除動作!";
            tsbClear.ToolTipText = "按下[清除]鈕,以進行輸入欄位資料清除動作!";
            tsbQuery.ToolTipText = "按下[查詢]鈕,以查詢輸入盤點單號是否存在，並且可選擇是否載入資料!";
            tsbPrint.ToolTipText = "按下[列印]鈕,若有找到輸入的盤點單號會將相關商品明細進行列印!";
            tsbExit.ToolTipText = "按下[離開]鈕,會將本表單進行關閉!";


        }

        #endregion


        /// <summary>
        /// 清除欄位資料
        /// </summary>
        private void ClearField()
        {
            txtTakeStockID.Text = "";
            this.rtbNotes.Text = "";
        }


        private void FrmSISTakeStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                e.Handled = true;
                this.Close();
            }
            else if (e.KeyCode == Keys.F2)
            {
                ClearField();
            }
        }

        private void LoadTakeStockItems()
        {
            SIS.DBClass.DBClassItemsInfo DBCII = new DBClass.DBClassItemsInfo();
            SIS.Configuration.ClsTakeStockConfig CTSC = new Configuration.ClsTakeStockConfig();

            bool result = DBCII.QueryAllItems(CTSC);
            if (result)
            {

                dgvTakeStockItemsInfo.Rows.Clear();

                for (int i = 0; i < CTSC.TakeStockItems.Length; i++)
                {
                    var index = dgvTakeStockItemsInfo.Rows.Add();
                    dgvTakeStockItemsInfo.Rows[index].Cells["ItemsID"].Value = CTSC.TakeStockItems[i].ItemsID;
                    dgvTakeStockItemsInfo.Rows[index].Cells["NAME"].Value = CTSC.TakeStockItems[i].NAME;
                    dgvTakeStockItemsInfo.Rows[index].Cells["Inventory"].Value = CTSC.TakeStockItems[i].Inventory.ToString();
                    dgvTakeStockItemsInfo.Rows[index].Cells["TakeStockInventory"].Value = CTSC.TakeStockItems[i].TakeStockInventory.ToString();
                    dgvTakeStockItemsInfo.Rows[index].Cells["GainLossInventory"].Value = CTSC.TakeStockItems[i].GainLossInventory.ToString();
                    dgvTakeStockItemsInfo.Rows[index].Cells["IsTakeStock"].Value = CTSC.TakeStockItems[i].IsTakeStock;
                    dgvTakeStockItemsInfo.Rows[index].Cells["ItemsUnit"].Value = CTSC.TakeStockItems[i].ItemsUnit;
                    dgvTakeStockItemsInfo.Rows[index].Cells["Price"].Value = CTSC.TakeStockItems[i].Price.ToString();
                    dgvTakeStockItemsInfo.Rows[index].Cells["Totals"].Value = CTSC.TakeStockItems[i].Totals.ToString();
                    dgvTakeStockItemsInfo.Rows[index].Cells["Notes"].Value = CTSC.TakeStockItems[i].Notes;
                }

            }
        }

        private void dgvTakeStockItemsInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0) // 確保一行Row只執行一次。 
            {
                dgvTakeStockItemsInfo.Rows[e.RowIndex].HeaderCell.Value = String.Format("{0}", e.RowIndex + 1);
            }
        }

        //自動產生盤點單號
        private void btnAutoNumber_Click(object sender, EventArgs e)
        {
            txtTakeStockID.Text = My.MyMethod.RunID("TS");
        }

        private void dgvTakeStockItemsInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 3 && dgvTakeStockItemsInfo.Rows[e.RowIndex].Cells["Totals"].Value != null)
            {
                if (dgvTakeStockItemsInfo.Rows[e.RowIndex].Cells["TakeStockInventory"].Value != null)
                {
                    int Inventory = int.Parse(dgvTakeStockItemsInfo.Rows[e.RowIndex].Cells["Inventory"].Value.ToString());
                    int takeStockInventory = int.Parse(dgvTakeStockItemsInfo.Rows[e.RowIndex].Cells["TakeStockInventory"].Value.ToString());
                    int gainLossInventory =  takeStockInventory - Inventory ;

                    dgvTakeStockItemsInfo.Rows[e.RowIndex].Cells["GainLossInventory"].Value = gainLossInventory.ToString();

                    int prices = int.Parse(dgvTakeStockItemsInfo.Rows[e.RowIndex].Cells["Price"].Value.ToString());
                    int totals = takeStockInventory * prices;

                    dgvTakeStockItemsInfo.Rows[e.RowIndex].Cells["Totals"].Value = totals.ToString();
                }
                else
                {
                    dgvTakeStockItemsInfo.Rows[e.RowIndex].Cells["TakeStockInventory"].Value = "0";
                }

            }
        }

        #region "欄位驗證"

        /// <summary>
        /// 欄位驗證
        /// </summary>
        /// <returns>輸入欄位型態正確回傳true,否則回傳false</returns>
        public bool CheckField()
        {

            if (txtTakeStockID.Text == "")
            {
                MessageBox.Show("[盤點單號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(txtTakeStockID, "[盤點單號]不得為空白!");
                txtTakeStockID.Focus();
                return false;
            }

            return true;

        }

        #endregion


        private SIS.Configuration.TakeStockItem[] getItemsValueFromDataGridView(DataGridView dgv)
        {
            SIS.Configuration.TakeStockItem[] items = null;
            try
            {
                if (dgv.Rows.Count >= 1)
                {
                    items = new Configuration.TakeStockItem[dgv.Rows.Count];
                    int i = 0;
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.IsNewRow)
                        {
                            //
                        }
                        SIS.Configuration.TakeStockItem oneItem = new Configuration.TakeStockItem();
                        if (row.Cells["ItemsID"].Value != null)
                        {
                            oneItem.ItemsID = row.Cells["ItemsID"].Value.ToString();
                        }
                        if (row.Cells["NAME"].Value != null)
                        {
                            oneItem.NAME = row.Cells["NAME"].Value.ToString();
                        }
                        if (row.Cells["Inventory"].Value != null)
                        {
                            oneItem.Inventory = int.Parse(row.Cells["Inventory"].Value.ToString()); 
                        }
                        if (row.Cells["TakeStockInventory"].Value != null)
                        {
                            oneItem.TakeStockInventory = int.Parse(row.Cells["TakeStockInventory"].Value.ToString());
                        }
                        if (row.Cells["GainLossInventory"].Value != null)
                        {
                            oneItem.GainLossInventory = int.Parse(row.Cells["GainLossInventory"].Value.ToString());
                        }
                        if (row.Cells["IsTakeStock"].Value != null)
                        {
                            oneItem.IsTakeStock = bool.Parse(row.Cells["IsTakeStock"].Value.ToString());
                        }
                        if (row.Cells["ItemsUnit"].Value != null)
                        {
                            oneItem.ItemsUnit = row.Cells["ItemsUnit"].Value.ToString();
                        }
                        if (row.Cells["Price"].Value != null)
                        {
                            oneItem.Price = int.Parse(row.Cells["Price"].Value.ToString());
                        }
                        if (row.Cells["Totals"].Value != null)
                        {
                            oneItem.Totals = int.Parse(row.Cells["Totals"].Value.ToString());
                        }
                        if (row.Cells["Notes"].Value != null)
                        {
                            oneItem.Notes = row.Cells["Notes"].Value.ToString();
                        }
                        items[i] = oneItem;
                        i = i + 1;
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }


            return items;

        }




        #region "資料庫異動處理區"

        /// <summary>
        /// 將資料寫入資料庫中
        /// </summary>
        private void RunInsertData()
        {
            try
            {
                My.MyDatabase MyDb = new My.MyDatabase();
                SIS.Configuration.ClsTakeStockConfig CTSC = new Configuration.ClsTakeStockConfig();
                CTSC.TakeStockID = txtTakeStockID.Text;
                CTSC.TakeStockDate = dtpTakeStockDate.Value.ToString("yyyy年MM月dd日");
                CTSC.TakeStockStaff = cboTakeStockStaff.Text;
                CTSC.Notes = rtbNotes.Text.Replace("'", "''");
                CTSC.TakeStockItems = getItemsValueFromDataGridView(dgvTakeStockItemsInfo);

                SIS.DBClass.DBClassTakeStockMaster DBCTSM = new DBClass.DBClassTakeStockMaster();

                if (MyDb.AuthPK(CTSC.TakeStockID, "TakeStockID", "TakeStockMaster") == false)
                {
                    if (DBCTSM.InsertData(CTSC))
                    {
                        MessageBox.Show("新增[" + CTSC.TakeStockID +
                            "]盤點單資料成功", "新增盤點單資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show("新增[" + CTSC.TakeStockID +
                            "]盤點單資料失敗", "新增盤點單資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("對不起，資料庫已存在[ " + CTSC.TakeStockID +
                          " ]盤點單資料!!(資料重複)", "資料新增");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤訊息:" + ex.Message.ToString(), "發生例外");
            }

        }

        private void RunUpdateData()
        {
            try
            {
                My.MyDatabase MyDb = new My.MyDatabase();
                SIS.Configuration.ClsTakeStockConfig CTSC = new Configuration.ClsTakeStockConfig();
                CTSC.TakeStockID = txtTakeStockID.Text;
                CTSC.TakeStockDate = dtpTakeStockDate.Value.ToString("yyyy年MM月dd日");
                CTSC.TakeStockStaff = cboTakeStockStaff.Text;
                CTSC.Notes = rtbNotes.Text.Replace("'", "''");
                CTSC.TakeStockItems = getItemsValueFromDataGridView(dgvTakeStockItemsInfo);

                SIS.DBClass.DBClassTakeStockMaster DBCTSM = new DBClass.DBClassTakeStockMaster();

                if (MyDb.AuthPK(CTSC.TakeStockID, "TakeStockID", "TakeStockMaster") == true)
                {
                    if (DBCTSM.Update(CTSC))
                    {
                        MessageBox.Show("更新[" + CTSC.TakeStockID +
                            "]盤點單資料成功", "更新盤點單資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show("更新[" + CTSC.TakeStockID +
                            "]盤點單資料失敗", "更新盤點單資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("對不起，資料庫不存在[ " + CTSC.TakeStockID +
                          " ]更新單資料!!(資料不存在)", "資料更新");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤訊息:" + ex.Message.ToString(), "發生例外");
            }

        }


        private void RunDeleteData()
        {
            try
            {
                My.MyDatabase MyDb = new My.MyDatabase();
                SIS.Configuration.ClsTakeStockConfig CTSC = new Configuration.ClsTakeStockConfig();
                CTSC.TakeStockID = txtTakeStockID.Text;

                SIS.DBClass.DBClassTakeStockMaster DBCTSM = new DBClass.DBClassTakeStockMaster();

                if (MyDb.AuthPK(CTSC.TakeStockID, "TakeStockID", "TakeStockMaster") == true)
                {
                    if (DBCTSM.DeleteMasterDetailsData(CTSC.TakeStockID))
                    {
                        MessageBox.Show("刪除[" + CTSC.TakeStockID +
                            "]盤點單資料成功", "刪除盤點單資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show("刪除[" + CTSC.TakeStockID +
                            "]盤點單資料失敗", "刪除盤點單資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("對不起，資料庫不存在[ " + CTSC.TakeStockID +
                          " ]刪除單資料!!(資料不存在)", "資料刪除");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤訊息:" + ex.Message.ToString(), "發生例外");
            }

        }


        #endregion


        #region "工具列功能區"

        //新增
        private void tsbAddNew_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行盤點單[" + txtTakeStockID.Text  + "]新增動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "新增盤點單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunInsertData();
                }
            }
            else
            {
                MessageBox.Show("取消盤點單新增動作!!", "新增盤點單");
            }
        }

        //更改
        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行盤點單[" + txtTakeStockID.Text + "]更新動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "更新盤點單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunUpdateData();
                }
            }
            else
            {
                MessageBox.Show("取消盤點單更新動作!!", "更新盤點單");
            }
        }


        //刪除
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行盤點單[" + txtTakeStockID.Text + "]刪除動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "刪除盤點單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunDeleteData();
                }
            }
            else
            {
                MessageBox.Show("取消盤點單刪除動作!!", "刪除盤點單");
            }
        }

        //清除
        private void tsbClear_Click(object sender, EventArgs e)
        {
            ClearField();
            MessageBox.Show("欄位資料清除完畢!!", "清除");
        }

        //查詢
        private void tsbQuery_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行盤點單[" + txtTakeStockID.Text + "]查詢動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "查詢盤點單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    SIS.DBClass.DBClassTakeStockMaster DBCTSM = new DBClass.DBClassTakeStockMaster();
                    SIS.Configuration.ClsTakeStockConfig CTSC = new Configuration.ClsTakeStockConfig();

                    bool result = DBCTSM.QueryData(txtTakeStockID.Text, CTSC);
                    if (result)
                    {
                        MessageBox.Show("有找到盤點單號:[" + txtTakeStockID.Text + "]資料!\r\n是否將盤點單資料載入?", "搜尋結果", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DR == DialogResult.Yes)
                        {

                            //要從最後面資料列開始往上移除才能正確執行
                            for (int i = dgvTakeStockItemsInfo.Rows.Count - 1; i >= 0; i--)
                            {
                                dgvTakeStockItemsInfo.Rows.RemoveAt(i);
                                //System.Threading.Thread.Sleep(10);
                            }

                            txtTakeStockID.Text = CTSC.TakeStockID;
                            dtpTakeStockDate.Text = CTSC.TakeStockDate;
                            cboTakeStockStaff.Text = CTSC.TakeStockStaff;
                            rtbNotes.Text = CTSC.Notes;

                            for (int i = 0; i < CTSC.TakeStockItems.Length; i++)
                            {
                                var index = dgvTakeStockItemsInfo.Rows.Add();
                                dgvTakeStockItemsInfo.Rows[index].Cells["ItemsID"].Value = CTSC.TakeStockItems[i].ItemsID;
                                dgvTakeStockItemsInfo.Rows[index].Cells["NAME"].Value = CTSC.TakeStockItems[i].NAME;
                                dgvTakeStockItemsInfo.Rows[index].Cells["Inventory"].Value = CTSC.TakeStockItems[i].Inventory.ToString();
                                dgvTakeStockItemsInfo.Rows[index].Cells["TakeStockInventory"].Value = CTSC.TakeStockItems[i].TakeStockInventory.ToString();
                                dgvTakeStockItemsInfo.Rows[index].Cells["GainLossInventory"].Value = CTSC.TakeStockItems[i].GainLossInventory.ToString();
                                dgvTakeStockItemsInfo.Rows[index].Cells["IsTakeStock"].Value = CTSC.TakeStockItems[i].IsTakeStock; //Boolean
                                dgvTakeStockItemsInfo.Rows[index].Cells["ItemsUnit"].Value = CTSC.TakeStockItems[i].ItemsUnit;
                                dgvTakeStockItemsInfo.Rows[index].Cells["Price"].Value = CTSC.TakeStockItems[i].Price.ToString();
                                dgvTakeStockItemsInfo.Rows[index].Cells["Totals"].Value = CTSC.TakeStockItems[i].Totals.ToString();
                                dgvTakeStockItemsInfo.Rows[index].Cells["Notes"].Value = CTSC.TakeStockItems[i].Notes;
                            }

                            tsslDataCount.Text = dgvTakeStockItemsInfo.Rows.Count.ToString();
                        }

                    }
                    else
                    {
                        MessageBox.Show("沒有找到盤點單號:[" + txtTakeStockID.Text + "]資料!", "搜尋結果");
                    }
                }
            }
            else
            {
                MessageBox.Show("取消盤點單查詢動作!!", "查詢盤點單");
            }
        }

        //列印
        private void tsbPrint_Click(object sender, EventArgs e)
        {
            if (CheckField())
            {
                SIS.DBClass.DBClassTakeStockMaster DBCTSM = new DBClass.DBClassTakeStockMaster();
                bool result = DBCTSM.QueryData(txtTakeStockID.Text);
                if (result)
                {

                    FrmReportPrint FRP = new FrmReportPrint("TakeStockID", txtTakeStockID.Text, "rptTakeStockMaster");
                    FRP.ShowDialog();

                }
                else
                {
                    MessageBox.Show("沒有找到盤點單號:[" + txtTakeStockID.Text + "]資料，無法列印!", "列印結果");
                }
            }
        }
        //離開
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
       

       
       
       
       
    }
}
