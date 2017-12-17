using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Configuration
{
    class ClsReversalConfig
    {
        /// <summary>
        /// 沖銷單號
        /// </summary>
        public string ReversalID { get; set; }
        /// <summary>
        /// 沖銷日期
        /// </summary>
        public string ReversalDate { get; set; }
        /// <summary>
        /// 沖銷人員
        /// </summary>
        public string ReversalStaff { get; set; }
        /// <summary>
        /// 沖銷類型
        /// </summary>
        public string ReversalType { get; set; }
        /// <summary>
        /// 客戶或廠商編號
        /// </summary>
        public string CustomerOrManufacturer { get; set; }
        /// <summary>
        /// 進出貨單號
        /// </summary>
        public string StockIDOrShipID { get; set; }
        /// <summary>
        /// 支付金額，分為應收金額或應付金額
        /// </summary>
        public int PaymentAmount { get; set; }
        /// <summary>
        /// 沖銷金額
        /// </summary>
        public int ReversalAmount { get; set; }
        /// <summary>
        /// 是否沖銷
        /// </summary>
        public bool IsReversal { get; set; }
        /// <summary>
        /// 付款方式-線上刷卡 , 傳真刷卡 , 銀行匯款 , ATM轉帳 , 月結 , 現金支付
        /// </summary>
        public string PaymentType { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Notes { get; set; }
    }
}
