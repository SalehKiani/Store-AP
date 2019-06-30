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
            LoginPage login = new LoginPage();
            this.GridPage.Children.Add(login);
        }

        private void Line_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Power_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void FakeAccount_Click(object sender, RoutedEventArgs e)
        {
            string[] names = new string[] {"Ali","Reza","Hassan","Mohammad","Hossein","Amir","Saleh","Mehdi","Hamid","Sajad"};
            int pass,k1,k2,k3;
            Int64 phone;
            string name;
            Random random = new Random();
            var db = new DataBase_connection();
            for(int i=1; i <= 10; i++)
            {
                pass = random.Next(1000,10000);
                phone = random.Next(900,1000)*10000000 + random.Next(10000000);
                k1 = random.Next(10);
                k2 = random.Next(10);
                k3 = random.Next(10);
                name = names[k1] + names[k2] + names[k3];

                db.users.Add(new UserProps(){Email = (name + pass.ToString() +"@gmail.com"),
                                             PhoneNo = phone.ToString(),
                                             Name = name,
                                             Adress = names[k1] +","+ names[k2]+","+names[k3]+",House Number"+pass.ToString(),
                                             Password = pass.ToString()});
            }
        }
    }
}
