using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Configuration
{
    class ClsCustomerConfig
    {
        /// <summary>
        /// 客戶編號
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 中文名稱
        /// </summary>
        public string CNAME { get; set; }
        /// <summary>
        /// 英文名稱
        /// </summary>
        public string ENAME { get; set; }
        /// <summary>
        /// 相片
        /// </summary>
        public byte[] Photos { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string Birthday { get; set; }
        /// <summary>
        /// 客戶類型-分為金卡、銀卡、普通
        /// </summary>
        public string CustomerType { get; set; }
        /// <summary>
        /// 客戶電話
        /// </summary>
        public string Phone { get;set;}
        /// <summary>
        /// 客戶手機
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 客戶傳真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        ///  客戶地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Notes { get; set; }
    }
}
