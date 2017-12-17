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
    public partial class FrmCompanyMaintain : Form
    {
        public FrmCompanyMaintain()
        {
            InitializeComponent();
        }

        private void FrmCompanyMaintain_Load(object sender, EventArgs e)
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
            string SQLCommand = "Select * from CompanyInfo order by CompanyID ";
            My.MyDatabase MyDb = new My.MyDatabase();

            DataView DV = MyDb.CreateDataView(SQLCommand, "CompanyInfo");
            this.dgvCompanyInfo.DataSource = DV;

            //dataGridView表頭名稱中文化
            dgvCompanyInfo.Columns[0].HeaderText = "公司編號";
            dgvCompanyInfo.Columns[1].HeaderText = "中文名稱";
            dgvCompanyInfo.Columns[2].HeaderText = "英文名稱";
            dgvCompanyInfo.Columns[3].HeaderText = "統一編號";
            dgvCompanyInfo.Columns[4].HeaderText = "公司類型";
            dgvCompanyInfo.Columns[5].HeaderText = "負責人";
            dgvCompanyInfo.Columns[6].HeaderText = "聯絡人";
            dgvCompanyInfo.Columns[7].HeaderText = "公司電話";
            dgvCompanyInfo.Columns[8].HeaderText = "聯絡人手機";
            dgvCompanyInfo.Columns[9].HeaderText = "公司傳真";
            dgvCompanyInfo.Columns[10].HeaderText = "公司地址";
            dgvCompanyInfo.Columns[11].HeaderText = "網站";
            dgvCompanyInfo.Columns[12].HeaderText = "備註";

            tsslDataCount.Text = DV.Count.ToString();

            //凍結 中文名稱 欄位
            this.dgvCompanyInfo.Columns["CNAME"].Frozen = true;

            //設定點選任一儲存格變選取所屬資料列的所有資料
            this.dgvCompanyInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //替代資料列樣式 
            this.dgvCompanyInfo.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dgvCompanyInfo.AlternatingRowsDefaultCellStyle.BackColor = Color.Ivory;

            //自動調整資料列與資料行的高度與寬度
            this.dgvCompanyInfo.AutoResizeColumns();
            this.dgvCompanyInfo.AutoResizeRows();

            //防止在 DataGridView 控制項中新增和刪除資料列 
            this.dgvCompanyInfo.AllowUserToAddRows = false;
            this.dgvCompanyInfo.AllowUserToDeleteRows = false;

            toolTip1.SetToolTip(txtCompanyID, "請輸入[公司編號]!");
            toolTip1.SetToolTip(txtCNAME, "請輸入公司[中文名稱]!");
            tsbAddNew.ToolTipText = "按下[新增]鈕,以進行公司新增動作!";
            tsbUpdate.ToolTipText = "按下[更改]鈕,以進行公司更改動作!";
            tsbDelete.ToolTipText = "按下[刪除]鈕,以進行公司刪除動作!";
            tsbClear.ToolTipText = "按下[清除]鈕,以進行輸入欄位資料清除動作!";
            tsbExit.ToolTipText = "按下[離開]鈕,會將本表單進行關閉!";
        }

        #endregion


        /// <summary>
        /// 清除欄位資料
        /// </summary>
        private void ClearField()
        {
            this.txtCompanyID.Text = "";
            this.txtCNAME.Text = "";
            this.txtENAME.Text = "";
            this.mtbUnifiedBusinessNo.Text = "";
            this.cboCompanyType.Text = cboCompanyType.Items[0].ToString();
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

            if (txtCompanyID.Text == "")
            {
                MessageBox.Show("[公司編號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(txtCompanyID, "[公司編號]不得為空白!");
                txtCompanyID.Focus();
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
            SIS.Configuration.ClsCompanyConfig CCC = new Configuration.ClsCompanyConfig();
            CCC.CompanyID = txtCompanyID.Text;
            CCC.CNAME = txtCNAME.Text;
            CCC.ENAME = txtENAME.Text;
            CCC.UnifiedBusinessNo = mtbUnifiedBusinessNo.Text;
            CCC.CompanyType = cboCompanyType.Text;
            CCC.Owner = txtOwner.Text;
            CCC.Contact = txtContact.Text;
            CCC.Phone = mtbPhone.Text;
            CCC.MobilePhone = mtbMobilePhone.Text;
            CCC.Fax = mtbFax.Text;
            CCC.Address = txtAddress.Text;
            CCC.WebSite = txtWebSite.Text;
            CCC.Notes = rtbNotes.Text;

            SIS.DBClass.DBClassCompanyInfo DBCCI = new DBClass.DBClassCompanyInfo();

            if (MyDb.AuthPK(CCC.CompanyID, "CompanyID", "CompanyInfo") == false)
            {
                if (DBCCI.InsertData(CCC))
                {
                    MessageBox.Show("新增[" + CCC.CompanyID + "-" + CCC.CNAME +
                        "]公司資料成功", "新增公司資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDefaultValue();
                }
                else
                {
                    MessageBox.Show("新增[" + CCC.CompanyID + "-" + CCC.CNAME +
                        "]公司資料失敗", "新增公司資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("對不起，資料庫已存在[ " + CCC.CompanyID + "-" + CCC.CNAME +
                      " ]公司資料!!(資料重複)", "資料新增");
            }



        }

        #endregion


        private void FrmCompanyMaintain_KeyDown(object sender, KeyEventArgs e)
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
        //新增
        private void tsbAddNew_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行公司[" + txtCompanyID.Text + "-" + txtCNAME.Text + "]新增動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "新增公司", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunInsertData();
                }
            }
            else
            {
                MessageBox.Show("取消公司新增動作!!", "新增公司");
            }
        }
        //更改
        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行公司[" + txtCompanyID.Text + "-" + txtCNAME.Text + "]更新動作?\r\n";

            DialogResult DR;
            DR = MessageBox.Show(Msg, "更新公司", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunUpdateData();
                }
            }
            else
            {
                MessageBox.Show("取消公司更新動作!!", "更新公司");
            }
        }

        private void RunUpdateData()
        {
            My.MyDatabase MyDb = new My.MyDatabase();
            SIS.Configuration.ClsCompanyConfig CCC = new Configuration.ClsCompanyConfig();
            CCC.CompanyID = txtCompanyID.Text;
            CCC.CNAME = txtCNAME.Text;
            CCC.ENAME = txtENAME.Text;
            CCC.UnifiedBusinessNo = mtbUnifiedBusinessNo.Text;
            CCC.CompanyType = cboCompanyType.Text;
            CCC.Owner = txtOwner.Text;
            CCC.Contact = txtContact.Text;
            CCC.Phone = mtbPhone.Text;
            CCC.MobilePhone = mtbMobilePhone.Text;
            CCC.Fax = mtbFax.Text;
            CCC.Address = txtAddress.Text;
            CCC.WebSite = txtWebSite.Text;
            CCC.Notes = rtbNotes.Text;

            SIS.DBClass.DBClassCompanyInfo DBCCI = new DBClass.DBClassCompanyInfo();

            if (MyDb.AuthPK(CCC.CompanyID, "CompanyID", "CompanyInfo") == true)
            {
                if (DBCCI.Update(CCC))
                {
                    MessageBox.Show("更新[" + CCC.CompanyID + "-" + CCC.CNAME +
                        "]公司資料成功", "更新公司資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDefaultValue();
                }
                else
                {
                    MessageBox.Show("更新[" + CCC.CompanyID + "-" + CCC.CNAME +
                        "]公司資料失敗", "更新公司資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("對不起，資料庫不存在[ " + CCC.CompanyID + "-" + CCC.CNAME +
                      " ]公司資料!!(資料不存在)", "資料更新");
            }
        }

        //刪除
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行公司[" + txtCompanyID.Text + "-" + txtCNAME.Text + "]刪除動作?\r\n";

            DialogResult DR;
            DR = MessageBox.Show(Msg, "刪除公司", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunDeleteData();
                }
            }
            else
            {
                MessageBox.Show("取消公司刪除動作!!", "刪除公司");
            }
        }

        private void RunDeleteData()
        {
            My.MyDatabase MyDb = new My.MyDatabase();
            SIS.Configuration.ClsCompanyConfig CCC = new Configuration.ClsCompanyConfig();
            CCC.CompanyID = txtCompanyID.Text;
            CCC.CNAME = txtCNAME.Text;
            CCC.ENAME = txtENAME.Text;
            CCC.UnifiedBusinessNo = mtbUnifiedBusinessNo.Text;

            SIS.DBClass.DBClassCompanyInfo DBCCI = new DBClass.DBClassCompanyInfo();

            if (MyDb.AuthPK(CCC.CompanyID, "CompanyID", "CompanyInfo") == true)
            {
                if (DBCCI.DeleteOneData(CCC.CompanyID))
                {
                    MessageBox.Show("刪除[" + CCC.CompanyID + "-" + CCC.CNAME +
                        "]公司資料成功", "刪除公司資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDefaultValue();
                }
                else
                {
                    MessageBox.Show("刪除[" + CCC.CompanyID + "-" + CCC.CNAME +
                        "]公司資料失敗", "刪除公司資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("對不起，資料庫不存在[ " + CCC.CompanyID + "-" + CCC.CNAME +
                      " ]公司資料!!(資料不存在)", "資料刪除");
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

        private void dgvCompanyInfo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.txtCompanyID.Text = dgvCompanyInfo[0, e.RowIndex].Value.ToString();
            this.txtCNAME.Text = dgvCompanyInfo[1, e.RowIndex].Value.ToString();
            this.txtENAME.Text = dgvCompanyInfo[2, e.RowIndex].Value.ToString();
            this.mtbUnifiedBusinessNo.Text = dgvCompanyInfo[3, e.RowIndex].Value.ToString();
            this.cboCompanyType.Text = dgvCompanyInfo[4, e.RowIndex].Value.ToString();
            this.txtOwner.Text = dgvCompanyInfo[5, e.RowIndex].Value.ToString();
            this.txtContact.Text = dgvCompanyInfo[6, e.RowIndex].Value.ToString();
            this.mtbPhone.Text = dgvCompanyInfo[7, e.RowIndex].Value.ToString();
            this.mtbMobilePhone.Text = dgvCompanyInfo[8, e.RowIndex].Value.ToString();
            this.mtbFax.Text = dgvCompanyInfo[9, e.RowIndex].Value.ToString();
            this.txtAddress.Text = dgvCompanyInfo[10, e.RowIndex].Value.ToString();
            this.txtWebSite.Text = dgvCompanyInfo[11, e.RowIndex].Value.ToString();
            this.rtbNotes.Text = dgvCompanyInfo[12, e.RowIndex].Value.ToString();

        }
    }
}
