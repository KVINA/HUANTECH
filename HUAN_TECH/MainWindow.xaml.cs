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


namespace HUAN_TECH
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuitem)
            {
                var tabitem = new TabItem();
                var header = menuitem.Header.ToString();
                var nameuc = menuitem.Tag;
                if (nameuc != null)
                {
                    tabitem.Header = TabItem_Header(header, tabitem);                    
                    if (DisplayUC.ControlUC(nameuc.ToString()) is UserControl content)
                    {
                        content.Margin = new Thickness(0, 10, 0, 0);
                        tabitem.Content = content;
                    }
                    tct_body.Items.Add(tabitem);
                    tct_body.SelectedItem = tabitem;
                }
                else
                {
                    MessageBox.Show("ERROR: MenuItem.Tag is NULL");
                }


            }
        }

        Grid TabItem_Header(string? header, TabItem tabitem)
        {
            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength() });

            var textblock = new TextBlock() { Text = header, Margin = new Thickness(2) };
            grid.Children.Add(textblock);

            var border = new Border() { Cursor = Cursors.Hand, DataContext = tabitem };
            border.Child = new TextBlock() { Text = "❌", Foreground = Brushes.Red, Background = Brushes.AliceBlue, Margin = new Thickness(2) };
            border.MouseLeftButtonUp += Border_MouseLeftButtonUp;

            grid.Children.Add(border);
            Grid.SetColumn(border, 1);

            return grid;
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border && border.DataContext is TabItem tabitem)
            {
                tct_body.Items.Remove(tabitem);
            }
        }
    }
}
