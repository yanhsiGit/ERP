using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Configuration
{
    class ClsOnlineUpgradeSetting
    {
        /// <summary>
        /// 系統名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 系統最新版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 系統語系
        /// </summary>
        public string Locale { get; set; }
        /// <summary>
        /// 系統建立者
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 系統代碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 系統訊息
        /// </summary>
        public string Message { get; set; }
    }
}
