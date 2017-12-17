using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
namespace SIS
{
    public partial class FrmBasicSetting : Form
    {
        public FrmBasicSetting()
        {
            InitializeComponent();
        }

        private void FrmBasicSetting_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            LoadDefaultValue();
        }
        #region "載入表單預設值"

        /// <summary>
        /// 載入表單預設值
        /// </summary>
        private void LoadDefaultValue()
        {
            if (My.MyGlobal.INIDateFormatYearSet == "103") rdoROC.Checked = true;
            if (My.MyGlobal.INIDateFormatYearSet == "2014") rdoAD.Checked = true;
            if (My.MyGlobal.INIDateFormatYearSet == "14") rdoADShort.Checked = true;

            txtDate.Text = My.MyGlobal.INIDateFormatDateSet;
            txtDateShow.Text = DateTime.Now.ToString(txtDate.Text);
            //reference to LoadSystemINI()
            txtComputeOrIP.Text = My.MyGlobal.INIDatabaseComputeOrIP;
            txtID.Text = My.MyGlobal.INIDatabaseID;
            txtPWD.Text = My.MyGlobal.INIDatabasePassword;
            txtShipTaxRate.Text = My.MyGlobal.INIBusinessTaxShipTaxRate;
            txtStockTaxRate.Text = My.MyGlobal.INIBusinessTaxStockTaxRate;
            cboItemPoint.Text = My.MyGlobal.INIPointSettingItemPoint;
            cboReceiptPoint.Text = My.MyGlobal.INIPointSettingReceiptPoint;
        }

        #endregion

        #region "欄位檢查"

        /// <summary>
        /// 欄位檢查
        /// </summary>
        /// <returns></returns>
        public bool CheckField()
        {
            errorProvider1.Clear();
            if (txtComputeOrIP.Text == "")
            {
                MessageBox.Show(this, "電腦名稱或IP不得為空白", "欄位檢查");
                txtComputeOrIP.Focus();
                errorProvider1.SetError(txtComputeOrIP, "帳號不得為空白");
                return false;
            }

            if (Microsoft.VisualBasic.Information.IsNumeric(txtStockTaxRate.Text)==false)
            {
                MessageBox.Show(this, "進貨稅率須為數字型態", "欄位檢查");
                txtStockTaxRate.Focus();
                errorProvider1.SetError(txtStockTaxRate, "進貨稅率須為數字型態");
                return false;
            }

            return true;

        }

        #endregion


        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (CheckField())
                {
                    string filePath = Application.StartupPath + "\\System.ini";
                    My.MyINI myINI = new My.MyINI(filePath);
                    myINI.setKeyValue("System", "Name", "超級進銷存系統(SIS)");
                    myINI.setKeyValue("System", "Version", "1.0");
                    myINI.setKeyValue("System", "Locale", "ZH-TW");
                    myINI.setKeyValue("System", "Creator", "許清榮(Ryu)");

                    myINI.setKeyValue("Compnay", "Name", "DrMaster");
                    myINI.setKeyValue("Compnay", "Address", "台北縣汐止市新台五路一段112號10樓A棟");
                    myINI.setKeyValue("Compnay", "Telephone", "(02)2696-2869");

                    if (rdoROC.Checked == true)
                    {
                        myINI.setKeyValue("DateFormat", "YearSet", "103");
                        myINI.setKeyValue("DateFormat", "DateSet", "yyy年MM月dd日");
                    }
                    else if (rdoAD.Checked == true)
                    {
                        myINI.setKeyValue("DateFormat", "YearSet", "2014");
                        myINI.setKeyValue("DateFormat", "DateSet", "yyy年MM月dd日");
                    }
                    else if (rdoADShort.Checked == true)
                    {
                        myINI.setKeyValue("DateFormat", "YearSet", "14");
                        myINI.setKeyValue("DateFormat", "DateSet", "yyy年MM月dd日");
                    }

                    myINI.setKeyValue("Database", "ComputeOrIP", txtComputeOrIP.Text);
                    myINI.setKeyValue("Database", "ID", txtID.Text);
                    myINI.setKeyValue("Database", "Password", txtPWD.Text);

                    myINI.setKeyValue("BusinessTax", "StockTaxRate", txtStockTaxRate.Text);
                    myINI.setKeyValue("BusinessTax", "ShipTaxRate", txtShipTaxRate.Text);

                    myINI.setKeyValue("PointSetting", "ItemPoint", cboItemPoint.Text);
                    myINI.setKeyValue("PointSetting", "ReceiptPoint", cboReceiptPoint.Text);

                    MessageBox.Show("完成系統參數儲存動作!!\r\n請重新啟動程式以完成INI設定值套用^_^", "資訊");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("錯誤訊息:" + ex.Message.ToString(), "發生例外");
            }
           

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();
        }

        private void clearField()
        {
            txtDateShow.Text = "";
            txtComputeOrIP.Text = "";
            txtID.Text = "";
            txtPWD.Text = "";
            txtShipTaxRate.Text = "";
            txtStockTaxRate.Text = "";
        }


        //恢復原廠設定值
        private void btnDefault_Click(object sender, EventArgs e)
        {
            LoadDefaultValue();
        }
        //離開
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoROC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoROC.Checked == true)
            {
                txtDate.Text = "yyy年MM月dd日";

                TaiwanCalendar cal = new TaiwanCalendar();   
                int twYear = cal.GetYear(DateTime.Now);
                txtDateShow.Text = String.Format("{0:D3}年{1:D2}月{2:D2}日", twYear, DateTime.Now.Month, DateTime.Now.Day);
            }
        }

        private void rdoAD_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAD.Checked == true)
            {
                txtDate.Text = "yyyy年MM月dd日";
                txtDateShow.Text = DateTime.Now.ToString(txtDate.Text);
            }
        }

        private void rdoADShort_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoADShort.Checked == true)
            {
                txtDate.Text = "yy年MM月dd日";
                txtDateShow.Text = DateTime.Now.ToString(txtDate.Text);
            }
        }

        private void FrmBasicSetting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                e.Handled = true;
                this.Close();
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnClear_Click(sender, e);
            }
        }
    }
}
