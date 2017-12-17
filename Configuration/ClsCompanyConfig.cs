using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Configuration
{
    class ClsCompanyConfig
    {
        /// <summary>
        /// 公司編號
        /// </summary>
        public string CompanyID { get; set; }
        /// <summary>
        /// 中文名稱
        /// </summary>
        public string CNAME { get; set; }
        /// <summary>
        /// 英文名稱
        /// </summary>
        public string ENAME { get; set; }
        /// <summary>
        /// 統一編號
        /// </summary>
        public string UnifiedBusinessNo { get; set; }
        /// <summary>
        /// 公司類型
        /// </summary>
        public string CompanyType { get; set; }
        /// <summary>
        /// 負責人
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// 聯絡人
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// 公司電話
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 聯絡人手機
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 公司傳真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        ///  公司地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 網站
        /// </summary>
        public string WebSite { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Notes { get; set; }
    }
}
