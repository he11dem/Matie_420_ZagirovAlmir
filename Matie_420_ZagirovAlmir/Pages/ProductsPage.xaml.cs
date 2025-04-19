using Matie_420_ZagirovAlmir.Model;
using Matie_420_ZagirovAlmir.Model.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Matie_420_ZagirovAlmir.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public static List<Service> services { get; set; }
        
        public ProductsPage()
        {
            InitializeComponent();
            services = new List<Service>(DBConnection.matie.Service.ToList());
            ServiceLV.ItemsSource = services;

            this.DataContext = services;

        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow?.Close();
        }

        private void ServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServicePage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void SearchTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            var filterProduct = DBConnection.matie.Service.ToList();

            if(SearchTbx.Text.Length > 0)
            {
                filterProduct = filterProduct.Where(i => i.Name.ToLower().StartsWith(SearchTbx.Text.Trim().ToLower())).ToList();
            }

            ServiceLV.ItemsSource = filterProduct;

        }
    }
}
