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
            products.Add(new Product { name = "Picka numero uno", category = "Pizza", description = "dgshkjagfdkjhfga", price = 9.99M, amount = 9, imagePath = "Images/pizza_1.png" });
            products.Add(new Product { name = "Picka superowa", category = "Pizza", description = "dgshkjagfdkjhfga", price = 19.99M, amount = 4, imagePath = "Images/pizza_2.png" });
            products.Add(new Product { name = "Picka doskonała", category = "Pizza", description = "dgshkjagfdkjhfga", price = 29.99M, amount = 11, imagePath = "Images/pizza_3.png" });
            products.Add(new Product { name = "Kebabik numero uno", category = "Kebab", description = "dgshkjagfdkjhfga", price = 9.99M, amount = 9, imagePath = "Images/kebab_1.png" });
            products.Add(new Product { name = "Kebabik superowy", category = "Kebab", description = "dgshkjagfdkjhfga", price = 19.99M, amount = 4, imagePath = "Images/kebab_2.png" });
            products.Add(new Product { name = "Kebabik doskonały", category = "Kebab", description = "dgshkjagfdkjhfga", price = 29.99M, amount = 11, imagePath = "Images/kebab_3.png" });
            products.Add(new Product { name = "Sałatka numero uno", category = "Sałatka", description = "dgshkjagfdkjhfga", price = 9.99M, amount = 9, imagePath = "Images/salatka_1.png" });
            products.Add(new Product { name = "Sałatka superowa", category = "Sałatka", description = "dgshkjagfdkjhfga", price = 19.99M, amount = 4, imagePath = "Images/salatka_2.png" });
            products.Add(new Product { name = "Sałatka doskonała", category = "Sałatka", description = "dgshkjagfdkjhfga", price = 29.99M, amount = 11, imagePath = "Images/salatka_3.png" });

            clients.Add(new Client { Name = "Michał", Surname = "Pol", PhoneNumber = "123456789", details = "Szczegółowe informacje Pola", login = "pol", password = "pol123", adminRights = false });
            clients.Add(new Client { Name = "Mateusz", Surname = "Borek", PhoneNumber = "725602849", details = "Szczegółowe informacje Borka", login = "bor", password = "bor123", adminRights = false });
            clients.Add(new Client { Name = "Tomasz", Surname = "Smokowski", PhoneNumber = "827028124", details = "Szczegółowe informacje Smokowskiego", login = "smoku", password = "smoku123", adminRights = false });
            clients.Add(new Client { Name = "Jacek", Surname = "Nowak", PhoneNumber = "123634745", details = "Szczegółowe dane Nowaka", login = "admin", password = "admin123", adminRights = true });

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
