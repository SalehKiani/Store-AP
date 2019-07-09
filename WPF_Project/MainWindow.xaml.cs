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
    public partial class Window : System.Windows.Window
    {
        public Window()
        {
            InitializeComponent();
            this.GridPage.Children.Add(new LoginPage());
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
            FakeAccount fakeaccount = new FakeAccount();
            fakeaccount.Create();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e) // Translation To StorePage
        {
            var storepage = new Store_Page();
            storepage.Show();
            this.Close();
        }
    }
}
