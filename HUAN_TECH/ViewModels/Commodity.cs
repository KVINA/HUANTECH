using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HUAN_TECH.ViewModels
{
    class Commodity
    {
        public static DataTable? Get_ListCommodityName(int GroupID)
        {
            string query = "Select [CommodityName] From [commodity] Where [GroupId] = @GroupId ";      
            var data = DataProvider.Instance.ExecuteQuery(out string? exception, DataProvider.SERVER.HUANTECH, query , new object[] { GroupID });
            return data;
        }

        public static DataTable? Get_ListCommodity(int GroupID)
        {
            string query = "Select * From [commodity] Where [GroupId] = @GroupId ";
            var data = DataProvider.Instance.ExecuteQuery(out string? exception, DataProvider.SERVER.HUANTECH, query, new object[] { GroupID });
            return data;
        }

        public static int? Get_CommodityID(string CommodityName,int GroupID)
        {
            string query = "Select [CommodityId] From [commodity] Where [CommodityName] = @CommodityName And [GroupId] = @GroupId ";
            var parameter = new object[] { CommodityName, GroupID };
            var data = DataProvider.Instance.ExecuteScalar(out string? exception, DataProvider.SERVER.HUANTECH, query, parameter);
            if (data != null)
            {
                return (int)data;
            }
            else { return null; }
        }
        public static DataTable? Table_Commodity(string? GroupName = null, string? CommodityName = null)
        {
            string query = "SELECT [CommodityId] ,[GroupName],[CommodityName],[DescriptionCommodity],[CellingPrice],[StockQuantity],[Unit],A.[TimeUpdate] " +
                "FROM [HUANTECH].[dbo].[commodity] as A  INNER JOIN [commodity_group] As B ON A.GroupId = B.GroupId ";
            string condition = "";
            object[] parmeter = new object[0];
            int i = 0;

            if (!string.IsNullOrEmpty(GroupName))
            {
                condition = string.IsNullOrEmpty(condition) ? "Where [GroupName] = @GroupName " : "And [GroupName] = @GroupName ";
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

        public static bool Insert_Commodity(int GroupId, string CommodityName, string DescriptionCommodity, decimal CellingPrice, int StockQuantity, string unit)
        {
            string query = "Insert Into [commodity] ([GroupId],[CommodityName],[DescriptionCommodity],[CellingPrice],[StockQuantity],[Unit]) " +
                                    "Values ( @GroupId , @CommodityName , @DescriptionCommodity , @CellingPrice , @StockQuantity , @Unit )";
            var parameter = new object[] { GroupId, CommodityName, DescriptionCommodity, CellingPrice, StockQuantity,unit };
            var res = DataProvider.Instance.ExecuteNonquery(out string? ex, DataProvider.SERVER.HUANTECH, query, parameter);
            return res > 0;
        }

        public static bool Update_Commodity(int GroupId, string CommodityName, string DescriptionCommodity, decimal CellingPrice, int StockQuantity,string unit, int CommodityId)
        {
            string query = "Update [commodity] Set [GroupId] = @GroupID ,[CommodityName] = @CommodityName ,[DescriptionCommodity] = @DescriptionCommodity ," +
                "[CellingPrice] = @CellingPrice ,[StockQuantity] = @StockQuantity ,[Unit] = @Unit , [TimeUpdate] = GetDate() Where [CommodityId] = @CommodityId ";
            var parameter = new object[] { GroupId, CommodityName, DescriptionCommodity, CellingPrice, StockQuantity,unit, CommodityId };
            var res = DataProvider.Instance.ExecuteNonquery(out string? ex, DataProvider.SERVER.HUANTECH, query, parameter);
            return res > 0;
        }

        public static bool Delete_Commodity(int CommodityId)
        {
            string query = $"Delete From [commodity] Where [CommodityId] = {CommodityId} ";
            var res = DataProvider.Instance.ExecuteNonquery(out string? ex, DataProvider.SERVER.HUANTECH, query);
            return res > 0;
        }
    }
}
