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
using WPF_Project;
using WPF_Project.Backend;
using WPF_Project.Backend.Exceptions;
using WPF_Project.FrontEnd.Views;

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
                    MessageBox.Show("Login Succesfully", "LOGIN", MessageBoxButton.OK, MessageBoxImage.Information);
                    Store_Page stp = new Store_Page();
                    stp.Show();
                    MainWindow main = Window.GetWindow(this) as MainWindow;
                    main.Close();
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
            catch(EmptyField)
            {
                MessageBox.Show("Please fill all of the fields!", "LOGIN", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Login_admin_click(object sender, RoutedEventArgs e)
        {
            var db = new DataBase_connection();
            if(password.Password=="1234567890")
            {
                try
                {
                    var res = db.admins.Where(i => i.Email == email.Text);
                    if(res != null)
                    {
                        MessageBox.Show("You Logged in As Administrator", "LOGIN ADMIN", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        MessageBox.Show("You Are Not Signed Up As Administrator","LOGIN ADMIN",MessageBoxButton.OK,MessageBoxImage.Information);
                    }
                }
                catch(DBFail)
                {
                    MessageBox.Show("UnExpected Happen", "LOGIN ADMIN", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private void HaveNotAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SingUpPage singUp = new SingUpPage();
                MainWindow main = Window.GetWindow(this) as MainWindow;
                main.GridPage.Children.Remove(this);
                main.GridPage.Children.Add(singUp);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
