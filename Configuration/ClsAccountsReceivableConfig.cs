using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Configuration
{
    class ClsAccountsReceivableConfig
    {
        public List<Items> ItemsCollections;
        /// <summary>
        /// 出貨單號
        /// </summary>
        public string ShipID { get; set; }
        /// <summary>
        /// 客戶編號
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 中文名稱
        /// </summary>
        public string CNAME { get; set; }
        /// <summary>
        /// 未付金額
        /// </summary>
        public int UnpaidAmount { get; set; }
        /// <summary>
        /// 沖銷金額
        /// </summary>
        public int ReversalAmount { get; set; }
        /// <summary>
        /// 結餘
        /// </summary>
        public int Surplus { get; set; }

    }
}
