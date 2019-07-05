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
using WPF_Project.FrontEnd.Views;

namespace WPF_Project
{
    /// <summary>
    /// Interaction logic for Store_Page.xaml
    /// </summary>
    public partial class Store_Page : Window
    {
        public Store_Page()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            //Get Number Product In TextBox,Get URL Product From DataBase, Send URL To (AddPicture)in(ShowProduct)Page ---------- DATABASE - CONNECTION
            //Creat Object From ShowProduct And Add It To (WrapProduct)
        }

        private void ButtonRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            //Remove Objects
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ClosePage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //DELET THIS FUNCTION
        }

        private void TextBlock_ClosePage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LoginSignupButton_Click(object sender, RoutedEventArgs e)
        {
            var mainwin = new MainWindow();
            mainwin.Show();
            this.Close();
        }

        private void TextBlock_MyProfile_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Profile_Page profile_page = new Profile_Page();
            AddPagesGrid.Children.Clear();
            AddPagesGrid.Children.Add(profile_page);
        }

        private void TextBlock_Home_MouseUp(object sender, MouseButtonEventArgs e)
        {
            AddPagesGrid.Children.Clear();
        }
    }
}
