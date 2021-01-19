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

        // Zaladowanie produktow
        private void LoadProducts(object sender, RoutedEventArgs e)
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
        }
    }
}
