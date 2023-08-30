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
    /// Interaction logic for UC_Account.xaml
    /// </summary>
    public partial class UC_Account : UserControl
    {
        public UC_Account()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Tính năng đang phát triển. Chúng tôi sẽ thông báo khi hoàn thành. Vui lòng thử lại sau");
        }
    }
}
