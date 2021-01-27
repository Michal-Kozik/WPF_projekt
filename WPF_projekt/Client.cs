using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_projekt
{
    public class Client
    {
        // Pola.
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length > 20)
                {
                    throw new ArgumentException("Imię musi być krótsze niż 20 znaków!");
                }
                name = value;
            }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                if (value.Length > 25)
                {
                    throw new ArgumentException("Nazwisko musi być krótsze niż 25 znaków!");
                }
                surname = value;
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value.Length != 9)
                    throw new ArgumentException("Nr telefonu musi mieć 9 cyfr!");
                foreach (char c in value)
                {
                    if (c < '0' || c > '9')
                        throw new ArgumentException("Nr telefonu nie może zawierać znaków innych niż cyfry!");
                }
                phoneNumber = value;
            }
        }

        public string details { get; set; }
        public string everythingToString
        {
            get { return $"Login: {login}\nNr telefonu: {phoneNumber}"; }
        }
        public string login { get; set; }
        public string password { get; set; }
        public bool adminRights { get; set; }

        /* Konstruktor */
        public Client(string login, string password, string name, string surname, string phoneNumber)
        {
            this.login = login;
            this.password = password;
            this.name = name;
            this.surname = surname;
            this.phoneNumber = phoneNumber;
            adminRights = false;
        }

        // Metody.
        public void MakeAdmin()
        {
            adminRights = true;
        }
    }
}
