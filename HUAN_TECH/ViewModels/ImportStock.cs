﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUAN_TECH.ViewModels
{
    public class ImportStock
    {
        public static bool ImportStock_Insert(dbo_ImportStock item)
        {
            string query = "Insert Into [import_stock] ([ImportDate],[CommodityId],[ImportFrom],[ImportQuantity],[ImportPrice],[UserImport]) "+
                "Values ( @ImportDate , @CommodityId , @ImportFrom , @ImportQuantity , @ImportPrice , @UserImport )";
            var parameter = new object?[] {item.ImportDate, item.CommodityId,item.ImportFrom,item.ImportQuantity,item.ImportPrice,item.UserImport };
            var res = DataProvider.Instance.ExecuteNonquery(out string? exception, DataProvider.SERVER.HUANTECH, query, parameter);
            return res > 0;
        }
    }

    public class dbo_ImportStock
    {
        private DateTime? importDate;
        private int? commodityId;
        private string? importFrom;
        private int? importQuantity;
        private decimal? importPrice;
        private int? importStatus;
        private string? userImport;
        private DateTime? timeUpdate;

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
