using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;//new

namespace SIS.Configuration
{
    class ClsReportConfig
    {
        /// <summary>
        /// 報表編號
        /// </summary>
        public string ReportID { get; set; }
        /// <summary>
        /// 報表名稱
        /// </summary>
        public string ReportName { get; set; }
        /// <summary>
        /// 報表路徑
        /// </summary>
        public string ReportPath { get; set; }
        /// <summary>
        /// 報表參數
        /// </summary>
        public ReportParameter[] Parms { get; set; }
        /// <summary>
        /// 報表資料來源
        /// </summary>
        public ReportDataSource ReportDatasource { get; set; }
        /// <summary>
        /// 報表資料來源名稱
        /// </summary>
        public string ReportDataSourceName { get; set; }
    }
}
