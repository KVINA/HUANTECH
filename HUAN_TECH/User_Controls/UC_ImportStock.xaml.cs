using HUAN_TECH.View;
using HUAN_TECH.ViewModels;
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
    /// Interaction logic for UC_ImportStock.xaml
    /// </summary>
    public partial class UC_ImportStock : UserControl
    {
        public UC_ImportStock()
        {
            InitializeComponent();
            Load_commondity_group();
            Load_import_stock();
        }
        void Load_import_stock()
        {
            var datetime = string.IsNullOrEmpty(dpk_importdate.Text) ? null : dpk_importdate.SelectedDate;
            var commodity = txt_commodityGroup.Text;
            var data = ImportStock.Table_ImportStack( ImportStock.ImportStatus.Complated, datetime, commodity);
            if (data != null)
            {
                dtg_importstock.ItemsSource = data.DefaultView;
            }
            else
            {
                dtg_importstock.ItemsSource = null;
            }
        }
        void Load_commondity_group()
        {
            var data = CommodityGroup.Table_CommodityGroup();
            if (data != null)
            {
                txt_commodityGroup.ItemsSource = data.DefaultView;
                txt_commodityGroup.DisplayMemberPath = "GroupName";
            }
            else
            {
                txt_commodityGroup.ItemsSource = null;
            }
        }

        private void Event_Import(object sender, RoutedEventArgs e)
        {
            var wd = new ImportStock_Submit();
            wd.ShowDialog();
            Load_import_stock();
        }
    }    
}
