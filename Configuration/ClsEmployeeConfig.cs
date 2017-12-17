using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Configuration
{
    class ClsEmployeeConfig
    {
        /// <summary>
        /// 職員編號
        /// </summary>
        public string EmployeeID { get; set; }
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
        /// 性別
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string Birthday { get; set; }
        /// <summary>
        /// 血型
        /// </summary>
        public string BooldType { get; set; }
        /// <summary>
        /// 身分證字號
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 通訊地址
        /// </summary>
        public string PresentAddress { get; set; }
        /// <summary>
        /// 專長
        /// </summary>
        public string Professional { get; set; }
        /// <summary>
        /// 到職日期
        /// </summary>
        public string HireDate { get; set; }
        /// <summary>
        /// 職稱
        /// </summary>
        public string Positions { get; set; }
        /// <summary>
        /// 最高學歷
        /// </summary>
        public string Background { get; set; }
        /// <summary>
        /// 電話
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 在職狀態
        /// </summary>
        public string Status { get; set; }
    }
}
