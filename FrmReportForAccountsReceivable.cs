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
    public partial class FrmReportForAccountsReceivable : Form
    {
        public FrmReportForAccountsReceivable()
        {
            InitializeComponent();
        }
        public string strReport { get; set; }
        private void FrmReportForAccountsReceivable_Load(object sender, EventArgs e)
        {
            LoadAccountsReceivableData(); //生成應收帳款資料
            this.KeyPreview = true;
            ReloadReport("rptAccountsReceivable", "%");
        }

        private void LoadAccountsReceivableData()
        {
            try
            {
                SIS.DBClass.DBClassAccountsReceivable DBCAR = new DBClass.DBClassAccountsReceivable();
                DBCAR.DeleteAllData();

                string SQLCommand = "DECLARE @tempData TABLE( " +
                               "[ShipID] [nvarchar](20) NULL, " +
                               "[CustomerID] [nvarchar](20) NULL, " +
                               "[CNAME] [nvarchar](20) NULL, " +
                               "[UnpaidAmount] [int] NULL, " +
                               "[ReversalAmount] [int] NULL) " +
                               "INSERT INTO @tempData " +
                               "SELECT  ShipMaster.ShipID,ShipMaster.CustomerID, " +
                               "CustomerInfo.CNAME , ResultUnpaidAmout = case  " +
                               "When RMAMaster.UnpaidAmount is null Then ShipMaster.UnpaidAmount " +
                               "Else " +
                               "RMAMaster.UnpaidAmount " +
                               "End ,ReversalAmount  = case " +
                               "When Reversal.ReversalAmount is null Then 0 " +
                               "Else " +
                               "Reversal.ReversalAmount " +
                               "End " +
                               "FROM  ShipMaster INNER JOIN " +
                               "CustomerInfo ON ShipMaster.CustomerID = CustomerInfo.CustomerID " +
                               "LEFT JOIN RMAMaster ON ShipMaster.ShipID = RMAMaster.StockIDOrShipID " +
                               "LEFT JOIN Reversal ON Reversal.StockIDOrShipID = ShipMaster.ShipID " +
                               "WHERE ShipMaster.UnpaidAmount < 0  AND (RMAMaster.UnpaidAmount is null or RMAMaster.UnpaidAmount < 0) " +
                              "Select * , (UnpaidAmount + ReversalAmount) as Surplus From @tempData";

                My.MyDatabase myDB = new My.MyDatabase();
                DataTable dt = myDB.CreateDataTable(SQLCommand, "TempAccountsReceivable");
                myDB.BulkCopyToTable(dt, "AccountsReceivable");
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤訊息:" + ex.Message.ToString(), "發生例外");
            }
        }

        //查詢
        private void btnQuery_Click(object sender, EventArgs e)
        {
            string SearchKey = "%" + txtSearchKeyword.Text + "%";
            ReloadReport("rptAccountsReceivable", SearchKey);
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


                SIS.DataSets.DataSetAccountsReceivable ds = new SIS.DataSets.DataSetAccountsReceivable();
                SIS.DataSets.DataSetAccountsReceivableTableAdapters.AccountsReceivableTableAdapter da = new SIS.DataSets.DataSetAccountsReceivableTableAdapters.AccountsReceivableTableAdapter();
                da.Fill(ds.AccountsReceivable, searchKeyValue, searchKeyValue);
                rptDataSource = new ReportDataSource("DataSetAccountsReceivable", ds.Tables["AccountsReceivable"]);

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

        //離開
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
