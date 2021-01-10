using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_projekt
{
    public class Product
    {
        // pola
        public static int freeID { get; set; }
        public int id { get; set; }

        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int amount { get; set; }
        public string everythingToString
        {
            get { return $"Nazwa: {name}\nOpis: {description}\nCena: {price}\nIlość: {amount}"; }
        }

        // konstruktory
        static Product()
        {
            freeID = 0;
        }
        public Product()
        {
            id = freeID;
            freeID++;
        }

        // metody
    }
}
