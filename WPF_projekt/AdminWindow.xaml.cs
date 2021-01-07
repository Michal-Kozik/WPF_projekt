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
        public Collection<Product> Products { get; } = new ObservableCollection<Product>();

        public AdminWindow()
        {
            InitializeComponent();

            Products.Add(new Product { Name = "item1", Description = "dgshkjagfdkjhfga", Price = 9.99M, Amount = 10 });
            Products.Add(new Product { Name = "item2", Description = "dgshkjagfdkjhfga", Price = 19.99M, Amount = 11 });
            Products.Add(new Product { Name = "item3", Description = "dgshkjagfdkjhfga", Price = 29.99M, Amount = 12 });
        }

        private void LoadProducts(object sender, RoutedEventArgs e)
        {
            MagazineListBox.ItemsSource = Products;
        }
    }
}
