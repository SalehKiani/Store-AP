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

namespace WPF_Project
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

        private void Line_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
        private void SignUpclick(object sender, RoutedEventArgs e)
        {
            if (password.Password == "1234")
            {
                using (var db = new DataBase_connection())
                {
                    db.admins.Add(new Admin() { Email = email.Text, Password = password.Password });
                    db.SaveChanges();
                }
            }
            else
            {
                using (var db = new DataBase_connection())
                {
                    db.users.Add(new UserProps() { Email = email.Text, Password = password.Password });
                    db.SaveChanges();
                }
            }
                
            
            password.Password = "";
            email.Text = "";
        }

        private void Loginclick(object sender, RoutedEventArgs e)
        {
            Repository repo = new Repository();
            try
            {
                bool result = repo.loginCheck(email.Text, password.Password);
                if (result)
                {
                    MessageBox.Show("Login Successfully", "LOGIN", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (LoginFail)
            {
                MessageBox.Show("User or Pass incorrect.", "LOGIN", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (DBFail)
            {
                MessageBox.Show("Uexpected happen.", "LOGIN", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
