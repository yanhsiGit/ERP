using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data ;

namespace My
{
    class ClsMyLINQ
    {
        public object GetTableRowsData(DataTable dt , string PKName, string PKValue)
        {
            var table = dt.AsEnumerable();

            var tableQuery = from L in table
                             where (L.Field<string>(PKName) == PKValue)
                             select L;

            return tableQuery;
        }
    }
}
