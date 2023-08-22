using HUAN_TECH.View;
using Microsoft.IdentityModel.Tokens;
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

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            Add_commodity_group();
        }

        #region MyRegion
        void Add_commodity_group()
        {
            if (string.IsNullOrEmpty(txt_groupname.Text) || string.IsNullOrEmpty(txt_description.Text))
            {
                MessageBox.Show("Tên nhóm hàng (Group Name) và mô tả (Description) không được để trống.");
            }
            else
            {
                string username = Environment.UserName;
                string query = "Insert Into [commodity_group] ([GroupName],[Description],[UserUpdate]) Values ( @GroupName , @Description , @UserUpdate )";
                var parameter = new object[] {txt_groupname.Text.Trim(),txt_description.Text.Trim(), username };
                var res = DataProvider.Instance.ExecuteNonquery(out string? ex, DataProvider.SERVER.HUANTECH, query, parameter);
                if (res)
                {
                    Load_commodity_group();
                    MessageBox.Show("Thêm thành công nhóm hàng");
                    txt_groupname.Text = null; txt_description.Text = null;
                }
                else
                {
                    MessageBox.Show($"ERROR: INSERT LOSE{Environment.NewLine}{ex}");
                }                
            }
        }
        #endregion

        private void Event_EditItem(object sender, RoutedEventArgs e)
        {
            if (dtg_commodity_group.SelectedItem is DataRowView datarow)
            {
                var wd = new Edit_commodity_group(datarow);
                wd.ShowDialog();
                Load_commodity_group();
            }
        }
    }
}
