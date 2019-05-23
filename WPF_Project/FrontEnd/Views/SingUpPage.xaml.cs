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

namespace WPF_Project.FrontEnd.Views
{
    /// <summary>
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SingUpPage : UserControl
    {
        public SingUpPage()
        {
            InitializeComponent();
        }

        private void HaveAccount_Click(object sender, RoutedEventArgs e)
        {
            SingUpPage signup = new SingUpPage();
            LoginPage login = new LoginPage();
            MainWindow mainwindow = new MainWindow();

            mainwindow.GridPage.Children.Remove(signup);
            mainwindow.GridPage.Children.Add(login);
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            Repository repo = new Repository();
            bool result;
            try
            {
                result = repo.signupCheck(email.Text, password.Password);

                if(!result)
                {
                    MessageBox.Show("This Email Is Existing.Please Enter Another Email Or (Login) With This Emain","SIGNUP",MessageBoxButton.OK,MessageBoxImage.Error);
                }
                else
                {
                    MainWindow mainWindow = new MainWindow();
                    SingUpPage singUp = new SingUpPage();


                }
            }
            catch(DBFail)
            {
                MessageBox.Show("Unexpected Happened,Please Try Again Later", "SIGNUP", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SignUp_admin_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
