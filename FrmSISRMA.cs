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
    public partial class FrmSISRMA : Form , IDisposable 
    {
        public FrmSISRMA()
        {
            InitializeComponent();
        }
        //實作Singleton Pattern
        private static object syncRoot = new Object();
        private static FrmSISRMA RMA;
        public static FrmSISRMA Instance
        {
            get
            {
                lock(syncRoot)
                {
                    if (RMA ==null)
                    {
                        RMA = new FrmSISRMA();
                    }
                    return RMA;
                }
            }
        }
        ~FrmSISRMA()
        {
            RMA = null;
        }

        private string RMAType = "Customer"; //Customer or Manufacturer
        private void FrmSISRMA_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            rdoRMAShip.Checked = true;
            LoadDefaultValue();
            My.MyMethod.DataIntoComboBox(cboStaff, "EmployeeInfo", "EmployeeID", "CNAME", "%");
            My.MyMethod.DataIntoComboBox(cboPaymentType, "PaymentType", "PaymentID", "PaymentName", "%", true);
            cboStaff.Text = cboStaff.Items[0].ToString();
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
            this.dgvRMADetails.Columns["NAME"].Frozen = true;

            //設定點選任一儲存格變選取所屬資料列的所有資料
            this.dgvRMADetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //替代資料列樣式 
            this.dgvRMADetails.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dgvRMADetails.AlternatingRowsDefaultCellStyle.BackColor = Color.Ivory;

            //自動調整資料列與資料行的高度與寬度
            this.dgvRMADetails.AutoResizeColumns();
            this.dgvRMADetails.AutoResizeRows();

            //防止在 DataGridView 控制項中新增和刪除資料列 
            this.dgvRMADetails.AllowUserToAddRows = false;
            this.dgvRMADetails.AllowUserToDeleteRows = false;

            //列標頭依據顯示內容自動調整大小
            this.dgvRMADetails.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            dgvRMADetails.Columns["ItemsID"].ReadOnly = true;
            dgvRMADetails.Columns["Name"].ReadOnly = true;
            dgvRMADetails.Columns["Quantity"].ReadOnly = true;
            dgvRMADetails.Columns["ItemsUnit"].ReadOnly = true;
            dgvRMADetails.Columns["Price"].ReadOnly = true;
            dgvRMADetails.Columns["Totals"].ReadOnly = true;


            toolTip1.SetToolTip(txtRMAID, "請輸入[退貨單號]!");
            tsbAddNew.ToolTipText = "按下[新增]鈕,以進行退貨單新增動作!";
            tsbUpdate.ToolTipText = "按下[更改]鈕,以進行退貨單更改動作!";
            tsbDelete.ToolTipText = "按下[刪除]鈕,以進行退貨單刪除動作!";
            tsbClear.ToolTipText = "按下[清除]鈕,以進行輸入欄位資料清除動作!";
            tsbQuery.ToolTipText = "按下[查詢]鈕,以查詢輸入退貨單號是否存在，並且可選擇是否載入資料!";
            tsbPrint.ToolTipText = "按下[列印]鈕,若有找到輸入的退貨單號會將相關商品明細進行列印!";
            tsbExit.ToolTipText = "按下[離開]鈕,會將本表單進行關閉!";

        }

        #endregion



        
        //自動產生進貨單號
        private void btnAutoNumber_Click(object sender, EventArgs e)
        {
            txtRMAID.Text = My.MyMethod.RunID("RMA");
        }

        /// <summary>
        /// 清除欄位資料
        /// </summary>
        private void ClearField()
        {
            txtRMAID.Text = "";
            txtStockIDOrShipID.Text = "";
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
            if (txtStockIDOrShipID.Text == "")
            {
                MessageBox.Show("[出貨單號]或[進貨單號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(txtStockIDOrShipID, "[出貨單號]或[進貨單號]不得為空白!");
                txtStockIDOrShipID.Focus();
                return false;
            }
            return true;
        }
        public bool CheckField(SIS.Configuration.CheckFieldType checkFieldType)
        {
            if (txtRMAID.Text == "")
            {
                MessageBox.Show("[退貨單號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(txtStockIDOrShipID, "[退貨單號]不得為空白!");
                txtStockIDOrShipID.Focus();
                return false;
            }
            switch (checkFieldType)
            {
                case  Configuration.CheckFieldType.Insert :


                    if (txtStockIDOrShipID.Text == "")
                    {
                        MessageBox.Show("[出貨單號]或[進貨單號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                        errorProvider1.SetError(txtStockIDOrShipID, "[出貨單號]或[進貨單號]不得為空白!");
                        txtStockIDOrShipID.Focus();
                        return false;
                    }
                    break;
                case  Configuration.CheckFieldType.Update :
                    goto case Configuration.CheckFieldType.Insert; //Update 與 Insert 檢查欄位一樣
                case Configuration.CheckFieldType.Delete :
                    return true;
                case Configuration.CheckFieldType.Query :
                    return true;
                case  Configuration.CheckFieldType.Print :
                    return true;
            }

            return true;

        }

        #endregion




        private void getTaxTotals()
        {
            if (dgvRMADetails.Rows.Count >= 1)
            {
                double amount = 0; //商品總計
                amount = ComputeDataGridViewCell(dgvRMADetails, "Totals");// int.Parse(dgvPurchaseDetails.Rows[0].Cells["Totals"].Value.ToString());
                txtTotalPreTax.Text = amount.ToString();
                int taxRate = int.Parse(txtBusinessTax.Text);
                double tax = Math.Round(((amount * taxRate) / 100), 0, MidpointRounding.AwayFromZero);//稅額-四捨五入
                txtTax.Text = tax.ToString();
                double TotalAfterTax = amount + tax;
                txtTotalAfterTax.Text = TotalAfterTax.ToString();
                tsslDataCount.Text = string.Format("{0}", (dgvRMADetails.Rows.Count));
                int AmountPad = int.Parse(mtbAmountPaid.Text);
                double CountResult = AmountPad - TotalAfterTax;
                if ( CountResult >0 )
                {
                    mtbRMAAmount.Text = CountResult.ToString();
                    txtUnpaidAmount.Text ="0";
                }
                else
                {
                    txtUnpaidAmount.Text = CountResult.ToString();
                    mtbRMAAmount.Text = "0";
                }
            }
            else
            {
                txtTotalPreTax.Text = "";
                txtTax.Text = "";
                txtTotalAfterTax.Text = "";
                txtUnpaidAmount.Text = "";
                mtbRMAAmount.Text = "";
            }
        }


        private void btnLoadItems_Click(object sender, EventArgs e)
        {
            if (CheckField())
            {
                if (rdoRMAShip.Checked ==true)
                {
                    SIS.DBClass.DBClassShipMaster DBCSM = new DBClass.DBClassShipMaster();
                    SIS.Configuration.ClsShipConfig CSC = new Configuration.ClsShipConfig();

                    bool result = DBCSM.QueryData(txtStockIDOrShipID.Text, CSC);
                    mtbAmountPaid.Text = CSC.AmountPaid.ToString();
                    txtUnpaidAmount.Text = CSC.UnpaidAmount.ToString();
                    txtBusinessTax.Text = CSC.BusinessTaxShipTaxRate.ToString();
                    mtbRMAAmount.Text = mtbAmountPaid.Text;

                    if (result)
                    {
                        DialogResult DR;
                        DR = MessageBox.Show("有找到出貨單號:[" + txtStockIDOrShipID.Text + "]資料!\r\n是否將出貨單資料載入?", "搜尋結果", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DR == DialogResult.Yes)
                        {

                            if (dgvRMADetails.Rows.Count > 1)
                            {
                                //要從最後面資料列開始往上移除才能正確執行
                                for (int i = dgvRMADetails.Rows.Count - 1; i >= 0; i--)
                                {
                                    dgvRMADetails.Rows.RemoveAt(i);
                                    System.Threading.Thread.Sleep(100);
                                }

                            }

                            for (int i = 0; i < CSC.ShipItems.Length; i++)
                            {
                                var index = dgvRMADetails.Rows.Add();
                                dgvRMADetails.Rows[index].Cells["ItemsID"].Value = CSC.ShipItems[i].ItemsID;
                                dgvRMADetails.Rows[index].Cells["NAME"].Value = CSC.ShipItems[i].NAME;
                                dgvRMADetails.Rows[index].Cells["Quantity"].Value = CSC.ShipItems[i].Quantity.ToString();
                                dgvRMADetails.Rows[index].Cells["RMAQuantity"].Value = CSC.ShipItems[i].Quantity.ToString();
                                dgvRMADetails.Rows[index].Cells["ItemsUnit"].Value = CSC.ShipItems[i].ItemsUnit;
                                dgvRMADetails.Rows[index].Cells["Price"].Value = CSC.ShipItems[i].Price.ToString();
                                dgvRMADetails.Rows[index].Cells["Totals"].Value = CSC.ShipItems[i].Totals.ToString();
                                dgvRMADetails.Rows[index].Cells["Notes"].Value = CSC.ShipItems[i].Notes;
                            }
                            getTaxTotals();

                        }

                    }
                    else
                    {
                        MessageBox.Show("沒有找到出貨單號:[" + txtStockIDOrShipID.Text + "]資料!", "搜尋結果");
                    }
                }
                else //  if (rdoRMAShip.Checked ==false)
                {
                    SIS.DBClass.DBClassStockMaster DBCSM = new DBClass.DBClassStockMaster();
                    SIS.Configuration.ClsStockConfig CSC = new Configuration.ClsStockConfig();

                    bool result = DBCSM.QueryData(txtStockIDOrShipID.Text, CSC);
                    mtbAmountPaid.Text = CSC.AmountPaid.ToString();
                    txtUnpaidAmount.Text = CSC.UnpaidAmount.ToString();
                    txtBusinessTax.Text = CSC.BusinessTaxStockTaxRate.ToString();

                    if (result)
                    {
                        DialogResult DR;
                        DR = MessageBox.Show("有找到進貨單號:[" + txtStockIDOrShipID.Text + "]資料!\r\n是否將進貨單資料載入?", "搜尋結果", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DR == DialogResult.Yes)
                        {

                            if (dgvRMADetails.Rows.Count > 1)
                            {
                                //要從最後面資料列開始往上移除才能正確執行
                                for (int i = dgvRMADetails.Rows.Count - 1; i >= 0; i--)
                                {
                                    dgvRMADetails.Rows.RemoveAt(i);
                                    System.Threading.Thread.Sleep(100);
                                }

                            }

                            for (int i = 0; i < CSC.StockItems.Length; i++)
                            {
                                var index = dgvRMADetails.Rows.Add();
                                dgvRMADetails.Rows[index].Cells["ItemsID"].Value = CSC.StockItems[i].ItemsID;
                                dgvRMADetails.Rows[index].Cells["NAME"].Value = CSC.StockItems[i].NAME;
                                dgvRMADetails.Rows[index].Cells["Quantity"].Value = CSC.StockItems[i].Quantity.ToString();
                                dgvRMADetails.Rows[index].Cells["RMAQuantity"].Value = CSC.StockItems[i].Quantity.ToString();
                                dgvRMADetails.Rows[index].Cells["ItemsUnit"].Value = CSC.StockItems[i].ItemsUnit;
                                dgvRMADetails.Rows[index].Cells["Price"].Value = CSC.StockItems[i].Price.ToString();
                                dgvRMADetails.Rows[index].Cells["Totals"].Value = CSC.StockItems[i].Totals.ToString();
                                dgvRMADetails.Rows[index].Cells["Notes"].Value = CSC.StockItems[i].Notes;
                            }
                            getTaxTotals();

                        }

                    }
                    else
                    {
                        MessageBox.Show("沒有找到進貨單號:[" + txtStockIDOrShipID.Text + "]資料!", "搜尋結果");
                    }
                }
              
            }

        }

        private void btnRemoveItems_Click(object sender, EventArgs e)
        {
            if (dgvRMADetails.Rows.Count > 1)
            {
                string Msg = "是否要將目前出貨清單所有商品移除動作?\r\n移除商品數:" + string.Format("{0}", (dgvRMADetails.Rows.Count));

                DialogResult DR;
                DR = MessageBox.Show(Msg, "移除所有商品", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (DR == DialogResult.Yes)
                {
                    //要從最後面資料列開始往上移除才能正確執行
                    for (int i = dgvRMADetails.Rows.Count - 1; i >= 0; i--)
                    {
                        dgvRMADetails.Rows.RemoveAt(i);
                        System.Threading.Thread.Sleep(100);
                    }
                    getTaxTotals();
                }
            }
            else if (dgvRMADetails.Rows.Count <= 1)
            {
                MessageBox.Show("出貨清單上沒有任何商品", "移除所有商品", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int ComputeDataGridViewCell(DataGridView dgv, string ColumnName)
        {
            int amout = 0;
            int totals = 0;
            if (dgv.Rows.Count >= 1)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {

                    if (row.Cells[ColumnName].Value != null)
                    {
                        //totals = int.Parse(row.Cells[ColumnName].Value.ToString());
                        int a = int.Parse(row.Cells["Quantity"].Value.ToString());
                        int b =  int.Parse(row.Cells["RMAQuantity"].Value.ToString());
                        int c = int.Parse(row.Cells["Price"].Value.ToString());
                        totals =  c * (a-b); //totals = 價格 * (購買數量-退貨數量)
                        amout = amout + totals;
                    }
                }
            }

            return amout;
        }


        private int FindDataGridViewCell(DataGridView dgv, string ColumnName, string ColumnValue)
        {
            if (dgv.Rows.Count >= 1)
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
                if (dgv.Rows.Count >= 1)
                {
                    items = new Configuration.Items[dgv.Rows.Count];
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
                        if (row.Cells["RMAQuantity"].Value != null)
                        {
                            oneItem.Quantity = int.Parse(row.Cells["RMAQuantity"].Value.ToString()); //注意：是退貨數量，不是購買數量
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

        #region "控制項事件處理區"

        private void dgvRMADetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 3 && dgvRMADetails.Rows[e.RowIndex].Cells["Totals"].Value != null )
            {
                if (dgvRMADetails.Rows[e.RowIndex].Cells["RMAQuantity"].Value != null)
                {
                    int rmaQuantity = int.Parse(dgvRMADetails.Rows[e.RowIndex].Cells["RMAQuantity"].Value.ToString());
                    int quantity = int.Parse(dgvRMADetails.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
                    if (rmaQuantity > quantity)
                    {
                        dgvRMADetails.Rows[e.RowIndex].Cells["RMAQuantity"].Value = quantity.ToString();
                        rmaQuantity = quantity;
                    }
                    int prices = int.Parse(dgvRMADetails.Rows[e.RowIndex].Cells["Price"].Value.ToString());
                    int totals = rmaQuantity * prices;
                    dgvRMADetails.Rows[e.RowIndex].Cells["Totals"].Value = totals.ToString();
                    getTaxTotals();
                }
                else
                {
                    dgvRMADetails.Rows[e.RowIndex].Cells["RMAQuantity"].Value = "1";
                }
               
            }

        }

        private void dgvRMADetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.RowIndex !=-1 && dgvRMADetails.Rows[e.RowIndex].Cells["ItemsID"].Value != null) //刪除鈕索引值
            {
                string Msg = "是否要進行商品[" + dgvRMADetails.Rows[e.RowIndex].Cells["ItemsID"].Value.ToString() + "-" + dgvRMADetails.Rows[e.RowIndex].Cells["Name"].Value.ToString() + "]刪除動作?\r\n";

                DialogResult DR;
                DR = MessageBox.Show(Msg, "刪除商品", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (DR == DialogResult.Yes)
                {
                    //MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
                    dgvRMADetails.Rows.RemoveAt(e.RowIndex);
                    getTaxTotals();
                }
            }
        }


        private void FrmSISRMA_KeyDown(object sender, KeyEventArgs e)
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


        private void rdoRMAStock_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRMAStock.Checked == true)
            {
                lblID.Text = "進貨單號";
                lblBusinessTax.Text = "進貨稅率";
                RMAType = "Manufacturer";
                txtBusinessTax.Text = My.MyGlobal.INIBusinessTaxStockTaxRate;
            }
            else
            {
                lblID.Text = "出貨單號";
                lblBusinessTax.Text = "出貨稅率";
                RMAType = "Customer";
                txtBusinessTax.Text = My.MyGlobal.INIBusinessTaxShipTaxRate;
            }
        }

        private void FrmSISRMA_FormClosing(object sender, FormClosingEventArgs e)
        {

            ClearField();
            //要從最後面資料列開始往上移除才能正確執行
            for (int i = dgvRMADetails.Rows.Count - 1; i >= 0; i--)
            {
                dgvRMADetails.Rows.RemoveAt(i);
            }
            getTaxTotals();
            //因為獨體模式若表單整個關閉，當重新開啟表單會產生錯誤，故採用隱藏方式處理表單。
            this.Hide();
            e.Cancel = true;
        }

        private void dgvRMADetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0) // 確保一行Row只執行一次。 
            {
                dgvRMADetails.Rows[e.RowIndex].HeaderCell.Value = String.Format("{0}", e.RowIndex + 1);
            }
        }


        #endregion


        #region "工具列功能區"

        //新增
        private void tsbAddNew_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行退貨單[" + txtRMAID.Text + "]新增動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "新增退貨單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField(SIS.Configuration.CheckFieldType.Insert))
                {
                    RunInsertData();
                }
            }
            else
            {
                MessageBox.Show("取消退貨單新增動作!!", "新增退貨單");
            }
        }

        //更改
        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行退貨單[" + txtRMAID.Text + "]更新動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "更新退貨單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField(SIS.Configuration.CheckFieldType.Update))
                {
                    SIS.DBClass.DBClassRMADetails DBCSD = new DBClass.DBClassRMADetails();
                    SIS.Configuration.Items[] oldItems = null;

                    oldItems = DBCSD.QueryData(txtRMAID.Text);
                    if (oldItems == null)
                    {
                        MessageBox.Show("對不起，資料庫不存在[ " + txtRMAID.Text +
                          " ]退貨單資料!!(資料不存在)", "資料更新");
                        return;
                    }
                    RunUpdateData(oldItems);
                }
            }
            else
            {
                MessageBox.Show("取消退貨單更新動作!!", "更新退貨單");
            }
        }
        //刪除
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行退貨單[" + txtRMAID.Text + "]刪除動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "刪除退貨單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField(SIS.Configuration.CheckFieldType.Delete))
                {
                    SIS.DBClass.DBClassRMAMaster DBCSM = new DBClass.DBClassRMAMaster();
                    SIS.Configuration.ClsRMAConfig CRC = new SIS.Configuration.ClsRMAConfig();
                    bool result = DBCSM.QueryData(txtRMAID.Text, CRC);
                    if (result==false)
                    {
                        MessageBox.Show("對不起，資料庫不存在[ " + txtRMAID.Text +
                          " ]出貨單資料!!(資料不存在)", "資料刪除");
                        return;
                    }
                    RunDeleteData(CRC);
                }
            }
            else
            {
                MessageBox.Show("取消退貨單刪除動作!!", "刪除退貨單");
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
            string Msg = "是否要進行退貨單[" + txtRMAID.Text + "]查詢動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "查詢退貨單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField( SIS.Configuration.CheckFieldType.Query))
                {
                    SIS.DBClass.DBClassRMAMaster DBCRM = new DBClass.DBClassRMAMaster();
                    SIS.Configuration.ClsRMAConfig CRC = new Configuration.ClsRMAConfig();

                    bool result = DBCRM.QueryData(txtRMAID.Text, CRC);
                    if (result)
                    {
                        MessageBox.Show("有找到退貨單號:[" + txtRMAID.Text + "]資料!\r\n是否將退貨單資料載入?", "搜尋結果", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DR == DialogResult.Yes)
                        {
                            txtRMAID.Text = CRC.RMAID;
                            dtpRMADate.Text = CRC.RMADate;
                            if (CRC.RMAType == "Customer")
                            {
                                rdoRMAShip.Checked = true;
                            }
                            else
                            {
                                rdoRMAStock.Checked = true;
                            }
                            //rdoRMAShip.Checked = (CRC.RMAType == "Customer") ? true : false;
                            //rdoRMAStock.Checked = (CRC.RMAType == "Manufacturer") ? true : false;
                            txtTotalPreTax.Text = CRC.TotalPreTax.ToString();
                            txtTax.Text = CRC.Tax.ToString();
                            txtTotalAfterTax.Text = CRC.TotalAfterTax.ToString();
                            txtStockIDOrShipID.Text = CRC.StockIDOrShipID;
                            txtBusinessTax.Text = CRC.BusinessTax.ToString();
                            mtbAmountPaid.Text = CRC.AmountPaid.ToString();
                            txtUnpaidAmount.Text = CRC.UnpaidAmount.ToString();
                            mtbRMAAmount.Text = CRC.RMAAmount.ToString();
                            cboStaff.Text = CRC.Staff;
                            cboPaymentType.Text = My.MyMethod.SearchComboBoxItems(cboPaymentType, CRC.PaymentType);
                            rtbNotes.Text = CRC.Notes;

                            if (dgvRMADetails.Rows.Count >= 1)
                            {
                                btnRemoveItems_Click(sender, e);
                            }

                            DBClass.DBClassShipDetails DBShip = new DBClass.DBClassShipDetails();
                            DBClass.DBClassStockDetails DBStock = new DBClass.DBClassStockDetails();

                            for (int i = 0; i < CRC.RMAItems.Length; i++)
                            {
                                var index = dgvRMADetails.Rows.Add();
                                dgvRMADetails.Rows[index].Cells["ItemsID"].Value = CRC.RMAItems[i].ItemsID;
                                dgvRMADetails.Rows[index].Cells["NAME"].Value = CRC.RMAItems[i].NAME;
                                if (CRC.RMAType == "Customer")
                                {
                                    dgvRMADetails.Rows[index].Cells["Quantity"].Value = DBShip.QueryItemQuantity(CRC.StockIDOrShipID, CRC.RMAItems[i].ItemsID);
                                }
                                else
                                {
                                    dgvRMADetails.Rows[index].Cells["Quantity"].Value = DBStock.QueryItemQuantity(CRC.StockIDOrShipID, CRC.RMAItems[i].ItemsID);
                                }
                                //dgvRMADetails.Rows[index].Cells["Quantity"].Value = CRC.RMAItems[i].Quantity.ToString();
                                dgvRMADetails.Rows[index].Cells["RMAQuantity"].Value = CRC.RMAItems[i].Quantity.ToString();
                                dgvRMADetails.Rows[index].Cells["ItemsUnit"].Value = CRC.RMAItems[i].ItemsUnit;
                                dgvRMADetails.Rows[index].Cells["Price"].Value = CRC.RMAItems[i].Price.ToString();
                                dgvRMADetails.Rows[index].Cells["Totals"].Value = CRC.RMAItems[i].Totals.ToString();
                                dgvRMADetails.Rows[index].Cells["Notes"].Value = CRC.RMAItems[i].Notes;
                            }
                            getTaxTotals();

                        }

                    }
                    else
                    {
                        MessageBox.Show("沒有找到退貨單號:[" + txtRMAID.Text + "]資料!", "搜尋結果");
                    }
                }
            }
            else
            {
                MessageBox.Show("取消退貨單查詢動作!!", "查詢進貨單");
            }
        }

        //列印
        private void tsbPrint_Click(object sender, EventArgs e)
        {
            if (CheckField(Configuration.CheckFieldType.Print))
            {
                SIS.DBClass.DBClassRMAMaster DBCRM = new DBClass.DBClassRMAMaster();
                bool result = DBCRM.QueryData(txtRMAID.Text);
                if (result)
                {

                    FrmReportPrint FRP = new FrmReportPrint("RMAID", txtRMAID.Text, "rptRMAMaster");
                    FRP.ShowDialog();

                }
                else
                {
                    MessageBox.Show("沒有找到退貨單號:[" + txtRMAID.Text + "]資料，無法列印!", "列印結果");
                }
            }
        }

        //離開
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region "資料庫異動處理區"

        /// <summary>
        /// 將資料寫入資料庫中
        /// </summary>
        private void RunInsertData()
        {
            try
            {
                My.MyDatabase MyDb = new My.MyDatabase();
                SIS.Configuration.ClsRMAConfig CRC = new Configuration.ClsRMAConfig();
                CRC.RMAID = txtRMAID.Text;
                CRC.RMADate = dtpRMADate.Value.ToString("yyyy年MM月dd日");
                CRC.RMAType = RMAType;
                CRC.TotalPreTax = int.Parse(txtTotalPreTax.Text);
                CRC.Tax = int.Parse(txtTax.Text);
                CRC.TotalAfterTax = int.Parse(txtTotalAfterTax.Text);
                CRC.StockIDOrShipID = txtStockIDOrShipID.Text ;
                CRC.BusinessTax = int.Parse(txtBusinessTax.Text);
                CRC.AmountPaid = int.Parse(mtbAmountPaid.Text);
                CRC.UnpaidAmount = int.Parse(txtUnpaidAmount.Text);
                CRC.RMAAmount = int.Parse(mtbRMAAmount.Text);
                CRC.Staff = cboStaff.Text;
                CRC.PaymentType = cboPaymentType.Text.Split('-')[1];
                CRC.Notes = rtbNotes.Text.Replace("'", "''");
                CRC.RMAItems = getItemsValueFromDataGridView(dgvRMADetails);

                SIS.DBClass.DBClassRMAMaster DBCRM = new DBClass.DBClassRMAMaster();

                if (MyDb.AuthPK(CRC.RMAID, "RMAID", "RMAMaster") == false)
                {
                    if (DBCRM.InsertData(CRC))
                    {
                        MessageBox.Show("新增[" + CRC.RMAID +
                            "]退貨單資料成功", "新增退貨單資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show("新增[" + CRC.RMAID +
                            "]退貨單資料失敗", "新增退貨單資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("對不起，資料庫已存在[ " + CRC.RMAID +
                          " ]退貨單資料!!(資料重複)", "資料新增");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤訊息:" + ex.Message.ToString(), "發生例外");
            }

        }



        /// <summary>
        /// 更新資料庫中的相關資料
        /// </summary>
        private void RunUpdateData(SIS.Configuration.Items[] OldItems)
        {
            try
            {
                My.MyDatabase MyDb = new My.MyDatabase();
                SIS.Configuration.ClsRMAConfig CRC = new Configuration.ClsRMAConfig();
                CRC.RMAID = txtRMAID.Text;
                CRC.RMADate = dtpRMADate.Value.ToString("yyyy年MM月dd日");
                CRC.RMAType = RMAType;
                CRC.TotalPreTax = int.Parse(txtTotalPreTax.Text);
                CRC.Tax = int.Parse(txtTax.Text);
                CRC.TotalAfterTax = int.Parse(txtTotalAfterTax.Text);
                CRC.StockIDOrShipID = txtStockIDOrShipID.Text;
                CRC.BusinessTax = int.Parse(txtBusinessTax.Text);
                CRC.AmountPaid = int.Parse(mtbAmountPaid.Text);
                CRC.UnpaidAmount = int.Parse(txtUnpaidAmount.Text);
                CRC.RMAAmount = int.Parse(mtbRMAAmount.Text);
                CRC.Staff = cboStaff.Text;
                CRC.PaymentType = cboPaymentType.Text.Split('-')[1];
                CRC.Notes = rtbNotes.Text.Replace("'", "''");
                CRC.RMAItems = getItemsValueFromDataGridView(dgvRMADetails);

                SIS.DBClass.DBClassRMAMaster DBCRM = new DBClass.DBClassRMAMaster();

                if (MyDb.AuthPK(CRC.RMAID, "RMAID", "RMAMaster") == true)
                {
                    if (DBCRM.Update(CRC , OldItems))
                    {
                        MessageBox.Show("更新[" + CRC.RMAID +
                            "]退貨單資料成功", "更新退貨單資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show("更新[" + CRC.RMAID +
                            "]退貨單資料失敗", "更新退貨單資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("對不起，資料庫不存在[ " + CRC.RMAID +
                          " ]退貨單資料!!(資料不存在)", "資料更新");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤訊息:" + ex.Message.ToString(), "發生例外");
            }
        }

        /// <summary>
        /// 刪除資料庫中的相關資料
        /// </summary>
        private void RunDeleteData(SIS.Configuration.ClsRMAConfig  OldCRC)
        {
            try
            {
                My.MyDatabase MyDb = new My.MyDatabase();
                SIS.Configuration.ClsRMAConfig CRC = new Configuration.ClsRMAConfig();
                CRC.RMAID = txtRMAID.Text;

                SIS.DBClass.DBClassRMAMaster DBCRM = new DBClass.DBClassRMAMaster();

                if (MyDb.AuthPK(CRC.RMAID, "RMAID", "RMAMaster") == true)
                {
                    if (DBCRM.DeleteMasterDetailsData(CRC.RMAID, OldCRC))
                    {
                        MessageBox.Show("刪除[" + CRC.RMAID +
                            "]退貨單資料成功", "刪除退貨單資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show("刪除[" + CRC.RMAID +
                            "]退貨單資料失敗", "刪除退貨單資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("對不起，資料庫不存在[ " + CRC.RMAID +
                          " ]退貨單資料!!(資料不存在)", "資料刪除");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤訊息:" + ex.Message.ToString(), "發生例外");
            }
        }

        #endregion



      
       
        

      

       



    }

   

}
