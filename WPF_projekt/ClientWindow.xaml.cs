using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
        // Produkty w koszyku.
        private ObservableCollection<Product> cart = new ObservableCollection<Product>();
        // Produkty szukane wedlug kategorii.
        private ObservableCollection<Product> searched = new ObservableCollection<Product>();

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

        // Zaladowanie danych.
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            ProductsListBox.ItemsSource = products;
            CartListBox.ItemsSource = cart;
            cart.CollectionChanged += CalculatePrice;
            ProductsListBox.SelectionChanged += ItemSelected;
        }

        // Dodanie produktu do koszyka.
        private void AddToCart(object sender, RoutedEventArgs e)
        {
            // ~ jeszcze nie jestem pewien czy ten if jest potrzebny,
            if (ProductsListBox.SelectedIndex >= 0)
            {
                Product product = ProductsListBox.SelectedItem as Product;
                cart.Add(product);
                MessageBox.Show($"Dodano {product.name} do koszyka.");
                AddButton.IsEnabled = false;
            }
        }

        // Zaznaczenie przedmiotu na liscie.
        private void ItemSelected(object sender, RoutedEventArgs e)
        {
            AddButton.IsEnabled = true;
        }

        // Podliczenie zamowienia.
        private void CalculatePrice(object sender, NotifyCollectionChangedEventArgs e)
        {
            decimal result = 0;
            foreach (Product p in cart)
            {
                result += p.price;
            }
            PriceLabel.Content = $"Cena: {result}";
        }
        
        // Wyszukanie produktow wedlug zaznaczonych kategorii.
        private void Find(object sender, RoutedEventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            string searchedCategory = checkbox.Content.ToString();
            foreach (Product p in products)
            {
                if (p.category == searchedCategory)
                {
                    searched.Add(p);
                }
            }
            ProductsListBox.ItemsSource = searched;
            AddButton.IsEnabled = false;
        }

        // Wyszukiwanie produktow w przypadku odhaczenia kategorii.
        private void Erase(object sender, RoutedEventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            string erasedCategory = checkbox.Content.ToString();
            List<Product> forDelete = new List<Product>();
            foreach (Product p in searched)
            {
                if (p.category == erasedCategory)
                {
                    forDelete.Add(p);
                }
            }
            foreach (Product p in forDelete)
            {
                searched.Remove(p);
            }
            // Jezeli odhaczone zostana wszystkie kategorie.
            if (searched.Count() == 0)
            {
                ProductsListBox.ItemsSource = products;
            }
            AddButton.IsEnabled = false;
        }
    }
}
