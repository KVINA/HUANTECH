using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HUAN_TECH.User_Controls
{
    /// <summary>
    /// Interaction logic for UC_CommodityGroup.xaml
    /// </summary>
    public partial class UC_CommodityGroup : UserControl
    {
        public UC_CommodityGroup()
        {
            InitializeComponent();
            Load_commodity_group();
        }

        void Load_commodity_group()
        {
            string query = "Select * From commodity_group";
            var data = DataProvider.Instance.ExecuteQuery(out string? ex, DataProvider.SERVER.HUANTECH, query);
            if (data != null) 
            {
                dtg_commodity_group.ItemsSource = data.DefaultView;
            }
            else
            {
                dtg_commodity_group.ItemsSource = null;
            }
        }
    }
}
