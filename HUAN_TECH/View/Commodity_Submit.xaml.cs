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
using System.Windows.Shapes;

namespace HUAN_TECH.View
{
    /// <summary>
    /// Interaction logic for Commodity_Submit.xaml
    /// </summary>
    public partial class Commodity_Submit : Window
    {
        public Commodity_Submit(DataRowView? item = null)
        {
            InitializeComponent();
            Load_commondity_group();
            if (item != null)
            {
                this.Tag = (int)item.Row["CommodityId"];
                txt_commodityGroup.Text = item.Row["GroupName"].ToString();
                txt_commodityName.Text = item.Row["CommodityName"].ToString();
                txt_description.Text = item.Row["DescriptionCommodity"].ToString();
                txt_price.Text = item.Row["CellingPrice"].ToString();
                txt_quantity.Text = item.Row["StockQuantity"].ToString();
                Set_Type("Edit");
            }
            else
            {
                Set_Type("Add");
            }
        }

        void Set_Type(string type)
        {
            switch (type)
            {
                case "Add":
                    btn_submit.Content = "Add";
                    break;
                case "Edit":
                    btn_submit.Content = "Edit";
                    break;
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

        private void Event_Submit(object sender, RoutedEventArgs e)
        {
            if (btn_submit.Content is string content)
            {
                if (IsCheckEnterValue())
                {
                    if (txt_commodityGroup.SelectedItem is DataRowView item)
                    {
                        int GroupId = (int)item.Row["GroupId"];
                        string CommodityName = txt_commodityName.Text.Trim();
                        string DescriptionCommodity = txt_description.Text.Trim();
                        decimal CellingPrice = decimal.Parse(txt_price.Text);
                        int StockQuantity = int.Parse(txt_quantity.Text);

                        var res = false;
                        switch (content)
                        {
                            case "Add":                                
                                res = Commodity.Insert_Commodity(GroupId, CommodityName, DescriptionCommodity, CellingPrice, StockQuantity);                                
                                break;
                            case "Edit":
                                int CommodityId = (int)this.Tag;
                                res = Commodity.Update_Commodity(GroupId, CommodityName, DescriptionCommodity, CellingPrice, StockQuantity, CommodityId);
                                break;
                            default:
                                break;
                        }
                        if (res)
                        {
                            MessageBox.Show("Thành công cập nhật sản phẩm");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show($"ERROR: INSERT - UPDATE LOSE!");
                        }
                    }
                }
            }
        }

        bool IsCheckEnterValue()
        {
            foreach (var item in grid_body.Children.OfType<Control>())
            {
                if (item is ComboBox combobox && string.IsNullOrEmpty(combobox.Text))
                {
                    return false;
                }
                else if (item is TextBox textbox && string.IsNullOrEmpty(textbox.Text))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
