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
    public partial class FrmItemsQuery : Form
    {
        private string PriceType;
        public FrmItemsQuery()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="priceType">有三種CostPrice,SellingPrice,MSRP</param>
        public FrmItemsQuery(string priceType)
        {
            InitializeComponent();
            PriceType = priceType;
        }
        public string ItemsID = "";
        public string NAME = "";
        public string Quantity = "0";
        public string ItemsUnit = "";
        public string CostPrice = "0";
        public string SellingPrice = "0";
        public string Totals = "0";
        public string Notes = "";
        public bool isAddButtonClick = false;
        private void FrmItemQuery_Load(object sender, EventArgs e)
        {
            LoadDefaultValue();
            toolTip1.SetToolTip(btnQuery, "按下[查詢]鈕,以進行查詢產品相關資訊!");
            toolTip1.SetToolTip(btnClear, "按下[清除]鈕,以清除相關欄位文字!");
            toolTip1.SetToolTip(btnRefresh, "按下[重新整理]鈕,重新載入預設值!");
            toolTip1.SetToolTip(btnAdd, "按下[加入]鈕,把商品加入清單明細!");
            toolTip1.SetToolTip(btnExit, "按下[離開]鈕,以關閉本表單!");
        }

        #region "載入表單控制項相關預設值"

        /// <summary>
        /// 載入表單控制項相關預設值
        /// </summary>
        public void LoadDefaultValue()
        {
            string SQLCommand = "Select A1.ItemsID ,A1.Name,A1.ItemsType , A1.ItemsUnit,A1.SellingPrice,A1.CostPrice,A1.MSRP, (A1.ManufacturerID + '-' + A2.CNAME) as Manufacturer " +
                "from ItemsInfo A1 INNER JOIN ManufacturerInfo A2 On A1.ManufacturerID = A2.ManufacturerID order by A1.ItemsID ";
            My.MyDatabase MyDb = new My.MyDatabase();

            DataView DV = MyDb.CreateDataView(SQLCommand, "ItemsInfo");
            
            this.dgvItemsInfo.DataSource = DV;

            //dataGridView表頭名稱中文化
            dgvItemsInfo.Columns[0].HeaderText = "商品編號";
            dgvItemsInfo.Columns[1].HeaderText = "商品名稱";
            dgvItemsInfo.Columns[2].HeaderText = "商品類別";
            dgvItemsInfo.Columns[3].HeaderText = "基本單位";
            dgvItemsInfo.Columns[4].HeaderText = "出貨價格";
            dgvItemsInfo.Columns[5].HeaderText = "進貨價格";
            dgvItemsInfo.Columns[6].HeaderText = "建議售價";
            dgvItemsInfo.Columns[7].HeaderText = "進貨廠商";

            tsslDataCount.Text = DV.Count.ToString();

            dgvItemsInfo.Columns[0].Visible = false;//隱藏商品編號

            //凍結 中文名稱 欄位
            this.dgvItemsInfo.Columns["NAME"].Frozen = true;

            //設定點選任一儲存格變選取所屬資料列的所有資料
            this.dgvItemsInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //替代資料列樣式 
            this.dgvItemsInfo.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dgvItemsInfo.AlternatingRowsDefaultCellStyle.BackColor = Color.Ivory;

            //自動調整資料列與資料行的高度與寬度
            this.dgvItemsInfo.AutoResizeColumns();
            this.dgvItemsInfo.AutoResizeRows();

            //防止在 DataGridView 控制項中新增和刪除資料列 
            this.dgvItemsInfo.AllowUserToAddRows = false;
            this.dgvItemsInfo.AllowUserToDeleteRows = false;

            //列標頭依據顯示內容自動調整大小
            this.dgvItemsInfo.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

        }

        #endregion

        private void dgvItemsInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0) // 確保一行Row只執行一次。 
            {
                dgvItemsInfo.Rows[e.RowIndex].HeaderCell.Value = String.Format("{0}", e.RowIndex + 1);
            }
        }

        private void dgvItemsInfo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.txtItemsID.Text = dgvItemsInfo[0, e.RowIndex].Value.ToString();
            this.txtNAME.Text = dgvItemsInfo[1, e.RowIndex].Value.ToString();
            cboItemsUnit.Text = dgvItemsInfo[3, e.RowIndex].Value.ToString();
            switch (PriceType)
            {
                case "CostPrice":
                    mtbPrice.Text = dgvItemsInfo[5, e.RowIndex].Value.ToString();
                    break;
                case "SellingPrice":
                    mtbPrice.Text = dgvItemsInfo[4, e.RowIndex].Value.ToString();
                    break;
                case "MSRP":
                    mtbPrice.Text = dgvItemsInfo[6, e.RowIndex].Value.ToString();
                    break;
                default:
                    mtbPrice.Text = dgvItemsInfo[5, e.RowIndex].Value.ToString();
                    break;
            }
            
            int totals = Convert.ToInt32(mtbPrice.Text) * Convert.ToInt32(mtbQuantity.Text);
            mtbTotals.Text = totals.ToString();
        }

        private void mtbQuantity_TextChanged(object sender, EventArgs e)
        {
            if (mtbQuantity.Text !="0" && mtbQuantity.Text.Length  >=1)
            {
                int totals = Convert.ToInt32(mtbPrice.Text) * Convert.ToInt32(mtbQuantity.Text);
                mtbTotals.Text = totals.ToString();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string SQLCommand = "Select A1.ItemsID ,A1.Name,A1.ItemsType , A1.ItemsUnit,A1.SellingPrice,A1.CostPrice,A1.MSRP, (A1.ManufacturerID + '-' + A2.CNAME) as Manufacturer " +
               "from ItemsInfo A1 INNER JOIN ManufacturerInfo A2 On A1.ManufacturerID = A2.ManufacturerID " + 
               "Where A1.ItemsID Like '" + txtSearchKeyword.Text.Trim() + "%' OR A1.Name Like '%" + txtSearchKeyword.Text.Trim() + "%'  order by A1.ItemsID ";
            My.MyDatabase MyDb = new My.MyDatabase();

            this.dgvItemsInfo.Columns["NAME"].Frozen = false;
            DataView DV = MyDb.CreateDataView(SQLCommand, "ItemsInfo");
            this.dgvItemsInfo.DataSource = DV;
            this.dgvItemsInfo.Columns["NAME"].Frozen = true;
            //自動調整資料列與資料行的高度與寬度
            this.dgvItemsInfo.AutoResizeColumns();
            this.dgvItemsInfo.AutoResizeRows();

            if (DV.Count == 0)
            {
                MessageBox.Show("搜尋條件並未找到任何符合資料", "搜尋結果", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("共找到資料筆數" + DV.Count.ToString(), "搜尋結果");
            }

            //dataGridView表頭名稱中文化
            dgvItemsInfo.Columns[0].HeaderText = "商品編號";
            dgvItemsInfo.Columns[1].HeaderText = "商品名稱";
            dgvItemsInfo.Columns[2].HeaderText = "商品類別";
            dgvItemsInfo.Columns[3].HeaderText = "基本單位";
            dgvItemsInfo.Columns[4].HeaderText = "出貨價格";
            dgvItemsInfo.Columns[5].HeaderText = "進貨價格";
            dgvItemsInfo.Columns[6].HeaderText = "建議售價";
            dgvItemsInfo.Columns[7].HeaderText = "進貨廠商";

            tsslDataCount.Text = DV.Count.ToString();
        }
        //清除
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearField();
        }

          /// <summary>
        /// 清除欄位資料
        /// </summary>
        private void ClearField()
        {
            txtSearchKeyword.Text = "";
            txtItemsID.Text = "";
            txtNAME.Text = "";
            mtbQuantity.Text = "1";
            cboItemsUnit.Text = "";
            mtbPrice.Text = "0";
            mtbTotals.Text = "0";
            rtbNotes.Text = "";
        }

        #region "欄位驗證"

        /// <summary>
        /// 欄位驗證
        /// </summary>
        /// <returns>輸入欄位型態正確回傳true,否則回傳false</returns>
        public bool CheckField()
        {

            if (txtItemsID.Text == "")
            {
                MessageBox.Show("[商品編號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(txtItemsID, "[商品編號]不得為空白!");
                txtItemsID.Focus();
                return false;
            }

            if (txtNAME.Text == "")
            {
                MessageBox.Show("[商品名稱]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(txtNAME, "[商品名稱]不得為空白!");
                txtNAME.Focus();
                return false;
            }

            if (mtbPrice.Text == "")
            {
                MessageBox.Show("[進貨價格]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(mtbPrice, "[進貨價格]不得為空白!");
                mtbPrice.Text = "0";
                mtbPrice.Focus();
                return false;
            }

            return true;

        }

        #endregion


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.dgvItemsInfo.Columns["NAME"].Frozen = false;//載入資料前凍結欄位設定須設為false才能將資料載入,但DataGridView在沒有任何資料前是不能設定凍結欄位
            LoadDefaultValue();
            MessageBox.Show("資料重新整理完成^_^", "重新整理");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckField())
            {
                isAddButtonClick = true;
                ItemsID = txtItemsID.Text;
                NAME = txtNAME.Text;
                Quantity = mtbQuantity.Text;
                ItemsUnit = cboItemsUnit.Text;
                CostPrice = mtbPrice.Text;
                Totals = mtbTotals.Text;
                Notes = rtbNotes.Text;
                MessageBox.Show(" 商品編號:" + ItemsID + "\r\n 商品名稱:" + NAME + "\r\n 數量:" + Quantity + "\r\n 價格:" + CostPrice + "\r\n 合計:" + Totals, "加入清單成功");
                this.Close();
            }
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
