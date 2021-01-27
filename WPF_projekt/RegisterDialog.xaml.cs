using System;
using System.Collections.Generic;
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
    /// Interaction logic for RegisterDialog.xaml
    /// </summary>
    public partial class RegisterDialog : Window
    {
        int loginPassed;
        int passwordPassed;
        int namePassed;
        int surnamePassed;
        int phonePassed;

        public RegisterDialog()
        {
            InitializeComponent();
        }

        
        private void CreateAccount(object sender, RoutedEventArgs e)
        {
            /*
            bool accepted = true;

            // Walidacja loginu.
            if (LoginTextBox.Text == "")
            {
                ValidateLoginLabel.Content = "Login nie może być pusty.";
                accepted = false;
            }
            else
            {
                if (LoginTextBox.Text.Length > 20)
                {
                    ValidateLoginLabel.Content = "Login nie może mieć więcej niż 20 znaków.";
                    accepted = false;
                } 
            }
            
            // Walidacja hasla.
            if (PasswordTextBox.Text == "")
            {
                ValidatePasswordLabel.Content = "Hasło nie może być puste.";
                accepted = false;
            }

            // Walidacja imienia.
            if (NameTextBox.Text == "")
            {
                ValidateNameLabel.Content = "Imię nie może być puste.";
                accepted = false;
            }
            else
            {
                if (NameTextBox.Text.Length > 20)
                {
                    ValidateNameLabel.Content = "Imię nie może mieć więcej niż 20 znaków.";
                    accepted = false;
                }
            }

            // Walidacja nazwiska.
            if (SurnameTextBox.Text == "")
            {
                ValidateSurnameLabel.Content = "Nazwisko nie może być puste.";
                accepted = false;
            }
            else
            {
                if (SurnameTextBox.Text.Length > 25)
                {
                    ValidateSurnameLabel.Content = "Nazwisko nie może mieć więcej niż 25 znaków.";
                    accepted = false;
                }
            }

            // Walidacja numeru telefonu.
            if (PhoneNumberTextBox.Text == "")
            {
                ValidatePhoneNumberLabel.Content = "Nr telefonu nie może być pusty.";
                accepted = false;
            }
            else
            {
                foreach (char c in PhoneNumberTextBox.Text)
                {
                    if (c < '0' || c > '9')
                    {
                        ValidatePhoneNumberLabel.Content = "Nr telefonu musi zawierać same cyfry.";
                        accepted = false;
                    }
                }
                if (PhoneNumberTextBox.Text.Length != 9)
                {
                    ValidatePhoneNumberLabel.Content = "Nr telefony musi składać się z 9 cyfr.";
                    accepted = false;
                } 
            }
            */

            if (loginPassed + passwordPassed + namePassed + surnamePassed + phonePassed != 5)
            {
                MessageBox.Show("Nie wszystkie pola wypełniono poprawnie.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string login = LoginTextBox.Text;
                string password = PasswordTextBox.Text;
                string name = NameTextBox.Text;
                string surname = SurnameTextBox.Text;
                string phoneNumber = PhoneNumberTextBox.Text;

                Client client = new Client(login, password, name, surname, phoneNumber);
                DataBase.AddClient(client);
                MessageBox.Show("Utworzenie użytkownika zakończyło się powodzeniem.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }
        

        // Walidacja loginu
        private void ValidateLogin(object sender, RoutedEventArgs e)
        {
            TextBox item = sender as TextBox;
            if (item.Text == "")
            {
                ValidateLoginLabel.Content = "Login nie może być pusty.";
                loginPassed = 0;
                return;
            }
            else
            {
                if (item.Text.Length > 20)
                {
                    ValidateLoginLabel.Content = "Login nie może zawierać więcej niż 20 znaków.";
                    loginPassed = 0;
                    return;
                }
            }

            ValidateLoginLabel.Content = null;
            loginPassed = 1;
        }

        // Walidacja hasla.
        private void ValidatePassword(object sender, RoutedEventArgs e)
        {
            TextBox item = sender as TextBox;
            if (item.Text == "")
            {
                ValidatePasswordLabel.Content = "Hasło nie może być puste.";
                passwordPassed = 0;
                return;
            }

            ValidatePasswordLabel.Content = null;
            passwordPassed = 1;
        }

        // Walidacja imienia.
        private void ValidateName(object sender, RoutedEventArgs e)
        {
            TextBox item = sender as TextBox;
            if (item.Text == "")
            {
                ValidateNameLabel.Content = "Imię nie może być puste.";
                namePassed = 0;
                return;
            }
            else
            {
                if (item.Text.Length > 20)
                {
                    ValidateNameLabel.Content = "Imię nie może zawierać więcej niż 20 znaków.";
                    namePassed = 0;
                    return;
                }
            }

            ValidateNameLabel.Content = null;
            namePassed = 1;
        }

        // Walidacja nazwiska.
        private void ValidateSurname(object sender, RoutedEventArgs e)
        {
            TextBox item = sender as TextBox;
            if (item.Text == "")
            {
                ValidateSurnameLabel.Content = "Nazwisko nie może być puste.";
                surnamePassed = 0;
                return;
            }
            else
            {
                if (item.Text.Length > 25)
                {
                    ValidateSurnameLabel.Content = "Nazwisko nie może zawierać więcej niż 25 znaków.";
                    surnamePassed = 0;
                    return;
                }
            }

            ValidateSurnameLabel.Content = null;
            surnamePassed = 1;
        }

        // Walidacja nr telefonu.
        private void ValidatePhoneNumber(object sender, RoutedEventArgs e)
        {
            TextBox item = sender as TextBox;
            if (item.Text == "")
            {
                ValidatePhoneNumberLabel.Content = "Nr telefonu nie może być pusty.";
                phonePassed = 0;
                return;
            }
            else
            {
                if (item.Text.Length != 9)
                {
                    ValidatePhoneNumberLabel.Content = "Nr telefonu musi składać się z 9 cyfr.";
                    phonePassed = 0;
                    return;
                }
                else
                {
                    foreach (char c in item.Text)
                    {
                        if (c < '0' || c > '9')
                        {
                            ValidatePhoneNumberLabel.Content = "Nr telefonu może zawierać tylko cyfry.";
                            phonePassed = 0;
                            return;
                        }
                    }
                }
            }

            ValidatePhoneNumberLabel.Content = null;
            phonePassed = 1;
        }

        // Wcisniecie przycisku 'Anuluj'.
        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
