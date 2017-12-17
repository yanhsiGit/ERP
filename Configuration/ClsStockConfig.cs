using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Configuration
{
    class ClsStockConfig
    {

        public List<Items> ItemsCollections;
        /// <summary>
        /// 進貨單號
        /// </summary>
        public string StockID { get; set; }
        /// <summary>
        /// 進貨日期
        /// </summary>
        public string StockDate { get; set; }
        /// <summary>
        /// 稅前總計
        /// </summary>
        public int TotalPreTax { get; set; }
        /// <summary>
        /// 稅額
        /// </summary>
        public int Tax { get; set; }
        /// <summary>
        /// 稅後總計
        /// </summary>
        public int TotalAfterTax { get; set; }
        /// <summary>
        /// 廠商編號
        /// </summary>
        public string ManufacturerID { get; set; }
        /// <summary>
        /// 進貨稅率-營業稅率
        /// </summary>
        public int BusinessTaxStockTaxRate { get; set; }
        /// <summary>
        /// 已付金額
        /// </summary>
        public int AmountPaid { get; set; }
        /// <summary>
        /// 未付金額
        /// </summary>
        public int UnpaidAmount { get; set; }
        /// <summary>
        /// 進貨人員
        /// </summary>
        public string StockStaff { get; set; }
        /// <summary>
        /// 付款方式-線上刷卡 , 傳真刷卡 , 銀行匯款 , ATM轉帳 , 月結 , 現金支付
        /// </summary>
        public string PaymentType { get; set; }
        /// <summary>
        /// 進貨明細
        /// </summary>
        public Items[] StockItems { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Notes { get; set; }


    }
}
