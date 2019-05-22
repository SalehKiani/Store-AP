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

        private void Loginclick(object sender, RoutedEventArgs e)
        {
            Repository repo = new Repository();
            try
            {
                repo.loginCheck(email.Text, password.Password);
            }
            catch(LoginFail)
            {
                MessageBox.Show("Emain Or Password Is Not Correct","Login",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            catch(DBFail)
            {
                MessageBox.Show("The Exception Was Happened,Please Try Again Later","Login",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            
        }

        private void HaveNotAccount_Click(object sender, RoutedEventArgs e)
        {
            LoginPage login = new LoginPage();
            SingUpPage signup = new SingUpPage();
            MainWindow mainwindow = new MainWindow();

            mainwindow.PageStack.Children.Remove(login);
            mainwindow.PageStack.Children.Add(signup);
        }
    }
}
