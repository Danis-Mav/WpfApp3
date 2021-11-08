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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для autor.xaml
    /// </summary>
    public partial class autor : Page
    {
        public autor()
        {
            InitializeComponent();
        }

        private void author_event_click(object sender, RoutedEventArgs e)
        {
            if  (txt_Password.Password == "123")
            {
                NavigationService.Navigate(new security_page());

            }
            else
            {
                MessageBox.Show("логин или  пароль не верные", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
