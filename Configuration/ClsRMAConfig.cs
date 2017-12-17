using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Configuration
{
    class ClsRMAConfig
    {
        public List<Items> ItemsCollections;
        /// <summary>
        /// 退貨單號
        /// </summary>
        public string RMAID { get; set; }
        /// <summary>
        /// 退貨日期
        /// </summary>
        public string RMADate { get; set; }
        /// <summary>
        /// 退貨類型-Customer , Manufacturer
        /// </summary>
        public string RMAType { get; set; }
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
        /// 進出貨單號
        /// </summary>
        public string StockIDOrShipID { get; set; }
        /// <summary>
        /// 進出貨營業稅率
        /// </summary>
        public int BusinessTax { get; set; }
        /// <summary>
        /// 已付金額
        /// </summary>
        public int AmountPaid { get; set; }
        /// <summary>
        /// 未付金額
        /// </summary>
        public int UnpaidAmount { get; set; }
        /// <summary>
        /// 退貨金額
        /// </summary>
        public int RMAAmount { get; set; }
        /// <summary>
        /// 經辦人員
        /// </summary>
        public string Staff { get; set; }
        /// <summary>
        /// 付款方式-線上刷卡 , 傳真刷卡 , 銀行匯款 , ATM轉帳 , 月結 , 現金支付
        /// </summary>
        public string PaymentType { get; set; }
        /// <summary>
        /// 進貨明細
        /// </summary>
        public Items[] RMAItems { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Notes { get; set; }


    }
}
