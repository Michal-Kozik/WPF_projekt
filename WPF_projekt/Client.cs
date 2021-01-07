using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_projekt
{
    public class Client
    {
        //pola
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Details { get; set; }
        public string EverythingToString
        {
            get { return $"Imię: {Name}\nNazwisko: {Surname}\nNr telefonu: {PhoneNumber}"; }
        }

        //metody
    }
}
