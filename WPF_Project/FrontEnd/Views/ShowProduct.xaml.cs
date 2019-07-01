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

namespace WPF_Project.FrontEnd.Views
{
    /// <summary>
    /// Interaction logic for ShowProduct.xaml
    /// </summary>
    public partial class ShowProduct : UserControl
    {
        public ShowProduct()
        {
            InitializeComponent();
        }

        private void AddPicture(string URL)
        {
            try
            {
                var image = new Image();
                var P = URL;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(P,UriKind.Absolute);
                bitmap.EndInit();

                image.Source = bitmap;

                product_picture.Children.Add(image);
            }
            catch(Exception)
            {
                MessageBox.Show("Error Loading Image", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
