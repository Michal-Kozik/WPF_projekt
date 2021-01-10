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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Collection<Product> products = new ObservableCollection<Product>();
        private static Collection<Client> clients = new ObservableCollection<Client>();
        private static Collection<Order> orders = new ObservableCollection<Order>();

        private static Dictionary<string, Client> clientsMap = new Dictionary<string, Client>();

        /* Konstruktor */
        public MainWindow()
        {
            InitializeComponent();

            products.Add(new Product { name = "item1", description = "dgshkjagfdkjhfga", price = 9.99M, amount = 10 });
            products.Add(new Product { name = "item2", description = "dgshkjagfdkjhfga", price = 19.99M, amount = 11 });
            products.Add(new Product { name = "item3", description = "dgshkjagfdkjhfga", price = 29.99M, amount = 12 });

            clients.Add(new Client { name = "Michał", surname = "Pol", phoneNumber = "123456789", details = "Szczegółowe informacje Pola", login = "pol", password = "pol123", adminRights = false });
            clients.Add(new Client { name = "Mateusz", surname = "Borek", phoneNumber = "725602849", details = "Szczegółowe informacje Borka", login = "bor", password = "bor123", adminRights = false });
            clients.Add(new Client { name = "Tomasz", surname = "Smokowski", phoneNumber = "827028124", details = "Szczegółowe informacje Smokowskiego", login = "smoku", password = "smoku123", adminRights = false });
            clients.Add(new Client { name = "Jacek", surname = "Nowak", phoneNumber = "123634745", details = "Szczegółowe dane Nowaka", login = "admin", password = "admin123", adminRights = true });

            clientsMap.Add(clients.ElementAt(0).login, clients.ElementAt(0));
            clientsMap.Add(clients.ElementAt(1).login, clients.ElementAt(1));
            clientsMap.Add(clients.ElementAt(2).login, clients.ElementAt(2));
            clientsMap.Add(clients.ElementAt(3).login, clients.ElementAt(3));

            orders.Add(new Order(1, products, clients.ElementAt(0)));
            orders.Add(new Order(2, products, clients.ElementAt(1)));
            orders.Add(new Order(3, products, clients.ElementAt(2)));
        }

        /* Gettery */
        public static Collection<Product> GetProducts()
        {
            return products;
        }
        public static Collection<Client> GetClients()
        {
            return clients;
        }
        public static Collection<Order> GetOrders()
        {
            return orders;
        }

        /* Logowanie */
        private void Log_in(object sender, RoutedEventArgs e)
        {
            // sprawdzenie czy taki login wgl istnieje
            if (clientsMap.ContainsKey(LoginTextBox.Text))
                // porownanie hasla wpisanego oraz hasla pod danym loginem
                if (PassBox.Password == clientsMap[LoginTextBox.Text].password)
                {
                    // sprawdzenie czy uzytkownik ma prawa administracyjne
                    if (clientsMap[LoginTextBox.Text].adminRights == true)
                    {
                        AdminWindow window = new AdminWindow(clientsMap[LoginTextBox.Text]);
                        window.Show();
                        Close();
                    }
                    else
                    {
                        ClientWindow window = new ClientWindow(clientsMap[LoginTextBox.Text]);
                        window.Show();
                        Close();
                    }
                }
                else
                {
                    ValidationLabel.Content = "Podany login i hasło nie pasują do siebie!";
                }
            else
                ValidationLabel.Content = "Podane pola nie mogą być puste!";
        }
    }
}
