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
            this.Tag = null;
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
        private void Event_UpdateStock(object sender, RoutedEventArgs e)
        {
            var qs = MessageBox.Show($"Nhấn YES để đồng bộ dữ liệu kho.{Environment.NewLine}Chú ý: Khi đồng bộ dữ liệu sẽ không thể thay đổi thông tin.{Environment.NewLine}Hãy xác nhận kỹ trước khi đồng bộ.","Thông báo",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (qs == MessageBoxResult.Yes)
            {

            }
        
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            EmptyEnterValue();            
            btn_add.IsEnabled = true;            
        }

        private void Event_GetDataSubmit(object sender, RoutedEventArgs e)
        {
            if (dtg_waitImport.SelectedItem is DataRowView rowView)
            {
                this.Tag = rowView.Row["SerialID"];
                dpk_importDate.SelectedDate = (DateTime)rowView.Row["ImportDate"];
                txt_commodityGroup.Text = rowView.Row["GroupName"].ToString();
                txt_commodityName.Text = rowView.Row["CommodityName"].ToString();
                txt_importFrom.Text = rowView.Row["ImportFrom"].ToString();
                txt_importQuantity.Text = rowView.Row["ImportQuantity"].ToString();
                txt_importPrice.Text = rowView.Row["ImportPrice"].ToString();
                btn_add.IsEnabled = false;
            }
        }

        private void Event_Edit(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.IsEnabled)
            {
                if (IsCheckEnterValue())
                {
                    if (txt_commodityGroup.SelectedItem is DataRowView rowView)
                    {
                        int GroupId = (int)rowView.Row["GroupId"];
                        var CommodityName = txt_commodityName.Text.Trim();
                        int? CommodityID = Commodity.Get_CommodityID(CommodityName, GroupId);
                        if (CommodityID != null)
                        {
                            if (ServiceProvider.Account != null)
                            {
                                
                                if (this.Tag != null)
                                {
                                    var item = new dbo_ImportStock();
                                    item.SerialID = (int)this.Tag;
                                    item.ImportDate = dpk_importDate.SelectedDate;
                                    item.CommodityId = CommodityID;
                                    item.ImportFrom = txt_importFrom.Text.Trim();
                                    item.ImportQuantity = int.Parse(txt_importQuantity.Text.Trim());
                                    item.ImportPrice = decimal.Parse(txt_importPrice.Text.Trim());
                                    item.UserImport = ServiceProvider.Account.Username;
                                    var res = ImportStock.ImportStock_Update(item);
                                    if (res)
                                    {
                                        MessageBox.Show("Thành công sửa thông tin.");
                                        Load_WaitImportStock();
                                        EmptyEnterValue();
                                        btn_add.IsEnabled = true;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Không xác định được SerialID cần sửa: this.Tag is NULL");
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
        }
    }
}
