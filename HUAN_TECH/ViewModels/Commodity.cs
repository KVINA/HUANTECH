using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HUAN_TECH.ViewModels
{
    class Commodity
    {
        public static DataTable? Table_Commodity(string? GroupName = null, string? CommodityName = null)
        {
            string query = "SELECT [CommodityId] ,[GroupName],[CommodityName],[DescriptionCommodity],[CellingPrice],[StockQuantity],A.[TimeUpdate] " +
                "FROM [HUANTECH].[dbo].[commodity] as A  INNER JOIN [commodity_group] As B ON A.GroupId = B.GroupId ";
            string condition = "";
            object[] parmeter = new object[0];
            int i = 0;
  
            if (!string.IsNullOrEmpty(GroupName))
            {
                condition = string.IsNullOrEmpty(condition)? "Where [GroupName] = @GroupName " : "And [GroupName] = @GroupName ";
                i++;
                Array.Resize(ref parmeter, i);
                parmeter[i - 1] = GroupName;
            }

            if (!string.IsNullOrEmpty(CommodityName))
            {
                condition += string.IsNullOrEmpty(condition) ? "Where [CommodityName] = @CommodityName " : "And [CommodityName] = @CommodityName ";
                i++;
                Array.Resize(ref parmeter, i);
                parmeter[i - 1] = CommodityName;
            }
            return DataProvider.Instance.ExecuteQuery(out string? ex, DataProvider.SERVER.HUANTECH, query + condition, parmeter);
        }

        public static bool Insert_Commodity(int GroupId, string CommodityName, string DescriptionCommodity, decimal CellingPrice, int StockQuantity)
        {
            string query = "Insert Into [commodity] ([GroupId],[CommodityName],[DescriptionCommodity],[CellingPrice],[StockQuantity]) " +
                                    "Values ( @GroupId , @CommodityName , @DescriptionCommodity , @CellingPrice , @StockQuantity )";
            var parameter = new object[] { GroupId, CommodityName, DescriptionCommodity, CellingPrice, StockQuantity };
            var res = DataProvider.Instance.ExecuteNonquery(out string? ex, DataProvider.SERVER.HUANTECH, query, parameter);
            return res > 0;
        }

        public static bool Update_Commodity(int GroupId, string CommodityName, string DescriptionCommodity, decimal CellingPrice, int StockQuantity, int CommodityId)
        {
            string query = "Update [commodity] Set [GroupId] = @GroupID ,[CommodityName] = @CommodityName ,[DescriptionCommodity] = @DescriptionCommodity ," +
                "[CellingPrice] = @CellingPrice ,[StockQuantity] = @StockQuantity , [TimeUpdate] = GetDate() Where [CommodityId] = @CommodityId ";
            var parameter = new object[] { GroupId, CommodityName, DescriptionCommodity, CellingPrice, StockQuantity, CommodityId };
            var res = DataProvider.Instance.ExecuteNonquery(out string? ex, DataProvider.SERVER.HUANTECH, query, parameter);
            return res > 0;
        }

        public static bool Delete_Commodity( int CommodityId)
        {
            string query = $"Delete From [commodity] Where [CommodityId] = {CommodityId} ";
            var res = DataProvider.Instance.ExecuteNonquery(out string? ex, DataProvider.SERVER.HUANTECH, query);
            return res > 0;
        }
    }
}
