using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Configuration
{
    class ClsTakeStockConfig
    {
        public List<Items> ItemsCollections;
        /// <summary>
        /// 盤點單號
        /// </summary>
        public string TakeStockID { get; set; }
        /// <summary>
        /// 盤點日期
        /// </summary>
        public string TakeStockDate { get; set; }
        /// <summary>
        /// 盤點人員
        /// </summary>
        public string TakeStockStaff { get; set; }
        /// <summary>
        /// 盤點明細
        /// </summary>
        public TakeStockItem[] TakeStockItems { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Notes { get; set; }
    }
}
