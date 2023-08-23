using HUAN_TECH.User_Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HUAN_TECH
{
    internal class DisplayUC
    {
        public static UserControl? ControlUC(string? NameUC)
        {
            switch (NameUC)
            {
                case "UC_CommodityGroup":
                    return new UC_CommodityGroup();
                case "UC_Commodity":
                    return new UC_Commodity();
                case "UC_ImportStock":
                    return new UC_ImportStock();
                default:
                    return null;
            }
        }
    }
}
