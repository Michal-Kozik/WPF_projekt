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
        private Collection<Product> products;
        private Collection<Client> clients;
        private Collection<Order> orders;

        private Client client;

        /* Konstruktor */
        public AdminWindow(Client client)
        {
            InitializeComponent();

            this.client = client;
            ProfileTabItem.Header = client.login;

            products = MainWindow.GetProducts();
            clients = MainWindow.GetClients();
            orders = MainWindow.GetOrders();

            /*
            products.Add(new Product { name = "item1", description = "dgshkjagfdkjhfga", price = 9.99M, amount = 10 });
            products.Add(new Product { name = "item2", description = "dgshkjagfdkjhfga", price = 19.99M, amount = 11 });
            products.Add(new Product { name = "item3", description = "dgshkjagfdkjhfga", price = 29.99M, amount = 12 });

            clients.Add(new Client { name = "Michał", surname = "Pol", phoneNumber = "123456789", details = "Szczegółowe informacje Pola" });
            clients.Add(new Client { name = "Mateusz", surname = "Borek", phoneNumber = "725602849", details = "Szczegółowe informacje Borka" });
            clients.Add(new Client { name = "Tomasz", surname = "Smokowski", phoneNumber = "827028124", details = "Szczegółowe informacje Smokowskiego" });

            orders.Add(new Order(1, products, clients.ElementAt(0)));
            orders.Add(new Order(2, products, clients.ElementAt(1)));
            orders.Add(new Order(3, products, clients.ElementAt(2)));
            */
        }

        private void LoadProducts(object sender, RoutedEventArgs e)
        {
            MagazineListBox.ItemsSource = products;
            ClientsListBox.ItemsSource = clients;
            OrdersListBox.ItemsSource = orders;
        }
    }
}
