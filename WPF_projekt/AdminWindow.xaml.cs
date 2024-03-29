﻿using System;
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

        // Kolekcja do wyswietlania towarow wymagajacych uzupelnienia.
        private ObservableCollection<Product> needSupply = new ObservableCollection<Product>();
        // Kolekcja do wyswietlania wyszukiwanych klientow.
        private ObservableCollection<Client> searchedClients = new ObservableCollection<Client>();
        // Kolekcja do wyswietlania wyszukiwanych zamowien.
        private ObservableCollection<Order> searchedOrders = new ObservableCollection<Order>();

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

            // Uzupelnienie okna 'Profil'.
            LoginLabel.Content = client.login;
            NameLabel.Content = client.Name;
            SurnameLabel.Content = client.Surname;
            PhoneLabel.Content = client.PhoneNumber;
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
                    if (c.login.ToUpper().Contains(searched) || c.PhoneNumber.Contains(searched))
                    {
                        searchedClients.Add(c);
                    }
                }
                ClientsListBox.ItemsSource = searchedClients;
            }
        }

        // Wyszukanie zamowienia wg ID, loginu zamawiajacego lub nr telefonu zamawiajacego.
        private void FindOrder(object sender, RoutedEventArgs e)
        {
            string searched = SearchOrderTextBox.Text.ToUpper();
            // Jezeli wyszukano wg pustego tekstu to zwrocona zostanie cala lista zamowien.
            if (searched == "")
            {
                OrdersListBox.ItemsSource = orders;
            }
            // W przeciwnym wypadku zwrocone zostana zamowienia, ktorych ID, login lub telefon zamawiajacego bedzie pasowal do wyszukiwania.
            else
            {
                searchedOrders.Clear();
                foreach (Order o in orders)
                {
                    if (o.id.ToUpper().Contains(searched) || o.client.login.ToUpper().Contains(searched) || o.client.PhoneNumber.Contains(searched))
                    {
                        searchedOrders.Add(o);
                    }
                }
                OrdersListBox.ItemsSource = searchedOrders;
            }
        }

        // Wylogowanie sie.
        private void LogOut(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        // Uzupelnienie produktu - nowa wersja.
        private void SupplyProduct(object sender, RoutedEventArgs e)
        {
            Button cmd = sender as Button;
            Product product = cmd.Tag as Product;

            product.amount += 10;
            needSupply.Remove(product);
            MessageBox.Show($"Uzupełniono produkt - {product.name}.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Walidacja.
        private void ValidationInfo(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString(), "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
