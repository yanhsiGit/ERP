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
    public partial class FrmManufacturerMaintain : Form
    {
        public FrmManufacturerMaintain()
        {
            InitializeComponent();
        }

        private void FrmManufacturerMaintain_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            LoadDefaultValue();
        }

        #region "載入表單控制項相關預設值"

        /// <summary>
        /// 載入表單控制項相關預設值
        /// </summary>
        public void LoadDefaultValue()
        {
            string SQLCommand = "Select * from ManufacturerInfo order by ManufacturerID ";
            My.MyDatabase MyDb = new My.MyDatabase();

            DataView DV = MyDb.CreateDataView(SQLCommand, "ManufacturerInfo");
            this.dgvManufacturerInfo.DataSource = DV;

            //dataGridView表頭名稱中文化
            dgvManufacturerInfo.Columns[0].HeaderText = "廠商編號";
            dgvManufacturerInfo.Columns[1].HeaderText = "中文名稱";
            dgvManufacturerInfo.Columns[2].HeaderText = "英文名稱";
            dgvManufacturerInfo.Columns[3].HeaderText = "統一編號";
            dgvManufacturerInfo.Columns[4].HeaderText = "負責人";
            dgvManufacturerInfo.Columns[5].HeaderText = "聯絡人";
            dgvManufacturerInfo.Columns[6].HeaderText = "廠商電話";
            dgvManufacturerInfo.Columns[7].HeaderText = "聯絡人手機";
            dgvManufacturerInfo.Columns[8].HeaderText = "廠商傳真";
            dgvManufacturerInfo.Columns[9].HeaderText = "廠商地址";
            dgvManufacturerInfo.Columns[10].HeaderText = "網站";
            dgvManufacturerInfo.Columns[11].HeaderText = "備註";

            tsslDataCount.Text = DV.Count.ToString();

            //凍結 中文名稱 欄位
            this.dgvManufacturerInfo.Columns["CNAME"].Frozen = true;

            //設定點選任一儲存格變選取所屬資料列的所有資料
            this.dgvManufacturerInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //替代資料列樣式 
            this.dgvManufacturerInfo.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dgvManufacturerInfo.AlternatingRowsDefaultCellStyle.BackColor = Color.Ivory;

            //自動調整資料列與資料行的高度與寬度
            this.dgvManufacturerInfo.AutoResizeColumns();
            this.dgvManufacturerInfo.AutoResizeRows();

            //防止在 DataGridView 控制項中新增和刪除資料列 
            this.dgvManufacturerInfo.AllowUserToAddRows = false;
            this.dgvManufacturerInfo.AllowUserToDeleteRows = false;

            toolTip1.SetToolTip(txtManufacturerID, "請輸入[廠商編號]!");
            toolTip1.SetToolTip(txtCNAME, "請輸入廠商[中文名稱]!");
            tsbAddNew.ToolTipText = "按下[新增]鈕,以進行廠商新增動作!";
            tsbUpdate.ToolTipText = "按下[更改]鈕,以進行廠商更改動作!";
            tsbDelete.ToolTipText = "按下[刪除]鈕,以進行廠商刪除動作!";
            tsbClear.ToolTipText = "按下[清除]鈕,以進行輸入欄位資料清除動作!";
            tsbExit.ToolTipText = "按下[離開]鈕,會將本表單進行關閉!";
        }

        #endregion


        /// <summary>
        /// 清除欄位資料
        /// </summary>
        private void ClearField()
        {
            this.txtManufacturerID.Text = "";
            this.txtCNAME.Text = "";
            this.txtENAME.Text = "";
            this.mtbUnifiedBusinessNo.Text = "";
            this.txtOwner.Text = "";
            this.txtContact.Text = "";
            this.mtbPhone.Text = "";
            this.mtbMobilePhone.Text = "";
            this.mtbFax.Text = "";
            this.txtAddress.Text = "";
            this.txtWebSite.Text = "";
            this.rtbNotes.Text = "";

        }

        #region "欄位驗證"

        /// <summary>
        /// 欄位驗證
        /// </summary>
        /// <returns>輸入欄位型態正確回傳true,否則回傳false</returns>
        public bool CheckField()
        {

            if (txtManufacturerID.Text == "")
            {
                MessageBox.Show("[廠商編號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(txtManufacturerID, "[廠商編號]不得為空白!");
                txtManufacturerID.Focus();
                return false;
            }

            if (txtCNAME.Text == "")
            {
                MessageBox.Show("[中文名稱]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(txtCNAME, "[中文名稱]不得為空白!");
                txtCNAME.Focus();
                return false;
            }

            if (mtbUnifiedBusinessNo.Text == "")
            {
                MessageBox.Show("[統一編號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(mtbUnifiedBusinessNo, "[統一編號]不得為空白!");
                mtbUnifiedBusinessNo.Focus();
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

            My.MyDatabase MyDb = new My.MyDatabase();
            SIS.Configuration.ClsManufacturerConfig CMC = new Configuration.ClsManufacturerConfig();
            CMC.ManufacturerID = txtManufacturerID.Text;
            CMC.CNAME = txtCNAME.Text;
            CMC.ENAME = txtENAME.Text;
            CMC.UnifiedBusinessNo = mtbUnifiedBusinessNo.Text;
            CMC.Owner = txtOwner.Text;
            CMC.Contact = txtContact.Text;
            CMC.Phone = mtbPhone.Text;
            CMC.MobilePhone = mtbMobilePhone.Text;
            CMC.Fax = mtbFax.Text;
            CMC.Address = txtAddress.Text;
            CMC.WebSite = txtWebSite.Text;
            CMC.Notes = rtbNotes.Text;

            SIS.DBClass.DBClassManufacturerInfo DBCMI = new DBClass.DBClassManufacturerInfo();

            if (MyDb.AuthPK(CMC.ManufacturerID, "ManufacturerID", "ManufacturerInfo") == false)
            {
                if (DBCMI.InsertData(CMC))
                {
                    MessageBox.Show("新增[" + CMC.ManufacturerID  + "-" + CMC.CNAME +
                        "]公司資料成功", "新增廠商資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDefaultValue();
                }
                else
                {
                    MessageBox.Show("新增[" + CMC.ManufacturerID + "-" + CMC.CNAME +
                        "]廠商資料失敗", "新增廠商資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("對不起，資料庫已存在[ " + CMC.ManufacturerID + "-" + CMC.CNAME +
                      " ]廠商資料!!(資料重複)", "資料新增");
            }



        }

        #endregion

        /// <summary>
        /// 更新資料庫資料
        /// </summary>
        private void RunUpdateData()
        {
            My.MyDatabase MyDb = new My.MyDatabase();
            SIS.Configuration.ClsManufacturerConfig CMC = new Configuration.ClsManufacturerConfig();
            CMC.ManufacturerID = txtManufacturerID.Text;
            CMC.CNAME = txtCNAME.Text;
            CMC.ENAME = txtENAME.Text;
            CMC.UnifiedBusinessNo = mtbUnifiedBusinessNo.Text;
            CMC.Owner = txtOwner.Text;
            CMC.Contact = txtContact.Text;
            CMC.Phone = mtbPhone.Text;
            CMC.MobilePhone = mtbMobilePhone.Text;
            CMC.Fax = mtbFax.Text;
            CMC.Address = txtAddress.Text;
            CMC.WebSite = txtWebSite.Text;
            CMC.Notes = rtbNotes.Text;

            SIS.DBClass.DBClassManufacturerInfo DBCMI = new DBClass.DBClassManufacturerInfo();

            if (MyDb.AuthPK(CMC.ManufacturerID, "ManufacturerID", "ManufacturerInfo") == true)
            {
                if (DBCMI.Update(CMC))
                {
                    MessageBox.Show("更新[" + CMC.ManufacturerID + "-" + CMC.CNAME +
                        "]公司資料成功", "更新廠商資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDefaultValue();
                }
                else
                {
                    MessageBox.Show("更新[" + CMC.ManufacturerID + "-" + CMC.CNAME +
                        "]廠商資料失敗", "更新廠商資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("對不起，資料庫不存在[ " + CMC.ManufacturerID + "-" + CMC.CNAME +
                      " ]廠商資料!!(資料重複)", "資料更新");
            }
        }

        /// <summary>
        /// 刪除資料庫的某一筆資料
        /// </summary>
        private void RunDeleteData()
        {
            My.MyDatabase MyDb = new My.MyDatabase();
            SIS.Configuration.ClsManufacturerConfig CMC = new Configuration.ClsManufacturerConfig();
            CMC.ManufacturerID = txtManufacturerID.Text;
            CMC.CNAME = txtCNAME.Text;
            CMC.ENAME = txtENAME.Text;
            CMC.UnifiedBusinessNo = mtbUnifiedBusinessNo.Text;

            SIS.DBClass.DBClassManufacturerInfo DBCMI = new DBClass.DBClassManufacturerInfo();

            if (MyDb.AuthPK(CMC.ManufacturerID, "ManufacturerID", "ManufacturerInfo") == true)
            {
                if (DBCMI.DeleteOneData(CMC.ManufacturerID))
                {
                    MessageBox.Show("刪除[" + CMC.ManufacturerID + "-" + CMC.CNAME +
                        "]公司資料成功", "刪除廠商資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDefaultValue();
                }
                else
                {
                    MessageBox.Show("刪除[" + CMC.ManufacturerID + "-" + CMC.CNAME +
                        "]公司資料失敗", "刪除廠商資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("對不起，資料庫不存在[ " + CMC.ManufacturerID + "-" + CMC.CNAME + 
                      " ]廠商資料!!(資料不存在)", "資料刪除");
            }
        }

        private void FrmManufacturerMaintain_KeyDown(object sender, KeyEventArgs e)
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

        private void tsbAddNew_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行廠商[" +txtManufacturerID.Text  + "-" + txtCNAME.Text + "]新增動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "新增廠商", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunInsertData();
                }
            }
            else
            {
                MessageBox.Show("取消廠商新增動作!!", "新增廠商");
            }
        }



        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行廠商[" + txtManufacturerID.Text + "-" + txtCNAME.Text + "]更新動作?\r\n";

            DialogResult DR;
            DR = MessageBox.Show(Msg, "更新廠商", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunUpdateData();
                }
            }
            else
            {
                MessageBox.Show("取消廠商更新動作!!", "更新廠商");
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行廠商[" + txtManufacturerID.Text + "-" + txtCNAME.Text + "]刪除動作?\r\n";

            DialogResult DR;
            DR = MessageBox.Show(Msg, "刪除廠商", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunDeleteData();
                }
            }
            else
            {
                MessageBox.Show("取消廠商刪除動作!!", "刪除廠商");
            }
        }
        //清除
        private void tsbClear_Click(object sender, EventArgs e)
        {
            ClearField();
        }
        //離開
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvManufacturerInfo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.txtManufacturerID.Text = dgvManufacturerInfo[0, e.RowIndex].Value.ToString();
            this.txtCNAME.Text = dgvManufacturerInfo[1, e.RowIndex].Value.ToString();
            this.txtENAME.Text = dgvManufacturerInfo[2, e.RowIndex].Value.ToString();
            this.mtbUnifiedBusinessNo.Text = dgvManufacturerInfo[3, e.RowIndex].Value.ToString();
            this.txtOwner.Text = dgvManufacturerInfo[4, e.RowIndex].Value.ToString();
            this.txtContact.Text = dgvManufacturerInfo[5, e.RowIndex].Value.ToString();
            this.mtbPhone.Text = dgvManufacturerInfo[6, e.RowIndex].Value.ToString();
            this.mtbMobilePhone.Text = dgvManufacturerInfo[7, e.RowIndex].Value.ToString();
            this.mtbFax.Text = dgvManufacturerInfo[8, e.RowIndex].Value.ToString();
            this.txtAddress.Text = dgvManufacturerInfo[9, e.RowIndex].Value.ToString();
            this.txtWebSite.Text = dgvManufacturerInfo[10, e.RowIndex].Value.ToString();
            this.rtbNotes.Text = dgvManufacturerInfo[11, e.RowIndex].Value.ToString();
        }

    }
}
