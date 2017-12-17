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
    public partial class FrmReportForSaleOrders : Form
    {
        public FrmReportForSaleOrders()
        {
            InitializeComponent();
        }
        public string strReport { get; set; }
        private void FrmReportForSaleOrders_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            dtpStartDate.Text = "2014年01月01日";
            ReloadReport("rptSaleOrders", "%", "2014年01月01日", DateTime.Now.ToString("yyyy年MM月dd日"));
        }

        private void ReloadReport(string ReportName, string searchKeyValue , string StartDate , string EndDate)
        {

            try
            {
                ReportDataSource rptDataSource = new ReportDataSource();
                ReportParameter[] Parms = new ReportParameter[4];

                Parms[0] = new ReportParameter("rpCompanyName", My.MyGlobal.INICompanyName); //需在Report參數新增CompanyName
                Parms[1] = new ReportParameter("rpCompanyAddress", My.MyGlobal.INICompanyAddress);
                Parms[2] = new ReportParameter("rpCompanyTelephone", My.MyGlobal.INICompanyTelephone);
                Parms[3] = new ReportParameter("rpBusinessTax", My.MyGlobal.INIBusinessTaxShipTaxRate);

                strReport = ReportName;
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Reports\\" + strReport + ".rdlc";
                reportViewer1.LocalReport.SetParameters(Parms); //需定義於ReportPath之後
                reportViewer1.LocalReport.DataSources.Clear();


                SIS.DataSets.DataSetSaleOrders ds = new SIS.DataSets.DataSetSaleOrders();
                SIS.DataSets.DataSetSaleOrdersTableAdapters.ShipDetailsTableAdapter da = new SIS.DataSets.DataSetSaleOrdersTableAdapters.ShipDetailsTableAdapter();
                da.Fill(ds.ShipDetails, searchKeyValue, StartDate , EndDate);
                rptDataSource = new ReportDataSource("DataSetSaleOrders", ds.Tables["ShipDetails"]);

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
            string StartDate = dtpStartDate.Value.ToString("yyyy年MM月dd日");
            string EndDate = dtpEndDate.Value.ToString("yyyy年MM月dd日");
            ReloadReport("rptSaleOrders", SearchKey, StartDate, EndDate);
        }

        //離開
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmReportForSaleOrders_KeyPress(object sender, KeyPressEventArgs e)
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
