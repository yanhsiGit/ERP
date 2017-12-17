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

namespace SIS
{
    public partial class FrmCustomerMaintain : Form
    {
        public FrmCustomerMaintain()
        {
            InitializeComponent();
        }
        public string ApplicationStartupPath;
        public string PreviousPhotoPath;
        private object syncRoot = new Object();
        private void FrmCustomerMaintain_Load(object sender, EventArgs e)
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
            string SQLCommand = "Select * from CustomerInfo order by CustomerID ";
            My.MyDatabase MyDb = new My.MyDatabase();

            DataView DV = MyDb.CreateDataView(SQLCommand, "CustomerInfo");
            this.dgvCustomerInfo.DataSource = DV;

            //dataGridView表頭名稱中文化
            dgvCustomerInfo.Columns[0].HeaderText = "客戶編號";
            dgvCustomerInfo.Columns[1].HeaderText = "中文名稱";
            dgvCustomerInfo.Columns[2].HeaderText = "英文名稱";
            dgvCustomerInfo.Columns[3].HeaderText = "相片";
            dgvCustomerInfo.Columns[4].HeaderText = "生日";
            dgvCustomerInfo.Columns[5].HeaderText = "客戶類型";
            dgvCustomerInfo.Columns[6].HeaderText = "客戶電話";
            dgvCustomerInfo.Columns[7].HeaderText = "客戶手機";
            dgvCustomerInfo.Columns[8].HeaderText = "客戶傳真";
            dgvCustomerInfo.Columns[9].HeaderText = "客戶地址";
            dgvCustomerInfo.Columns[10].HeaderText = "備註";

            tsslDataCount.Text = DV.Count.ToString();

            //凍結 中文名稱 欄位
            this.dgvCustomerInfo.Columns["CNAME"].Frozen = true;

            //設定點選任一儲存格變選取所屬資料列的所有資料
            this.dgvCustomerInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //替代資料列樣式 
            this.dgvCustomerInfo.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dgvCustomerInfo.AlternatingRowsDefaultCellStyle.BackColor = Color.Ivory;

            //自動調整資料列與資料行的高度與寬度
            this.dgvCustomerInfo.AutoResizeColumns();
            //this.dgvCustomerInfo.AutoResizeRows();

            //防止在 DataGridView 控制項中新增和刪除資料列 
            this.dgvCustomerInfo.AllowUserToAddRows = false;
            this.dgvCustomerInfo.AllowUserToDeleteRows = false;

            toolTip1.SetToolTip(txtCustomerID, "請輸入[客戶編號]!");
            toolTip1.SetToolTip(txtCNAME, "請輸入客戶[中文名稱]!");
            tsbAddNew.ToolTipText = "按下[新增]鈕,以進行客戶新增動作!";
            tsbUpdate.ToolTipText = "按下[更改]鈕,以進行客戶更改動作!";
            tsbDelete.ToolTipText = "按下[刪除]鈕,以進行客戶刪除動作!";
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
            string CustomerID = this.txtCustomerID.Text;

            //將圖片檔案轉換成二進位資料
            byte[] Photos = My.MyFileIO.FileToByteArray(FilePath);
            arrList.Insert(0, CustomerID);
            //職員編號
            arrList.Insert(1, Photos);
            //相片

            SIS.DBClass.DBClassCustomerInfo DBCCustomerInfo = new DBClass.DBClassCustomerInfo();
            My.MyDatabase myDB = new My.MyDatabase();

            if (myDB.AuthPK(CustomerID, "CustomerID", "CustomerInfo") == true)
            {
                if (DBCCustomerInfo.ParameterUpdateData(arrList))
                {
                    MessageBox.Show("更新" + CustomerID + "- 圖片資料成功", "更新客戶資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDefaultValue();
                }
                else
                {
                    MessageBox.Show("更新" + CustomerID + "-圖片資料失敗", "更新客戶資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("對不起，資料庫不存在 " + CustomerID + "-客戶資料!!", "圖片資料無法更新");
                return;
            }
        }

        private void DeletePhotoTempFile()
        {
            try
            {
                string DirPath = Application.StartupPath + "\\Photos\\Customer";
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
            string Msg = "是否要進行客戶[" + txtCustomerID.Text + "-" + txtCNAME.Text + "]新增動作?\r\n";


            DialogResult DR;
            DR = MessageBox.Show(Msg, "新增客戶", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunInsertData();
                }
            }
            else
            {
                MessageBox.Show("取消客戶新增動作!!", "新增客戶");
            }
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行客戶[" + txtCustomerID.Text + "-" + txtCNAME.Text + "]更新動作?\r\n";

            DialogResult DR;
            DR = MessageBox.Show(Msg, "更新客戶", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunUpdateData();
                }
            }
            else
            {
                MessageBox.Show("取消客戶更新動作!!", "更新客戶");
            }
        }
        //刪除
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string Msg = "是否要進行客戶[" + txtCustomerID.Text + "-" + txtCNAME.Text + "]刪除動作?\r\n";

            DialogResult DR;
            DR = MessageBox.Show(Msg, "刪除客戶", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DR == DialogResult.Yes)
            {
                if (CheckField())
                {
                    RunDeleteData();
                }
            }
            else
            {
                MessageBox.Show("取消客戶刪除動作!!", "刪除客戶");
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

        private void dgvCustomerInfo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.txtCustomerID.Text = dgvCustomerInfo[0, e.RowIndex].Value.ToString();
            this.txtCNAME.Text = dgvCustomerInfo[1, e.RowIndex].Value.ToString();
            this.txtENAME.Text = dgvCustomerInfo[2, e.RowIndex].Value.ToString();

            byte[] PicturePhoto = null;
            PicturePhoto = (byte[])dgvCustomerInfo[3, e.RowIndex].Value;
            string TempPath = Application.StartupPath + "\\Photos\\Customer\\" + My.MyMethod.RunID("") + ".tmp";
            string Path = Application.StartupPath + "\\Photos\\Customer\\" + this.txtCustomerID.Text + ".bmp";

            My.MyFileIO.ByteArrayToFile(PicturePhoto, TempPath);

            //My.MyFileIO.FileCopy(TempPath, Path , true);

            Bitmap BP = new Bitmap(TempPath);
            PicPhotos.Image = BP;

            //My.MyFileIO.FileDelete(TempPath);
            //My.MyFileIO.FileCopy(Path, NowPicturePath);

            this.dtpBirthday.Text = dgvCustomerInfo[4, e.RowIndex].Value.ToString();
            this.cboCustomerType.Text = dgvCustomerInfo[5, e.RowIndex].Value.ToString();
            this.mtbPhone.Text = dgvCustomerInfo[6, e.RowIndex].Value.ToString();
            this.mtbMobilePhone.Text = dgvCustomerInfo[7, e.RowIndex].Value.ToString();
            this.mtbFax.Text = dgvCustomerInfo[8, e.RowIndex].Value.ToString();
            this.txtAddress.Text = dgvCustomerInfo[9, e.RowIndex].Value.ToString();
            this.rtbNotes.Text = dgvCustomerInfo[10, e.RowIndex].Value.ToString(); 
        }

        private void PicPhotos_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "BMP File|*.bmp|JPG File|*.JPG|Gif File|*.GIF|All Files|*.*";
            openFileDialog1.Title = "請選擇要匯入的圖片檔案";
            openFileDialog1.InitialDirectory = ApplicationStartupPath + "\\";


            if ((openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK))
            {
                openFileDialog1.InitialDirectory = ApplicationStartupPath + "\\";
                Bitmap BP = (Bitmap)Image.FromFile(openFileDialog1.FileName);

                string Path = ApplicationStartupPath + "\\Photos\\Customer\\" + "NewPicture.bmp";
                string DirPath = ApplicationStartupPath + "\\Photos\\Customer";

                if ((!My.MyFileIO.DirExists(DirPath)))
                {
                    My.MyFileIO.DirCreate(DirPath);
                }

                //My.MyFileIO.FileDelete(Path);
                My.MyFileIO.FileCopy(openFileDialog1.FileName, Path, true);


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
                        MessageBox.Show("取消更新資料庫", "照片更新失敗");
                    }
                }
                else
                {
                    MessageBox.Show("圖片大小建議100*100 ~ 200*200之間,照片變更失敗.");
                }
            }
        }

        #region "欄位驗證"

        /// <summary>
        /// 欄位驗證
        /// </summary>
        /// <returns>輸入欄位型態正確回傳true,否則回傳false</returns>
        public bool CheckField()
        {

            if (txtCustomerID.Text == "")
            {
                MessageBox.Show("[客戶編號]不得為空白!", "欄位檢查", MessageBoxButtons.OK);
                errorProvider1.SetError(txtCustomerID, "[客戶編號]不得為空白!");
                txtCustomerID.Focus();
                return false;
            }

            if (txtCNAME.Text == "")
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
            SIS.Configuration.ClsCustomerConfig CCC = new Configuration.ClsCustomerConfig();
            CCC.CustomerID = txtCustomerID.Text;
            CCC.CNAME = txtCNAME.Text;
            CCC.ENAME = txtENAME.Text;
            string FilePath = Application.StartupPath + "\\Photos\\Customer\\" + "NoPicture.bmp";
            CCC.Photos = My.MyFileIO.FileToByteArray(FilePath);
            CCC.Birthday = dtpBirthday.Value.ToString("yyyy年MM月dd日");
            CCC.CustomerType = cboCustomerType.Text;
            CCC.Phone = mtbPhone.Text;
            CCC.MobilePhone = mtbMobilePhone.Text;
            CCC.Fax = mtbFax.Text;
            CCC.Address = txtAddress.Text;
            CCC.Notes = rtbNotes.Text;

            SIS.DBClass.DBClassCustomerInfo DBCCI = new DBClass.DBClassCustomerInfo();

            if (MyDb.AuthPK(CCC.CustomerID, "CustomerID", "CustomerInfo") == false)
            {
                if (DBCCI.ParameterInsertData(CCC))
                {
                    MessageBox.Show("新增[" + CCC.CustomerID + "-" + CCC.CNAME +
                        "]客戶資料成功", "新增客戶資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDefaultValue();
                }
                else
                {
                    MessageBox.Show("新增[" + CCC.CustomerID + "-" + CCC.CNAME +
                        "]客戶資料失敗", "新增客戶資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("對不起，資料庫已存在[ " + CCC.CustomerID + "-" + CCC.CNAME +
                      " ]客戶資料!!(資料重複)", "資料新增");
            }



        }

        #endregion

        #region "更新資料庫中的某一筆資料"
        private void RunUpdateData()
        {

            My.MyDatabase MyDb = new My.MyDatabase();
            SIS.Configuration.ClsCustomerConfig CCC = new Configuration.ClsCustomerConfig();
            CCC.CustomerID  = txtCustomerID.Text;
            CCC.CNAME = txtCNAME.Text;
            CCC.ENAME = txtENAME.Text;

            CCC.Photos = My.MyMethod.ImageToByte(PicPhotos.Image);

            CCC.Birthday = dtpBirthday.Value.ToString("yyyy年MM月dd日");
            CCC.CustomerType = cboCustomerType.Text;
            CCC.Phone = mtbPhone.Text;
            CCC.MobilePhone = mtbMobilePhone.Text;
            CCC.Fax = mtbFax.Text;
            CCC.Address = txtAddress.Text;
            CCC.Notes = rtbNotes.Text;

            SIS.DBClass.DBClassCustomerInfo DBCCI = new DBClass.DBClassCustomerInfo();

            if (MyDb.AuthPK(CCC.CustomerID, "CustomerID", "CustomerInfo") == true)
            {
                if (DBCCI.ParameterUpdateData(CCC))
                {
                    MessageBox.Show("更新[" + CCC.CustomerID + "-" + CCC.CNAME +
                        "]客戶資料成功", "更新客戶資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDefaultValue();
                }
                else
                {
                    MessageBox.Show("更新[" + CCC.CustomerID + "-" + CCC.CNAME +
                        "]客戶資料失敗", "更新客戶資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("對不起，資料庫不存在[ " + CCC.CustomerID + "-" + CCC.CNAME +
                      " ]客戶資料!!(資料不存在)", "資料更新");
            }



        }

        #endregion 

        #region "刪除資料庫某一筆資料"

        private void RunDeleteData()
        {

            My.MyDatabase MyDb = new My.MyDatabase();
            SIS.Configuration.ClsCustomerConfig CCC = new Configuration.ClsCustomerConfig();
            CCC.CustomerID = txtCustomerID.Text;
            CCC.CNAME = txtCNAME.Text;


            SIS.DBClass.DBClassCustomerInfo DBCCI = new DBClass.DBClassCustomerInfo();

            if (MyDb.AuthPK(CCC.CustomerID, "CustomerID", "CustomerInfo") == true)
            {
                if (DBCCI.DeleteOneData(CCC.CustomerID))
                {
                    MessageBox.Show("刪除[" + CCC.CustomerID + "-" + CCC.CNAME +
                        "]客戶資料成功", "刪除客戶資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDefaultValue();
                }
                else
                {
                    MessageBox.Show("刪除[" + CCC.CustomerID + "-" + CCC.CNAME +
                        "]客戶資料失敗", "刪除客戶資料", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("對不起，資料庫不存在[ " + CCC.CustomerID + "-" + CCC.CNAME +
                      " ]客戶資料!!(資料重複)", "資料刪除");
            }

        }

        #endregion

        /// <summary>
        /// 清除欄位資料
        /// </summary>
        private void ClearField()
        {
            this.txtCustomerID.Text = "";
            this.txtCNAME.Text = "";
            this.txtENAME.Text = "";


            string Path = Application.StartupPath + "\\Photos\\Customer\\" + "NoPicture.bmp";
            Image photo = Image.FromFile(Path);
            PicPhotos.Image = photo;
            
            this.dtpBirthday.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            cboCustomerType.Text = cboCustomerType.Items[0].ToString();
            mtbPhone.Text = "";
            mtbMobilePhone.Text = "";
            mtbFax.Text = "";
            txtAddress.Text = "";
            rtbNotes.Text = "";
        }

        private void FrmCustomerMaintain_KeyDown(object sender, KeyEventArgs e)
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
