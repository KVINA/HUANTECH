using HUAN_TECH.ViewModels;
using Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
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
                int? billId = ExportStock.GetOrCreateBillId();
                if (billId is not null)
                {
                    var data = ExportStock.Get_UseBillId((int)billId);
                    if (data != null && data.Rows.Count > 0)
                    {
                        txt_billId.Text = billId.ToString();
                        dpk_billDate.SelectedDate = DateTime.Now;
                        txt_nameCustomer.Text = data.Rows[0]["Customer"].ToString();
                        txt_phone.Text = data.Rows[0]["Phone"].ToString();
                        txt_address.Text = data.Rows[0]["HomeAddress"].ToString();
                        txt_email.Text = data.Rows[0]["Email"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không lấy đươc thông tin hóa đơn.");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Không tạo được mã hóa đơn.");
                    this.Close();
                }
            }
            else
            {
                txt_billId.Text = dataRow.Row["BillId"].ToString();
                if (dataRow.Row["BillDate"] is DateTime date) dpk_billDate.SelectedDate = date;
                txt_nameCustomer.Text = dataRow.Row["Customer"].ToString();
                txt_phone.Text = dataRow.Row["Phone"].ToString();
                txt_address.Text = dataRow.Row["HomeAddress"].ToString();
                txt_email.Text = dataRow.Row["Email"].ToString();
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            Load_commondity_group();
            Load_ExportStock();
        }

        List<dbo_ExportStock> ListExportData(DataTable data)
        {
            var mylist = new List<dbo_ExportStock>();
            foreach (DataRow row in data.Rows)
            {
                mylist.Add(new dbo_ExportStock(row));
            }
            return mylist;
        }
        void Load_ExportStock()
        {
            int billId = int.Parse(txt_billId.Text);
            var data = ExportStock.Table_BillById(billId);
            if (data is not null)
            {
                dtg_exportstork.ItemsSource = ListExportData(data);
            }
            else
            {
                dtg_exportstork.ItemsSource = null;
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
                        item.BillId = int.Parse(txt_billId.Text);
                        item.CommodityId = (int)commodity.Row["CommodityId"];
                        item.CommodityName = commodity.Row["CommodityName"].ToString();
                        item.UnitPrice = decimal.Parse(txt_unitPrice.Text);
                        item.Quantity = int.Parse(txt_quantity.Text);
                        item.Unit = commodity.Row["Unit"].ToString();
                        item.TotalAmount = item.UnitPrice * item.Quantity;
                        item.Note = "-";
                        var res = ExportStock.ExportStock_AddItem(item);
                        if (res)
                        {
                            Load_ExportStock();
                            MessageBox.Show("Thành công thêm vào giỏ hàng.");
                        }
                        else
                            MessageBox.Show("ERROR: Số lượng trong kho không đủ.");
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
                    StringBuilder builder = new StringBuilder();
                    foreach (dbo_ExportStock item in dtg_exportstork.Items)
                    {
                        var note = string.IsNullOrEmpty(item.Note) ? "-" : item.Note.Replace("'", "");
                        string query = $"Update [export_stock] Set Note = N'{note}' Where [ExportId] = {item.ExportId};";

                        builder.Append(query);

                        sheet.Cells[row_start, 1].Value = row_start - 10; //STT
                        sheet.Cells[row_start, 2].Value = item.CommodityName; //Ten thiet bi
                        sheet.Cells[row_start, 3].Value = item.Unit;
                        sheet.Cells[row_start, 4].Value = item.Quantity;
                        sheet.Cells[row_start, 5].Value = item.UnitPrice;
                        sheet.Cells[row_start, 6].Value = item.TotalAmount;
                        sheet.Cells[row_start, 7].Value = item.Note;
                        row_start++;
                    }
                    var res = DataProvider.Instance.ExecuteTransection(out string? exception, DataProvider.SERVER.HUANTECH, builder.ToString());
                    if (res > 0)
                    {
                        string path_bill = System.IO.Path.Combine("D:\\New folder", $"{DateTime.Now.ToString("yyyyMMdd hhmmssfff")}.xlsx");
                        package.SaveAs(path_bill);
                        package.Dispose();
                        MessageBox.Show("Thành công xuất hóa đơn.");
                        try
                        {
                            ProcessStartInfo psi = new ProcessStartInfo
                            {
                                FileName = path_bill,
                                UseShellExecute = true
                            };
                            Process.Start(psi);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"{path_bill}{Environment.NewLine}{ex.Message}");
                        }
                        
                    }
                    else
                    {
                        package.Dispose();
                        MessageBox.Show("Không xuất được bill. Vui lòng thử lại.");
                    }
                    
                }                
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
                    var res = ExportStock.ExportStock_ReturnItem(item.ExportId, item.CommodityId,item.BillId,item.TotalAmount, item.Quantity);
                    if (res)
                    {
                        Load_ExportStock();
                        MessageBox.Show("Hoàn thành xóa khỏi giỏ hàng.");
                    }
                    else
                    {
                        MessageBox.Show("Xóa khỏi giỏ hàng thất bại.");
                    }
                }
            }
        }

        private void Event_ShowEdit(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                switch (btn.Content.ToString())
                {
                    case "Edit":
                        IsEnnableInput(true);
                        btn.Content = "Save";
                        break;
                    case "Save":
                        if (!string.IsNullOrEmpty(dpk_billDate.Text) && dpk_billDate.SelectedDate is DateTime)
                        {
                            if (ServiceProvider.Account != null)
                            {
                                string date = dpk_billDate.SelectedDate.Value.ToString("yyyy-MM-dd");
                                string? _seller = ServiceProvider.Account.Username;
                                string? _custoner = txt_nameCustomer.Text.Trim();
                                string? _phone = txt_phone.Text.Trim();
                                string? _address = txt_address.Text.Trim();
                                string? _email = txt_email.Text.Trim();
                                int _builId = int.Parse(txt_billId.Text.Trim());
                                string query = $"Update [bill] Set [BillDate] = '{date}' ,[Seller] = @Seller ,[Customer] = @Customer ,[Phone] = @Phone ," +
                                "[HomeAddress] = @HomeAddress ,[Email] = @Email ,[TimeUpdate] = GetDate() Where [BillId] = @BillId ;";
                                var parameter = new object?[] { _seller, _custoner, _phone, _address, _email, _builId };
                                var res = DataProvider.Instance.ExecuteNonquery(out string? exception, DataProvider.SERVER.HUANTECH, query, parameter);
                                if (res > 0)
                                {
                                    IsEnnableInput(false);
                                    btn.Content = "Edit";
                                    MessageBox.Show("Hoàn thành lưu lại thay đổi.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Lỗi đăng nhập. Vui lòng khởi động lại chương trình");
                                Application.Current.Shutdown();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Ngày bán không được phép để trống.");
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        void IsEnnableInput(bool isValue)
        {
            dpk_billDate.IsEnabled = isValue;
            txt_nameCustomer.IsEnabled = isValue;
            txt_phone.IsEnabled = isValue;
            txt_address.IsEnabled = isValue;
            txt_email.IsEnabled = isValue;
        }

        private void Event_Cancel(object sender, RoutedEventArgs e)
        {
            string query = $"Select * From [bill] Where [BillId] = {txt_billId.Text}";
            var data = DataProvider.Instance.ExecuteQuery(out string? exception, DataProvider.SERVER.HUANTECH, query);
            if (data != null && data.Rows.Count > 0)
            {
                if (data.Rows[0]["BillDate"] is DateTime date) dpk_billDate.SelectedDate = date;               
                txt_nameCustomer.Text = data.Rows[0]["Customer"].ToString();
                txt_phone.Text = data.Rows[0]["Phone"].ToString();
                txt_address.Text = data.Rows[0]["HomeAddress"].ToString();
                txt_email.Text = data.Rows[0]["Email"].ToString();
                IsEnnableInput(false);
                btn_edit.Content = "Edit";
            }
        }
    }
}
