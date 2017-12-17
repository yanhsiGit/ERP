using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;// for ArrayList

namespace SIS
{
    public partial class FrmUserRegistration : Form
    {
        public FrmUserRegistration()
        {
            InitializeComponent();
        }
        public string NowTabPageName;
        private void FrmUserRegistration_Load(object sender, EventArgs e)
        {
            LoadDefaultValue1();
            LoadDefaultValue2();
            NowTabPageName = "tabPage1";
        }

        #region "載入表單控制項相關預設值"

        /// <summary>
        /// 載入表單控制項相關預設值
        /// </summary>
        public void LoadDefaultValue1()
        {
            string SQLCommand = "Select TOP 100 * from UserInfo order by CNAME DESC";
            My.MyDatabase MyDb = new My.MyDatabase();

            DataView DV = MyDb.CreateDataView(SQLCommand, "UserInfo");
            this.dataGridView1.DataSource = DV;

            //dataGridView表頭名稱中文化
            dataGridView1.Columns[0].HeaderText = "使用者帳號";
            dataGridView1.Columns[1].HeaderText = "中文名稱";
            dataGridView1.Columns[2].HeaderText = "英文名稱";
            dataGridView1.Columns[3].HeaderText = "性別";
            dataGridView1.Columns[4].HeaderText = "生日";
            dataGridView1.Columns[5].HeaderText = "血型";
            dataGridView1.Columns[6].HeaderText = "身份證字號";
            dataGridView1.Columns[7].HeaderText = "通訊地址";
            dataGridView1.Columns[8].HeaderText = "電話";

            tSSL_DataCount1.Text = DV.Count.ToString();


            //設定點選任一儲存格變選取所屬資料列的所有資料
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //替代資料列樣式 
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Ivory;

            //自動調整資料列與資料行的高度與寬度
            this.dataGridView1.AutoResizeColumns();
            this.dataGridView1.AutoResizeRows();

            //防止在 DataGridView 控制項中新增和刪除資料列 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
        }

        /// <summary>
        /// 載入表單控制項相關預設值
        /// </summary>
        public void LoadDefaultValue2()
        {
            string SQLCommand = "Select TOP 100 * from ManagementInfo order by CNAME DESC";
            My.MyDatabase MyDb = new My.MyDatabase();

            DataView DV = MyDb.CreateDataView(SQLCommand, "ManagementInfo");
            this.dataGridView2.DataSource = DV;

            //dataGridView表頭名稱中文化
            dataGridView2.Columns[0].HeaderText = "使用者帳號";
            dataGridView2.Columns[1].HeaderText = "中文名稱";
            dataGridView2.Columns[2].HeaderText = "英文名稱";
            dataGridView2.Columns[3].HeaderText = "性別";
            dataGridView2.Columns[4].HeaderText = "生日";
            dataGridView2.Columns[5].HeaderText = "血型";
            dataGridView2.Columns[6].HeaderText = "身份證字號";
            dataGridView2.Columns[7].HeaderText = "通訊地址";
            dataGridView2.Columns[8].HeaderText = "電話";
            dataGridView2.Columns[9].HeaderText = "職稱";

            tSSL_DataCount2.Text = DV.Count.ToString();


            //設定點選任一儲存格變選取所屬資料列的所有資料
            this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //替代資料列樣式 
            this.dataGridView2.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.Ivory;

            //自動調整資料列與資料行的高度與寬度
            this.dataGridView2.AutoResizeColumns();
            this.dataGridView2.AutoResizeRows();

            //防止在 DataGridView 控制項中新增和刪除資料列 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
        }


        #endregion

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (tabControl1.TabPages[e.TabPageIndex].Name)
            {
                case "tabPage1":
                    tSSL_PageLocation.Text = "一般使用者服務區";
                    NowTabPageName = "tabPage1";
                    break;
                case "tabPage2":
                    tSSL_PageLocation.Text = "進銷存管理者服務區";
                    NowTabPageName = "tabPage2";
                    break;
                default:
                    break;
            }
        }
        //新增
        private void tSBAddNew_Click(object sender, EventArgs e)
        {
            string RoleName = "";
            switch (this.NowTabPageName)
            {
                case "tabPage1":
                    RoleName = "一般使用者";
                    break;
                case "tabPage2":
                    RoleName = "進銷存管理者";
                    break;

            }

            DialogResult DR;
            DR = MessageBox.Show("是否要進行[" + RoleName + "]新增", "人員新增", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField(this.NowTabPageName))
                {
                    RunInsertData(this.NowTabPageName);
                }
            }
            else
            {
                MessageBox.Show("取消人員新增動作!!", "新增人員");
            }
        }

        //更改
        private void tSBUpdate_Click(object sender, EventArgs e)
        {
            string RoleName = "";
            switch (this.NowTabPageName)
            {
                case "tabPage1":
                    RoleName = "一般使用者";
                    break;
                case "tabPage2":
                    RoleName = "進銷存管理者";
                    break;

            }

            DialogResult DR;
            DR = MessageBox.Show("是否要進行[" + RoleName + "]更新", "人員更新", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField(this.NowTabPageName))
                {
                    RunUpdateData(this.NowTabPageName);
                }
            }
            else
            {
                MessageBox.Show("取消人員更新動作!!", "更新人員");
            }
        }
        //刪除
        private void tSBDelete_Click(object sender, EventArgs e)
        {
            string RoleName = "";
            string UserId = "";
            switch (this.NowTabPageName)
            {
                case "tabPage1":
                    RoleName = "一般使用者";
                    UserId = txtUserId.Text;
                    break;
                case "tabPage2":
                    RoleName = "進銷存管理者";
                    UserId = txtUserId2.Text;
                    break;

            }

            DialogResult DR;
            DR = MessageBox.Show("是否要進行[" + RoleName + "]刪除-->" + UserId, "人員刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckFieldforDelete(this.NowTabPageName))
                {
                    RunDeleteData(this.NowTabPageName);
                }
            }
            else
            {
                MessageBox.Show("取消人員刪除動作!!", "刪除人員");
            }
        }
        //清除
        private void tSBClear_Click(object sender, EventArgs e)
        {
            ClearField(this.NowTabPageName);
            switch (this.NowTabPageName)
            {
                case "tabPage1":
                    MessageBox.Show("一般使用者-欄位資料清除完成!!", "清除");
                    break;
                case "tabPage2":
                    MessageBox.Show("進銷存管理者-欄位資料清除完成!!", "清除");
                    break;

            }
        }
        //離開
        private void tSBExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region "欄位驗證"

        /// <summary>
        /// 欄位驗證
        /// </summary>
        /// <param name="PageName"></param>
        /// <returns>輸入欄位型態正確回傳true,否則回傳false</returns>
        public bool CheckField(string PageName)
        {
            switch (PageName)
            {
                case "tabPage1":
                    if (txtUserId.Text == "")
                    {
                        MessageBox.Show("[使用者帳號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                        errorProvider1.SetError(txtUserId, "[使用者帳號]不得為空白!");
                        txtUserId.Focus();
                        return false;
                    }

                    if (txtCNAME.Text == "")
                    {
                        MessageBox.Show("[中文名稱]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                        errorProvider1.SetError(txtCNAME, "[中文名稱]不得為空白!");
                        txtCNAME.Focus();
                        return false;
                    }

                    if (txtENAME.Text == "")
                    {
                        MessageBox.Show("[英文名稱]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                        errorProvider1.SetError(txtENAME, "[英文名稱]不得為空白!");
                        txtENAME.Focus();
                        return false;
                    }

                    if (cboSex.Text == "")
                    {
                        MessageBox.Show("[性別]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                        errorProvider1.SetError(cboSex, "[性別]不得為空白!");
                        cboSex.Focus();
                        return false;
                    }

                    if (cboBooldType.Text == "")
                    {
                        MessageBox.Show("[血型]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                        errorProvider1.SetError(cboBooldType, "[血型]不得為空白!");
                        cboBooldType.Focus();
                        return false;
                    }

                    if (mtbID.Text == "")
                    {
                        MessageBox.Show("[身份證字號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                        errorProvider1.SetError(mtbID, "[身份證字號]不得為空白!");
                        mtbID.Focus();
                        return false;
                    }

                    if (txtPresentAddress.Text == "")
                    {
                        MessageBox.Show("[通訊地址]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                        errorProvider1.SetError(txtPresentAddress, "[通訊地址]不得為空白!");
                        txtPresentAddress.Focus();
                        return false;
                    }


                    if (mtbPhone.Text.Length != 10)
                    {
                        MessageBox.Show("[手機]號碼長度為10!", "欄位檢查", MessageBoxButtons.OK);
                        errorProvider1.SetError(mtbPhone, "[手機]號碼長度為10!");
                        mtbPhone.Focus();
                        return false;
                    }

                    break;
                case "tabPage2":
                    if (txtUserId2.Text == "")
                    {
                        MessageBox.Show("[使用者帳號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                        errorProvider1.SetError(txtUserId2, "[使用者帳號]不得為空白!");
                        txtUserId2.Focus();
                        return false;
                    }

                    if (txtCNAME2.Text == "")
                    {
                        MessageBox.Show("[中文名稱]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                        errorProvider1.SetError(txtCNAME2, "[中文名稱]不得為空白!");
                        txtCNAME2.Focus();
                        return false;
                    }

                    if (txtENAME2.Text == "")
                    {
                        MessageBox.Show("[英文名稱]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                        errorProvider1.SetError(txtENAME2, "[英文名稱]不得為空白!");
                        txtENAME2.Focus();
                        return false;
                    }

                    if (cboSex2.Text == "")
                    {
                        MessageBox.Show("[性別]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                        errorProvider1.SetError(cboSex2, "[性別]不得為空白!");
                        cboSex2.Focus();
                        return false;
                    }

                    if (cboBooldType2.Text == "")
                    {
                        MessageBox.Show("[血型]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                        errorProvider1.SetError(cboBooldType2, "[血型]不得為空白!");
                        cboBooldType2.Focus();
                        return false;
                    }

                    if (mtbID2.Text == "")
                    {
                        MessageBox.Show("[身份證字號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                        errorProvider1.SetError(mtbID2, "[身份證字號]不得為空白!");
                        mtbID2.Focus();
                        return false;
                    }

                    if (txtPresentAddress2.Text == "")
                    {
                        MessageBox.Show("[通訊地址]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                        errorProvider1.SetError(txtPresentAddress2, "[通訊地址]不得為空白!");
                        txtPresentAddress2.Focus();
                        return false;
                    }


                    if (mtbPhone2.Text.Length != 10)
                    {
                        MessageBox.Show("[手機]號碼長度為10!", "欄位檢查", MessageBoxButtons.OK);
                        errorProvider1.SetError(mtbPhone2, "[手機]號碼長度為10!");
                        mtbPhone2.Focus();
                        return false;
                    }
                    break;
            }

            return true;

        }

        #endregion


        #region "欄位驗證for Delete"

        /// <summary>
        /// 欄位驗證
        /// </summary>
        /// <param name="PageName"></param>
        /// <returns>輸入欄位型態正確回傳true,否則回傳false</returns>
        public bool CheckFieldforDelete(string PageName)
        {
            switch (PageName)
            {
                case "tabPage1":
                    if (txtUserId.Text == "")
                    {
                        MessageBox.Show("[使用者帳號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                        errorProvider1.SetError(txtUserId, "[使用者帳號]不得為空白!");
                        txtUserId.Focus();
                        return false;
                    }
                    break;
                case "tabPage2":
                    if (txtUserId2.Text == "")
                    {
                        MessageBox.Show("[使用者帳號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                        errorProvider1.SetError(txtUserId2, "[使用者帳號]不得為空白!");
                        txtUserId2.Focus();
                        return false;
                    }

                    break;
            }

            return true;

        }

        #endregion


        #region "清除欄位資料"

        public void ClearField(string PageName)
        {
            switch (PageName)
            {
                case "tabPage1":
                    this.txtUserId.Text = "";
                    this.txtCNAME.Text = "";
                    this.txtENAME.Text = "";
                    this.cboSex.Text = "";
                    this.cboBooldType.Text = "";
                    this.mtbID.Text = "";
                    this.txtPresentAddress.Text = "";
                    this.mtbPhone.Text = "";
                    break;
                case "tabPage2":
                    this.txtUserId2.Text = "";
                    this.txtCNAME2.Text = "";
                    this.txtENAME2.Text = "";
                    this.cboSex2.Text = "";
                    this.cboBooldType2.Text = "";
                    this.mtbID2.Text = "";
                    this.txtPresentAddress2.Text = "";
                    this.mtbPhone2.Text = "";
                    this.cboTitle.Text = "";
                    break;

            }
        }

        #endregion



        #region "將資料寫入資料庫中"

        /// <summary>
        /// 將資料寫入資料庫中
        /// </summary>
        private void RunInsertData(string PageName)
        {

            ArrayList arrList = new ArrayList();
            My.MyDatabase MyDb = new My.MyDatabase();

            switch (PageName)
            {
                case "tabPage1"://一般使用者
                    SIS.DBClass.DBClassUserInfo DbUI = new SIS.DBClass.DBClassUserInfo();

                    string UserId = this.txtUserId.Text;
                    string CNAME = this.txtCNAME.Text;
                    string ENAME = this.txtENAME.Text;
                    string Sex = this.cboSex.Text;
                    string Birthday = this.dtpBirthday.Value.ToString("yyyy年MM月dd日");
                    string BoolType = this.cboBooldType.Text;
                    string ID = this.mtbID.Text;
                    string PresentAddress = this.txtPresentAddress.Text;
                    string Phone = mtbPhone.Text;

                    arrList.Clear();
                    arrList.Insert(0, UserId);
                    arrList.Insert(1, CNAME);
                    arrList.Insert(2, ENAME);
                    arrList.Insert(3, Sex);
                    arrList.Insert(4, Birthday);
                    arrList.Insert(5, BoolType);
                    arrList.Insert(6, ID);
                    arrList.Insert(7, PresentAddress);
                    arrList.Insert(8, Phone);



                    if (MyDb.AuthPK(UserId, "UserId", "UserInfo") == false)
                    {
                        if (DbUI.InsertData(arrList))
                        {
                            MessageBox.Show("新增" + UserId + "-" + CNAME +
                                "一般使用者資料成功", "新增人員資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDefaultValue1();
                            if (InsertNewLoginAccount(UserId, "Users"))
                            {
                                MessageBox.Show("帳號:[" + UserId + "]建立成功，預設密碼為[12345]，登入系統後請記得變更。", "建立登入系統帳號成功");
                            }
                        }
                        else
                        {
                            MessageBox.Show("新增" + UserId + "-" + CNAME +
                                "一般使用者資料失敗", "新增人員資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("對不起，資料庫已存在 " + UserId + "-" + CNAME +
                              " 人員資料!!(資料重複)", "資料新增");
                    }

                    break;
                case "tabPage2"://進銷存管理者
                    SIS.DBClass.DBClassManagementInfo DbMI = new SIS.DBClass.DBClassManagementInfo();

                    string UserId2 = this.txtUserId2.Text;
                    string CNAME2 = this.txtCNAME2.Text;
                    string ENAME2 = this.txtENAME2.Text;
                    string Sex2 = this.cboSex2.Text;
                    string Birthday2 = this.dtpBirthday2.Value.ToString("yyyy年MM月dd日");
                    string BoolType2 = this.cboBooldType2.Text;
                    string ID2 = this.mtbID2.Text;
                    string PresentAddress2 = this.txtPresentAddress2.Text;
                    string Phone2 = mtbPhone2.Text;
                    string Title = cboTitle.Text;

                    arrList.Clear();
                    arrList.Insert(0, UserId2);
                    arrList.Insert(1, CNAME2);
                    arrList.Insert(2, ENAME2);
                    arrList.Insert(3, Sex2);
                    arrList.Insert(4, Birthday2);
                    arrList.Insert(5, BoolType2);
                    arrList.Insert(6, ID2);
                    arrList.Insert(7, PresentAddress2);
                    arrList.Insert(8, Phone2);
                    arrList.Insert(9, Title);


                    if (MyDb.AuthPK(UserId2, "UserId", "ManagementInfo") == false)
                    {
                        if (DbMI.InsertData(arrList))
                        {
                            MessageBox.Show("新增" + UserId2 + "-" + CNAME2 +
                                "進銷存管理者資料成功", "新增人員資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDefaultValue2();
                            if (InsertNewLoginAccount(UserId2, "Management"))
                            {
                                MessageBox.Show("帳號:[" + UserId2 + "]建立成功，預設密碼為[12345]，登入系統後請記得變更。", "建立登入系統帳號成功");
                            }
                        }
                        else
                        {
                            MessageBox.Show("新增" + UserId2 + "-" + CNAME2 +
                                "進銷存管理者資料失敗", "新增人員資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("對不起，資料庫已存在 " + UserId2 + "-" + CNAME2 +
                              " 人員資料!!(資料重複)", "資料新增");
                    }

                    break;

            }



        }

        #endregion


        #region "更新資料庫資料"

        /// <summary>
        /// 更新資料庫資料
        /// </summary>
        private void RunUpdateData(string PageName)
        {

            ArrayList arrList = new ArrayList();
            My.MyDatabase MyDb = new My.MyDatabase();

            switch (PageName)
            {
                case "tabPage1"://一般使用者
                    SIS.DBClass.DBClassUserInfo DbUI = new SIS.DBClass.DBClassUserInfo();

                    string UserId = this.txtUserId.Text;
                    string CNAME = this.txtCNAME.Text;
                    string ENAME = this.txtENAME.Text;
                    string Sex = this.cboSex.Text;
                    string Birthday = this.dtpBirthday.Value.ToString("yyyy年MM月dd日");
                    string BoolType = this.cboBooldType.Text;
                    string ID = this.mtbID.Text;
                    string PresentAddress = this.txtPresentAddress.Text;
                    string Phone = mtbPhone.Text;

                    arrList.Clear();
                    arrList.Insert(0, UserId);
                    arrList.Insert(1, CNAME);
                    arrList.Insert(2, ENAME);
                    arrList.Insert(3, Sex);
                    arrList.Insert(4, Birthday);
                    arrList.Insert(5, BoolType);
                    arrList.Insert(6, ID);
                    arrList.Insert(7, PresentAddress);
                    arrList.Insert(8, Phone);


                    //資料存在才進行更新動作
                    if (MyDb.AuthPK(UserId, "UserId", "UserInfo") == true)
                    {
                        if (DbUI.Update(arrList))
                        {
                            MessageBox.Show("更新" + UserId + "-" + CNAME +
                                "一般使用者資料成功", "更新人員資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDefaultValue1();
                        }
                        else
                        {
                            MessageBox.Show("更新" + UserId + "-" + CNAME +
                                "一般使用者資料失敗", "更新人員資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("對不起，資料庫不存在 " + UserId + "-" + CNAME +
                              " 人員資料!!(無法更新)", "資料更新");
                    }

                    break;
                case "tabPage2"://進銷存管理者
                    SIS.DBClass.DBClassManagementInfo DbMI = new SIS.DBClass.DBClassManagementInfo();

                    string UserId2 = this.txtUserId2.Text;
                    string CNAME2 = this.txtCNAME2.Text;
                    string ENAME2 = this.txtENAME2.Text;
                    string Sex2 = this.cboSex2.Text;
                    string Birthday2 = this.dtpBirthday2.Value.ToString("yyyy年MM月dd日");
                    string BoolType2 = this.cboBooldType2.Text;
                    string ID2 = this.mtbID2.Text;
                    string PresentAddress2 = this.txtPresentAddress2.Text;
                    string Phone2 = mtbPhone2.Text;
                    string Title = cboTitle.Text;

                    arrList.Clear();
                    arrList.Insert(0, UserId2);
                    arrList.Insert(1, CNAME2);
                    arrList.Insert(2, ENAME2);
                    arrList.Insert(3, Sex2);
                    arrList.Insert(4, Birthday2);
                    arrList.Insert(5, BoolType2);
                    arrList.Insert(6, ID2);
                    arrList.Insert(7, PresentAddress2);
                    arrList.Insert(8, Phone2);
                    arrList.Insert(9, Title);


                    if (MyDb.AuthPK(UserId2, "UserId", "ManagementInfo") == true)
                    {
                        if (DbMI.Update(arrList))
                        {
                            MessageBox.Show("更新" + UserId2 + "-" + CNAME2 +
                                "進銷存管理者資料成功", "更新人員資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDefaultValue2();
                        }
                        else
                        {
                            MessageBox.Show("更新" + UserId2 + "-" + CNAME2 +
                                "進銷存管理者資料失敗", "更新人員資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("對不起，資料庫不存在 " + UserId2 + "-" + CNAME2 +
                              " 人員資料!!(無法更新)", "資料更新");
                    }

                    break;

            }



        }

        #endregion


        #region "刪除資料庫資料"

        /// <summary>
        /// 刪除資料庫資料
        /// </summary>
        private void RunDeleteData(string PageName)
        {

            ArrayList arrList = new ArrayList();
            My.MyDatabase MyDb = new My.MyDatabase();

            switch (PageName)
            {
                case "tabPage1"://一般使用者
                    SIS.DBClass.DBClassUserInfo DbUI = new SIS.DBClass.DBClassUserInfo();

                    string UserId = this.txtUserId.Text;
                    string CNAME = this.txtCNAME.Text;



                    //資料存在才進行更新動作
                    if (MyDb.AuthPK(UserId, "UserId", "UserInfo") == true)
                    {
                        if (DbUI.DeleteOneData(UserId))
                        {
                            MessageBox.Show("刪除" + UserId + "-" + CNAME +
                                "一般使用者資料成功", "刪除人員資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDefaultValue1();
                        }
                        else
                        {
                            MessageBox.Show("刪除" + UserId + "-" + CNAME +
                                "一般使用者資料失敗", "刪除人員資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("對不起，資料庫不存在 " + UserId + "-" + CNAME +
                              " 人員資料!!(無法刪除)", "資料刪除");
                    }

                    break;
                case "tabPage2"://進銷存管理者
                    SIS.DBClass.DBClassManagementInfo DbMI = new SIS.DBClass.DBClassManagementInfo();

                    string UserId2 = this.txtUserId2.Text;
                    string CNAME2 = this.txtCNAME2.Text;


                    if (MyDb.AuthPK(UserId2, "UserId", "ManagementInfo") == true)
                    {
                        if (DbMI.DeleteOneData(UserId2))
                        {
                            MessageBox.Show("刪除" + UserId2 + "-" + CNAME2 +
                                "進銷存管理者資料成功", "刪除人員資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDefaultValue2();
                        }
                        else
                        {
                            MessageBox.Show("刪除" + UserId2 + "-" + CNAME2 +
                                "進銷存管理者資料失敗", "刪除人員資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("對不起，資料庫不存在 " + UserId2 + "-" + CNAME2 +
                              " 人員資料!!(無法刪除)", "資料刪除");
                    }

                    break;

            }



        }

        #endregion

       
         private bool InsertNewLoginAccount(string UserID , string RoleId)
        {
            SIS.Configuration.ClsLoginConfig CLC = new Configuration.ClsLoginConfig();
            CLC.UserId = UserID;
            CLC.Pwd = My.MyMethod.HashEncryption("SHA1", "12345"); //預設密碼為12345
            CLC.RoleId = RoleId;
            CLC.CreateDate = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
            CLC.IsValid = 1;
            SIS.DBClass.DBClsLogin DBCLogin = new DBClass.DBClsLogin();
            return DBCLogin.InsertData(CLC);
        }


        #region "事件處理部分"

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.txtUserId.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            this.txtCNAME.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            this.txtENAME.Text = dataGridView1[2, e.RowIndex].Value.ToString();
            this.cboSex.Text = dataGridView1[3, e.RowIndex].Value.ToString();
            this.dtpBirthday.Text = dataGridView1[4, e.RowIndex].Value.ToString();
            this.cboBooldType.Text = dataGridView1[5, e.RowIndex].Value.ToString();
            this.mtbID.Text = dataGridView1[6, e.RowIndex].Value.ToString();
            this.txtPresentAddress.Text = dataGridView1[7, e.RowIndex].Value.ToString();
            this.mtbPhone.Text = dataGridView1[8, e.RowIndex].Value.ToString();
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.txtUserId2.Text = dataGridView2[0, e.RowIndex].Value.ToString();
            this.txtCNAME2.Text = dataGridView2[1, e.RowIndex].Value.ToString();
            this.txtENAME2.Text = dataGridView2[2, e.RowIndex].Value.ToString();
            this.cboSex2.Text = dataGridView2[3, e.RowIndex].Value.ToString();
            this.dtpBirthday2.Text = dataGridView2[4, e.RowIndex].Value.ToString();
            this.cboBooldType2.Text = dataGridView2[5, e.RowIndex].Value.ToString();
            this.mtbID2.Text = dataGridView2[6, e.RowIndex].Value.ToString();
            this.txtPresentAddress2.Text = dataGridView2[7, e.RowIndex].Value.ToString();
            this.mtbPhone2.Text = dataGridView2[8, e.RowIndex].Value.ToString();
            this.cboTitle.Text = dataGridView2[9, e.RowIndex].Value.ToString();
        }

        #endregion

        

    }
}
