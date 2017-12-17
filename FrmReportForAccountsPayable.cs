using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;//new

namespace SIS
{
    public partial class FrmReportForAccountsPayable : Form
    {
        public FrmReportForAccountsPayable()
        {
            InitializeComponent();
        }
        public string strReport { get; set; }
        private void FrmReportForAccountsPayable_Load(object sender, EventArgs e)
        {
            LoadAccountsPayableData(); //生成應付帳款資料
            this.KeyPreview = true;
            ReloadReport("rptAccountsPayable", "%");
        }

        private void ReloadReport(string ReportName, string searchKeyValue)
        {

            try
            {
                ReportDataSource rptDataSource = new ReportDataSource();
                ReportParameter[] Parms = new ReportParameter[3];

                Parms[0] = new ReportParameter("rpCompanyName", My.MyGlobal.INICompanyName); //需在Report參數新增CompanyName
                Parms[1] = new ReportParameter("rpCompanyAddress", My.MyGlobal.INICompanyAddress);
                Parms[2] = new ReportParameter("rpCompanyTelephone", My.MyGlobal.INICompanyTelephone);

                strReport = ReportName;
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Reports\\" + strReport + ".rdlc";
                reportViewer1.LocalReport.SetParameters(Parms); //需定義於ReportPath之後
                reportViewer1.LocalReport.DataSources.Clear();


                SIS.DataSets.DataSetAccountsPayable ds = new SIS.DataSets.DataSetAccountsPayable();
                SIS.DataSets.DataSetAccountsPayableTableAdapters.AccountsPayableTableAdapter da = new SIS.DataSets.DataSetAccountsPayableTableAdapters.AccountsPayableTableAdapter();
                da.Fill(ds.AccountsPayable, searchKeyValue, searchKeyValue);
                rptDataSource = new ReportDataSource("DataSetAccountsPayable", ds.Tables["AccountsPayable"]);

                if (this.reportViewer1.LocalReport.DataSources.Count > 0)
                {
                    this.reportViewer1.LocalReport.DataSources.RemoveAt(0);
                }

                this.reportViewer1.LocalReport.DataSources.Add(rptDataSource);

                this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal); 

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            this.reportViewer1.RefreshReport();
        }

        //查詢
        private void btnQuery_Click(object sender, EventArgs e)
        {
            string SearchKey = "%" + txtSearchKeyword.Text + "%";
            ReloadReport("rptAccountsPayable", SearchKey);
        }

        /// <summary>
        /// 生成應付帳款資料
        /// </summary>
        private void LoadAccountsPayableData()
        {
            try
            {
                SIS.DBClass.DBClassAccountsPayable DBCAP = new DBClass.DBClassAccountsPayable();
                DBCAP.DeleteAllData();

                string SQLCommand = "DECLARE @tempData TABLE( " +
                               "[StockID] [nvarchar](20) NULL, " +
                               "[ManufacturerID] [nvarchar](20) NULL, " +
                               "[CNAME] [nvarchar](20) NULL, " +
                               "[UnpaidAmount] [int] NULL, " +
                               "[ReversalAmount] [int] NULL) " +
                               "INSERT INTO @tempData " +
                               "SELECT  StockMaster.StockID,StockMaster.ManufacturerID, " +
                               "ManufacturerInfo.CNAME , ResultUnpaidAmout = case  " +
                               "When RMAMaster.UnpaidAmount is null Then StockMaster.UnpaidAmount " +
                               "Else " +
                               "RMAMaster.UnpaidAmount " +
                               "End ,ReversalAmount  = case " +
                               "When Reversal.ReversalAmount is null Then 0 " +
                               "Else " +
                               "Reversal.ReversalAmount " +
                               "End " +
                               "FROM  StockMaster INNER JOIN " +
                              "ManufacturerInfo ON StockMaster.ManufacturerID = ManufacturerInfo.ManufacturerID " +
                              "LEFT JOIN RMAMaster ON StockMaster.StockID = RMAMaster.StockIDOrShipID " +
                              "LEFT JOIN Reversal ON Reversal.StockIDOrShipID = StockMaster.StockID " +
                              "WHERE StockMaster.UnpaidAmount < 0  AND (RMAMaster.UnpaidAmount is null or RMAMaster.UnpaidAmount < 0) " +
                              "Select * , (UnpaidAmount + ReversalAmount) as Surplus From @tempData";

                My.MyDatabase myDB = new My.MyDatabase();
                DataTable dt = myDB.CreateDataTable(SQLCommand, "TempAccountsPayable");
                myDB.BulkCopyToTable(dt, "AccountsPayable");
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤訊息:" + ex.Message.ToString(), "發生例外");
            }
           

        }

        //離開
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmReportForAccountsPayable_KeyPress(object sender, KeyPressEventArgs e)
        {
            //當按下[Enter]鍵時執行登入動作
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnQuery_Click(sender, e);
            }
        }

    }
}
