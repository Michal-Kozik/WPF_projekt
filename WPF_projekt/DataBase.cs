using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_projekt
{
    class DataBase
    {
        private static ObservableCollection<Product> products = new ObservableCollection<Product>();
        private static ObservableCollection<Client> clients = new ObservableCollection<Client>();
        private static ObservableCollection<Order> orders = new ObservableCollection<Order>();
        private static Dictionary<string, Client> clientsMap = new Dictionary<string, Client>();

        /* Konstruktor */
        static DataBase()
        {
            products.Add(new Product { name = "item1", category = "Kategoria 1", description = "dgshkjagfdkjhfga", price = 9.99M, amount = 9 });
            products.Add(new Product { name = "item2", category = "Kategoria 2", description = "dgshkjagfdkjhfga", price = 19.99M, amount = 10 });
            products.Add(new Product { name = "item3", category = "Kategoria 3", description = "dgshkjagfdkjhfga", price = 29.99M, amount = 11 });

            clients.Add(new Client { name = "Michał", surname = "Pol", phoneNumber = "123456789", details = "Szczegółowe informacje Pola", login = "pol", password = "pol123", adminRights = false });
            clients.Add(new Client { name = "Mateusz", surname = "Borek", phoneNumber = "725602849", details = "Szczegółowe informacje Borka", login = "bor", password = "bor123", adminRights = false });
            clients.Add(new Client { name = "Tomasz", surname = "Smokowski", phoneNumber = "827028124", details = "Szczegółowe informacje Smokowskiego", login = "smoku", password = "smoku123", adminRights = false });
            clients.Add(new Client { name = "Jacek", surname = "Nowak", phoneNumber = "123634745", details = "Szczegółowe dane Nowaka", login = "admin", password = "admin123", adminRights = true });

            clientsMap.Add(clients.ElementAt(0).login, clients.ElementAt(0));
            clientsMap.Add(clients.ElementAt(1).login, clients.ElementAt(1));
            clientsMap.Add(clients.ElementAt(2).login, clients.ElementAt(2));
            clientsMap.Add(clients.ElementAt(3).login, clients.ElementAt(3));

            orders.Add(new Order("1", products, clients.ElementAt(0)));
            orders.Add(new Order("2", products, clients.ElementAt(1)));
            orders.Add(new Order("3", products, clients.ElementAt(2)));
        }

        /* Gettery */
        public static ObservableCollection<Product> GetProducts()
        {
            return products;
        }
        public static ObservableCollection<Client> GetClients()
        {
            return clients;
        }
        public static ObservableCollection<Order> GetOrders()
        {
            return orders;
        }
        public static Dictionary<string, Client> GetClientsMap()
        {
            return clientsMap;
        }

        /* Symulowanie dodawania do bazy */
        public static void AddOrder(Order order)
        {
            orders.Add(order);
        }
    }
}
