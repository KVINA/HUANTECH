using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUAN_TECH.ViewModels
{
    class ExportStock
    {
    }

    class dbo_ExportStock
    {
        private int exportId;
        private int billId;
        private int commodityId;
        private decimal unitPrice;
        private int quantity;
        private decimal totalCost;
        private string? note;
        public int ExportId { get => exportId; set => exportId = value; }
        public int BillId { get => billId; set => billId = value; }
        public int CommodityId { get => commodityId; set => commodityId = value; }
        public decimal UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public decimal TotalCost { get => totalCost; set => totalCost = value; }
        public string? Note { get => note; set => note = value; }
    }
}
