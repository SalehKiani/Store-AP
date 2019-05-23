﻿using System;
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
using WPF_Project.Backend;
using WPF_Project.Backend.Exceptions;

namespace WPF_Project.FrontEnd.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : UserControl
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            bool result;
            Repository repo = new Repository();
            try
            {
                result = repo.loginCheck(email.Text, password.Password);
                if(result)
                {
                    MessageBox.Show("Login Succesfully","LOGIN",MessageBoxButton.OK,MessageBoxImage.Information);
                }
            }
            catch(LoginFail)
            {
                MessageBox.Show("Email Or Password Incorrect","LOGIN",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            catch(DBFail)
            {
                MessageBox.Show("UnExpected Happen","LOGIN",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            
        }

        private void Login_admin_click(object sender, RoutedEventArgs e)
        {

        }

        private void HaveNotAccount_Click(object sender, RoutedEventArgs e)
        {
            SingUpPage signup = new SingUpPage();
            LoginPage login = new LoginPage();
            MainWindow mainwindow = new MainWindow();

            mainwindow.GridPage.Children.Remove(login);
            mainwindow.GridPage.Children.Add(signup);
        }
    }
}
