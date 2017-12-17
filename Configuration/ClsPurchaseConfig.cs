using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Configuration
{
    class ClsPurchaseConfig
    {
        public List<Items> ItemsCollections;
        /// <summary>
        /// 採購單號
        /// </summary>
        public string PurchaseID { get; set; }
        /// <summary>
        /// 採購日期
        /// </summary>
        public string PurchaseDate { get; set; }
        /// <summary>
        /// 交貨日期
        /// </summary>
        public string DeliveryDate { get; set; }
        /// <summary>
        /// 廠商編號
        /// </summary>
        public string ManufacturerID { get; set; }
        /// <summary>
        /// 採購人
        /// </summary>
        public string PurchaseStaff { get; set; }
        /// <summary>
        /// 採購人電話
        /// </summary>
        public string PurchasePhone { get; set; }
        /// <summary>
        /// 送貨地址
        /// </summary>
        public string DeliveryAddress { get; set; }
        /// <summary>
        /// 付款方式-線上刷卡 , 傳真刷卡 , 銀行匯款 , ATM轉帳 , 月結 , 現金支付
        /// </summary>
        public string PaymentType { get; set; }
        /// <summary>
        /// 採購明細
        /// </summary>
        public Items[] PurchaseItems { get; set; }
        /// <summary>
        /// 營業稅率-進貨
        /// </summary>
        public int BusinessTaxStockTaxRate { get; set; }
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
        /// 備註
        /// </summary>
        public string Notes { get; set; }

    }

   

}
