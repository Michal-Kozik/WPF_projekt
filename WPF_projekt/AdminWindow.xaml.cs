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
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private ObservableCollection<Product> products;
        private ObservableCollection<Client> clients;
        private ObservableCollection<Order> orders;

        private ObservableCollection<Product> needSupply = new ObservableCollection<Product>();
        private ObservableCollection<Client> searchedClients = new ObservableCollection<Client>();

        private Client client;

        /* Konstruktor */
        public AdminWindow(Client client)
        {
            InitializeComponent();

            this.client = client;
            ProfileTabItem.Header = client.login;

            products = DataBase.GetProducts();
            clients = DataBase.GetClients();
            orders = DataBase.GetOrders();
        }

        // Zaladowanie produktow.
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            // Wyszukiwanie produktow, ktore wymagaja uzupelnienia.
            foreach (Product p in products)
            {
                if (p.amount < 10)
                {
                    needSupply.Add(p);
                }
            }
            MagazineListBox.ItemsSource = needSupply;
            ClientsListBox.ItemsSource = clients;
            OrdersListBox.ItemsSource = orders;
            MagazineListBox.SelectionChanged += ItemSelected;
        }

        // Wyszukiwanie klientow wg loginu lub nr telefonu.
        private void FindClient(object sender, RoutedEventArgs e)
        {
            string searched = SearchClientTextBox.Text.ToUpper();
            // Jezeli wyszukano wg pustego tekstu to zwrocona zostanie cala lista klientow.
            if (searched == "")
            {
                ClientsListBox.ItemsSource = clients;
            }
            // W przeciwnym wypadku zwroceni zostana klienci, ktorych login lub nr telefonu bedzie pasowal do wyszukiwania.
            else
            {
                searchedClients.Clear();
                foreach (Client c in clients)
                {
                    if (c.login.ToUpper().Contains(searched) || c.phoneNumber.Contains(searched))
                    {
                        searchedClients.Add(c);
                    }
                }
                ClientsListBox.ItemsSource = searchedClients;
            }
        }

        // Zaznaczenie przedmiotu wymagajacego uzupelnienia.
        private void ItemSelected(object sender, RoutedEventArgs e)
        {
            SupplyButton.IsEnabled = true;
        }

        // Wylogowanie sie.
        private void LogOut(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        // Uzupelnienie produktu
        private void SupplyProduct(object sender, RoutedEventArgs e)
        {
            if (MagazineListBox.SelectedIndex >= 0)
            {
                Product product = MagazineListBox.SelectedItem as Product;
                product.amount += 10;
                needSupply.Remove(product);
                SupplyButton.IsEnabled = false;
                MessageBox.Show($"Uzupełniono produkt - {product.name}");
            }
        }
    }
}
