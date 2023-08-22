using HUAN_TECH.View;
using HUAN_TECH.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for UC_Commodity.xaml
    /// </summary>
    public partial class UC_Commodity : UserControl
    {
        public UC_Commodity()
        {
            InitializeComponent();
            Load_commondity_group();
            Load_commondity();
        }

        void Load_commondity()
        {
            string GroupName = txt_commodityGroup.Text.Trim();
            string CommodityName = txt_commodityName.Text.Trim();
            var data = Commodity.Table_Commodity(GroupName, CommodityName);
            if (data != null)
            {
                dtg_commodity.ItemsSource = data.DefaultView;
            }
            else
            {
                dtg_commodity.ItemsSource = null;
            }
        }

        void Load_commondity_group()
        {
            var data = CommodityGroup.Table_CommodityGroup();
            if (data != null )
            {
                txt_commodityGroup.ItemsSource = data.DefaultView;
                txt_commodityGroup.DisplayMemberPath = "GroupName";
            }
            else
            {
                txt_commodityGroup.ItemsSource = null;
            }            
        }

        private void Event_Search(object sender, RoutedEventArgs e)
        {
            Load_commondity();
        }

        private void Event_Add(object sender, RoutedEventArgs e)
        {
            var wd = new Commodity_Submit();
            wd.ShowDialog();
            Load_commondity();
        }

        private void Event_Edit(object sender, RoutedEventArgs e)
        {
            if (dtg_commodity.SelectedItem is DataRowView item)
            {
                var wd = new Commodity_Submit(item);
                wd.ShowDialog();
                Load_commondity();
            }
        }

        private void Event_Delete(object sender, RoutedEventArgs e)
        {
            if (dtg_commodity.SelectedItem is DataRowView item)
            {
                int CommodityID = (int)item.Row["CommodityId"];
                string? CommodityName = item.Row["CommodityName"].ToString();
                var qs = MessageBox.Show($"Bạn muốn xóa sản phẩm {CommodityName} có ID là {CommodityID} không?","Question",MessageBoxButton.YesNo,MessageBoxImage.Question);
                if (qs == MessageBoxResult.Yes)
                {
                    var res = Commodity.Delete_Commodity(CommodityID);
                    if (res)
                    {
                        MessageBox.Show("Hoàn thành xóa sản phẩm");
                        Load_commondity();
                    }
                    else
                    {
                        MessageBox.Show("ERROR: Can't delete.");
                    }
                }
            }                
        }
    }
}
