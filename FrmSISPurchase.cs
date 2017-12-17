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
    public partial class FrmSISPurchase : Form
    {
        public FrmSISPurchase()
        {
            InitializeComponent();
        }
        FrmItemsQuery FIQ;
        private void FrmSISPurchase_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            LoadDefaultValue();
            My.MyMethod.DataIntoComboBox(cboManufacturer, "ManufacturerInfo", "ManufacturerID", "CNAME", "%");
            My.MyMethod.DataIntoComboBox(cboPurchaseStaff, "EmployeeInfo", "EmployeeID", "CNAME", "%");
            My.MyMethod.DataIntoComboBox(cboDeliveryAddress, "CompanyInfo", "Address");
            My.MyMethod.DataIntoComboBox(cboPaymentType, "PaymentType", "PaymentID", "PaymentName", "%",true);
            txtBusinessTaxStockTaxRate.Text = My.MyGlobal.INIBusinessTaxStockTaxRate;
            cboManufacturer.Text = cboManufacturer.Items[0].ToString();
            cboPurchaseStaff.Text = cboPurchaseStaff.Items[0].ToString();
            cboDeliveryAddress.Text = cboDeliveryAddress.Items[0].ToString();
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
            this.dgvPurchaseDetails.Columns["NAME"].Frozen = true;

            //設定點選任一儲存格變選取所屬資料列的所有資料
            this.dgvPurchaseDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //替代資料列樣式 
            this.dgvPurchaseDetails.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dgvPurchaseDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.Ivory;

            //自動調整資料列與資料行的高度與寬度
            this.dgvPurchaseDetails.AutoResizeColumns();
            this.dgvPurchaseDetails.AutoResizeRows();

            //防止在 DataGridView 控制項中新增和刪除資料列 
            //this.dgvPurchaseDetails.AllowUserToAddRows = false;
            //this.dgvPurchaseDetails.AllowUserToDeleteRows = false;

            //列標頭依據顯示內容自動調整大小
            this.dgvPurchaseDetails.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            dgvPurchaseDetails.Columns["ItemsID"].ReadOnly = true;
            dgvPurchaseDetails.Columns["Name"].ReadOnly = true;
            dgvPurchaseDetails.Columns["ItemsUnit"].ReadOnly = true;
            dgvPurchaseDetails.Columns["CostPrice"].ReadOnly = true;
            dgvPurchaseDetails.Columns["Totals"].ReadOnly = true;


            toolTip1.SetToolTip(txtPurchaseID, "請輸入[採購單號]!");
            tsbAddNew.ToolTipText = "按下[新增]鈕,以進行採購單新增動作!";
            tsbUpdate.ToolTipText = "按下[更改]鈕,以進行採購單更改動作!";
            tsbDelete.ToolTipText = "按下[刪除]鈕,以進行採購單刪除動作!";
            tsbClear.ToolTipText = "按下[清除]鈕,以進行輸入欄位資料清除動作!";
            tsbQuery.ToolTipText = "按下[查詢]鈕,以查詢輸入採購單號是否存在，並且可選擇是否載入資料!";
            tsbPrint.ToolTipText ="按下[列印]鈕,若有找到輸入的採購單號會將相關商品明細進行列印!";
            tsbExit.ToolTipText = "按下[離開]鈕,會將本表單進行關閉!";

        }

        #endregion


        /// <summary>
        /// 清除欄位資料
        /// </summary>
        private void ClearField()
        {
            txtPurchaseID.Text = "";
            mtbPurchasePhone.Text = "";
            this.cboManufacturer.Text = cboManufacturer.Items[0].ToString();
            cboDeliveryAddress.Text = "";
            this.rtbNotes.Text = "";
        }


        //自動產生採購單號
        private void btnAutoNumber_Click(object sender, EventArgs e)
        {
            txtPurchaseID.Text = My.MyMethod.RunID("PU");
        }

        private void cboPurchaseStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPurchaseStaff.Text != "")
            {
                string EmployeeID = cboPurchaseStaff.Text.Split('-')[0];
                My.MyDatabase myDB = new My.MyDatabase();
                mtbPurchasePhone.Text = myDB.GetTableFieldData("EmployeeInfo", "EmployeeID", EmployeeID, "Phone");
            }
        }

        private void dgvPurchaseDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0) // 確保一行Row只執行一次。 
            {
                dgvPurchaseDetails.Rows[e.RowIndex].HeaderCell.Value = String.Format("{0}", e.RowIndex + 1);
            }
        }

        private void dgvPurchaseDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.RowIndex != -1 && dgvPurchaseDetails.Rows[e.RowIndex].Cells["ItemsID"].Value != null) //刪除鈕索引值
            {
                string Msg = "是否要進行商品[" + dgvPurchaseDetails.Rows[e.RowIndex].Cells["ItemsID"].Value.ToString() + "-" + dgvPurchaseDetails.Rows[e.RowIndex].Cells["Name"].Value.ToString() + "]刪除動作?\r\n";

                DialogResult DR;
                DR = MessageBox.Show(Msg, "刪除商品", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (DR == DialogResult.Yes)
                {
                    //MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
                    dgvPurchaseDetails.Rows.RemoveAt(e.RowIndex);
                    getTaxTotals();
                }

            }

            dgvPurchaseDetails.Rows[e.RowIndex].ReadOnly = true;

            if (dgvPurchaseDetails.Rows[e.RowIndex].Cells["Quantity"].Value != null)
            {

                dgvPurchaseDetails.Rows[e.RowIndex].ReadOnly = false;

            }
        }

        private void dgvPurchaseDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 2 && dgvPurchaseDetails.Rows[e.RowIndex].Cells["Totals"].Value != null)
            {
                int quantity = int.Parse(dgvPurchaseDetails.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
                int prices = int.Parse(dgvPurchaseDetails.Rows[e.RowIndex].Cells["CostPrice"].Value.ToString());
                int totals = quantity * prices;
                dgvPurchaseDetails.Rows[e.RowIndex].Cells["Totals"].Value = totals.ToString();
                getTaxTotals();
            }
        }

        //加入商品
        private void btnAddItems_Click(object sender, EventArgs e)
        {
            FIQ = new FrmItemsQuery();
            FIQ.Closed += new EventHandler(FIQClose);
            FIQ.ShowDialog();
        }

        public void FIQClose(object sender, EventArgs e)
        {
            if (FIQ.isAddButtonClick ==true)
            {
                int rowIndex = FindDataGridViewCell(dgvPurchaseDetails, "ItemsID", FIQ.ItemsID);
                if (rowIndex !=-1) //有找到相同商品編號
                {
                    dgvPurchaseDetails.Rows[rowIndex].Cells["ItemsID"].Value = FIQ.ItemsID;
                    dgvPurchaseDetails.Rows[rowIndex].Cells["NAME"].Value = FIQ.NAME;
                    int totalQuantity = int.Parse(FIQ.Quantity) + int.Parse(dgvPurchaseDetails.Rows[rowIndex].Cells["Quantity"].Value.ToString());
                    dgvPurchaseDetails.Rows[rowIndex].Cells["Quantity"].Value = totalQuantity.ToString();
                    dgvPurchaseDetails.Rows[rowIndex].Cells["ItemsUnit"].Value = FIQ.ItemsUnit;
                    dgvPurchaseDetails.Rows[rowIndex].Cells["CostPrice"].Value = FIQ.CostPrice ;
                    int newTotals = int.Parse(FIQ.CostPrice) * totalQuantity;
                    dgvPurchaseDetails.Rows[rowIndex].Cells["Totals"].Value = newTotals.ToString();
                    dgvPurchaseDetails.Rows[rowIndex].Cells["Notes"].Value = FIQ.Notes;
                }
                else
                {
                var index = dgvPurchaseDetails.Rows.Add();
                dgvPurchaseDetails.Rows[index].Cells["ItemsID"].Value = FIQ.ItemsID;
                dgvPurchaseDetails.Rows[index].Cells["NAME"].Value = FIQ.NAME;
                dgvPurchaseDetails.Rows[index].Cells["Quantity"].Value = FIQ.Quantity;
                dgvPurchaseDetails.Rows[index].Cells["ItemsUnit"].Value = FIQ.ItemsUnit;
                dgvPurchaseDetails.Rows[index].Cells["CostPrice"].Value = FIQ.CostPrice;
                dgvPurchaseDetails.Rows[index].Cells["Totals"].Value = FIQ.Totals;
                dgvPurchaseDetails.Rows[index].Cells["Notes"].Value = FIQ.Notes;
                }
                getTaxTotals();
              

            }
            

        }

        private void getTaxTotals()
        {
            if (dgvPurchaseDetails.Rows.Count >= 2)
            {
                double amount = 0; //商品總計
                amount = ComputeDataGridViewCell(dgvPurchaseDetails, "Totals");// int.Parse(dgvPurchaseDetails.Rows[0].Cells["Totals"].Value.ToString());
                txtTotalPreTax.Text = amount.ToString();
                int taxRate = int.Parse(txtBusinessTaxStockTaxRate.Text);
                double tax = Math.Round(((amount * taxRate) / 100), 0, MidpointRounding.AwayFromZero);//稅額-四捨五入
                txtTax.Text = tax.ToString();
                double TotalAfterTax = amount + tax;
                txtTotalAfterTax.Text = TotalAfterTax.ToString(); 
                tsslDataCount.Text = (dgvPurchaseDetails.Rows.Count - 1).ToString();
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


        private int FindDataGridViewCell(DataGridView dgv , string ColumnName , string ColumnValue)
        {
            if (dgv.Rows.Count >1)
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
            SIS.Configuration.Items[] items=null;
            try
            {
                if (dgv.Rows.Count > 1)
                {
                    items = new Configuration.Items[dgv.Rows.Count-1];
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


        private void btnRemoveItems_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseDetails.Rows.Count >1)
            {
                string Msg = "是否要將目前採購清單所有商品移除動作?\r\n移除商品數:" + string.Format("{0}",(dgvPurchaseDetails.Rows.Count -1));

                DialogResult DR;
                DR = MessageBox.Show(Msg, "移除所有商品", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (DR == DialogResult.Yes)
                {
                    //要從最後面資料列開始往上移除才能正確執行
                    for (int i = dgvPurchaseDetails.Rows.Count -2 ; i >= 0; i--)
                    {
                        dgvPurchaseDetails.Rows.RemoveAt(i);
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            else if (dgvPurchaseDetails.Rows.Count <=1)
            {
                MessageBox.Show("採購清單上沒有任何商品", "移除所有商品", MessageBoxButtons.OK , MessageBoxIcon.Information);
            }
            
        }

        #region "欄位驗證"

        /// <summary>
        /// 欄位驗證
        /// </summary>
        /// <returns>輸入欄位型態正確回傳true,否則回傳false</returns>
        public bool CheckField()
        {

            if (txtPurchaseID.Text == "")
            {
                MessageBox.Show("[採購單號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(txtPurchaseID, "[採購單號]不得為空白!");
                txtPurchaseID.Focus();
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
                SIS.Configuration.ClsPurchaseConfig CPC = new Configuration.ClsPurchaseConfig();
                CPC.PurchaseID = txtPurchaseID.Text;
                CPC.PurchaseDate = dtpPurchaseDate.Value.ToString("yyyy年MM月dd日");
                CPC.DeliveryDate = dtpDeliveryDate.Value.ToString("yyyy年MM月dd日");
                CPC.ManufacturerID = cboManufacturer.Text.Substring(0, cboManufacturer.Text.IndexOf("-"));
                CPC.PurchaseStaff = cboPurchaseStaff.Text;
                CPC.PurchasePhone = mtbPurchasePhone.Text;
                CPC.DeliveryAddress = cboDeliveryAddress.Text;
                CPC.PaymentType = cboPaymentType.Text.Split('-')[1];
                CPC.BusinessTaxStockTaxRate = int.Parse(txtBusinessTaxStockTaxRate.Text);
                CPC.TotalPreTax = int.Parse(txtTotalPreTax.Text);
                CPC.Tax = int.Parse(txtTax.Text);
                CPC.TotalAfterTax = int.Parse(txtTotalAfterTax.Text);
                CPC.Notes = rtbNotes.Text.Replace("'", "''");

                CPC.PurchaseItems = getItemsValueFromDataGridView(dgvPurchaseDetails);

                //SIS.DBClass.DBClassPurchaseMaster DBCPM = new DBClass.DBClassPurchaseMaster();
                //實作工廠模式(Factory Pattern)
                var Processor = SIS.Configuration.SISProcessorFactory.getInstance(SIS.Configuration.SISOperating.Purchase);

                if (MyDb.AuthPK(CPC.PurchaseID, "PurchaseID", "PurchaseMaster") == false)
                {
                    if (Processor.Insert(CPC)) //DBCPM.InsertData(CPC)
                    {
                        MessageBox.Show("新增[" + CPC.PurchaseID +
                            "]採購單資料成功", "新增採購單資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show("新增[" + CPC.PurchaseID +
                            "]採購單資料失敗", "新增採購單資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("對不起，資料庫已存在[ " + CPC.PurchaseID +
                          " ]採購單資料!!(資料重複)", "資料新增");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤訊息:" + ex.Message.ToString(), "發生例外");
            }

        }


        #endregion

        private void RunUpdateData()
        {
            try
            {
                My.MyDatabase MyDb = new My.MyDatabase();
                SIS.Configuration.ClsPurchaseConfig CPC = new Configuration.ClsPurchaseConfig();
                CPC.PurchaseID = txtPurchaseID.Text;
                CPC.PurchaseDate = dtpPurchaseDate.Value.ToString("yyyy年MM月dd日");
                CPC.DeliveryDate = dtpDeliveryDate.Value.ToString("yyyy年MM月dd日");
                CPC.ManufacturerID = cboManufacturer.Text.Substring(0, cboManufacturer.Text.IndexOf("-"));
                CPC.PurchaseStaff = cboPurchaseStaff.Text;
                CPC.PurchasePhone = mtbPurchasePhone.Text;
                CPC.DeliveryAddress = cboDeliveryAddress.Text;
                CPC.PaymentType = cboPaymentType.Text.Split('-')[1];
                CPC.BusinessTaxStockTaxRate = int.Parse(txtBusinessTaxStockTaxRate.Text);
                CPC.TotalPreTax = int.Parse(txtTotalPreTax.Text);
                CPC.Tax = int.Parse(txtTax.Text);
                CPC.TotalAfterTax = int.Parse(txtTotalAfterTax.Text);
                CPC.Notes = rtbNotes.Text.Replace("'", "''");

                CPC.PurchaseItems = getItemsValueFromDataGridView(dgvPurchaseDetails);

                SIS.DBClass.DBClassPurchaseMaster DBCPM = new DBClass.DBClassPurchaseMaster();

                if (MyDb.AuthPK(CPC.PurchaseID, "PurchaseID", "PurchaseMaster") == true)
                {
                    if (DBCPM.Update(CPC))
                    {
                        MessageBox.Show("更新[" + CPC.PurchaseID +
                            "]採購單資料成功", "更新採購單資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show("更新[" + CPC.PurchaseID +
                            "]採購單資料失敗", "更新採購單資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("對不起，資料庫不存在[ " + CPC.PurchaseID +
                          " ]採購單資料!!(資料不存在)", "資料更新");
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
                SIS.Configuration.ClsPurchaseConfig CPC = new Configuration.ClsPurchaseConfig();
                CPC.PurchaseID = txtPurchaseID.Text;

                SIS.DBClass.DBClassPurchaseMaster DBCPM = new DBClass.DBClassPurchaseMaster();

                if (MyDb.AuthPK(CPC.PurchaseID, "PurchaseID", "PurchaseMaster") == true)
                {
                    if (DBCPM.DeleteMasterDetailsData(CPC.PurchaseID))
                    {
                        MessageBox.Show("刪除[" + CPC.PurchaseID +
                            "]採購單資料成功", "刪除採購單資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show("刪除[" + CPC.PurchaseID +
                            "]採購單資料失敗", "刪除採購單資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("對不起，資料庫不存在[ " + CPC.PurchaseID +
                          " ]採購單資料!!(資料不存在)", "資料刪除");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤訊息:" + ex.Message.ToString(), "發生例外");
            }
        }


        //新增
        private void tsbAddNew_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行採購單[" +txtPurchaseID.Text  + "]新增動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "新增採購單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunInsertData();
                }
            }
            else
            {
                MessageBox.Show("取消採購單新增動作!!", "新增採購單");
            }
        }


        //更改
        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行採購單[" + txtPurchaseID.Text + "]更新動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "更新採購單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunUpdateData();
                }
            }
            else
            {
                MessageBox.Show("取消採購單更新動作!!", "更新採購單");
            }
        }
        //刪除
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行採購單[" + txtPurchaseID.Text + "]刪除動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "刪除採購單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunDeleteData();
                }
            }
            else
            {
                MessageBox.Show("取消採購單刪除動作!!", "刪除採購單");
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
            string Msg = "是否要進行採購單[" + txtPurchaseID.Text + "]查詢動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "查詢採購單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    SIS.DBClass.DBClassPurchaseMaster DBCPM = new DBClass.DBClassPurchaseMaster();
                    SIS.Configuration.ClsPurchaseConfig CPC = new Configuration.ClsPurchaseConfig();

                    bool result = DBCPM.QueryData(txtPurchaseID.Text ,CPC);
                    if (result)
                    {
                        MessageBox.Show("有找到採購單號:[" + txtPurchaseID.Text + "]資料!\r\n是否將採購單資料載入?", "搜尋結果", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DR == DialogResult.Yes)
                        {
                            txtPurchaseID.Text = CPC.PurchaseID;
                            dtpPurchaseDate.Text = CPC.PurchaseDate;
                            dtpDeliveryDate.Text = CPC.DeliveryDate;
                            cboManufacturer.Text = My.MyMethod.SearchComboBoxItems(cboManufacturer, CPC.ManufacturerID);
                            cboPurchaseStaff.Text = CPC.PurchaseStaff;
                            mtbPurchasePhone.Text = CPC.PurchasePhone;
                            cboDeliveryAddress.Text = CPC.DeliveryAddress;
                            cboPaymentType.Text = My.MyMethod.SearchComboBoxItems(cboPaymentType, CPC.PaymentType);
                            txtBusinessTaxStockTaxRate.Text = CPC.BusinessTaxStockTaxRate.ToString();
                            txtTotalPreTax.Text = CPC.TotalPreTax.ToString();
                            txtTax.Text = CPC.Tax.ToString();
                            txtTotalAfterTax.Text = CPC.TotalAfterTax.ToString();
                            rtbNotes.Text = CPC.Notes;

                            if (dgvPurchaseDetails.Rows.Count >1)
                            {
                                btnRemoveItems_Click(sender, e);
                            }

                            for(int i=0;i< CPC.PurchaseItems.Length ;i++)
                            {
                                var index = dgvPurchaseDetails.Rows.Add();
                                dgvPurchaseDetails.Rows[index].Cells["ItemsID"].Value = CPC.PurchaseItems[i].ItemsID;
                                dgvPurchaseDetails.Rows[index].Cells["NAME"].Value =  CPC.PurchaseItems[i].NAME;
                                dgvPurchaseDetails.Rows[index].Cells["Quantity"].Value =  CPC.PurchaseItems[i].Quantity.ToString();
                                dgvPurchaseDetails.Rows[index].Cells["ItemsUnit"].Value = CPC.PurchaseItems[i].ItemsUnit;
                                dgvPurchaseDetails.Rows[index].Cells["CostPrice"].Value = CPC.PurchaseItems[i].Price.ToString();
                                dgvPurchaseDetails.Rows[index].Cells["Totals"].Value = CPC.PurchaseItems[i].Totals.ToString();
                                dgvPurchaseDetails.Rows[index].Cells["Notes"].Value = CPC.PurchaseItems[i].Notes;
                            }
                            getTaxTotals();

                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("沒有找到採購單號:[" + txtPurchaseID.Text + "]資料!", "搜尋結果");
                    }
                }
            }
            else
            {
                MessageBox.Show("取消採購單查詢動作!!", "查詢採購單");
            }

            //if (DV.Count == 0)
            //{
            //    MessageBox.Show("搜尋條件並未找到任何符合資料", "搜尋結果", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            //}
            //else
            //{
            //    MessageBox.Show("共找到資料筆數" + DV.Count.ToString(), "搜尋結果");
            //}

        }
        //列印
        private void tsbPrint_Click(object sender, EventArgs e)
        {
            if (CheckField())
            {
                SIS.DBClass.DBClassPurchaseMaster DBCPM = new DBClass.DBClassPurchaseMaster();
                bool result = DBCPM.QueryData(txtPurchaseID.Text);
                if (result)
                {

                    FrmReportPrint FRP = new FrmReportPrint("PurchaseID", txtPurchaseID.Text, "rptPurchaseMaster");
                    FRP.ShowDialog();
                
                }
                else
                {
                    MessageBox.Show("沒有找到採購單號:[" + txtPurchaseID.Text + "]資料，無法列印!", "列印結果");
                }
            }

        }
        //離開
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSISPurchase_KeyDown(object sender, KeyEventArgs e)
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

    }
}
