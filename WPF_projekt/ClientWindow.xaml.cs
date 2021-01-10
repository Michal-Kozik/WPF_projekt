using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPF_projekt
{
    public partial class ClientWindow : Window
    {
        private Client client;



        private Collection<Product> products;
        private Collection<Client> clients;
        private Collection<Order> orders;
        private Collection<Product> cart = new ObservableCollection<Product>();

        /* Konstruktor */
        public ClientWindow(Client client)
        {
            InitializeComponent();

            products = MainWindow.GetProducts();
            clients = MainWindow.GetClients();
            orders = MainWindow.GetOrders();

            this.client = client;
            ProfileTabItem.Header = client.login;

        }

        // Zaladowanie danych
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            ProductsListBox.ItemsSource = products;
            CartListBox.ItemsSource = cart;
            ProductsListBox.SelectionChanged += ItemSelected;
        }

        // Dodanie produktu do koszyka
        private void AddToCart(object sender, RoutedEventArgs e)
        {
            // jeszcze nie jestem pewien czy ten if jest potrzebny,
            // trzeba bedzie do tej metody wrocic jak oprogramujemy kategorie do wszukiwania
            if (ProductsListBox.SelectedIndex >= 0)
            {
                Product product = products.ElementAt(ProductsListBox.SelectedIndex);
                cart.Add(product);
                MessageBox.Show($"Dodano {product.name} do koszyka.");
                AddButton.IsEnabled = false;
            }
        }

        // Zaznaczenie przedmiotu na liscie
        private void ItemSelected(object sender, RoutedEventArgs e)
        {
            AddButton.IsEnabled = true;
        }
    }
}
