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
    public partial class FrmSISReversal : Form
    {
        public FrmSISReversal()
        {
            InitializeComponent();
        }

        private void FrmSISReversal_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            LoadDefaultValue();
            rdoReversalShip.Checked = true;
            tsslDataCount.Text = dgvAccountsReceivable.Rows.Count.ToString();
            My.MyMethod.DataIntoComboBox(cboReversalStaff, "EmployeeInfo", "EmployeeID", "CNAME", "%");
            My.MyMethod.DataIntoComboBox(cboPaymentType, "PaymentType", "PaymentID", "PaymentName", "%", true);
            cboReversalStaff.Text = cboReversalStaff.Items[0].ToString();
            cboPaymentType.Text = cboPaymentType.Items[0].ToString();

        }

        #region "載入表單控制項相關預設值"

        /// <summary>
        /// 載入表單控制項相關預設值
        /// </summary>
        public void LoadDefaultValue()
        {
            LoadAccountsReceivable();
            LoadAccountsPayable();
            
            toolTip1.SetToolTip(txtReversalID, "請輸入[沖銷單號]!");
            tsbAddNew.ToolTipText = "按下[新增]鈕,以進行沖銷單新增動作!";
            tsbUpdate.ToolTipText = "按下[更改]鈕,以進行沖銷單更改動作!";
            tsbDelete.ToolTipText = "按下[刪除]鈕,以進行沖銷單刪除動作!";
            tsbClear.ToolTipText = "按下[清除]鈕,以進行輸入欄位資料清除動作!";
            tsbQuery.ToolTipText = "按下[查詢]鈕,以查詢輸入退貨單號是否存在，並且可選擇是否載入資料!";
            tsbPrint.ToolTipText = "按下[列印]鈕,若有找到輸入的沖銷單號會將相關商品明細進行列印!";
            tsbExit.ToolTipText = "按下[離開]鈕,會將本表單進行關閉!";

        }

        #endregion

        private void LoadAccountsReceivable()
        {
            string SQLCommand = "SELECT  ShipMaster.ShipID,ShipMaster.CustomerID, " +
                            "CustomerInfo.CNAME , ResultUnpaidAmout = case  " +
                            "When RMAMaster.UnpaidAmount is null Then ShipMaster.UnpaidAmount " +
                            "Else " +
                            "RMAMaster.UnpaidAmount " +
                            "End ,ReversalAmount  = case " +
                            "When Reversal.ReversalAmount is null Then 0 " +
                            "Else " +
                            "Reversal.ReversalAmount " +
                            "End ,Reversal.IsReversal " +
                            "FROM  ShipMaster INNER JOIN " +
                           "CustomerInfo ON ShipMaster.CustomerID = CustomerInfo.CustomerID " +
                           "LEFT JOIN RMAMaster ON ShipMaster.ShipID = RMAMaster.StockIDOrShipID " +
                           "LEFT JOIN Reversal ON Reversal.StockIDOrShipID = ShipMaster.ShipID " +
                           "WHERE ShipMaster.UnpaidAmount < 0  AND (RMAMaster.UnpaidAmount is null or RMAMaster.UnpaidAmount < 0) ";

            My.MyDatabase MyDb = new My.MyDatabase();

            DataView DV = MyDb.CreateDataView(SQLCommand, "AccountsReceivable");
            this.dgvAccountsReceivable.DataSource = DV;

            //dataGridView表頭名稱中文化
            dgvAccountsReceivable.Columns[0].HeaderText = "出貨單號";
            dgvAccountsReceivable.Columns[1].HeaderText = "客戶編號";
            dgvAccountsReceivable.Columns[2].HeaderText = "客戶名稱";
            dgvAccountsReceivable.Columns[3].HeaderText = "未收金額";
            dgvAccountsReceivable.Columns[4].HeaderText = "沖銷金額";
            dgvAccountsReceivable.Columns[5].HeaderText = "是否沖銷";

            //凍結 中文名稱 欄位
            this.dgvAccountsReceivable.Columns["CNAME"].Frozen = true;

            //設定點選任一儲存格變選取所屬資料列的所有資料
            this.dgvAccountsReceivable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //替代資料列樣式 
            this.dgvAccountsReceivable.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dgvAccountsReceivable.AlternatingRowsDefaultCellStyle.BackColor = Color.Ivory;

            //自動調整資料列與資料行的高度與寬度
            this.dgvAccountsReceivable.AutoResizeColumns();
            this.dgvAccountsReceivable.AutoResizeRows();

            //防止在 DataGridView 控制項中新增和刪除資料列 
            this.dgvAccountsReceivable.AllowUserToAddRows = false;
            this.dgvAccountsReceivable.AllowUserToDeleteRows = false;

            //列標頭依據顯示內容自動調整大小
            this.dgvAccountsReceivable.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            //設定不能進行編輯的所有欄位
            dgvAccountsReceivable.Columns["ShipID"].ReadOnly = true;
            dgvAccountsReceivable.Columns["CustomerID"].ReadOnly = true;
            dgvAccountsReceivable.Columns["CNAME"].ReadOnly = true;
            dgvAccountsReceivable.Columns["ResultUnpaidAmout"].ReadOnly = true;
            dgvAccountsReceivable.Columns["ReversalAmount"].ReadOnly = true;
            dgvAccountsReceivable.Columns["IsReversal"].ReadOnly = true;
        }

        private void LoadAccountsPayable()
        {
            string SQLCommand = "SELECT  StockMaster.StockID,StockMaster.ManufacturerID, " +
                            "ManufacturerInfo.CNAME , ResultUnpaidAmout = case  " +
                            "When RMAMaster.UnpaidAmount is null Then StockMaster.UnpaidAmount " +
                            "Else " +
                            "RMAMaster.UnpaidAmount " +
                            "End ,ReversalAmount  = case " +
                            "When Reversal.ReversalAmount is null Then 0 " +
                            "Else " +
                            "Reversal.ReversalAmount " +
                            "End ,Reversal.IsReversal " +
                            "FROM  StockMaster INNER JOIN " +
                           "ManufacturerInfo ON StockMaster.ManufacturerID = ManufacturerInfo.ManufacturerID " +
                           "LEFT JOIN RMAMaster ON StockMaster.StockID = RMAMaster.StockIDOrShipID " +
                           "LEFT JOIN Reversal ON Reversal.StockIDOrShipID = StockMaster.StockID " +
                           "WHERE StockMaster.UnpaidAmount < 0  AND (RMAMaster.UnpaidAmount is null or RMAMaster.UnpaidAmount < 0) ";

            My.MyDatabase MyDb = new My.MyDatabase();

            DataView DV = MyDb.CreateDataView(SQLCommand, "AccountsPayable");
            this.dgvAccountsPayable.DataSource = DV;

            //dataGridView表頭名稱中文化
            dgvAccountsPayable.Columns[0].HeaderText = "進貨單號";
            dgvAccountsPayable.Columns[1].HeaderText = "廠商編號";
            dgvAccountsPayable.Columns[2].HeaderText = "廠商名稱";
            dgvAccountsPayable.Columns[3].HeaderText = "未付金額";
            dgvAccountsPayable.Columns[4].HeaderText = "沖銷金額";
            dgvAccountsPayable.Columns[5].HeaderText = "是否沖銷";


            //凍結 中文名稱 欄位
            this.dgvAccountsPayable.Columns["CNAME"].Frozen = true;

            //設定點選任一儲存格變選取所屬資料列的所有資料
            this.dgvAccountsPayable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //替代資料列樣式 
            this.dgvAccountsPayable.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dgvAccountsPayable.AlternatingRowsDefaultCellStyle.BackColor = Color.Ivory;

            //自動調整資料列與資料行的高度與寬度
            this.dgvAccountsPayable.AutoResizeColumns();
            this.dgvAccountsPayable.AutoResizeRows();

            //防止在 DataGridView 控制項中新增和刪除資料列 
            this.dgvAccountsPayable.AllowUserToAddRows = false;
            this.dgvAccountsPayable.AllowUserToDeleteRows = false;

            //列標頭依據顯示內容自動調整大小
            this.dgvAccountsPayable.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            //設定不能進行編輯的所有欄位
            dgvAccountsPayable.Columns["StockID"].ReadOnly = true;
            dgvAccountsPayable.Columns["ManufacturerID"].ReadOnly = true;
            dgvAccountsPayable.Columns["CNAME"].ReadOnly = true;
            dgvAccountsPayable.Columns["ResultUnpaidAmout"].ReadOnly = true;
            dgvAccountsPayable.Columns["ReversalAmount"].ReadOnly = true;
            dgvAccountsPayable.Columns["IsReversal"].ReadOnly = true;

        }

        private void rdoReversalShip_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoReversalShip.Checked == true)
            {
                lblCustomerOrManufacturer.Text = "客戶名稱";
                lblID.Text = "出貨單號";
                lblPaymentAmount.Text = "應收金額";
                tabControl1.SelectedIndex = 0;
            }
            else
            {
                lblCustomerOrManufacturer.Text = "廠商名稱";
                lblID.Text = "進貨單號";
                lblPaymentAmount.Text = "應付金額";
                tabControl1.SelectedIndex = 1;
            }
        }

        private void dgvAccountsReceivable_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex !=-1)
            {
                this.txtStockIDOrShipID.Text = dgvAccountsReceivable[0, e.RowIndex].Value.ToString();
                this.txtCustomerOrManufacturer.Text = dgvAccountsReceivable[1, e.RowIndex].Value.ToString() + "-" + dgvAccountsReceivable[2, e.RowIndex].Value.ToString();
                this.txtPaymentAmount.Text = dgvAccountsReceivable[3, e.RowIndex].Value.ToString();
                this.mtbReversalAmount.Text = dgvAccountsReceivable[4, e.RowIndex].Value.ToString();
                bool ischeck = (dgvAccountsReceivable[5, e.RowIndex].Value != null && true == (bool)dgvAccountsReceivable[5, e.RowIndex].EditedFormattedValue);
                if (ischeck)
                {
                    this.cbxIsReversal.Checked = bool.Parse(dgvAccountsReceivable[5, e.RowIndex].EditedFormattedValue.ToString());

                }
                else
                {
                    this.cbxIsReversal.Checked = false;
                }

            }
           
        }

        private void dgvAccountsPayable_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                this.txtStockIDOrShipID.Text = dgvAccountsPayable[0, e.RowIndex].Value.ToString();
                this.txtCustomerOrManufacturer.Text = dgvAccountsPayable[1, e.RowIndex].Value.ToString() + "-" + dgvAccountsPayable[2, e.RowIndex].Value.ToString();
                this.txtPaymentAmount.Text = dgvAccountsPayable[3, e.RowIndex].Value.ToString();
                this.mtbReversalAmount.Text = dgvAccountsPayable[4, e.RowIndex].Value.ToString();
                bool ischeck = (dgvAccountsPayable[5, e.RowIndex].Value != null && true == (bool)dgvAccountsPayable[5, e.RowIndex].EditedFormattedValue);
                if (ischeck)
                {
                    this.cbxIsReversal.Checked = bool.Parse(dgvAccountsPayable[5, e.RowIndex].EditedFormattedValue.ToString());

                }
                else
                {
                    this.cbxIsReversal.Checked = false;
                }

            }
        }


        private void cbxIsReversal_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxIsReversal.Checked && My.MyMethod.IsNumeric(txtPaymentAmount.Text))
            {
                int PaymentAmount = int.Parse(txtPaymentAmount.Text);
                mtbReversalAmount.Text = string.Format("{0}", -PaymentAmount);
            }
            else
            {
                mtbReversalAmount.Text = "0";
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (tabControl1.TabPages[e.TabPageIndex].Name)
            {
                case "tabPage1":
                    rdoReversalShip.Checked = true;
                    tsslDataCount.Text = dgvAccountsReceivable.Rows.Count.ToString();
                    break;
                case "tabPage2":
                    rdoReversalStock.Checked = true;
                    tsslDataCount.Text = dgvAccountsPayable.Rows.Count.ToString();
                    break;
                default:
                    rdoReversalShip.Checked = true;
                    break;
            }
        }

         /// <summary>
        /// 欄位驗證
        /// </summary>
        /// <returns>輸入欄位型態正確回傳true,否則回傳false</returns>
        public bool CheckField()
        {

            if (txtReversalID.Text == "")
            {
                MessageBox.Show("[沖銷單號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(txtReversalID, "[沖銷單號]不得為空白!");
                txtReversalID.Focus();
                return false;
            }

            return true;

        }

        /// <summary>
        /// 清除欄位資料
        /// </summary>
        private void ClearField()
        {
            txtReversalID.Text  = "";
            this.txtCustomerOrManufacturer.Text = "";
            txtStockIDOrShipID.Text = "";
            this.rtbNotes.Text = "";
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
                SIS.Configuration.ClsReversalConfig CRC = new Configuration.ClsReversalConfig();
                CRC.ReversalID = txtReversalID.Text;
                CRC.ReversalDate = dtpReversalDate.Value.ToString("yyyy年MM月dd日");
                CRC.ReversalStaff = cboReversalStaff.Text;
                if (rdoReversalShip.Checked ==true )
                {
                    CRC.ReversalType = "Customer";
                }
                else
                {
                    CRC.ReversalType = "Manufacturer";
                }

                CRC.CustomerOrManufacturer = txtCustomerOrManufacturer.Text;
                CRC.StockIDOrShipID = txtStockIDOrShipID.Text;
                CRC.PaymentAmount = int.Parse(txtPaymentAmount.Text);
                CRC.ReversalAmount = int.Parse(mtbReversalAmount.Text);
                CRC.IsReversal = cbxIsReversal.Checked;
                CRC.PaymentType = cboPaymentType.Text.Split('-')[1];
                CRC.Notes = rtbNotes.Text.Replace("'", "''");

                SIS.DBClass.DBClassReversal DBCR = new DBClass.DBClassReversal();

                if (MyDb.AuthPK(CRC.ReversalID, "ReversalID", "Reversal") == false)
                {
                    if (DBCR.InsertData(CRC))
                    {
                        MessageBox.Show("新增[" + CRC.ReversalID +
                            "]沖銷單資料成功", "新增沖銷單資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show("新增[" + CRC.ReversalID +
                            "]沖銷單資料失敗", "新增沖銷單資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("對不起，資料庫已存在[ " + CRC.ReversalID +
                          " ]沖銷單資料!!(資料重複)", "資料新增");
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
                SIS.Configuration.ClsReversalConfig CRC = new Configuration.ClsReversalConfig();
                CRC.ReversalID = txtReversalID.Text;
                CRC.ReversalDate = dtpReversalDate.Value.ToString("yyyy年MM月dd日");
                CRC.ReversalStaff = cboReversalStaff.Text;
                if (rdoReversalShip.Checked == true)
                {
                    CRC.ReversalType = "Customer";
                }
                else
                {
                    CRC.ReversalType = "Manufacturer";
                }

                CRC.CustomerOrManufacturer = txtCustomerOrManufacturer.Text;
                CRC.StockIDOrShipID = txtStockIDOrShipID.Text;
                CRC.PaymentAmount = int.Parse(txtPaymentAmount.Text);
                CRC.ReversalAmount = int.Parse(mtbReversalAmount.Text);
                CRC.IsReversal = cbxIsReversal.Checked;
                CRC.PaymentType = cboPaymentType.Text.Split('-')[1];
                CRC.Notes = rtbNotes.Text.Replace("'", "''");

                SIS.DBClass.DBClassReversal DBCR = new DBClass.DBClassReversal();

                if (MyDb.AuthPK(CRC.ReversalID, "ReversalID", "Reversal") == true)
                {
                    if (DBCR.Update(CRC))
                    {
                        MessageBox.Show("更新[" + CRC.ReversalID +
                            "]沖銷單資料成功", "更新沖銷單資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show("更新[" + CRC.ReversalID +
                            "]沖銷單資料失敗", "更新沖銷單資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("對不起，資料庫不存在[ " + CRC.ReversalID +
                          " ]沖銷單資料!!(資料不存在)", "資料更新");
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
                SIS.Configuration.ClsReversalConfig CRC = new Configuration.ClsReversalConfig();
                CRC.ReversalID = txtReversalID.Text;

                SIS.DBClass.DBClassReversal DBCR = new DBClass.DBClassReversal();

                if (MyDb.AuthPK(CRC.ReversalID, "ReversalID", "Reversal") == true)
                {
                    if (DBCR.DeleteOneData(CRC.ReversalID))
                    {
                        MessageBox.Show("刪除[" + CRC.ReversalID +
                            "]沖銷單資料成功", "刪除沖銷單資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show("刪除[" + CRC.ReversalID +
                            "]沖銷單資料失敗", "刪除沖銷單資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("對不起，資料庫不存在[ " + CRC.ReversalID +
                          " ]沖銷單資料!!(資料不存在)", "資料刪除");
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
            string Msg = "是否要進行沖銷單[" + txtReversalID.Text  + "]新增動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "新增沖銷單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunInsertData();
                }
            }
            else
            {
                MessageBox.Show("取消沖銷單新增動作!!", "新增盤點單");
            }
        }

        //更改
        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行沖銷單[" + txtReversalID.Text + "]更新動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "更新沖銷單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunUpdateData();
                }
            }
            else
            {
                MessageBox.Show("取消沖銷單更新動作!!", "更新沖銷單");
            }
        }

        //刪除
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行沖銷單[" + txtReversalID.Text + "]刪除動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "刪除沖銷單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunDeleteData();
                }
            }
            else
            {
                MessageBox.Show("取消沖銷單刪除動作!!", "刪除沖銷單");
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
            string Msg = "是否要進行沖銷單[" + txtReversalID.Text + "]查詢動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "查詢沖銷單", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    SIS.DBClass.DBClassReversal DBCR = new DBClass.DBClassReversal();
                    SIS.Configuration.ClsReversalConfig CRC = new Configuration.ClsReversalConfig();

                    bool result = DBCR.QueryData(txtReversalID.Text, CRC);
                    if (result)
                    {
                        MessageBox.Show("有找到沖銷單號:[" + txtReversalID.Text + "]資料!\r\n是否將沖銷單資料載入?", "搜尋結果", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DR == DialogResult.Yes)
                        {
                            txtReversalID.Text = CRC.ReversalID;
                            dtpReversalDate.Text = CRC.ReversalDate;
                            cboReversalStaff.Text = CRC.ReversalStaff;

                            if (CRC.ReversalType =="Customer")
                            {
                                //SIS.DBClass.DBClassCustomerInfo DBCCI = new DBClass.DBClassCustomerInfo();
                               // string CNAME = DBCCI.QueryData(CRC.CustomerOrManufacturer,"CNAME");
                                txtCustomerOrManufacturer.Text = CRC.CustomerOrManufacturer ;
                                rdoReversalShip.Checked =true ;
                            }
                            else
                            {
                                //SIS.DBClass.DBClassManufacturerInfo DBCMI = new DBClass.DBClassManufacturerInfo();
                                //string CNAME = DBCMI.QueryData(CRC.CustomerOrManufacturer, "CNAME");
                                txtCustomerOrManufacturer.Text = CRC.CustomerOrManufacturer;
                                rdoReversalStock.Checked =true;
                            }

                            txtStockIDOrShipID.Text = CRC.StockIDOrShipID;
                            txtPaymentAmount.Text = CRC.PaymentAmount.ToString();
                            mtbReversalAmount.Text = CRC.ReversalAmount.ToString();
                            cbxIsReversal.Checked = CRC.IsReversal ;
                            cboPaymentType.Text =My.MyMethod.SearchComboBoxItems(cboPaymentType, CRC.PaymentType);
                            rtbNotes.Text = CRC.Notes ;

                        }

                    }
                    else
                    {
                        MessageBox.Show("沒有找到沖銷單號:[" + txtReversalID.Text + "]資料!", "搜尋結果");
                    }
                }
            }
            else
            {
                MessageBox.Show("取消沖銷單查詢動作!!", "查詢沖銷單");
            }
        }


        //列印
        private void tsbPrint_Click(object sender, EventArgs e)
        {
            if (CheckField())
            {
                SIS.DBClass.DBClassReversal DBCR = new DBClass.DBClassReversal();
                bool result = DBCR.QueryData(txtReversalID.Text);
                if (result)
                {

                    FrmReportPrint FRP = new FrmReportPrint("ReversalID", txtReversalID.Text, "rptReversal");
                    FRP.ShowDialog();

                }
                else
                {
                    MessageBox.Show("沒有找到沖銷單號:[" + txtReversalID.Text + "]資料，無法列印!", "列印結果");
                }
            }
        }

        //離開
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
      
        //自動產生沖銷單號
        private void btnAutoNumber_Click(object sender, EventArgs e)
        {
            txtReversalID.Text = My.MyMethod.RunID("RE");
        }

        private void FrmSISReversal_KeyDown(object sender, KeyEventArgs e)
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

        private void dgvAccountsReceivable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0) // 確保一行Row只執行一次。 
            {
                dgvAccountsReceivable.Rows[e.RowIndex].HeaderCell.Value = String.Format("{0}", e.RowIndex + 1);
            }
        }

        private void dgvAccountsPayable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0) // 確保一行Row只執行一次。 
            {
                dgvAccountsPayable.Rows[e.RowIndex].HeaderCell.Value = String.Format("{0}", e.RowIndex + 1);
            }
        }

      

       



      
    }
}
