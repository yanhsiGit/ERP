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
    public partial class FrmReportForManufacturer : Form
    {
        public FrmReportForManufacturer()
        {
            InitializeComponent();
        }
        public string strReport { get; set; }
        private void FrmReportForManufacturer_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            ReloadReport("rptManufacturer", "%");
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
                reportViewer1.LocalReport.EnableHyperlinks = true;
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Reports\\" + strReport + ".rdlc";
                reportViewer1.LocalReport.SetParameters(Parms); //需定義於ReportPath之後
                reportViewer1.LocalReport.DataSources.Clear();


                SIS.DataSets.DataSetManufacturer ds = new SIS.DataSets.DataSetManufacturer();
                SIS.DataSets.DataSetManufacturerTableAdapters.ManufacturerInfoTableAdapter da = new SIS.DataSets.DataSetManufacturerTableAdapters.ManufacturerInfoTableAdapter();
                da.Fill(ds.ManufacturerInfo, searchKeyValue, searchKeyValue, searchKeyValue);
                rptDataSource = new ReportDataSource("DataSetManufacturer", ds.Tables["ManufacturerInfo"]);

                if (this.reportViewer1.LocalReport.DataSources.Count > 0)
                {
                    this.reportViewer1.LocalReport.DataSources.RemoveAt(0);
                }

                this.reportViewer1.LocalReport.DataSources.Add(rptDataSource);

                this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal); //設定Normal才能啟用URL Hyperlink功能

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
            ReloadReport("rptManufacturer", SearchKey);
        }

        //離開
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmReportForManufacturer_KeyPress(object sender, KeyPressEventArgs e)
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
