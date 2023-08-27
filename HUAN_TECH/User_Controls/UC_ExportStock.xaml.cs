using HUAN_TECH.View;
using HUAN_TECH.ViewModels;
using Microsoft.IdentityModel.Tokens;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HUAN_TECH.User_Controls
{
    /// <summary>
    /// Interaction logic for UC_ExportStock.xaml
    /// </summary>
    public partial class UC_ExportStock : UserControl
    {       
        public UC_ExportStock()
        {
            InitializeComponent();

        }

        private void Event_CreateBill(object sender, RoutedEventArgs e)
        {
            var wd = new Bill_Submit();
            wd.ShowDialog();
        }
    }
}
