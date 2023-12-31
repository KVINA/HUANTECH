﻿using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HUAN_TECH.ViewModels
{
    public class ImportStock
    {
        public enum ImportStatus
        {
            WaitImport = 0,
            Complated = 1
        }
        public static DataTable? Table_ImportStack(ImportStatus status, DateTime? ImportDate = null, string? CommodityName = null)
        {
            int? importStatus;
            switch (status)
            {
                case ImportStatus.WaitImport:
                    importStatus = 0;
                    break;
                case ImportStatus.Complated:
                    importStatus = 1;
                    break;
                default:
                    importStatus = null;
                    break;
            }

            if (importStatus != null)
            {
                string query = "SELECT [SerialID],[ImportDate],[GroupName],[CommodityName],[ImportFrom]," +
                "[ImportQuantity],[ImportPrice],[ImportStatus],[UserImport],A.[TimeUpdate]" +
                "FROM [HUANTECH].[dbo].[import_stock] As A  " +
                "Inner Join commodity As B On A.CommodityId = B.CommodityId " +
                "Inner Join commodity_group As C On B.GroupId = C.GroupId " +
                $"Where [ImportStatus] = {importStatus} ";

                if (ImportDate != null && ImportDate is DateTime date)
                {
                    query += $"And [ImportDate] = '{date.ToString("yyyy-MM-dd")}' ";
                }

                if (!string.IsNullOrEmpty(CommodityName))
                {
                    query += $"And [CommodityName] = '{CommodityName}' ";
                }

                var parameter = new object?[] { importStatus };
                var data = DataProvider.Instance.ExecuteQuery(out string? exception, DataProvider.SERVER.HUANTECH, query, new object?[] { importStatus });
                return data;
            }
            else
            {
                return null;
            }
        }
        public static bool ImportStock_Insert(dbo_ImportStock item)
        {
            string query = "Insert Into [import_stock] ([ImportDate],[CommodityId],[ImportFrom],[ImportQuantity],[ImportPrice],[UserImport]) " +
                "Values ( @ImportDate , @CommodityId , @ImportFrom , @ImportQuantity , @ImportPrice , @UserImport )";
            var parameter = new object?[] { item.ImportDate, item.CommodityId, item.ImportFrom, item.ImportQuantity, item.ImportPrice, item.UserImport };
            var res = DataProvider.Instance.ExecuteNonquery(out string? exception, DataProvider.SERVER.HUANTECH, query, parameter);
            return res > 0;
        }

        public static bool ImportStock_Update(dbo_ImportStock item)
        {
            string query = "Update [import_stock] Set [ImportDate] = @ImportDate ,[CommodityId] = @CommodityId ,[ImportFrom] = @ImportFrom " +
                ",[ImportQuantity] = @ImportQuantity ,[ImportPrice] = @ImportPrice ,[UserImport] = @UserImport " +
                "Where [SerialID] = @SerialID ";
            var parameter = new object?[] { item.ImportDate, item.CommodityId, item.ImportFrom, item.ImportQuantity, item.ImportPrice, item.UserImport, item.SerialID };

            var res = DataProvider.Instance.ExecuteNonquery(out string? exception, DataProvider.SERVER.HUANTECH, query, parameter);
            return res > 0;
        }
    }

    public class dbo_ImportStock
    {
        private int? serialID;
        private DateTime? importDate;
        private int? commodityId;
        private string? importFrom;
        private int? importQuantity;
        private decimal? importPrice;
        private int? importStatus;
        private string? userImport;
        private DateTime? timeUpdate;

        public int? SerialID { get => serialID; set => serialID = value; }
        public DateTime? ImportDate { get => importDate; set => importDate = value; }
        public int? CommodityId { get => commodityId; set => commodityId = value; }
        public string? ImportFrom { get => importFrom; set => importFrom = value; }
        public int? ImportQuantity { get => importQuantity; set => importQuantity = value; }
        public decimal? ImportPrice { get => importPrice; set => importPrice = value; }
        public int? ImportStatus { get => importStatus; set => importStatus = value; }
        public string? UserImport { get => userImport; set => userImport = value; }
        public DateTime? TimeUpdate { get => timeUpdate; set => timeUpdate = value; }
    }
}
