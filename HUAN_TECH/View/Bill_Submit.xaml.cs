using HUAN_TECH.ViewModels;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
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
using System.Windows.Shapes;

namespace HUAN_TECH.View
{
    /// <summary>
    /// Interaction logic for Bill_Submit.xaml
    /// </summary>
    public partial class Bill_Submit : Window
    {
        public Bill_Submit(DataRowView? dataRow = null)
        {
            InitializeComponent();
            if (dataRow is null)
            {

            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            dtg_exportstork.ItemsSource = exportStockItems;
            Load_commondity_group();
        }

        private ObservableCollection<dbo_ExportStock> exportStockItems = new ObservableCollection<dbo_ExportStock>();

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
                        item.Unit = commodity.Row["Unit"].ToString();
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
            int count_commodity = dtg_exportstork.Items.Count;
            if (count_commodity > 0)
            {
                string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bills.xlsx");
                using (var package = new ExcelPackage(new FileInfo(path), true))
                {
                    var sheet = package.Workbook.Worksheets[0];
                    int row_start = 11;//+30 = row_end
                    if (count_commodity > 4)
                    {
                        sheet.InsertRow(12, (count_commodity - 4), 11);
                    }
                    foreach (dbo_ExportStock item in dtg_exportstork.Items)
                    {
                        sheet.Cells[row_start, 1].Value = row_start - 10; //STT
                        sheet.Cells[row_start, 2].Value = item.CommodityName; //Ten thiet bi
                        sheet.Cells[row_start, 3].Value = item.Unit;
                        sheet.Cells[row_start, 4].Value = item.Quantity;
                        sheet.Cells[row_start, 5].Value = item.UnitPrice;
                        sheet.Cells[row_start, 6].Value = item.TotalCost;
                        sheet.Cells[row_start, 7].Value = item.Note;
                        row_start++;
                    }
                    string path_bill = System.IO.Path.Combine("D:\\New folder", $"{DateTime.Now.ToString("yyyyMMdd hhmmssfff")}.xlsx");
                    package.SaveAs(path_bill);
                    package.Dispose();
                }
                MessageBox.Show("Xuất hóa đơn.");
            }



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
                var qs = MessageBox.Show($"Bạn muốn xóa {item.CommodityName} ra khỏi giỏ hàng?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (qs == MessageBoxResult.Yes)
                {
                    exportStockItems.Remove(item);
                }
            }
        }
    }
}
