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
    public partial class FrmReportPrint : Form
    {
        public FrmReportPrint()
        {
            InitializeComponent();
        }
        private string searchKeyName;
        private string searchKeyValue;
        private string runReportName;
        public FrmReportPrint(string keyName , string keyValue , string reportName)
        {
            InitializeComponent();
            this.searchKeyName  = keyName;
            this.searchKeyValue = keyValue;
            this.runReportName = reportName;
        }

        public string strReport { get; set; }
        private void FrmReportPrint_Load(object sender, EventArgs e)
        {
            ReloadReport(runReportName);
        }

        private void ReloadReport(string ReportName)
        {
            ReportDataSource rptDataSource = new ReportDataSource();
            strReport = ReportName;

            ReportParameter[] Parms = new ReportParameter[3];
             
            Parms[0] = new ReportParameter("rpCompanyName", My.MyGlobal.INICompanyName); //需在Report參數新增CompanyName
            Parms[1] = new ReportParameter("rpCompanyAddress", My.MyGlobal.INICompanyAddress);
            Parms[2] = new ReportParameter("rpCompanyTelephone", My.MyGlobal.INICompanyTelephone);

            try
            {
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Reports\\" + strReport + ".rdlc";
                reportViewer1.LocalReport.SetParameters(Parms); //需定義於ReportPath之後
                reportViewer1.LocalReport.DataSources.Clear();

                switch (strReport)
                {
                    case "rptPurchaseMaster":
                        SIS.DataSets.DataSetPurchaseMaster ds = new SIS.DataSets.DataSetPurchaseMaster();
                        SIS.DataSets.DataSetPurchaseMasterTableAdapters.PurchaseMasterTableAdapter da = new DataSets.DataSetPurchaseMasterTableAdapters.PurchaseMasterTableAdapter();
                        reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SetSubDataSource);
                        da.Fill(ds.PurchaseMaster, searchKeyValue);
                        rptDataSource = new ReportDataSource("DataSetPurchase", ds.Tables["PurchaseMaster"]);
                        break;
                    case "rptStockMaster":
                        SIS.DataSets.DataSetStockMaster ds2 = new SIS.DataSets.DataSetStockMaster();
                        SIS.DataSets.DataSetStockMasterTableAdapters.StockMasterTableAdapter da2 = new DataSets.DataSetStockMasterTableAdapters.StockMasterTableAdapter();
                        reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SetSubDataSource2);
                        da2.Fill(ds2.StockMaster , searchKeyValue);
                        rptDataSource = new ReportDataSource("DataSetStock", ds2.Tables["StockMaster"]);
                        break;
                    case "rptShipMaster":
                        SIS.DataSets.DataSetShipMaster ds3 = new SIS.DataSets.DataSetShipMaster();
                        SIS.DataSets.DataSetShipMasterTableAdapters.ShipMasterTableAdapter da3 = new DataSets.DataSetShipMasterTableAdapters.ShipMasterTableAdapter();
                        reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SetSubDataSource3);
                        da3.Fill(ds3.ShipMaster, searchKeyValue);
                        rptDataSource = new ReportDataSource("DataSetShip", ds3.Tables["ShipMaster"]);
                        break;
                    case "rptRMAMaster":
                        SIS.DataSets.DataSetRMAMaster ds4 = new SIS.DataSets.DataSetRMAMaster();
                        SIS.DataSets.DataSetRMAMasterTableAdapters.RMAMasterTableAdapter da4 = new DataSets.DataSetRMAMasterTableAdapters.RMAMasterTableAdapter();
                        reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SetSubDataSource4);
                        da4.Fill(ds4.RMAMaster, searchKeyValue);
                        rptDataSource = new ReportDataSource("DataSetRMA", ds4.Tables["RMAMaster"]);
                        break;
                    case "rptTakeStockMaster":
                        SIS.DataSets.DataSetTakeStockMaster ds5 = new SIS.DataSets.DataSetTakeStockMaster();
                        SIS.DataSets.DataSetTakeStockMasterTableAdapters.TakeStockMasterTableAdapter da5 = new DataSets.DataSetTakeStockMasterTableAdapters.TakeStockMasterTableAdapter();
                        reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SetSubDataSource5);
                        da5.Fill(ds5.TakeStockMaster, searchKeyValue);
                        rptDataSource = new ReportDataSource("DataSetTakeStock", ds5.Tables["TakeStockMaster"]);
                        break;
                    case "rptReversal":
                        SIS.DataSets.DataSetReversal ds6 = new SIS.DataSets.DataSetReversal();
                        SIS.DataSets.DataSetReversalTableAdapters.ReversalTableAdapter da6 = new DataSets.DataSetReversalTableAdapters.ReversalTableAdapter();
                        //reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SetSubDataSource5);
                        da6.Fill(ds6.Reversal , searchKeyValue);
                        rptDataSource = new ReportDataSource("DataSetReversal", ds6.Tables["Reversal"]);
                        break;
                }

                if (this.reportViewer1.LocalReport.DataSources.Count > 0)
                {
                    this.reportViewer1.LocalReport.DataSources.RemoveAt(0);
                }

                this.reportViewer1.LocalReport.DataSources.Add(rptDataSource);

                this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            this.reportViewer1.RefreshReport();
        }

        public void SetSubDataSource(object sender, SubreportProcessingEventArgs e)
        {
            SIS.DataSets.DataSetPurchaseDetails ds = new SIS.DataSets.DataSetPurchaseDetails();
            SIS.DataSets.DataSetPurchaseDetailsTableAdapters.PurchaseDetailsTableAdapter da = new SIS.DataSets.DataSetPurchaseDetailsTableAdapters.PurchaseDetailsTableAdapter();
            da.Fill(ds.PurchaseDetails, e.Parameters["rpPurchaseID"].Values[0]);

            e.DataSources.Add(new ReportDataSource("DataSetPurchase", ds.Tables[0]));
        }

        public void SetSubDataSource2(object sender, SubreportProcessingEventArgs e)
        {
            SIS.DataSets.DataSetStockDetails ds = new SIS.DataSets.DataSetStockDetails();
            SIS.DataSets.DataSetStockDetailsTableAdapters.StockDetailsTableAdapter da = new SIS.DataSets.DataSetStockDetailsTableAdapters.StockDetailsTableAdapter();
            da.Fill(ds.StockDetails, e.Parameters["rpStockID"].Values[0]);

            e.DataSources.Add(new ReportDataSource("DataSetStock", ds.Tables[0]));
        }

        public void SetSubDataSource3(object sender, SubreportProcessingEventArgs e)
        {
            SIS.DataSets.DataSetShipDetails ds = new SIS.DataSets.DataSetShipDetails();
            SIS.DataSets.DataSetShipDetailsTableAdapters.ShipDetailsTableAdapter da = new SIS.DataSets.DataSetShipDetailsTableAdapters.ShipDetailsTableAdapter();
            da.Fill(ds.ShipDetails, e.Parameters["rpShipID"].Values[0]);

            e.DataSources.Add(new ReportDataSource("DataSetShip", ds.Tables[0]));
        }

        public void SetSubDataSource4(object sender, SubreportProcessingEventArgs e)
        {
            SIS.DataSets.DataSetRMADetails ds = new SIS.DataSets.DataSetRMADetails();
            SIS.DataSets.DataSetRMADetailsTableAdapters.RMADetailsTableAdapter da = new SIS.DataSets.DataSetRMADetailsTableAdapters.RMADetailsTableAdapter();
            da.Fill(ds.RMADetails, e.Parameters["rpRMAID"].Values[0]);

            e.DataSources.Add(new ReportDataSource("DataSetRMA", ds.Tables[0]));
        }

        public void SetSubDataSource5(object sender, SubreportProcessingEventArgs e)
        {
            SIS.DataSets.DataSetTakeStockDetails ds = new SIS.DataSets.DataSetTakeStockDetails();
            SIS.DataSets.DataSetTakeStockDetailsTableAdapters.TakeStockDetailsTableAdapter da = new SIS.DataSets.DataSetTakeStockDetailsTableAdapters.TakeStockDetailsTableAdapter();
            da.Fill(ds.TakeStockDetails, e.Parameters["rpTakeStockID"].Values[0]);

            e.DataSources.Add(new ReportDataSource("DataSetTakeStock", ds.Tables[0]));
        }


    }
}
