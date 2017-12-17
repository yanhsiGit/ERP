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
    public partial class FrmSISStock : Form
    {
        public FrmSISStock()
        {
            InitializeComponent();
        }
        FrmItemsQuery FIQ;
        private void FrmSISStock_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            LoadDefaultValue();
            My.MyMethod.DataIntoComboBox(cboManufacturer, "ManufacturerInfo", "ManufacturerID", "CNAME", "%");
            My.MyMethod.DataIntoComboBox(cboStockStaff, "EmployeeInfo", "EmployeeID", "CNAME", "%");
            My.MyMethod.DataIntoComboBox(cboPaymentType, "PaymentType", "PaymentID", "PaymentName", "%", true);
            txtBusinessTaxStockTaxRate.Text = My.MyGlobal.INIBusinessTaxStockTaxRate;
            cboManufacturer.Text = cboManufacturer.Items[0].ToString();
            cboStockStaff.Text = cboStockStaff.Items[0].ToString();
            cboPaymentType.Text = cboPaymentType.Items[0].ToString();
        }

        #region "載入表單控制項相關預設值"

        /// <summary>
        /// 載入表單控制項相關預設值
        /// </summary>
        public void LoadDefaultValue()
        {
            //string SQLCommand = "Select A1.ItemsID ,A1.Name,A1.ItemsType , A1.Specifications,A1.ItemsUnit,A1.SellingPrice,A1.CostPrice,A1.MSRP, (A1.ManufacturerID + '-' + A2.CNAME) as Manufacturer , A1.Inventory , A1.SafeInventory , A1.Notes " +
            //    "from ItemsInfo A1 INNER JOIN ManufacturerInfo A2 On A1.ManufacturerID = A2.ManufacturerID order by A1.ItemsID ";
            //My.MyDatabase MyDb = new My.MyDatabase();

            //DataView DV = MyDb.CreateDataView(SQLCommand, "ItemsInfo");
            //this.dgvItemsInfo.DataSource = DV;

            ////dataGridView表頭名稱中文化
            //dgvItemsInfo.Columns[0].HeaderText = "商品編號";
            //dgvItemsInfo.Columns[1].HeaderText = "商品名稱";
            //dgvItemsInfo.Columns[2].HeaderText = "商品類別";
            //dgvItemsInfo.Columns[3].HeaderText = "商品規格";
            //dgvItemsInfo.Columns[4].HeaderText = "基本單位";
            //dgvItemsInfo.Columns[5].HeaderText = "出貨價格";
            //dgvItemsInfo.Columns[6].HeaderText = "進貨價格";
            //dgvItemsInfo.Columns[7].HeaderText = "建議售價";
            //dgvItemsInfo.Columns[8].HeaderText = "進貨廠商";
            //dgvItemsInfo.Columns[9].HeaderText = "庫存量";
            //dgvItemsInfo.Columns[10].HeaderText = "安全庫存量";
            //dgvItemsInfo.Columns[11].HeaderText = "備註";

            //tsslDataCount.Text = DV.Count.ToString();

            //凍結 中文名稱 欄位
            this.dgvStockDetails.Columns["NAME"].Frozen = true;

            //設定點選任一儲存格變選取所屬資料列的所有資料
            this.dgvStockDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //替代資料列樣式 
            this.dgvStockDetails.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dgvStockDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.Ivory;

            //自動調整資料列與資料行的高度與寬度
            this.dgvStockDetails.AutoResizeColumns();
            this.dgvStockDetails.AutoResizeRows();

            //防止在 DataGridView 控制項中新增和刪除資料列 
            //this.dgvStockDetails.AllowUserToAddRows = false;
            //this.dgvStockDetails.AllowUserToDeleteRows = false;

            //列標頭依據顯示內容自動調整大小
            this.dgvStockDetails.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            dgvStockDetails.Columns["ItemsID"].ReadOnly = true;
            dgvStockDetails.Columns["Name"].ReadOnly = true;
            dgvStockDetails.Columns["ItemsUnit"].ReadOnly = true;
            dgvStockDetails.Columns["CostPrice"].ReadOnly = true;
            dgvStockDetails.Columns["Totals"].ReadOnly = true;


            toolTip1.SetToolTip(txtStockID, "請輸入[進貨單號]!");
            tsbAddNew.ToolTipText = "按下[新增]鈕,以進行採購單新增動作!";
            tsbUpdate.ToolTipText = "按下[更改]鈕,以進行採購單更改動作!";
            tsbDelete.ToolTipText = "按下[刪除]鈕,以進行採購單刪除動作!";
            tsbClear.ToolTipText = "按下[清除]鈕,以進行輸入欄位資料清除動作!";
            tsbQuery.ToolTipText = "按下[查詢]鈕,以查詢輸入進貨單號是否存在，並且可選擇是否載入資料!";
            tsbPrint.ToolTipText = "按下[列印]鈕,若有找到輸入的進貨單號會將相關商品明細進行列印!";
            tsbExit.ToolTipText = "按下[離開]鈕,會將本表單進行關閉!";

        }

        #endregion


        /// <summary>
        /// 清除欄位資料
        /// </summary>
        private void ClearField()
        {
            txtStockID.Text = "";
            this.cboManufacturer.Text = cboManufacturer.Items[0].ToString();
            mtbAmountPaid.Text = "0";
            this.rtbNotes.Text = "";
        }
        //自動產生進貨單號
        private void btnAutoNumber_Click(object sender, EventArgs e)
        {
            txtStockID.Text = My.MyMethod.RunID("ST");
        }

        #region "欄位驗證"

        /// <summary>
        /// 欄位驗證
        /// </summary>
        /// <returns>輸入欄位型態正確回傳true,否則回傳false</returns>
        public bool CheckField()
        {

            if (txtStockID.Text == "")
            {
                MessageBox.Show("[進貨單號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(txtStockID, "[進貨單號]不得為空白!");
                txtStockID.Focus();
                return false;
            }

            return true;

        }

        #endregion

        #region "將資料寫入資料庫中"

        /// <summary>
        /// 將資料寫入資料庫中
        /// </summary>
        private void RunInsertData()
        {
            try
            {
                My.MyDatabase MyDb = new My.MyDatabase();
                SIS.Configuration.ClsStockConfig CSC = new Configuration.ClsStockConfig();
                CSC.StockID = txtStockID.Text;
                CSC.StockDate = dtpStockDate.Value.ToString("yyyy年MM月dd日");
                CSC.TotalPreTax = int.Parse(txtTotalPreTax.Text);
                CSC.Tax = int.Parse(txtTax.Text);
                CSC.TotalAfterTax = int.Parse(txtTotalAfterTax.Text);
                CSC.ManufacturerID = cboManufacturer.Text.Substring(0, cboManufacturer.Text.IndexOf("-"));
                CSC.BusinessTaxStockTaxRate = int.Parse(txtBusinessTaxStockTaxRate.Text);
                CSC.AmountPaid = int.Parse(mtbAmountPaid.Text);
                CSC.UnpaidAmount = int.Parse(txtUnpaidAmount.Text);
                CSC.StockStaff = cboStockStaff.Text;
                CSC.PaymentType = cboPaymentType.Text.Split('-')[1];
                CSC.Notes = rtbNotes.Text.Replace("'", "''");
                CSC.StockItems = getItemsValueFromDataGridView(dgvStockDetails);

                SIS.DBClass.DBClassStockMaster DBCSM = new DBClass.DBClassStockMaster();

                if (MyDb.AuthPK(CSC.StockID, "StockID", "StockMaster") == false)
                {
                    if (DBCSM.InsertData(CSC))
                    {
                        MessageBox.Show("新增[" + CSC.StockID +
                            "]進貨單資料成功", "新增進貨單資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show("新增[" + CSC.StockID +
                            "]進貨單資料失敗", "新增進貨單資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("對不起，資料庫已存在[ " + CSC.StockID +
                          " ]進貨單資料!!(資料重複)", "資料新增");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤訊息:" + ex.Message.ToString(), "發生例外");
            }

        }


        #endregion


        private void RunUpdateData(SIS.Configuration.Items[] OldItems)
        {
            try
            {
                My.MyDatabase MyDb = new My.MyDatabase();
                SIS.Configuration.ClsStockConfig CSC = new Configuration.ClsStockConfig();
                CSC.StockID = txtStockID.Text;
                CSC.StockDate = dtpStockDate.Value.ToString("yyyy年MM月dd日");
                CSC.TotalPreTax = int.Parse(txtTotalPreTax.Text);
                CSC.Tax = int.Parse(txtTax.Text);
                CSC.TotalAfterTax = int.Parse(txtTotalAfterTax.Text);
                CSC.ManufacturerID = cboManufacturer.Text.Substring(0, cboManufacturer.Text.IndexOf("-"));
                CSC.BusinessTaxStockTaxRate = int.Parse(txtBusinessTaxStockTaxRate.Text);
                CSC.AmountPaid = int.Parse(mtbAmountPaid.Text);
                CSC.UnpaidAmount = int.Parse(txtUnpaidAmount.Text);
                CSC.StockStaff = cboStockStaff.Text;
                CSC.PaymentType = cboPaymentType.Text.Split('-')[1];
                CSC.Notes = rtbNotes.Text.Replace("'", "''");
                CSC.StockItems = getItemsValueFromDataGridView(dgvStockDetails);

                SIS.DBClass.DBClassStockMaster DBCSM = new DBClass.DBClassStockMaster();

                if (MyDb.AuthPK(CSC.StockID, "StockID", "StockMaster") == true)
                {
                    if (DBCSM.Update(CSC, OldItems))
                    {
                        MessageBox.Show("更新[" + CSC.StockID +
                            "]進貨單資料成功", "更新進貨單資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show("更新[" + CSC.StockID +
                            "]進貨單資料失敗", "更新進貨單資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("對不起，資料庫不存在[ " + CSC.StockID +
                          " ]進貨單資料!!(資料不存在)", "資料更新");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤訊息:" + ex.Message.ToString(), "發生例外");
            }

        }

        private void RunDeleteData(SIS.Configuration.Items[] OldItems)
        {
            try
            {
                My.MyDatabase MyDb = new My.MyDatabase();
                SIS.Configuration.ClsStockConfig CSC = new Configuration.ClsStockConfig();
                CSC.StockID = txtStockID.Text;

                SIS.DBClass.DBClassStockMaster DBCSM = new DBClass.DBClassStockMaster();

                if (MyDb.AuthPK(CSC.StockID, "StockID", "StockMaster") == true)
                {
                    if (DBCSM.DeleteMasterDetailsData(CSC.StockID , OldItems))
                    {
                        MessageBox.Show("刪除[" + CSC.StockID +
                            "]進貨單資料成功", "刪除進貨單資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show("刪除[" + CSC.StockID +
                            "]進貨單資料失敗", "刪除進貨單資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("對不起，資料庫不存在[ " + CSC.StockID +
                          " ]進貨單資料!!(資料不存在)", "資料刪除");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤訊息:" + ex.Message.ToString(), "發生例外");
            }

        }



        private int ComputeDataGridViewCell(DataGridView dgv, string ColumnName)
        {
            int amout = 0;
            int totals = 0;
            if (dgv.Rows.Count > 1)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {

                    if (row.Cells[ColumnName].Value != null)
                    {
                        totals = int.Parse(row.Cells[ColumnName].Value.ToString());
                        amout = amout + totals;
                    }
                }
            }

            return amout;
        }


        private int FindDataGridViewCell(DataGridView dgv, string ColumnName, string ColumnValue)
        {
            if (dgv.Rows.Count > 1)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {

                    if (row.Cells[ColumnName].Value != null)
                    {
                        if (row.Cells[ColumnName].Value.ToString() == ColumnValue)
                            return row.Cells[ColumnName].RowIndex;
                    }
                }
            }

            return -1;
        }

        private SIS.Configuration.Items[] getItemsValueFromDataGridView(DataGridView dgv)
        {
            SIS.Configuration.Items[] items = null;
            try
            {
                if (dgv.Rows.Count > 1)
                {
                    items = new Configuration.Items[dgv.Rows.Count - 1];
                    int i = 0;
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.IsNewRow)
                        {
                            //
                        }
                        SIS.Configuration.Items oneItem = new Configuration.Items();
                        if (row.Cells["ItemsID"].Value != null)
                        {
                            oneItem.ItemsID = row.Cells["ItemsID"].Value.ToString();
                        }
                        if (row.Cells["NAME"].Value != null)
                        {
                            oneItem.NAME = row.Cells["NAME"].Value.ToString();
                        }
                        if (row.Cells["Quantity"].Value != null)
                        {
                            oneItem.Quantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                        }
                        if (row.Cells["ItemsUnit"].Value != null)
                        {
                            oneItem.ItemsUnit = row.Cells["ItemsUnit"].Value.ToString();
                        }
                        if (row.Cells["CostPrice"].Value != null)
                        {
                            oneItem.Price = int.Parse(row.Cells["CostPrice"].Value.ToString());
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





        private void FrmSISStock_KeyDown(object sender, KeyEventArgs e)
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

        //加入商品
        private void btnAddItems_Click(object sender, EventArgs e)
        {
            FIQ = new FrmItemsQuery();
            FIQ.Closed += new EventHandler(FIQClose);
            FIQ.ShowDialog();
        }

        private void btnRemoveItems_Click(object sender, EventArgs e)
        {
            if (dgvStockDetails.Rows.Count > 1)
            {
                string Msg = "是否要將進貨清單所有商品移除動作?\r\n移除商品數:" + string.Format("{0}", (dgvStockDetails.Rows.Count - 1));

                DialogResult DR;
                DR = MessageBox.Show(Msg, "移除所有商品", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (DR == DialogResult.Yes)
                {
                    //要從最後面資料列開始往上移除才能正確執行
                    for (int i = dgvStockDetails.Rows.Count - 2; i >= 0; i--)
                    {
                        dgvStockDetails.Rows.RemoveAt(i);
                        System.Threading.Thread.Sleep(100);
                    }
                    getTaxTotals();
                }
            }
            else if (dgvStockDetails.Rows.Count <= 1)
            {
                MessageBox.Show("進貨清單上沒有任何商品", "移除所有商品", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void FIQClose(object sender, EventArgs e)
        {
            if (FIQ.isAddButtonClick == true)
            {
                int rowIndex = FindDataGridViewCell(dgvStockDetails, "ItemsID", FIQ.ItemsID);
                if (rowIndex != -1) //有找到相同商品編號
                {
                    dgvStockDetails.Rows[rowIndex].Cells["ItemsID"].Value = FIQ.ItemsID;
                    dgvStockDetails.Rows[rowIndex].Cells["NAME"].Value = FIQ.NAME;
                    int totalQuantity = int.Parse(FIQ.Quantity) + int.Parse(dgvStockDetails.Rows[rowIndex].Cells["Quantity"].Value.ToString());
                    dgvStockDetails.Rows[rowIndex].Cells["Quantity"].Value = totalQuantity.ToString();
                    dgvStockDetails.Rows[rowIndex].Cells["ItemsUnit"].Value = FIQ.ItemsUnit;
                    dgvStockDetails.Rows[rowIndex].Cells["CostPrice"].Value = FIQ.CostPrice;
                    int newTotals = int.Parse(FIQ.CostPrice) * totalQuantity;
                    dgvStockDetails.Rows[rowIndex].Cells["Totals"].Value = newTotals.ToString();
                    dgvStockDetails.Rows[rowIndex].Cells["Notes"].Value = FIQ.Notes;
                }
                else
                {
                    var index = dgvStockDetails.Rows.Add();
                    dgvStockDetails.Rows[index].Cells["ItemsID"].Value = FIQ.ItemsID;
                    dgvStockDetails.Rows[index].Cells["NAME"].Value = FIQ.NAME;
                    dgvStockDetails.Rows[index].Cells["Quantity"].Value = FIQ.Quantity;
                    dgvStockDetails.Rows[index].Cells["ItemsUnit"].Value = FIQ.ItemsUnit;
                    dgvStockDetails.Rows[index].Cells["CostPrice"].Value = FIQ.CostPrice;
                    dgvStockDetails.Rows[index].Cells["Totals"].Value = FIQ.Totals;
                    dgvStockDetails.Rows[index].Cells["Notes"].Value = FIQ.Notes;
                }
                getTaxTotals();

            }
        }
        private void getTaxTotals()
        {
            if (dgvStockDetails.Rows.Count >= 2)
            {
                double amount = 0; //商品總計
                amount = ComputeDataGridViewCell(dgvStockDetails, "Totals");// int.Parse(dgvPurchaseDetails.Rows[0].Cells["Totals"].Value.ToString());
                txtTotalPreTax.Text = amount.ToString();
                int taxRate = int.Parse(txtBusinessTaxStockTaxRate.Text);
                double tax = Math.Round(((amount * taxRate) / 100), 0, MidpointRounding.AwayFromZero);//稅額-四捨五入
                txtTax.Text = tax.ToString();
                double TotalAfterTax = amount + tax;
                txtTotalAfterTax.Text = TotalAfterTax.ToString(); 
                tsslDataCount.Text = string.Format("{0}",(dgvStockDetails.Rows.Count - 1));
            }
            else
            {
                txtTotalPreTax.Text = "";
                txtTax.Text = "";
                txtTotalAfterTax.Text = "";
                txtUnpaidAmount.Text = "";
            }
        }

        private void getUnpaidAmount()
        {
            if (txtTotalAfterTax.Text != "" && My.MyMethod.IsNumeric(mtbAmountPaid.Text))
            {
                int AmountPaid = int.Parse(mtbAmountPaid.Text);
                int TotalAfterTax = int.Parse(txtTotalAfterTax.Text);
                int UnpaidAmount = 0;
                if (AmountPaid >TotalAfterTax)
                {
                    mtbAmountPaid.Text = txtTotalAfterTax.Text;
                }
                else
                {
                    UnpaidAmount = AmountPaid - TotalAfterTax;
                    txtUnpaidAmount.Text = UnpaidAmount.ToString();
                }
               
            }
        }

        private void mtbAmountPaid_TextChanged(object sender, EventArgs e)
        {
            getUnpaidAmount();
        }

        private void txtTotalAfterTax_TextChanged(object sender, EventArgs e)
        {
            getUnpaidAmount();
        }

        private void dgvStockDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.RowIndex != -1 && dgvStockDetails.Rows[e.RowIndex].Cells["ItemsID"].Value != null) //刪除鈕索引值
            {
                string Msg = "是否要進行商品[" + dgvStockDetails.Rows[e.RowIndex].Cells["ItemsID"].Value.ToString() + "-" + dgvStockDetails.Rows[e.RowIndex].Cells["Name"].Value.ToString() + "]刪除動作?\r\n";

                DialogResult DR;
                DR = MessageBox.Show(Msg, "刪除商品", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (DR == DialogResult.Yes)
                {
                    //MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
                    dgvStockDetails.Rows.RemoveAt(e.RowIndex);
                    getTaxTotals();
                }
            }
        }

        private void dgvStockDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0) // 確保一行Row只執行一次。 
            {
                dgvStockDetails.Rows[e.RowIndex].HeaderCell.Value = String.Format("{0}", e.RowIndex + 1);
            }
        }

        private void dgvStockDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 2 && dgvStockDetails.Rows[e.RowIndex].Cells["Totals"].Value != null)
            {
                int quantity = int.Parse(dgvStockDetails.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
                int prices = int.Parse(dgvStockDetails.Rows[e.RowIndex].Cells["CostPrice"].Value.ToString());
                int totals = quantity * prices;
                dgvStockDetails.Rows[e.RowIndex].Cells["Totals"].Value = totals.ToString();
                getTaxTotals();
            }
        }
        //新增
        private void tsbAddNew_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行進貨單[" + txtStockID.Text + "]新增動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "新增進貨單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunInsertData();
                }
            }
            else
            {
                MessageBox.Show("取消進貨單新增動作!!", "新增進貨單");
            }
        }
        //更改
        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行進貨單[" + txtStockID.Text + "]更新動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "更新進貨單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    SIS.DBClass.DBClassStockDetails DBCSD = new DBClass.DBClassStockDetails();
                    SIS.Configuration.Items[] oldItems = null;

                    oldItems = DBCSD.QueryData(txtStockID.Text);
                    if (oldItems ==null)
                    {
                        MessageBox.Show("對不起，資料庫不存在[ " + txtStockID.Text +
                          " ]進貨單資料!!(資料不存在)", "資料更新");
                        return;
                    }
                    RunUpdateData(oldItems);
                }
            }
            else
            {
                MessageBox.Show("取消進貨單更新動作!!", "更新進貨單");
            }
        }
        //刪除
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行進貨單[" + txtStockID.Text + "]刪除動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "刪除進貨單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    SIS.DBClass.DBClassStockDetails DBCSD = new DBClass.DBClassStockDetails();
                    SIS.Configuration.Items[] oldItems = null;

                    oldItems = DBCSD.QueryData(txtStockID.Text);
                    if (oldItems == null)
                    {
                        MessageBox.Show("對不起，資料庫不存在[ " + txtStockID.Text +
                          " ]進貨單資料!!(資料不存在)", "資料刪除");
                        return;
                    }
                    RunDeleteData(oldItems);
                }
            }
            else
            {
                MessageBox.Show("取消進貨單刪除動作!!", "刪除進貨單");
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
            string Msg = "是否要進行進貨單[" + txtStockID.Text + "]查詢動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "查詢進貨單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    SIS.DBClass.DBClassStockMaster DBCSM = new DBClass.DBClassStockMaster();
                    SIS.Configuration.ClsStockConfig CSC = new Configuration.ClsStockConfig();

                    bool result = DBCSM.QueryData(txtStockID.Text, CSC);
                    if (result)
                    {
                        MessageBox.Show("有找到進貨單號:[" + txtStockID.Text + "]資料!\r\n是否將進貨單資料載入?", "搜尋結果", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DR == DialogResult.Yes)
                        {
                            txtStockID.Text = CSC.StockID;
                            dtpStockDate.Text = CSC.StockDate;
                            txtTotalPreTax.Text = CSC.TotalPreTax.ToString();
                            txtTax.Text = CSC.Tax.ToString();
                            txtTotalAfterTax.Text = CSC.TotalAfterTax.ToString();
                            cboManufacturer.Text = My.MyMethod.SearchComboBoxItems(cboManufacturer, CSC.ManufacturerID);
                            txtBusinessTaxStockTaxRate.Text = CSC.BusinessTaxStockTaxRate.ToString();
                            mtbAmountPaid.Text = CSC.AmountPaid.ToString();
                            txtUnpaidAmount.Text = CSC.UnpaidAmount.ToString();
                            cboStockStaff.Text = CSC.StockStaff;
                            cboPaymentType.Text = My.MyMethod.SearchComboBoxItems(cboPaymentType, CSC.PaymentType);
                            rtbNotes.Text = CSC.Notes;

                            if (dgvStockDetails.Rows.Count > 1)
                            {
                                btnRemoveItems_Click(sender, e);
                            }

                            for (int i = 0; i < CSC.StockItems.Length; i++)
                            {
                                var index = dgvStockDetails.Rows.Add();
                                dgvStockDetails.Rows[index].Cells["ItemsID"].Value = CSC.StockItems[i].ItemsID;
                                dgvStockDetails.Rows[index].Cells["NAME"].Value = CSC.StockItems[i].NAME;
                                dgvStockDetails.Rows[index].Cells["Quantity"].Value = CSC.StockItems[i].Quantity.ToString();
                                dgvStockDetails.Rows[index].Cells["ItemsUnit"].Value = CSC.StockItems[i].ItemsUnit;
                                dgvStockDetails.Rows[index].Cells["CostPrice"].Value = CSC.StockItems[i].Price.ToString();
                                dgvStockDetails.Rows[index].Cells["Totals"].Value = CSC.StockItems[i].Totals.ToString();
                                dgvStockDetails.Rows[index].Cells["Notes"].Value = CSC.StockItems[i].Notes;
                            }
                            getTaxTotals();

                        }

                    }
                    else
                    {
                        MessageBox.Show("沒有找到進貨單號:[" + txtStockID.Text + "]資料!", "搜尋結果");
                    }
                }
            }
            else
            {
                MessageBox.Show("取消進貨單查詢動作!!", "查詢進貨單");
            }
        }
        //列印
        private void tsbPrint_Click(object sender, EventArgs e)
        {
            if (CheckField())
            {
                SIS.DBClass.DBClassStockMaster DBCSM = new DBClass.DBClassStockMaster();
                bool result = DBCSM.QueryData(txtStockID.Text);
                if (result)
                {

                    FrmReportPrint FRP = new FrmReportPrint("StockID", txtStockID.Text,"rptStockMaster");
                    FRP.ShowDialog();

                }
                else
                {
                    MessageBox.Show("沒有找到進貨單號:[" + txtStockID.Text + "]資料，無法列印!", "列印結果");
                }
            }
        }
        //離開
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxPayOff_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPayOff.Checked == true && txtTotalAfterTax.Text != "")
            {
                if (My.MyMethod.IsNumeric(txtTotalAfterTax.Text))
                {
                    mtbAmountPaid.Text = txtTotalAfterTax.Text;
                }

            }
            else
            {
                mtbAmountPaid.Text = "0";
            }
        }

    }

}
