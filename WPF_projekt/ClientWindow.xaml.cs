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


        private ObservableCollection<Product> products;
        private ObservableCollection<Client> clients;
        private ObservableCollection<Order> orders;
        // Produkty w koszyku.
        private ObservableCollection<Product> cart = new ObservableCollection<Product>();
        // Produkty szukane wedlug kategorii.
        private ObservableCollection<Product> searched = new ObservableCollection<Product>();

        /* Konstruktor */
        public ClientWindow(Client client)
        {
            InitializeComponent();

            products = DataBase.GetProducts();
            clients = DataBase.GetClients();
            orders = DataBase.GetOrders();

            this.client = client;
            ProfileTabItem.Header = client.login;
        }

        // Zaladowanie danych.
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            ProductsListBox.ItemsSource = products;
            CartListBox.ItemsSource = cart;
            CartListBox.SelectionChanged += ItemSelectedCart;
            ProductsListBox.SelectionChanged += ItemSelected;

            // Uzupelnienie okna 'Profil'.
            LoginLabel.Content = client.login;
            NameLabel.Content = client.Name;
            SurnameLabel.Content = client.Surname;
            PhoneLabel.Content = client.PhoneNumber;

            // Zaladowanie najnowszych produktow.
            Uri fileUri = new Uri(products.ElementAt(products.Count() - 1).imagePath, UriKind.Relative);
            NewestItem1.Source = new BitmapImage(fileUri);
            fileUri = new Uri(products.ElementAt(products.Count() - 2).imagePath, UriKind.Relative);
            NewestItem2.Source = new BitmapImage(fileUri);
            fileUri = new Uri(products.ElementAt(products.Count() - 3).imagePath, UriKind.Relative);
            NewestItem3.Source = new BitmapImage(fileUri);
            fileUri = new Uri(products.ElementAt(products.Count() - 4).imagePath, UriKind.Relative);
            NewestItem4.Source = new BitmapImage(fileUri);
        }

        // Dodanie produktu do koszyka - do wywalanie.
        private void AddToCart(object sender, RoutedEventArgs e)
        {
            // ~ jeszcze nie jestem pewien czy ten if jest potrzebny
            if (ProductsListBox.SelectedIndex >= 0)
            {
            Product product = ProductsListBox.SelectedItem as Product;
            //Product product = sender as Product;
                if (product.cartAmount == 0)
                    cart.Add(product);
                product.cartAmount++;

                // Obliczanie ceny 
                decimal result = 0;
                foreach (Product p in cart)
                {
                    result += p.price * p.cartAmount;
                }
                PriceLabel.Content = $"Cena: {result} zł";

                ProductsListBox.SelectedIndex = -1;
                //AddButton.IsEnabled = false;
                OrderButton.IsEnabled = true;
                CartListBox.Items.Refresh();

                MessageBox.Show($"Dodano {product.name} do koszyka.");
            }
        }

        // Zaznaczenie przedmiotu na liscie produktow.
        private void ItemSelected(object sender, RoutedEventArgs e)
        {
            //AddButton.IsEnabled = true;
        }

        // Zaznaczenie przedmiotu w koszyku
        private void ItemSelectedCart(object sender, RoutedEventArgs e)
        {
            DeleteButton.IsEnabled = true;
        }

        // Podliczenie zamowienia.
        /*private void CalculatePrice(object sender, NotifyCollectionChangedEventArgs e)
        {
            decimal result = 0;
            foreach (Product p in cart)
            {
                result += p.price;
            }
            PriceLabel.Content = $"Cena: {result}";
        }
        */

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
            //AddButton.IsEnabled = false;
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
            ProductsListBox.ItemsSource = searched;
            // Jezeli odhaczone zostana wszystkie kategorie.
            if (searched.Count() == 0)
            {
                ProductsListBox.ItemsSource = products;
            }
            //AddButton.IsEnabled = false;
        }

        // Wyszukiwanie produktow na podstawie tekstu.
        private void FindByText(object sender, RoutedEventArgs e)
        {
            string searchedName = SearchTextBox.Text;
            searchedName = searchedName.ToUpper();
            ObservableCollection<Product> result = new ObservableCollection<Product>();
            // Jezeli sa produkty zwrocone po wyszukiwaniu wg kategorii
            // to wsrod nich bedzie szukany produkt wg tekstu.
            if (searched.Count() != 0)
            {
                foreach (Product p in searched)
                {
                    if (p.name.ToUpper().Contains(searchedName) || p.category.ToUpper().Contains(searchedName))
                    {
                        result.Add(p);
                    }
                }
                ProductsListBox.ItemsSource = result;
            }
            // Jezeli nie wyszukiwano produktow wg kategorii
            // to wyszukiwanie wg tektsu bedzie wsrod wszystkich produktow.
            else
            {
                foreach (Product p in products)
                {
                    if (p.name.ToUpper().Contains(searchedName) || p.category.ToUpper().Contains(searchedName))
                    {
                        result.Add(p);
                    }
                }
                ProductsListBox.ItemsSource = result;
            }
            //AddButton.IsEnabled = false;
            SearchTextBox.Text = "";
        }

        // Usuniecie przedmiotu z koszyka.
        private void DeleteFromCart(object sender, RoutedEventArgs e)
        {
            // ~ jeszcze nie jestem pewien czy ten if jest potrzebny
            if (CartListBox.SelectedIndex >= 0)
            {
                Product product = CartListBox.SelectedItem as Product;
                if (product.cartAmount == 1)
                    cart.Remove(product);
                product.cartAmount--;

                // Obliczanie ceny.
                decimal result = 0;
                foreach (Product p in cart)
                {
                    result += p.price * p.cartAmount;
                }
                PriceLabel.Content = $"Cena: {result} zł";

                if (cart.Count() == 0)
                    OrderButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
                CartListBox.Items.Refresh();
                MessageBox.Show($"Usunięto {product.name} z koszyka.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Zlozenie zamowienia.
        private void MakeOrder(object sender, RoutedEventArgs e)
        {
            // Wygenerowanie id zamowienia.
            DateTime moment = DateTime.Now;
            string id = "";
            id += moment.Hour.ToString();
            id += moment.Minute.ToString();
            id += moment.Second.ToString();
            id += moment.Day.ToString();
            id += moment.Month.ToString();
            id += moment.Year.ToString();
            id += client.login;

            // Stworzenie kolekcji z produktami zamowionymi przez klienta.
            Collection<Product> collection = new Collection<Product>();
            foreach (Product p in cart)
            {
                collection.Add(p);
            }

            Order order = new Order(id, collection, client);
            cart.Clear();
            DeleteButton.IsEnabled = false;
            OrderButton.IsEnabled = false;
            DataBase.AddOrder(order);

            // Ustawienie we wszystkich produktach zmiennej 'cartAmount' na 0.
            foreach (Product p in products)
            {
                p.cartAmount = 0;
            }

            MessageBox.Show($"Zamówienie zostało złożone pomyślnie.\n" +
                $"Szczegóły:\n{order.everythingToString}\n" +
                $"{order.details}");
        }

        // Wylogowanie sie.
        private void LogOut(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void PutIntoCart(object sender, RoutedEventArgs e)
        {
            Button cmd = sender as Button;
            Product product = cmd.Tag as Product;
            //ProductsListBox.SelectedItem = product;

            if (product.cartAmount == 0)
                cart.Add(product);
            product.cartAmount++;

            // Obliczanie ceny 
            decimal result = 0;
            foreach (Product p in cart)
            {
                result += p.price * p.cartAmount;
            }
            PriceLabel.Content = $"Cena: {result} zł";

            ProductsListBox.SelectedIndex = -1;
            //AddButton.IsEnabled = false;
            OrderButton.IsEnabled = true;
            CartListBox.Items.Refresh();
            MessageBox.Show($"Dodano {product.name} do koszyka.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
