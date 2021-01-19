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
        private Dictionary<string, Client> clientsMap;

        /* Konstruktor */
        public MainWindow()
        {
            InitializeComponent();
            clientsMap = DataBase.GetClientsMap();
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
