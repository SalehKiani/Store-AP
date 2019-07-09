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
    /// Interaction logic for Maneger_Page.xaml
    /// </summary>
    public partial class Maneger_Page : UserControl
    {
        public Maneger_Page()
        {
            InitializeComponent();
        }

        private void FakeAccount_MouseUp(object sender, MouseButtonEventArgs e)
        {
            FakeAccount fakeAccount = new FakeAccount();
            fakeAccount.Create();
        }

        private void CloseUsercontrol_Manager_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Store_Page storePage = Window.GetWindow(this) as Store_Page;
            storePage.BasicGrid.Children.Remove(this);
        }

        private void Makeproduct(object sender, RoutedEventArgs e)
        {
            if (Url.Text == "\0" || name.Text == "\0" || price.Text == "\0" || type.Text == "\0" || exist.Text == "\0")
                MessageBox.Show("plaese fill all of the fields!", "Empty Field", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                try
                {
                    var db = new DataBase_connection();
                    db.products.Add(new Product() { Name = name.Text, Type = type.Text, Specific = Url.Text, Exist = true, Price = Int32.Parse(price.Text) });
                }
                catch(Exception)
                {
                    throw new DBFail();
                }
                }
        }
    }
}
