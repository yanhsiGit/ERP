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
    public partial class FrmItemsMaintain : Form
    {
        public FrmItemsMaintain()
        {
            InitializeComponent();
        }
        private ContextMenuStrip cms;
        private void FrmItemsMaintain_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            LoadDefaultValue();
            My.MyMethod.DataIntoComboBox(cboManufacturer, "ManufacturerInfo", "ManufacturerID", "CNAME", "%");
            My.MyMethod.DataIntoComboBox(cboItemsType, "ItemsType", "ItemsTypeID", "ItemsTypeName", "%", true); 

            cms = new ContextMenuStrip();

            ToolStripMenuItem tsmi1 = new ToolStripMenuItem("複製(Copy)");
            ToolStripMenuItem tsmi2 = new ToolStripMenuItem("剪下(Cut)");
            ToolStripMenuItem tsmi3 = new ToolStripMenuItem("貼上(Paste)");
            cms.Items.Add(tsmi1);
            cms.Items.Add(tsmi2);
            cms.Items.Add(tsmi3);

            cms.ImageList = imageList1;
            cms.Items[0].ImageIndex = 0;
            cms.Items[1].ImageIndex = 1;
            cms.Items[2].ImageIndex = 2;

            rtbNotes.ContextMenuStrip = cms;
            this.cms.ItemClicked += new ToolStripItemClickedEventHandler(this.cms_ItemClicked);
        }

        private void cms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.ToString())
            {
                case "複製(Copy)":
                    rtbNotes.Copy();
                    break;
                case "剪下(Cut)":
                    rtbNotes.Cut();
                    break;
                case "貼上(Paste)":
                    rtbNotes.Paste();
                    break;
                default:
                    break;
            }
        }

        #region "載入表單控制項相關預設值"

        /// <summary>
        /// 載入表單控制項相關預設值
        /// </summary>
        public void LoadDefaultValue()
        {
            string SQLCommand = "Select A1.ItemsID ,A1.Name,A1.ItemsType , A1.Specifications,A1.ItemsUnit,A1.SellingPrice,A1.CostPrice,A1.MSRP, (A1.ManufacturerID + '-' + A2.CNAME) as Manufacturer , A1.Inventory , A1.SafeInventory , A1.Notes " + 
                "from ItemsInfo A1 INNER JOIN ManufacturerInfo A2 On A1.ManufacturerID = A2.ManufacturerID order by A1.ItemsID ";
            My.MyDatabase MyDb = new My.MyDatabase();

            DataView DV = MyDb.CreateDataView(SQLCommand, "ItemsInfo");
            this.dgvItemsInfo.DataSource = DV;

            //dataGridView表頭名稱中文化
            dgvItemsInfo.Columns[0].HeaderText = "商品編號";
            dgvItemsInfo.Columns[1].HeaderText = "商品名稱";
            dgvItemsInfo.Columns[2].HeaderText = "商品類別";
            dgvItemsInfo.Columns[3].HeaderText = "商品規格";
            dgvItemsInfo.Columns[4].HeaderText = "基本單位";
            dgvItemsInfo.Columns[5].HeaderText = "出貨價格";
            dgvItemsInfo.Columns[6].HeaderText = "進貨價格";
            dgvItemsInfo.Columns[7].HeaderText = "建議售價";
            dgvItemsInfo.Columns[8].HeaderText = "進貨廠商";
            dgvItemsInfo.Columns[9].HeaderText = "庫存量";
            dgvItemsInfo.Columns[10].HeaderText = "安全庫存量";
            dgvItemsInfo.Columns[11].HeaderText = "備註";

            tsslDataCount.Text = DV.Count.ToString();

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

            toolTip1.SetToolTip(txtItemsID, "請輸入[商品編號]!");
            toolTip1.SetToolTip(txtNAME, "請輸入公司[商品名稱]!");
            tsbAddNew.ToolTipText = "按下[新增]鈕,以進行商品新增動作!";
            tsbUpdate.ToolTipText = "按下[更改]鈕,以進行商品更改動作!";
            tsbDelete.ToolTipText = "按下[刪除]鈕,以進行商品刪除動作!";
            tsbClear.ToolTipText = "按下[清除]鈕,以進行輸入欄位資料清除動作!";
            tsbExit.ToolTipText = "按下[離開]鈕,會將本表單進行關閉!";

        }

        #endregion


        /// <summary>
        /// 清除欄位資料
        /// </summary>
        private void ClearField()
        {
            this.txtItemsID.Text = "";
            this.txtNAME.Text = "";
            this.cboItemsType.Text = cboItemsType.Items[0].ToString();
            this.txtSpecifications.Text = "";
            this.cboItemsUnit.Text = cboItemsUnit.Items[0].ToString();
            this.mtbSellingPrice.Text = "0";
            this.mtbCostPrice.Text = "0";
            this.mtbMSRP.Text = "0";
            this.cboManufacturer.Text = cboManufacturer.Items[0].ToString();
            this.mtbInventory.Text = "0";
            this.mtbSafeInventory.Text = "0";
            this.rtbNotes.Text = "";
            this.cbxAutoNumber.Checked = false;
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

            if (mtbSellingPrice.Text == "")
            {
                MessageBox.Show("[出貨價格]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(mtbSellingPrice, "[出貨價格]不得為空白!");
                mtbSellingPrice.Text = "0";
                mtbSellingPrice.Focus();
                return false;
            }

            if (mtbCostPrice.Text == "")
            {
                MessageBox.Show("[進貨價格]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(mtbCostPrice, "[進貨價格]不得為空白!");
                mtbCostPrice.Text = "0";
                mtbCostPrice.Focus();
                return false;
            }

            if (mtbMSRP.Text == "")
            {
                MessageBox.Show("[建議售價]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(mtbMSRP, "[建議售價]不得為空白!");
                mtbMSRP.Text = "0";
                mtbMSRP.Focus();
                return false;
            }

            if (mtbInventory.Text == "")
            {
                MessageBox.Show("[庫存量]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(mtbInventory, "[庫存量]不得為空白!");
                mtbInventory.Text = "0";
                mtbInventory.Focus();
                return false;
            }

            if (mtbSafeInventory.Text == "")
            {
                MessageBox.Show("[安全庫存量]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(mtbSafeInventory, "[安全庫存量]不得為空白!");
                mtbSafeInventory.Text = "0";
                mtbSafeInventory.Focus();
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
                SIS.Configuration.ClsItemsConfig CIC = new Configuration.ClsItemsConfig();
                CIC.ItemsID = txtItemsID.Text;
                CIC.NAME = txtNAME.Text;
                CIC.ItemsType = cboItemsType.Text.Substring(0, cboItemsType.Text.IndexOf("-"));
                CIC.Specifications = txtSpecifications.Text.Replace("'", "''"); //將一個單引號置換成二個單引號避免SQL語法錯誤
                CIC.ItemsUnit = cboItemsUnit.Text;
                CIC.SellingPrice = int.Parse(mtbSellingPrice.Text);
                CIC.CostPrice = int.Parse(mtbCostPrice.Text);
                CIC.MSRP = int.Parse(mtbMSRP.Text);
                CIC.ManufacturerID = cboManufacturer.Text.Substring(0, cboManufacturer.Text.IndexOf("-"));
                CIC.Inventory = int.Parse(mtbInventory.Text);
                CIC.SafeInventory = int.Parse(mtbSafeInventory.Text);
                CIC.Notes = rtbNotes.Text.Replace("'", "''");

                SIS.DBClass.DBClassItemsInfo DBCII = new DBClass.DBClassItemsInfo();

                if (MyDb.AuthPK(CIC.ItemsID, "ItemsID", "ItemsInfo") == false)
                {
                    if (DBCII.InsertData(CIC))
                    {
                        MessageBox.Show("新增[" + CIC.ItemsID + "-" + CIC.NAME +
                            "]商品資料成功", "新增商品資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaultValue();
                    }
                    else
                    {
                        MessageBox.Show("新增[" + CIC.ItemsID + "-" + CIC.NAME +
                            "]商品資料失敗", "新增商品資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("對不起，資料庫已存在[ " + CIC.ItemsID + "-" + CIC.NAME +
                          " ]商品資料!!(資料重複)", "資料新增");
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
            My.MyDatabase MyDb = new My.MyDatabase();
            SIS.Configuration.ClsItemsConfig CIC = new Configuration.ClsItemsConfig();
            CIC.ItemsID = txtItemsID.Text;
            CIC.NAME = txtNAME.Text;
            CIC.ItemsType = cboItemsType.Text.Substring(0, cboItemsType.Text.IndexOf("-"));
            CIC.Specifications = txtSpecifications.Text.Replace("'","''");
            CIC.ItemsUnit = cboItemsUnit.Text;
            CIC.SellingPrice = int.Parse(mtbSellingPrice.Text);
            CIC.CostPrice = int.Parse(mtbCostPrice.Text);
            CIC.MSRP = int.Parse(mtbMSRP.Text);
            CIC.ManufacturerID = cboManufacturer.Text.Substring(0, cboManufacturer.Text.IndexOf("-"));
            CIC.Inventory = int.Parse(mtbInventory.Text);
            CIC.SafeInventory = int.Parse(mtbSafeInventory.Text);
            CIC.Notes = rtbNotes.Text.Replace("'", "''");

            SIS.DBClass.DBClassItemsInfo DBCII = new DBClass.DBClassItemsInfo();

            if (MyDb.AuthPK(CIC.ItemsID, "ItemsID", "ItemsInfo") == true)
            {
                if (DBCII.Update(CIC))
                {
                    MessageBox.Show("更新[" + CIC.ItemsID + "-" + CIC.NAME +
                        "]商品資料成功", "更新商品資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDefaultValue();
                }
                else
                {
                    MessageBox.Show("更新[" + CIC.ItemsID + "-" + CIC.NAME +
                        "]商品資料失敗", "更新商品資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("對不起，資料庫不存在[ " + CIC.ItemsID + "-" + CIC.NAME +
                      " ]商品資料!!(資料不存在)", "資料更新");
            }
        }

        private void RunDeleteData()
        {
            My.MyDatabase MyDb = new My.MyDatabase();
            SIS.Configuration.ClsItemsConfig CIC = new Configuration.ClsItemsConfig();
            CIC.ItemsID = txtItemsID.Text;
            CIC.NAME = txtNAME.Text;

            SIS.DBClass.DBClassItemsInfo DBCII = new DBClass.DBClassItemsInfo();

            if (MyDb.AuthPK(CIC.ItemsID, "ItemsID", "ItemsInfo") == true)
            {
                if (DBCII.DeleteOneData(CIC.ItemsID))
                {
                    MessageBox.Show("刪除[" + CIC.ItemsID + "-" + CIC.NAME +
                        "]商品資料成功", "刪除商品資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDefaultValue();
                }
                else
                {
                    MessageBox.Show("刪除[" + CIC.ItemsID + "-" + CIC.NAME +
                        "]商品資料失敗", "刪除商品資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("對不起，資料庫不存在[ " + CIC.ItemsID + "-" + CIC.NAME +
                      " ]商品資料!!(資料不存在)", "資料刪除");
            }
        }





        private void FrmItemsMaintain_KeyDown(object sender, KeyEventArgs e)
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

        private void dgvItemsInfo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.txtItemsID.Text = dgvItemsInfo[0, e.RowIndex].Value.ToString();
            this.txtNAME.Text = dgvItemsInfo[1, e.RowIndex].Value.ToString();
            this.cboItemsType.Text = My.MyMethod.SearchComboBoxItems(cboItemsType,dgvItemsInfo[2, e.RowIndex].Value.ToString());
            this.txtSpecifications.Text = dgvItemsInfo[3, e.RowIndex].Value.ToString();
            this.cboItemsUnit.Text = dgvItemsInfo[4, e.RowIndex].Value.ToString();
            this.mtbSellingPrice.Text = dgvItemsInfo[5, e.RowIndex].Value.ToString();
            this.mtbCostPrice.Text = dgvItemsInfo[6, e.RowIndex].Value.ToString();
            this.mtbMSRP.Text = dgvItemsInfo[7, e.RowIndex].Value.ToString();
            this.cboManufacturer.Text = dgvItemsInfo[8, e.RowIndex].Value.ToString();
            this.mtbInventory.Text = dgvItemsInfo[9, e.RowIndex].Value.ToString();
            this.mtbSafeInventory.Text = dgvItemsInfo[10, e.RowIndex].Value.ToString();
            this.rtbNotes.Text = dgvItemsInfo[11, e.RowIndex].Value.ToString();
        }

        private void tsbAddNew_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行商品[" + txtItemsID.Text + "-" + txtNAME.Text + "]新增動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "新增商品", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunInsertData();
                }
            }
            else
            {
                MessageBox.Show("取消商品新增動作!!", "新增商品");
            }
        }
        //更新
        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行商品[" + txtItemsID.Text + "-" + txtNAME.Text + "]更新動作?\r\n";

            DialogResult DR;
            DR = MessageBox.Show(Msg, "更新商品", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunUpdateData();
                }
            }
            else
            {
                MessageBox.Show("取消商品更新動作!!", "更新商品");
            }
        }
        //刪除
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行商品[" + txtItemsID.Text + "-" + txtNAME.Text + "]刪除動作?\r\n";

            DialogResult DR;
            DR = MessageBox.Show(Msg, "刪除商品", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunDeleteData();
                }
            }
            else
            {
                MessageBox.Show("取消商品刪除動作!!", "刪除商品");
            }
        }
        //清除
        private void tsbClear_Click(object sender, EventArgs e)
        {
            ClearField();
            MessageBox.Show("欄位資料清除完畢!!", "清除");
        }
        //離開
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dgvItemsInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0) // 確保一行Row只執行一次。 
            {
                dgvItemsInfo.Rows[e.RowIndex].HeaderCell.Value = String.Format("{0}", e.RowIndex + 1); 
            }
        }


        private void cbxAutoNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAutoNumber.Checked == true)
            {
                txtItemsID.Text = My.MyMethod.RunID("IM");
            }
            else
            {
                txtItemsID.Text = "";
            }
        }



    }
}
