using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_projekt
{
    public class Client
    {
        // pola
        public string name { get; set; }
        public string surname { get; set; }
        public string phoneNumber { get; set; }
        public string details { get; set; }
        public string everythingToString
        {
            get { return $"Imię: {name}\nNazwisko: {surname}\nNr telefonu: {phoneNumber}"; }
        }

        // metody
    }
}
