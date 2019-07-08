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
    /// Interaction logic for Completion.xaml
    /// </summary>
    public partial class Completion : UserControl
    {
        public Completion()
        {
            InitializeComponent();
        }

        private void Name_TextChange(object sender, TextChangedEventArgs e)
        {
            string str = nameTXT.Text;
            int last=str.Length;
            try
            {
                Convert.ToInt32(str[last - 1]);
            }
            catch(FormatException)
            {
                char[] s = new char[last -1];
                for(int i=0; i<last-1 ;i++)
                {
                    s[i] = str[i];
                }
                nameTXT.Text = s.ToString();
            }
            catch
            {

            }
        }
        private void Name_Keydown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                phonenum.Focus();
            }
            if(!(e.Key >= Key.A && e.Key <= Key.Z))
            {
                e.Handled = true;
            }
        }
        private void Phonenumber_Preview(object sender, TextCompositionEventArgs e)
        {
            int a;
            if(int.TryParse(e.Text,out a) == false)
            {
                e.Handled = true;
            }
        }
        private void Phonenumber_Keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Address.Focus();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            Repository repository = new Repository();
            try
            {
                repository.complete_signup(nameTXT.Text, Address.Text, Convert.ToInt32(phonenum.Text));
            }
            catch(DBFail)
            {
                MessageBox.Show("Unexpected Happened,Please Try Again Later", "COMPLETION_SIGNUP", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Store_Page storePage = new Store_Page();
            storePage.Show();
            MainWindow m = new MainWindow();
            m.Close();
        }
    }
}
