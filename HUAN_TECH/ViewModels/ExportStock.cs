using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace HUAN_TECH.ViewModels
{
    public class ExportStock
    {
        public static int? GetOrCreateBillId()
        {
            string query = "USP_GetOrCreateBillId";
            var data = DataProvider.Instance.ExecuteScalar(out string? exception, DataProvider.SERVER.HUANTECH, query);
            if (data != null) return (int)data;
            else return null;
        }

        public static DataTable? Get_UseBillId(int billId)
        {
            string query = $"USP_UseBillId {billId}";
            var data = DataProvider.Instance.ExecuteQuery(out string? exception, DataProvider.SERVER.HUANTECH, query);
            return data;
        }

        public static DataTable? Table_BillById(int billId)
        {
            string query = "Select ExportId,A.BillId,A.CommodityId,CommodityName,UnitPrice,Quantity,Unit, (Quantity*UnitPrice) TotalAmount,Note " +
                "From export_stock as A " +
                "Inner join bill as B On A.BillId = B.BillId " +
                "Inner join commodity as C on A.CommodityId = C.CommodityId " +
                $"Where ExportStatus = 0 And B.BillId = {billId};";
            var data = DataProvider.Instance.ExecuteQuery(out string? exception, DataProvider.SERVER.HUANTECH, query);
            return data;
        }

        public static DataTable? Table_Bill(DateTime? billDate, int? billId)
        {
            string query = "Select * From bill Where BillStatus = 1 ";

            if (billDate != null && billDate is DateTime date)
            {
                query += $"And B.BillDate = '{date.ToString("yyyy-MM-dd")}' ";
            }

            if (billId != null)
            {
                query += $"And B.BillId = {billId} ";
            }

            var data = DataProvider.Instance.ExecuteQuery(out string? exception, DataProvider.SERVER.HUANTECH, query);
            return data;
        }

        public static DataTable? Table_ExportSport(DateTime? billDate, int? billId, int ExportSatus = 0, int billStatus = 1)
        {
            string query = "Select ExportId,A.BillId,A.CommodityId,CommodityName,UnitPrice,Quantity,Unit, (Quantity*UnitPrice) TotalAmount,Note " +
               "From export_stock as A " +
               "Inner join bill as B On A.BillId = B.BillId " +
               "Inner join commodity as C on A.CommodityId = C.CommodityId " +
               $"Where ExportStatus = 0 And B.BillStatus = {billStatus} ";
            if (billDate != null && billDate is DateTime date)
            {
                query += $"And B.BillDate = '{date.ToString("yyyy-MM-dd")}' ";
            }

            if (billId != null)
            {
                query += $"And B.BillId = {billId} ";
            }

            var data = DataProvider.Instance.ExecuteQuery(out string? exception, DataProvider.SERVER.HUANTECH, query);
            return data;
        }

        public static bool ExportStock_AddItem(dbo_ExportStock item)
        {
            string query = "EXEC USP_AddCart @BillId , @CommodityId , @UnitPrice , @Quantity , @Note ;";
            var parameter = new object?[] { item.BillId, item.CommodityId, item.UnitPrice, item.Quantity, item.Note };
            var res = DataProvider.Instance.ExecuteNonquery(out string? exception, DataProvider.SERVER.HUANTECH, query, parameter);
            return res > 0;
        }

        public static bool ExportStock_ReturnItem(int exportId, int commodityId,int billId,decimal totalAmount, int quantity)
        {
            string query = $"Update commodity Set StockQuantity = StockQuantity + {quantity} Where CommodityId = {commodityId}; " +
                $"Update export_stock Set [ExportStatus] = 1 Where [ExportId] = {exportId};" +
                $"Update bill Set [TotalCost] = [TotalCost] - {totalAmount} Where [BillId] = {billId};"; ;
            var res = DataProvider.Instance.ExecuteTransection(out string? exception, DataProvider.SERVER.HUANTECH, query);
            return res > 0;
        }
    }

    public class dbo_ExportStock
    {
        private int exportId;
        private int billId;
        private int commodityId;
        private string? commodityName;
        private decimal unitPrice;
        private int quantity;
        private string? unit;
        private decimal totalAmount;
        private string? note;
        public int ExportId { get => exportId; set => exportId = value; }
        public int BillId { get => billId; set => billId = value; }
        public int CommodityId { get => commodityId; set => commodityId = value; }
        public string? CommodityName { get => commodityName; set => commodityName = value; }
        public decimal UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string? Unit { get => unit; set => unit = value; }
        public decimal TotalAmount { get => totalAmount; set => totalAmount = value; }
        public string? Note { get => note; set => note = value; }


        public dbo_ExportStock() { }
        public dbo_ExportStock(DataRow row)
        {
            this.ExportId = (int)row["ExportId"];
            this.BillId = (int)row["BillId"];
            this.CommodityId = (int)row["CommodityId"];
            this.CommodityName = row["CommodityName"].ToString();
            this.UnitPrice = (decimal)row["UnitPrice"];
            this.Quantity = (int)row["Quantity"];
            this.Unit = row["Unit"].ToString();
            this.TotalAmount = (decimal)row["TotalAmount"];
            this.Note = row["Note"].ToString();
        }
    }
}
