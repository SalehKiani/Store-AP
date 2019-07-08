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
            try
            {
                LoginPage login = new LoginPage();
                MainWindow main = Window.GetWindow(this) as MainWindow;
                main.GridPage.Children.Remove(this);
                main.GridPage.Children.Add(login);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    Completion completion = new Completion();
                    MainWindow main = Window.GetWindow(this) as MainWindow;
                    main.GridPage.Children.Remove(this);
                    main.GridPage.Children.Add(completion);
                }
            }
            catch(DBFail)
            {
                MessageBox.Show("Unexpected Happened,Please Try Again Later", "SIGNUP", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SignUp_admin_click(object sender, RoutedEventArgs e)
        {
            if(password.Password == "1234567890")
            {
                try
                {
                    var db = new DataBase_connection();
                    var res = db.admins.Where(i => i.Email == email.Text);
                    if(res != null)
                    {
                        MessageBox.Show("This Email Was Signuped , You Can (Login) With This", "SIGNUP_ADMIN", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if (NameAdmin.Text != null)
                        {
                            try
                            {
                                db.admins.Add(new Admin { Name = NameAdmin.Text, Email = email.Text, Password = password.Password });
                            }
                            catch
                            {
                                MessageBox.Show("Unexpected Happened,Please Try Again Later", "SIGNUP_ADMIN", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Field (Name) Is Necessary For Admin.\nShoulden't Be Empty.","Name_Admin",MessageBoxButton.OK,MessageBoxImage.Error);
                        }
                    }
                }
                catch
                {

                }
            }
            else
            {
                password.Password = "";
                MessageBox.Show("Your AdminPassword Is Incorrect","ERROR",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
