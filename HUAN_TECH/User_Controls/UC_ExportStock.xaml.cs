using HUAN_TECH.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for UC_ExportStock.xaml
    /// </summary>
    public partial class UC_ExportStock : UserControl
    {
        private ObservableCollection<dbo_ExportStock> exportStockItems = new ObservableCollection<dbo_ExportStock>();
        public UC_ExportStock()
        {
            InitializeComponent();
            dtg_exportstork.ItemsSource = exportStockItems;
            Load_commondity_group();
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

        private void txt_commodityGroup_DropDownClosed(object sender, EventArgs e)
        {
            txt_commodityName.ItemsSource = null;
            if (txt_commodityGroup.SelectedItem is DataRowView rowView)
            {
                int GroupID = (int)rowView.Row["GroupID"];
                var data = Commodity.Get_ListCommodity(GroupID);
                if (data != null)
                {
                    txt_commodityName.ItemsSource = data.DefaultView;
                    txt_commodityName.DisplayMemberPath = "CommodityName";
                }
            }
        }

        bool IsCheckEnterValue()
        {
            foreach (var item in wpn_body.Children.OfType<Control>())
            {
                if (item is ComboBox combobox)
                {
                    if (string.IsNullOrEmpty(combobox.Text)) return false;
                }
                else if (item is TextBox textbox)
                {
                    if (string.IsNullOrEmpty(textbox.Text)) return false;
                }
            }
            return true;
        }
        private void Event_AddCart(object sender, RoutedEventArgs e)
        {
            if (IsCheckEnterValue())
            {
                if (txt_commodityName.SelectedItem is DataRowView commodity)
                {
                    try
                    {
                        var item = new dbo_ExportStock();
                        item.CommodityId = (int)commodity.Row["CommodityId"];
                        item.CommodityName = commodity.Row["CommodityName"].ToString();
                        item.UnitPrice = decimal.Parse(txt_unitPrice.Text);
                        item.Quantity = int.Parse(txt_quantity.Text);
                        item.TotalCost = item.UnitPrice * item.Quantity;
                        item.Note = "";
                        exportStockItems.Add(item);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Không xác định được thông tin sản phẩm.");
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập đủ thông tin.");
            }
        }

        private void Event_InvoicePrinting(object sender, RoutedEventArgs e)
        {

        }

        private void txt_commodityName_DropDownClosed(object sender, EventArgs e)
        {
            txt_unitPrice.Text = null;
            if (txt_commodityName.SelectedItem is DataRowView commodity)
            {
                txt_unitPrice.Text = commodity.Row["CellingPrice"].ToString();
            }            
        }

        private void Event_RemoveItem(object sender, RoutedEventArgs e)
        {
            if (dtg_exportstork.SelectedItem is dbo_ExportStock item)
            {
                var qs = MessageBox.Show($"Bạn muốn xóa {item.CommodityName} ra khỏi giỏ hàng?","Thông báo",MessageBoxButton.YesNo,MessageBoxImage.Question);
                if (qs == MessageBoxResult.Yes)
                {
                    exportStockItems.Remove(item);
                }
            }
        }
    }
}
