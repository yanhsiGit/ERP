using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Configuration
{
    class ClsLoginConfig
    {
        public string UserId { get; set; }
        public string Pwd { get; set; }
        public string RoleId { get; set; }
        public string CreateDate { get; set; }
        public int IsValid { get; set; } //1 -> true , 0 -> false
    }
}
