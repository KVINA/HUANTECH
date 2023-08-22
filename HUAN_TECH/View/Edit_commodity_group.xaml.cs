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
    /// Interaction logic for Edit_commodity_group.xaml
    /// </summary>
    public partial class Edit_commodity_group : Window
    {
        public Edit_commodity_group(DataRowView dataRow)
        {
            InitializeComponent();
            txt_id.Text = dataRow["GroupId"].ToString();
            txt_groupname.Text = dataRow["GroupName"].ToString();
            txt_description.Text = dataRow["Description"].ToString();
        }

        private void Event_Submit(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_id.Text) || string.IsNullOrEmpty(txt_groupname.Text) || string.IsNullOrEmpty(txt_description.Text))
                {
                    MessageBox.Show("Enter value.");
                }
                else
                {
                    int groupid = int.Parse(txt_id.Text);
                    string groupname = txt_groupname.Text.Trim();
                    string description = txt_description.Text.Trim();
                    string userupdate = Environment.UserName;
                    string query = "Update [commodity_group] set [GroupName] = @GroupName ,[Description] = @Description ,[UserUpdate] = @UserUpdate ,[TimeUpdate] = GetDate() Where [GroupId] = @GroupId ";
                    var parameter = new object[] { groupname, description, userupdate, groupid };
                    var res = DataProvider.Instance.ExecuteNonquery(out string? ex, DataProvider.SERVER.HUANTECH,query, parameter);
                    if (res > 0)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"ERROR: EDIT LOSE{Environment.NewLine}{ex}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
