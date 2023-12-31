﻿using HUAN_TECH.ViewModels;
using Models;
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
using System.Windows.Shapes;

namespace HUAN_TECH
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void GroupBox_DragOver(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Event_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Event_Login(object sender, RoutedEventArgs e)
        {
            bool isadmin = tgl_admin.IsChecked is bool? tgl_admin.IsChecked.Value: false;
            string username = txt_username.Text;
            string password = txt_password.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Hãy nhập vào Usernam và Password.");
            }
            else
            {
                var res = ServiceProvider.Set_Login(username, password, isadmin);
                if (res)
                {
                    var wd = new MainWindow();
                    this.Close();
                    wd.Show();
                }
                else
                {
                    MessageBox.Show("Username hoặc Passwrod không chính xác.");
                }
            }
        }
    }
}
