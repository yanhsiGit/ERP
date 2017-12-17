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
    public partial class FrmAuthoritySetup : Form
    {
        public FrmAuthoritySetup()
        {
            InitializeComponent();
        }

        public string RdoBtnAuthority = "";
        //取消所有權限-None
        //匿名參觀者權限-Guest
        //一般使用者權限-User
        //進銷存管理者權限-Management
        //系統管理者權限-Admin
        //選取所有權限-All

        private void FrmAuthoritySetup_Load(object sender, EventArgs e)
        {
            LoadDefaultValue();
        }

        #region "載入表單預設值"

        /// <summary>
        /// 載入表單預設值
        /// </summary>
        private void LoadDefaultValue()
        {
            runTreeViewUsers();
            runTreeViewAuthority();
            groupBox4.Visible = false;
            txtUserId.Text = "";
        }

        #endregion


        #region "用TreeView來顯示使用者"

        /// <summary>
        /// 用TreeView來顯示使用者
        /// </summary>
        private void runTreeViewUsers()
        {
            SIS.DBClass.DBClsLogin DbLogin = new SIS.DBClass.DBClsLogin();

            DataTable DT = DbLogin.GetLoginDataTable("UserId", "ASC");
            TreeNode TN;
            string RoleName = "";
            treeViewUsers.Nodes.Clear();
            treeViewUsers.ImageList = imgListForTreeView;

            //建立root節點
            TN = new TreeNode("人員管理子系統");
            TN.Tag = "";
            TN.ImageIndex = 0;
            TN.SelectedImageIndex = 0;
            treeViewUsers.Nodes.Add(TN);

            //建立人員分類節點
            TN = new TreeNode("系統管理者");
            TN.ImageIndex = 1;
            treeViewUsers.Nodes[0].Nodes.Add(TN);
            TN = new TreeNode("一般使用者");
            TN.ImageIndex = 1;
            treeViewUsers.Nodes[0].Nodes.Add(TN);
            TN = new TreeNode("進銷存管理者");
            TN.ImageIndex = 1;
            treeViewUsers.Nodes[0].Nodes.Add(TN);
            TN = new TreeNode("匿名參觀者");
            TN.ImageIndex = 1;
            treeViewUsers.Nodes[0].Nodes.Add(TN);

            foreach (DataRow Rows in DT.Rows)
            {
                RoleName = DbLogin.RoleIdToRoleName(Rows["UserId"].ToString());

                TN = new TreeNode(Rows["UserId"].ToString());
                TN.ImageIndex = 3;
                TN.SelectedImageIndex = 2;
                TN.ToolTipText = Rows["UserId"].ToString();
                TN.Tag = Rows["UserId"].ToString();

                switch (RoleName)
                {
                    case "系統管理者":
                        treeViewUsers.Nodes[0].Nodes[0].Nodes.Add(TN);
                        break;
                    case "一般使用者":
                        treeViewUsers.Nodes[0].Nodes[1].Nodes.Add(TN);
                        break;
                    case "進銷存管理者":
                        treeViewUsers.Nodes[0].Nodes[2].Nodes.Add(TN);
                        break;
                    case "匿名參觀者":
                        treeViewUsers.Nodes[0].Nodes[3].Nodes.Add(TN);
                        break;
                    default:
                        MessageBox.Show(this, "角色編號可能有誤!!", "警告訊息");
                        break;
                }


            }
            treeViewUsers.ShowNodeToolTips = true; //用來設定顯示節點顯示提示字串


        }

        #endregion


        #region "用TreeView來顯示權限"

        /// <summary>
        /// 用TreeView來顯示權限
        /// </summary>
        private void runTreeViewAuthority()
        {

            SIS.DBClass.DBClassSysFunction DbSF = new SIS.DBClass.DBClassSysFunction();

            DataTable DT = DbSF.GetSysFunctionDataTable("ASC");
            TreeNode TN;
            treeViewAuthority.Nodes.Clear();
            treeViewAuthority.ImageList = imgListForTreeView2;
            int i = -1;

            foreach (DataRow Rows in DT.Rows)
            {
                if (Rows["FuncId"].ToString().Substring(2, 2) == "00")
                {
                    //建立root節點
                    TN = new TreeNode(Rows["FuncName"].ToString());
                    TN.Tag = Rows["FuncId"].ToString();
                    TN.ImageIndex = 1;
                    TN.SelectedImageIndex = 0;
                    treeViewAuthority.Nodes.Add(TN);
                    i = i + 1;
                }
                else
                {
                    TN = new TreeNode(Rows["FuncName"].ToString());
                    TN.ImageIndex = 3;
                    TN.SelectedImageIndex = 2;
                    TN.ToolTipText = Rows["FuncName"].ToString();
                    TN.Tag = Rows["FuncId"].ToString();

                    switch (Rows["FuncGroup"].ToString())
                    {
                        case "共同功能":
                            treeViewAuthority.Nodes[i].Nodes.Add(TN);
                            break;
                        case "基本資料維護":
                            treeViewAuthority.Nodes[i].Nodes.Add(TN);
                            break;
                        case "進銷存操作":
                            treeViewAuthority.Nodes[i].Nodes.Add(TN);
                            break;
                        case "報表":
                            treeViewAuthority.Nodes[i].Nodes.Add(TN);
                            break;
                        case "系統設定與管理":
                            treeViewAuthority.Nodes[i].Nodes.Add(TN);
                            break;
                        case "視窗":
                            treeViewAuthority.Nodes[i].Nodes.Add(TN);
                            break;
                        case "說明":
                            treeViewAuthority.Nodes[i].Nodes.Add(TN);
                            break;
                        default:
                            MessageBox.Show(this, "角色編號可能有誤!!", "警告訊息");
                            break;
                    }
                }

            }
            treeViewAuthority.ShowNodeToolTips = true; //用來設定顯示節點顯示提示字串
            treeViewAuthority.CheckBoxes = true;

        }

        #endregion
        //確定變更
        private void tSBSureChange_Click(object sender, EventArgs e)
        {
            DialogResult DR;
            DR = MessageBox.Show(this, "您確定要對帳號[" + tSSL_UserId.Text + "]進行權限變更動作嗎?", "權限變更", MessageBoxButtons.YesNo);

            if (DR == DialogResult.Yes)
            {
                TreeViewNodesAuthorityToDB(treeViewAuthority.Nodes);
                MessageBox.Show(this, "帳號[" + tSSL_UserId.Text + "]權限變更成功!!", "權限變更", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(this, "您已經按下[否]鈕！！將不進行任何變更動作", "權限變更", MessageBoxButtons.OK);
            }
        }

        //重新整理
        private void tSBRefresh_Click(object sender, EventArgs e)
        {
            LoadDefaultValue();
            MessageBox.Show(this, "已經將最新的資料庫資料與控制項內容重新載入!!", "重新整理");
        }
        //人員查詢
        private void tSBQuery_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            txtUserId.Text = "";
            txtUserId.Focus();
        }
        //關閉表單
        private void tSBClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            SIS.DBClass.DBClsSysUserAuthority DbSUA = new SIS.DBClass.DBClsSysUserAuthority();
            DataTable DT = DbSUA.GetSysUserAuthorityDataTable(txtUserId.Text);

            // 取出TreeView的節點集合, PS此法只有一層
            //TreeNodeCollection nodes = treeView_Authority.Nodes;

            if (DT.Rows.Count > 0)
            {
                foreach (DataRow Rows in DT.Rows)
                {
                    FindTreeViewNodes(treeViewAuthority.Nodes, Rows["FuncId"].ToString(), Convert.ToBoolean(Rows["AuthStatus"]));
                }
                MessageBox.Show(this, "帳號[" + txtUserId.Text + "]有找到符合資料!!", "查詢結果");
                tSSL_UserId.Text = txtUserId.Text;
                FindTreeViewNodesText(treeViewUsers.Nodes, tSSL_UserId.Text);
                txtUserId.Text = "";
                tSBSureChange.Enabled = true;
                groupBox4.Visible = false;

            }
            else if (DT.Rows.Count == 0)
            {
                MessageBox.Show(this, "未找到任何符合資料!!", "查詢結果");
            }
        }
        //關閉查詢
        private void btnCloseQuery_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
            txtUserId.Text = "";
        }
        //點選TreeView項目之後所觸發的事件
        private void treeViewUsers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {

                tSSL_TreeViewPath.Text = e.Node.FullPath;
                tSSL_UserId.Text = e.Node.Text;
                if (e.Node.Text != "人員管理子系統")
                {
                    tSBSureChange.Enabled = true;
                    SIS.DBClass.DBClsSysUserAuthority DbSUA = new SIS.DBClass.DBClsSysUserAuthority();
                    DataTable DT = DbSUA.GetSysUserAuthorityDataTable(e.Node.Text);

                    // 取出TreeView的節點集合, PS此法只有一層
                    //TreeNodeCollection nodes = treeView_Authority.Nodes;

                    foreach (DataRow Rows in DT.Rows)
                    {
                        FindTreeViewNodes(treeViewAuthority.Nodes, Rows["FuncId"].ToString(), Convert.ToBoolean(Rows["AuthStatus"]));

                    }

                }
                else
                {
                    tSBSureChange.Enabled = false;
                    tSSL_UserId.Text = "使用者帳號";
                }
            }
        }


        #region "找尋 TreeView的節點Tag屬性值是否有與FindValue相同,並且設定節點Checked屬性值"

        /// <summary>
        /// 找尋 TreeView的節點Tag屬性值是否有與FindValue相同,並且設定節點Checked屬性值
        /// 例如:FindTreeViewNodes(treeView_Authority.Nodes , "FB02", true);
        /// </summary>
        /// <param name="TNs">傳入節點集合例如:TreeView1.Nodes</param>
        /// <param name="FindValue">要找尋的節點是否有跟FindValue相同值</param>
        /// <param name="IsChecked">設定節點Checked屬性是否為True或False</param>
        private void FindTreeViewNodes(TreeNodeCollection TNs, string FindValue, bool IsChecked)
        {

            if (TNs.Count != 0)
            {
                foreach (TreeNode TN in TNs)
                {
                    if (TN.Tag.ToString() == FindValue)
                    {
                        TN.Checked = IsChecked;
                    }
                    else
                    {
                        if (TN.Nodes.Count > 0)
                        {
                            FindTreeViewNodes(TN.Nodes, FindValue, IsChecked);
                        }
                    }
                }

            }

        }

        #endregion


        #region "找尋TreeView中Node的Text屬性值,若與傳入的參數FindValue的值相同,則將其路徑展開"

        /// <summary>
        /// 找尋TreeView中Node的Text屬性值,若與傳入的參數FindValue的值相同,則將其路徑展開
        /// </summary>
        /// <param name="TNs">傳入節點集合例如:TreeView1.Nodes</param>
        /// <param name="FindValue">要找尋的節點是否有跟FindValue相同值</param>
        /// <returns>找到其值回傳True,否則會傳False</returns>
        private bool FindTreeViewNodesText(TreeNodeCollection TNs, string FindValue)
        {

            if (TNs.Count != 0)
            {
                foreach (TreeNode TN in TNs)
                {
                    if (TN.Text == FindValue)
                    {
                        TN.Parent.Expand();
                        TN.Parent.Parent.Expand();
                        return true;
                    }
                    else
                    {
                        if (TN.Nodes.Count > 0)
                        {
                            FindTreeViewNodesText(TN.Nodes, FindValue);
                        }
                    }
                }


            }

            return false;

        }

        #endregion

        private void btnApply_Click(object sender, EventArgs e)
        {
            //FindTreeViewNodes(treeView_Authority.Nodes , "FB02", true);

            foreach (object obj in groupBox3.Controls)
            {
                if (obj.GetType().ToString() == "System.Windows.Forms.RadioButton")
                {
                    System.Windows.Forms.RadioButton RdoBtn = (RadioButton)obj;
                    if (RdoBtn.Checked == true)
                    {
                        RdoBtnAuthority = RdoBtn.Tag.ToString();

                        switch (RdoBtnAuthority)
                        {
                            case "None":
                                SetTreeViewNodesCheckBox(treeViewAuthority.Nodes, false);
                                break;
                            case "All":
                                SetTreeViewNodesCheckBox(treeViewAuthority.Nodes, true);
                                break;
                            default:
                                SIS.DBClass.DBClassSysRoleAuthority DbSRA = new SIS.DBClass.DBClassSysRoleAuthority();
                                DataTable DT = DbSRA.GetSysRoleAuthorityDataTable("ASC");

                                foreach (DataRow Rows in DT.Rows)
                                {
                                    FindTreeViewNodes(treeViewAuthority.Nodes,
                                        Rows["FuncId"].ToString(), Convert.ToBoolean(Rows[RdoBtnAuthority]));
                                }

                                break;
                        }

                    }
                }
            }
        }

        #region "用來設定TreeView所有節點是否為勾選狀態"

        /// <summary>
        /// 用來設定TreeView所有節點是否為勾選狀態
        /// </summary>
        /// <param name="TNs">傳入節點集合例如:TreeView1.Nodes</param>
        /// <param name="IsChecked"></param>
        private void SetTreeViewNodesCheckBox(TreeNodeCollection TNs, bool IsChecked)
        {

            if (TNs.Count != 0)
            {
                foreach (TreeNode TN in TNs)
                {
                    TN.Checked = IsChecked;

                    if (TN.Nodes.Count > 0)
                    {
                        SetTreeViewNodesCheckBox(TN.Nodes, IsChecked);
                    }
                }

            }

        }

        #endregion


        #region "將TreeView權限內容寫入資料庫中"

        /// <summary>
        /// 將TreeView權限內容寫入資料庫中
        /// </summary>
        /// <param name="TNs">傳入節點集合例如:TreeView1.Nodes</param>
        private void TreeViewNodesAuthorityToDB(TreeNodeCollection TNs)
        {
            SIS.DBClass.DBClsSysUserAuthority DbSUA = new SIS.DBClass.DBClsSysUserAuthority();

            My.MyDatabase MyDb = new My.MyDatabase();



            if (TNs.Count != 0)
            {
                foreach (TreeNode TN in TNs)
                {
                    if (MyDb.AuthPK(tSSL_UserId.Text, "UserId", TN.Tag.ToString(), "FuncId", "SysUserAuthority"))
                    {
                        DbSUA.UpdateAuthStatus(tSSL_UserId.Text, TN.Tag.ToString(), TN.Checked);
                    }
                    else
                    {
                        DbSUA.InsertData(tSSL_UserId.Text, TN.Tag.ToString(), TN.Checked);
                    }


                    if (TN.Nodes.Count > 0)
                    {
                        TreeViewNodesAuthorityToDB(TN.Nodes);
                    }
                }

            }

        }

        #endregion


    }
}
