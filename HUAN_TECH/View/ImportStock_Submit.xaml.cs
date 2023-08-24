using HUAN_TECH.ViewModels;
using Models;
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
using System.Windows.Shapes;

namespace HUAN_TECH.View
{
    /// <summary>
    /// Interaction logic for ImportStock_Submit.xaml
    /// </summary>
    public partial class ImportStock_Submit : Window
    {
        public ImportStock_Submit()
        {
            InitializeComponent();
            Load_commondity_group();
            Load_WaitImportStock();
        }

        void Load_WaitImportStock()
        {
            var data = ImportStock.Table_ImportStack(ImportStock.ImportStatus.WaitImport);
            if (data!= null)
            {
                dtg_waitImport.ItemsSource = data.DefaultView;
            }
            else
            {
                dtg_waitImport.ItemsSource = null;
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

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            if (IsCheckEnterValue())
            {
                if (txt_commodityGroup.SelectedItem is DataRowView rowView) {
                    int GroupId = (int)rowView.Row["GroupId"];
                    var CommodityName = txt_commodityName.Text.Trim();
                    int? CommodityID = Commodity.Get_CommodityID(CommodityName, GroupId);
                    if (CommodityID != null)
                    {
                        if (ServiceProvider.Account != null)
                        {
                            var item = new dbo_ImportStock();
                            item.ImportDate = dpk_importDate.SelectedDate;
                            item.CommodityId = CommodityID;
                            item.ImportFrom = txt_importFrom.Text.Trim();
                            item.ImportQuantity = int.Parse(txt_importQuantity.Text.Trim());
                            item.ImportPrice = decimal.Parse(txt_importPrice.Text.Trim());
                            item.UserImport = ServiceProvider.Account.Username;
                            var res = ImportStock.ImportStock_Insert(item);
                            if (res)
                            {
                                MessageBox.Show("Nhập kho thành công.");
                                Load_WaitImportStock();
                                EmptyEnterValue();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lỗi không xác định được tài khoản đăng nhập. Vui lòng khởi động lại chương trình");
                            Application.Current.Shutdown();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm chưa được khai báo trong kho sản phẩm. Vui lòng khai báo trước rồi nhập lại.");
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi không xác định được nhóm hàng. Hãy lựa chọn lại nhóm hàng.");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin.");
            }
        }
        void EmptyEnterValue()
        {
            foreach (Control control in grid_body.Children.OfType<Control>())
            {
                if (control is TextBox textbox) textbox.Text = null;
                else if (control is ComboBox combobox) combobox.Text = null;
                else if (control is DatePicker datepicker) datepicker.Text = null;

            }
        }

        bool IsCheckEnterValue()
        {
            foreach (Control control in grid_body.Children.OfType<Control>())
            {
                if (control is TextBox textbox && string.IsNullOrEmpty(textbox.Text)) return false;
                else if (control is ComboBox combobox && string.IsNullOrEmpty(combobox.Text)) return false;
                else if (control is DatePicker datepicker && string.IsNullOrEmpty(datepicker.Text)) return false;
            }
            return true;
        }

        private void txt_commodityGroup_DropDownClosed(object sender, EventArgs e)
        {
            txt_commodityName.ItemsSource = null;
            if (txt_commodityGroup.SelectedItem is DataRowView rowView)
            {
                int GroupID = (int)rowView.Row["GroupID"];
                var data = Commodity.Get_ListCommodityName(GroupID);
                if (data != null)
                {
                    txt_commodityName.ItemsSource = data.DefaultView;
                    txt_commodityName.DisplayMemberPath = "CommodityName";
                }
            }
        }

        private void dtg_waitImport_AutoGeneratedColumns(object sender, EventArgs e)
        {
            if (sender is DataGrid dataGrid)
            {
                foreach (var column in dataGrid.Columns)
                {
                    if (column.Header != null)
                    {
                        switch (column.Header.ToString())
                        {
                            case "ImportDate":
                                if (column is DataGridTextColumn textColumn)
                                {
                                    textColumn.Binding.StringFormat = "yyyy-MM-dd";
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
