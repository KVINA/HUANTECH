﻿using HUAN_TECH.User_Controls;
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
                default:
                    return null;
            }
        }
    }
}
