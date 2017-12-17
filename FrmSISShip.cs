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
    public partial class FrmSISShip : Form
    {
        public FrmSISShip()
        {
            InitializeComponent();
        }
        FrmItemsQuery FIQ;
        private void FrmSISShip_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            LoadDefaultValue();
            My.MyMethod.DataIntoComboBox(cboCustomer, "CustomerInfo", "CustomerID", "CNAME", "%");
            My.MyMethod.DataIntoComboBox(cboShipStaff, "EmployeeInfo", "EmployeeID", "CNAME", "%");
            My.MyMethod.DataIntoComboBox(cboPaymentType, "PaymentType", "PaymentID", "PaymentName", "%", true);
            txtBusinessTaxShipTaxRate.Text = My.MyGlobal.INIBusinessTaxShipTaxRate;
            cboCustomer.Text = cboCustomer.Items[0].ToString();
            cboShipStaff.Text = cboShipStaff.Items[0].ToString();
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
            this.dgvShipDetails.Columns["NAME"].Frozen = true;

            //設定點選任一儲存格變選取所屬資料列的所有資料
            this.dgvShipDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //替代資料列樣式 
            this.dgvShipDetails.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dgvShipDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.Ivory;

            //自動調整資料列與資料行的高度與寬度
            this.dgvShipDetails.AutoResizeColumns();
            this.dgvShipDetails.AutoResizeRows();

            //防止在 DataGridView 控制項中新增和刪除資料列 
            //this.dgvShipDetails.AllowUserToAddRows = false;
            //this.dgvShipDetails.AllowUserToDeleteRows = false;

            //列標頭依據顯示內容自動調整大小
            this.dgvShipDetails.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            dgvShipDetails.Columns["ItemsID"].ReadOnly = true;
            dgvShipDetails.Columns["Name"].ReadOnly = true;
            dgvShipDetails.Columns["ItemsUnit"].ReadOnly = true;
            dgvShipDetails.Columns["SellingPrice"].ReadOnly = true;
            dgvShipDetails.Columns["Totals"].ReadOnly = true;


            toolTip1.SetToolTip(txtShipID, "請輸入[出貨單號]!");
            tsbAddNew.ToolTipText = "按下[新增]鈕,以進行出貨單新增動作!";
            tsbUpdate.ToolTipText = "按下[更改]鈕,以進行出貨單更改動作!";
            tsbDelete.ToolTipText = "按下[刪除]鈕,以進行出貨單刪除動作!";
            tsbClear.ToolTipText = "按下[清除]鈕,以進行輸入欄位資料清除動作!";
            tsbQuery.ToolTipText = "按下[查詢]鈕,以查詢輸入出貨單號是否存在，並且可選擇是否載入資料!";
            tsbPrint.ToolTipText = "按下[列印]鈕,若有找到輸入的出貨單號會將相關商品明細進行列印!";
            tsbExit.ToolTipText = "按下[離開]鈕,會將本表單進行關閉!";

        }

        #endregion

        /// <summary>
        /// 清除欄位資料
        /// </summary>
        private void ClearField()
        {
            txtShipID.Text = "";
            this.cboCustomer.Text = cboCustomer.Items[0].ToString();
            mtbAmountPaid.Text = "0";
            this.rtbNotes.Text = "";
        }

        #region "欄位驗證"

        /// <summary>
        /// 欄位驗證
        /// </summary>
        /// <returns>輸入欄位型態正確回傳true,否則回傳false</returns>
        public bool CheckField()
        {

            if (txtShipID.Text == "")
            {
                MessageBox.Show("[出貨單號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(txtShipID, "[出貨單號]不得為空白!");
                txtShipID.Focus();
                return false;
            }

            return true;

        }

        #endregion


        private void getTaxTotals()
        {
            if (dgvShipDetails.Rows.Count >= 2)
            {
                double amount = 0; //商品總計
                amount = ComputeDataGridViewCell(dgvShipDetails, "Totals");// int.Parse(dgvPurchaseDetails.Rows[0].Cells["Totals"].Value.ToString());
                txtTotalPreTax.Text = amount.ToString();
                int taxRate = int.Parse(txtBusinessTaxShipTaxRate.Text);
                double tax = Math.Round(((amount * taxRate) / 100), 0, MidpointRounding.AwayFromZero);//稅額-四捨五入
                txtTax.Text = tax.ToString();
                double TotalAfterTax = amount + tax; 
                txtTotalAfterTax.Text = TotalAfterTax.ToString(); 
                tsslDataCount.Text = string.Format("{0}", (dgvShipDetails.Rows.Count - 1));
            }
            else
            {
                txtTotalPreTax.Text = "";
                txtTax.Text = "";
                txtTotalAfterTax.Text = "";
                txtUnpaidAmount.Text = "";
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
                        if (row.Cells["SellingPrice"].Value != null)
                        {
                            oneItem.Price = int.Parse(row.Cells["SellingPrice"].Value.ToString());
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

        #region "將資料寫入資料庫中"

        /// <summary>
        /// 將資料寫入資料庫中
        /// </summary>
        private void RunInsertData()
        {
            try
            {
                My.MyDatabase MyDb = new My.MyDatabase();
                SIS.Configuration.ClsShipConfig CSC = new Configuration.ClsShipConfig();
                CSC.ShipID = txtShipID.Text;
                CSC.ShipDate = dtpShipDate.Value.ToString("yyyy年MM月dd日");
                CSC.TotalPreTax = int.Parse(txtTotalPreTax.Text);
                CSC.Tax = int.Parse(txtTax.Text);
                CSC.TotalAfterTax = int.Parse(txtTotalAfterTax.Text);
                CSC.CustomerID = cboCustomer.Text.Substring(0, cboCustomer.Text.IndexOf("-"));
                CSC.BusinessTaxShipTaxRate = int.Parse(txtBusinessTaxShipTaxRate.Text);
                CSC.AmountPaid = int.Parse(mtbAmountPaid.Text);
                CSC.UnpaidAmount = int.Parse(txtUnpaidAmount.Text);
                CSC.ShipStaff = cboShipStaff.Text;
                CSC.PaymentType = cboPaymentType.Text.Split('-')[1];
                CSC.Notes = rtbNotes.Text.Replace("'", "''");
                CSC.ShipItems = getItemsValueFromDataGridView(dgvShipDetails);

                SIS.DBClass.DBClassShipMaster DBCSM = new DBClass.DBClassShipMaster();

                if (MyDb.AuthPK(CSC.ShipID, "ShipID", "ShipMaster") == false)
                {
                    if (DBCSM.InsertData(CSC))
                    {
                        MessageBox.Show("新增[" + CSC.ShipID +
                            "]出貨單資料成功", "新增出貨單資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show("新增[" + CSC.ShipID +
                            "]出貨單資料失敗", "新增出貨單資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("對不起，資料庫已存在[ " + CSC.ShipID +
                          " ]出貨單資料!!(資料重複)", "資料新增");
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
                SIS.Configuration.ClsShipConfig CSC = new Configuration.ClsShipConfig();
                CSC.ShipID = txtShipID.Text;
                CSC.ShipDate = dtpShipDate.Value.ToString("yyyy年MM月dd日");
                CSC.TotalPreTax = int.Parse(txtTotalPreTax.Text);
                CSC.Tax = int.Parse(txtTax.Text);
                CSC.TotalAfterTax = int.Parse(txtTotalAfterTax.Text);
                CSC.CustomerID = cboCustomer.Text.Substring(0, cboCustomer.Text.IndexOf("-"));
                CSC.BusinessTaxShipTaxRate = int.Parse(txtBusinessTaxShipTaxRate.Text);
                CSC.AmountPaid = int.Parse(mtbAmountPaid.Text);
                CSC.UnpaidAmount = int.Parse(txtUnpaidAmount.Text);
                CSC.ShipStaff = cboShipStaff.Text;
                CSC.PaymentType = cboPaymentType.Text.Split('-')[1];
                CSC.Notes = rtbNotes.Text.Replace("'", "''");
                CSC.ShipItems = getItemsValueFromDataGridView(dgvShipDetails);

                SIS.DBClass.DBClassShipMaster DBCSM = new DBClass.DBClassShipMaster();

                if (MyDb.AuthPK(CSC.ShipID, "ShipID", "ShipMaster") == true)
                {
                    if (DBCSM.Update(CSC , OldItems))
                    {
                        MessageBox.Show("更新[" + CSC.ShipID +
                            "]出貨單資料成功", "更新出貨單資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show("更新[" + CSC.ShipID +
                            "]出貨單資料失敗", "更新出貨單資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("對不起，資料庫不存在[ " + CSC.ShipID +
                          " ]出貨單資料!!(資料不存在)", "資料更新");
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
                SIS.Configuration.ClsShipConfig CSC = new Configuration.ClsShipConfig();
                CSC.ShipID = txtShipID.Text;

                SIS.DBClass.DBClassShipMaster DBCSM = new DBClass.DBClassShipMaster();

                if (MyDb.AuthPK(CSC.ShipID, "ShipID", "ShipMaster") == true)
                {
                    if (DBCSM.DeleteMasterDetailsData(CSC.ShipID, OldItems))
                    {
                        MessageBox.Show("刪除[" + CSC.ShipID +
                            "]出貨單資料成功", "刪除出貨單資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show("刪除[" + CSC.ShipID +
                            "]出貨單資料失敗", "刪除出貨單資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("對不起，資料庫不存在[ " + CSC.ShipID +
                          " ]出貨單資料!!(資料不存在)", "資料刪除");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤訊息:" + ex.Message.ToString(), "發生例外");
            }
        }


        private void FrmSISShip_KeyDown(object sender, KeyEventArgs e)
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



        //自動產生出貨單號
        private void btnAutoNumber_Click(object sender, EventArgs e)
        {
            txtShipID.Text = My.MyMethod.RunID("SH");
        }

        private void cbxPayOff_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPayOff.Checked == true && txtTotalAfterTax.Text !="")
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

        private void dgvShipDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.RowIndex != -1 && dgvShipDetails.Rows[e.RowIndex].Cells["ItemsID"].Value != null) //刪除鈕索引值
            {
                string Msg = "是否要進行商品[" + dgvShipDetails.Rows[e.RowIndex].Cells["ItemsID"].Value.ToString() + "-" + dgvShipDetails.Rows[e.RowIndex].Cells["Name"].Value.ToString() + "]刪除動作?\r\n";

                DialogResult DR;
                DR = MessageBox.Show(Msg, "刪除商品", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (DR == DialogResult.Yes)
                {
                    //MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
                    dgvShipDetails.Rows.RemoveAt(e.RowIndex);
                    getTaxTotals();
                }
            }
        }

        private void dgvShipDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 2 && dgvShipDetails.Rows[e.RowIndex].Cells["Totals"].Value != null)
            {
                int quantity = int.Parse(dgvShipDetails.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
                int prices = int.Parse(dgvShipDetails.Rows[e.RowIndex].Cells["SellingPrice"].Value.ToString());
                int totals = quantity * prices;
                dgvShipDetails.Rows[e.RowIndex].Cells["Totals"].Value = totals.ToString();
                getTaxTotals();
            }
        }

        private void dgvShipDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0) // 確保一行Row只執行一次。 
            {
                dgvShipDetails.Rows[e.RowIndex].HeaderCell.Value = String.Format("{0}", e.RowIndex + 1);
            }
        }

        //加入商品
        private void btnAddItems_Click(object sender, EventArgs e)
        {
            FIQ = new FrmItemsQuery("SellingPrice");
            FIQ.Closed += new EventHandler(FIQClose);
            FIQ.ShowDialog();
        }

        public void FIQClose(object sender, EventArgs e)
        {
            if (FIQ.isAddButtonClick == true)
            {
                int rowIndex = FindDataGridViewCell(dgvShipDetails, "ItemsID", FIQ.ItemsID);
                if (rowIndex != -1) //有找到相同商品編號
                {
                    dgvShipDetails.Rows[rowIndex].Cells["ItemsID"].Value = FIQ.ItemsID;
                    dgvShipDetails.Rows[rowIndex].Cells["NAME"].Value = FIQ.NAME;
                    int totalQuantity = int.Parse(FIQ.Quantity) + int.Parse(dgvShipDetails.Rows[rowIndex].Cells["Quantity"].Value.ToString());
                    dgvShipDetails.Rows[rowIndex].Cells["Quantity"].Value = totalQuantity.ToString();
                    dgvShipDetails.Rows[rowIndex].Cells["ItemsUnit"].Value = FIQ.ItemsUnit;
                    dgvShipDetails.Rows[rowIndex].Cells["SellingPrice"].Value = FIQ.CostPrice;
                    int newTotals = int.Parse(FIQ.CostPrice) * totalQuantity;
                    dgvShipDetails.Rows[rowIndex].Cells["Totals"].Value = newTotals.ToString();
                    dgvShipDetails.Rows[rowIndex].Cells["Notes"].Value = FIQ.Notes;
                }
                else
                {
                    var index = dgvShipDetails.Rows.Add();
                    dgvShipDetails.Rows[index].Cells["ItemsID"].Value = FIQ.ItemsID;
                    dgvShipDetails.Rows[index].Cells["NAME"].Value = FIQ.NAME;
                    dgvShipDetails.Rows[index].Cells["Quantity"].Value = FIQ.Quantity;
                    dgvShipDetails.Rows[index].Cells["ItemsUnit"].Value = FIQ.ItemsUnit;
                    dgvShipDetails.Rows[index].Cells["SellingPrice"].Value = FIQ.CostPrice;
                    dgvShipDetails.Rows[index].Cells["Totals"].Value = FIQ.Totals;
                    dgvShipDetails.Rows[index].Cells["Notes"].Value = FIQ.Notes;
                }
                getTaxTotals();

            }
        }

        private void btnRemoveItems_Click(object sender, EventArgs e)
        {
            if (dgvShipDetails.Rows.Count > 1)
            {
                string Msg = "是否要將目前出貨清單所有商品移除動作?\r\n移除商品數:" + string.Format("{0}", (dgvShipDetails.Rows.Count - 1));

                DialogResult DR;
                DR = MessageBox.Show(Msg, "移除所有商品", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (DR == DialogResult.Yes)
                {
                    //要從最後面資料列開始往上移除才能正確執行
                    for (int i = dgvShipDetails.Rows.Count - 2; i >= 0; i--)
                    {
                        dgvShipDetails.Rows.RemoveAt(i);
                        System.Threading.Thread.Sleep(100);
                    }
                    getTaxTotals();
                }
            }
            else if (dgvShipDetails.Rows.Count <= 1)
            {
                MessageBox.Show("出貨清單上沒有任何商品", "移除所有商品", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void getUnpaidAmount()
        {
            if (txtTotalAfterTax.Text != "" && My.MyMethod.IsNumeric(mtbAmountPaid.Text))
            {
                int AmountPaid = int.Parse(mtbAmountPaid.Text);
                int TotalAfterTax = int.Parse(txtTotalAfterTax.Text);
                int UnpaidAmount = 0;
                if (AmountPaid > TotalAfterTax)
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

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomer.Text != "")
            {
                string CustomerID = cboCustomer.Text.Split('-')[0];
                My.MyDatabase myDB = new My.MyDatabase();
                mtbPhone.Text = myDB.GetTableFieldData("CustomerInfo", "CustomerID", CustomerID, "Phone");
                txtAddress.Text = myDB.GetTableFieldData("CustomerInfo", "CustomerID", CustomerID, "Address");
            }
        }
        //新增
        private void tsbAddNew_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行出貨單[" + txtShipID.Text + "]新增動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "新增出貨單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunInsertData();
                }
            }
            else
            {
                MessageBox.Show("取消出貨單新增動作!!", "新增進貨單");
            }
        }
        //更改
        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行出貨單[" + txtShipID.Text + "]更新動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "更新出貨單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    SIS.DBClass.DBClassShipDetails DBCSD = new DBClass.DBClassShipDetails();
                    SIS.Configuration.Items[] oldItems = null;

                    oldItems = DBCSD.QueryData(txtShipID.Text);
                    if (oldItems == null)
                    {
                        MessageBox.Show("對不起，資料庫不存在[ " + txtShipID.Text +
                          " ]進貨單資料!!(資料不存在)", "資料更新");
                        return;
                    }

                    RunUpdateData(oldItems);
                }
            }
            else
            {
                MessageBox.Show("取消出貨單更新動作!!", "更新出貨單");
            }
        }
        //刪除
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行出貨單[" + txtShipID.Text + "]刪除動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "刪除出貨單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    SIS.DBClass.DBClassShipDetails DBCSD = new DBClass.DBClassShipDetails();
                    SIS.Configuration.Items[] oldItems = null;

                    oldItems = DBCSD.QueryData(txtShipID.Text);
                    if (oldItems == null)
                    {
                        MessageBox.Show("對不起，資料庫不存在[ " + txtShipID.Text +
                          " ]出貨單資料!!(資料不存在)", "資料刪除");
                        return;
                    }
                    RunDeleteData(oldItems);
                }
            }
            else
            {
                MessageBox.Show("取消出貨單刪除動作!!", "刪除出貨單");
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
            string Msg = "是否要進行出貨單[" + txtShipID.Text + "]查詢動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "查詢進貨單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    SIS.DBClass.DBClassShipMaster DBCSM = new DBClass.DBClassShipMaster();
                    SIS.Configuration.ClsShipConfig CSC = new Configuration.ClsShipConfig();

                    bool result = DBCSM.QueryData(txtShipID.Text, CSC);
                    if (result)
                    {
                        MessageBox.Show("有找到出貨單號:[" + txtShipID.Text + "]資料!\r\n是否將出貨單資料載入?", "搜尋結果", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DR == DialogResult.Yes)
                        {
                            txtShipID.Text = CSC.ShipID;
                            dtpShipDate.Text = CSC.ShipDate;
                            txtTotalPreTax.Text = CSC.TotalPreTax.ToString();
                            txtTax.Text = CSC.Tax.ToString();
                            txtTotalAfterTax.Text = CSC.TotalAfterTax.ToString();
                            cboCustomer.Text = My.MyMethod.SearchComboBoxItems(cboCustomer, CSC.CustomerID);
                            txtBusinessTaxShipTaxRate.Text = CSC.BusinessTaxShipTaxRate.ToString();
                            mtbAmountPaid.Text = CSC.AmountPaid.ToString();
                            txtUnpaidAmount.Text = CSC.UnpaidAmount.ToString();
                            cboShipStaff.Text = CSC.ShipStaff;
                            cboPaymentType.Text = My.MyMethod.SearchComboBoxItems(cboPaymentType, CSC.PaymentType);
                            rtbNotes.Text = CSC.Notes;

                            if (dgvShipDetails.Rows.Count > 1)
                            {
                                btnRemoveItems_Click(sender, e);
                            }

                            for (int i = 0; i < CSC.ShipItems.Length; i++)
                            {
                                var index = dgvShipDetails.Rows.Add();
                                dgvShipDetails.Rows[index].Cells["ItemsID"].Value = CSC.ShipItems[i].ItemsID;
                                dgvShipDetails.Rows[index].Cells["NAME"].Value = CSC.ShipItems[i].NAME;
                                dgvShipDetails.Rows[index].Cells["Quantity"].Value = CSC.ShipItems[i].Quantity.ToString();
                                dgvShipDetails.Rows[index].Cells["ItemsUnit"].Value = CSC.ShipItems[i].ItemsUnit;
                                dgvShipDetails.Rows[index].Cells["SellingPrice"].Value = CSC.ShipItems[i].Price.ToString();
                                dgvShipDetails.Rows[index].Cells["Totals"].Value = CSC.ShipItems[i].Totals.ToString();
                                dgvShipDetails.Rows[index].Cells["Notes"].Value = CSC.ShipItems[i].Notes;
                            }
                            getTaxTotals();

                        }

                    }
                    else
                    {
                        MessageBox.Show("沒有找到進貨單號:[" + txtShipID.Text + "]資料!", "搜尋結果");
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
                SIS.DBClass.DBClassShipMaster DBCSM = new DBClass.DBClassShipMaster();
                bool result = DBCSM.QueryData(txtShipID.Text);
                if (result)
                {

                    FrmReportPrint FRP = new FrmReportPrint("ShipID", txtShipID.Text, "rptShipMaster");
                    FRP.ShowDialog();

                }
                else
                {
                    MessageBox.Show("沒有找到出貨單號:[" + txtShipID.Text + "]資料，無法列印!", "列印結果");
                }
            }
        }


        //離開
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

 



    }
}
