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

namespace WPF_Project.FrontEnd.Views
{
    /// <summary>
    /// Interaction logic for Profile_Page.xaml
    /// </summary>
    public partial class Profile_Page : UserControl
    {
        public Profile_Page()
        {
            InitializeComponent();
            // Add Information To TextBoxes From Class(UserActivity)
        }

        private void Close_Button_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Store_Page store_Page = Window.GetWindow(this) as Store_Page;
            store_Page.AddPagesGrid.Children.Remove(this);
        }
    }
}
