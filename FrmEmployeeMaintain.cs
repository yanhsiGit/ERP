using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace SIS
{
    public partial class FrmEmployeeMaintain : Form
    {
        public FrmEmployeeMaintain()
        {
            InitializeComponent();
        }

        public string ApplicationStartupPath;
        public string PreviousPhotoPath;
        private  object syncRoot = new Object();
        private void FrmEmployeeMaintain_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            DeletePhotoTempFile();
            LoadDefaultValue();
            ApplicationStartupPath = Application.StartupPath;
        }

#region "載入表單控制項相關預設值"

           /// <summary>
        /// 載入表單控制項相關預設值
        /// </summary>
        public void LoadDefaultValue()
        {
            string SQLCommand = "Select * from EmployeeInfo order by EmployeeID ";
            My.MyDatabase MyDb = new My.MyDatabase();

            DataView DV = MyDb.CreateDataView(SQLCommand, "EmployeeInfo");
            this.dgvEmployeeInfo.DataSource = DV;

            //dataGridView表頭名稱中文化
            dgvEmployeeInfo.Columns[0].HeaderText = "職員編號";
            dgvEmployeeInfo.Columns[1].HeaderText = "中文名稱";
            dgvEmployeeInfo.Columns[2].HeaderText = "英文名稱";
            dgvEmployeeInfo.Columns[3].HeaderText = "相片";
            dgvEmployeeInfo.Columns[4].HeaderText = "性別";
            dgvEmployeeInfo.Columns[5].HeaderText = "生日";
            dgvEmployeeInfo.Columns[6].HeaderText = "血型";
            dgvEmployeeInfo.Columns[7].HeaderText = "身分證字號";
            dgvEmployeeInfo.Columns[8].HeaderText = "通訊地址";
            dgvEmployeeInfo.Columns[9].HeaderText = "專長";
            dgvEmployeeInfo.Columns[10].HeaderText = "到職日期";
            dgvEmployeeInfo.Columns[11].HeaderText = "職稱";
            dgvEmployeeInfo.Columns[12].HeaderText = "最高學歷";
            dgvEmployeeInfo.Columns[13].HeaderText = "電話";
            dgvEmployeeInfo.Columns[14].HeaderText = "在職狀態";

            tsslDataCount.Text = DV.Count.ToString();

            //凍結 中文名稱 欄位
            this.dgvEmployeeInfo.Columns["CNAME"].Frozen = true;

            //設定點選任一儲存格變選取所屬資料列的所有資料
            this.dgvEmployeeInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //替代資料列樣式 
            this.dgvEmployeeInfo.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dgvEmployeeInfo.AlternatingRowsDefaultCellStyle.BackColor = Color.Ivory;

            //自動調整資料列與資料行的高度與寬度
            this.dgvEmployeeInfo.AutoResizeColumns();
            //this.dgvEmployeeInfo.AutoResizeRows();

            //防止在 DataGridView 控制項中新增和刪除資料列 
            this.dgvEmployeeInfo.AllowUserToAddRows = false;
            this.dgvEmployeeInfo.AllowUserToDeleteRows = false;

            toolTip1.SetToolTip(txtEmployeeID , "請輸入[職員編號]!");
            toolTip1.SetToolTip(txtCNAME , "請輸入職員[中文名稱]!");
            tsbAddNew.ToolTipText = "按下[新增]鈕,以進行職員新增動作!";
            tsbUpdate.ToolTipText = "按下[更改]鈕,以進行職員更改動作!";
            tsbDelete.ToolTipText = "按下[刪除]鈕,以進行職員刪除動作!";
            tsbClear.ToolTipText = "按下[清除]鈕,以進行輸入欄位資料清除動作!";
            tsbExit.ToolTipText = "按下[離開]鈕,會將本表單進行關閉!";
        }

        #endregion


        /// <summary>
        /// 更新資料庫內的圖片二進位資料
        /// </summary>
        /// <remarks></remarks>
        public void UpdateImageIntoDB(string photoFilePath)
        {
            ArrayList arrList = new ArrayList();
            arrList.Clear();
            string FilePath = photoFilePath;
            string EmployeeID = this.txtEmployeeID.Text;

            //將圖片檔案轉換成二進位資料
            byte[] Photos = My.MyFileIO.FileToByteArray(FilePath);
            arrList.Insert(0, EmployeeID);
            //職員編號
            arrList.Insert(1, Photos);
            //相片

            SIS.DBClass.DBClassEmployeeInfo DBCEmployeeInfo = new DBClass.DBClassEmployeeInfo();
            My.MyDatabase myDB = new My.MyDatabase();

            if (myDB.AuthPK(EmployeeID, "EmployeeID", "EmployeeInfo") == true)
            {
                if (DBCEmployeeInfo.ParameterUpdateData(arrList))
                {
                    MessageBox.Show("更新" + EmployeeID + "- 圖片資料成功", "更新職員資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDefaultValue();
                }
                else
                {
                    MessageBox.Show("更新" + EmployeeID + "-圖片資料失敗", "更新職員資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("對不起，資料庫不存在 " + EmployeeID + "-職員資料!!", "圖片資料無法更新");
                return;
            }
        }




        private void dgvEmployeeInfo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.txtEmployeeID.Text = dgvEmployeeInfo[0, e.RowIndex].Value.ToString();
            this.txtCNAME.Text = dgvEmployeeInfo[1, e.RowIndex].Value.ToString();
            this.txtENAME.Text = dgvEmployeeInfo[2, e.RowIndex].Value.ToString();

            byte[] PicturePhoto = null;
            PicturePhoto = (byte[])dgvEmployeeInfo[3, e.RowIndex].Value;
            string TempPath = Application.StartupPath + "\\Photos\\Employee\\" + My.MyMethod.RunID("") + ".tmp";
            string Path = Application.StartupPath + "\\Photos\\Employee\\" + this.txtEmployeeID.Text + ".bmp";

            My.MyFileIO.ByteArrayToFile(PicturePhoto, TempPath);

            //My.MyFileIO.FileCopy(TempPath, Path , true);

            Bitmap BP = new Bitmap(TempPath);
            PicPhotos.Image = BP;

            //My.MyFileIO.FileDelete(TempPath);
            //My.MyFileIO.FileCopy(Path, NowPicturePath);

            this.cboSex.Text = dgvEmployeeInfo[4, e.RowIndex].Value.ToString();
            this.dtpBirthday.Text = dgvEmployeeInfo[5, e.RowIndex].Value.ToString();
            this.cboBooldType.Text = dgvEmployeeInfo[6, e.RowIndex].Value.ToString();
            this.mtbID.Text = dgvEmployeeInfo[7, e.RowIndex].Value.ToString();
            this.txtPresentAddress.Text = dgvEmployeeInfo[8, e.RowIndex].Value.ToString();
            this.txtProfessional.Text = dgvEmployeeInfo[9, e.RowIndex].Value.ToString();
            this.dtpHireDate.Text = dgvEmployeeInfo[10, e.RowIndex].Value.ToString();
            this.txtPosition.Text = dgvEmployeeInfo[11, e.RowIndex].Value.ToString();
            this.txtBackground.Text = dgvEmployeeInfo[12, e.RowIndex].Value.ToString();
            this.mtbPhone.Text = dgvEmployeeInfo[13, e.RowIndex].Value.ToString();
            this.cboStatus.Text = dgvEmployeeInfo[14, e.RowIndex].Value.ToString();

        }

        private void PicPhotos_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "BMP File|*.bmp|JPG File|*.JPG|Gif File|*.GIF|All Files|*.*";
            openFileDialog1.Title = "請選擇要匯入的圖片檔案";
            openFileDialog1.InitialDirectory = ApplicationStartupPath + "\\";


            if ((openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK))
            {
                openFileDialog1.InitialDirectory = ApplicationStartupPath + "\\";
                Bitmap BP = (Bitmap) Image.FromFile(openFileDialog1.FileName);
 
                string Path = ApplicationStartupPath + "\\Photos\\Employee\\" + "NewPicture.bmp";
                string DirPath = ApplicationStartupPath + "\\Photos\\Employee";

                if ((!My.MyFileIO.DirExists(DirPath)))
                {
                    My.MyFileIO.DirCreate(DirPath);
                }

                //My.MyFileIO.FileDelete(Path);
                My.MyFileIO.FileCopy(openFileDialog1.FileName, Path , true);


                if (((BP.Width >= 100 && BP.Width <= 200) && (BP.Height >= 100 && BP.Height <= 200)))
                {

                    PicPhotos.Width = BP.Width;
                    PicPhotos.Height = BP.Height;
                    PicPhotos.Image = BP;
                    openFileDialog1.RestoreDirectory = true;
                    openFileDialog1.Reset();
                    DialogResult dr = default(DialogResult);
                    dr = MessageBox.Show("是否要更新資料庫圖片資料", "圖片更新訊息", MessageBoxButtons.YesNo);
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        UpdateImageIntoDB(Path);
                    }
                    else
                    {
                        MessageBox.Show("取消更新資料庫","照片更新失敗");
                    }
                }
                else
                {
                    MessageBox.Show("圖片大小建議100*100 ~ 200*200之間,照片變更失敗.");
                }
            }
        }


        private void DeletePhotoTempFile()
        {
            try
            {
                string DirPath = Application.StartupPath + "\\Photos\\Employee";
                var files = System.IO.Directory.GetFiles(DirPath);

                var tmpfiles = from file in files.AsParallel()
                               where file.IndexOf(".tmp") != -1
                               select (file);

                int i = 0;
                Parallel.ForEach(tmpfiles, new ParallelOptions { MaxDegreeOfParallelism = 4 }, (file) =>
                {
                    lock (syncRoot)
                    {
                        if (My.MyFileIO.IsFileReady(file))
                        {
                            My.MyFileIO.FileDelete(file);
                            i = i + 1;
                        }
                    }
                });
                MessageBox.Show("共刪除" + i.ToString() + "暫存檔案");
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
           
        }

        private void tsbAddNew_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行職員[" + txtEmployeeID.Text + "-" + txtCNAME.Text + "]新增動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "新增職員", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunInsertData();
                }
            }
            else
            {
                MessageBox.Show("取消職員新增動作!!", "新增職員");
            }
        }

        #region "欄位驗證"

        /// <summary>
        /// 欄位驗證
        /// </summary>
        /// <returns>輸入欄位型態正確回傳true,否則回傳false</returns>
        public bool CheckField()
        {

            if (txtEmployeeID.Text  == "")
            {
                MessageBox.Show("[職員編號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(txtEmployeeID, "[職員編號]不得為空白!");
                txtEmployeeID.Focus();
                return false;
            }

            if (txtCNAME.Text  == "")
            {
                MessageBox.Show("[中文名稱]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(txtCNAME, "[中文名稱]不得為空白!");
                txtCNAME.Focus();
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
            SIS.Configuration.ClsEmployeeConfig CEC = new Configuration.ClsEmployeeConfig();
            CEC.EmployeeID = txtEmployeeID.Text;
            CEC.CNAME = txtCNAME.Text;
            CEC.ENAME = txtENAME.Text;
            string FilePath = Application.StartupPath + "\\Photos\\Employee\\" + "NoPicture.bmp";
            CEC.Photos = My.MyFileIO.FileToByteArray(FilePath);
            CEC.Sex = cboSex.Text;
            CEC.Birthday = dtpBirthday.Value.ToString("yyyy年MM月dd日");
            CEC.BooldType = cboBooldType.Text;
            CEC.ID = mtbID.Text;
            CEC.PresentAddress = txtPresentAddress.Text;
            CEC.Professional = txtProfessional.Text;
            CEC.HireDate = dtpHireDate.Value.ToString("yyyy年MM月dd日");
            CEC.Positions = txtPosition.Text;
            CEC.Background = txtBackground.Text;
            CEC.Phone = mtbPhone.Text;
            CEC.Status = cboStatus.Text;

            SIS.DBClass.DBClassEmployeeInfo DBCEI = new DBClass.DBClassEmployeeInfo();

            if (MyDb.AuthPK(CEC.EmployeeID, "EmployeeID", "EmployeeInfo") == false)
            {
                if (DBCEI.ParameterInsertData(CEC))
                {
                    MessageBox.Show("新增[" + CEC.EmployeeID + "-" + CEC.CNAME  +
                        "]職員資料成功", "新增職員資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDefaultValue();
                }
                else
                {
                    MessageBox.Show("新增[" + CEC.EmployeeID + "-" + CEC.CNAME +
                        "]職員資料失敗", "新增職員資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("對不起，資料庫已存在[ " + CEC.EmployeeID + "-" + CEC.CNAME +
                      " ]職員資料!!(資料重複)", "資料新增");
            }



        }

        #endregion

        //更新
        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行職員[" + txtEmployeeID.Text + "-" + txtCNAME.Text + "]更新動作?\r\n";

            DialogResult DR;
            DR = MessageBox.Show(Msg, "更新職員", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunUpdateData();
                }
            }
            else
            {
                MessageBox.Show("取消職員更新動作!!", "更新職員");
            }


        }

        private void RunUpdateData()
        {

            My.MyDatabase MyDb = new My.MyDatabase();
            SIS.Configuration.ClsEmployeeConfig CEC = new Configuration.ClsEmployeeConfig();
            CEC.EmployeeID = txtEmployeeID.Text;
            CEC.CNAME = txtCNAME.Text;
            CEC.ENAME = txtENAME.Text;
            
            CEC.Photos = My.MyMethod.ImageToByte(PicPhotos.Image); 
            CEC.Sex = cboSex.Text;
            CEC.Birthday = dtpBirthday.Value.ToString("yyyy年MM月dd日");
            CEC.BooldType = cboBooldType.Text;
            CEC.ID = mtbID.Text;
            CEC.PresentAddress = txtPresentAddress.Text;
            CEC.Professional = txtProfessional.Text;
            CEC.HireDate = dtpHireDate.Value.ToString("yyyy年MM月dd日");
            CEC.Positions = txtPosition.Text;
            CEC.Background = txtBackground.Text;
            CEC.Phone = mtbPhone.Text;
            CEC.Status = cboStatus.Text;

            SIS.DBClass.DBClassEmployeeInfo DBCEI = new DBClass.DBClassEmployeeInfo();

            if (MyDb.AuthPK(CEC.EmployeeID, "EmployeeID", "EmployeeInfo") == true)
            {
                if (DBCEI.ParameterUpdateData(CEC))
                {
                    MessageBox.Show("更新[" + CEC.EmployeeID + "-" + CEC.CNAME +
                        "]職員資料成功", "更新職員資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDefaultValue();
                }
                else
                {
                    MessageBox.Show("更新[" + CEC.EmployeeID + "-" + CEC.CNAME +
                        "]職員資料失敗", "更新職員資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("對不起，資料庫不存在[ " + CEC.EmployeeID + "-" + CEC.CNAME +
                      " ]職員資料!!(資料不存在)", "資料更新");
            }



        }


        //刪除
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行職員[" + txtEmployeeID.Text + "-" + txtCNAME.Text +  "]刪除動作?\r\n";

            DialogResult DR;
            DR = MessageBox.Show(Msg, "刪除職員", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunDeleteData();
                }
            }
            else
            {
                MessageBox.Show("取消職員刪除動作!!", "刪除職員");
            }
        }

        private void RunDeleteData()
        {

            My.MyDatabase MyDb = new My.MyDatabase();
            SIS.Configuration.ClsEmployeeConfig CEC = new Configuration.ClsEmployeeConfig();
            CEC.EmployeeID = txtEmployeeID.Text;
            CEC.CNAME = txtCNAME.Text;


            SIS.DBClass.DBClassEmployeeInfo DBCEI = new DBClass.DBClassEmployeeInfo();

            if (MyDb.AuthPK(CEC.EmployeeID, "EmployeeID", "EmployeeInfo") == true)
            {
                if (DBCEI.DeleteOneData(CEC.EmployeeID))
                {
                    MessageBox.Show("刪除[" + CEC.EmployeeID + "-" + CEC.CNAME +
                        "]職員資料成功", "刪除職員資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDefaultValue();
                }
                else
                {
                    MessageBox.Show("刪除[" + CEC.EmployeeID + "-" + CEC.CNAME +
                        "]職員資料失敗", "刪除職員資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("對不起，資料庫不存在[ " + CEC.EmployeeID + "-" + CEC.CNAME +
                      " ]職員資料!!(資料重複)", "資料刪除");
            }

        }


        //清除
        private void tsbClear_Click(object sender, EventArgs e)
        {
            ClearField();
            MessageBox.Show("欄位資料清除完畢!!", "清除");
        }

        /// <summary>
        /// 清除欄位資料
        /// </summary>
        private void ClearField()
        {
            this.txtEmployeeID.Text = "";
            this.txtCNAME.Text = "";
            this.txtENAME.Text = "";


            string Path = Application.StartupPath + "\\Photos\\Employee\\" + "NoPicture.bmp";
            Image photo = Image.FromFile(Path);
            PicPhotos.Image = photo;


            this.cboSex.Text = "";
            this.dtpBirthday.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            this.cboBooldType.Text = "";
            this.mtbID.Text = "";
            this.txtPresentAddress.Text = "";
            this.txtProfessional.Text = "";
            this.dtpHireDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            this.txtPosition.Text = "";
            this.txtBackground.Text = "";
            this.mtbPhone.Text = "";
            this.cboStatus.Text = "";
        }

        //離開
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEmployeeMaintain_KeyDown(object sender, KeyEventArgs e)
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
