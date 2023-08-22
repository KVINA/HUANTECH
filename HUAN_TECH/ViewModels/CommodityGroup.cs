using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUAN_TECH.ViewModels
{
    class CommodityGroup
    {
        public static DataTable? Table_CommodityGroup()
        {
            string query = "Select * From commodity_group";
            var data = DataProvider.Instance.ExecuteQuery(out string? ex, DataProvider.SERVER.HUANTECH, query);
            return data;
        }
    }
}
