using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Configuration
{
    class ClsItemsConfig
    {
        /// <summary>
        /// 商品編號
        /// </summary>
        public string ItemsID { get; set; }
        /// <summary>
        /// 商品名稱
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 商品類別
        /// </summary>
        public string ItemsType { get; set; }
        /// <summary>
        /// 商品規格
        /// </summary>
        public string Specifications { get; set; }
        /// <summary>
        /// 基本單位-個 台 張 本 片 箱 對 瓶
        /// </summary>
        public string ItemsUnit { get; set; }
        /// <summary>
        /// 出貨價格(售價)
        /// </summary>
        public int SellingPrice { get; set; }
        /// <summary>
        /// 進貨價格
        /// </summary>
        public int CostPrice { get; set; }
        /// <summary>
        /// 建議售價
        /// </summary>
        public int MSRP { get; set; }
        /// <summary>
        /// 進貨廠商編號
        /// </summary>
        public string ManufacturerID { get; set; }
        /// <summary>
        /// 庫存量
        /// </summary>
        public int Inventory { get; set; }
        /// <summary>
        /// 安全庫存量
        /// </summary>
        public int SafeInventory { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Notes { get; set; }
    }
}
