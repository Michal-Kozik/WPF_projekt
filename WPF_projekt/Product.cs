using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_projekt
{
    public class Product
    {
        // Pola.
        public static int freeID { get; set; }
        public int id { get; set; }
        public string imagePath { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public decimal price { get; set; }
        // Zmienna do przechowywania ilosci w koszyku.
        public int cartAmount { get; set; }
        public int amount { get; set; }
        public string everythingToString
        {
            get { return $"Nazwa: {name}\nKategoria: {category}\nOpis: {description}\nCena: {price}\nIlość: {amount}"; }
        }

        // Konstruktory.
        static Product()
        {
            freeID = 0;
        }
        public Product()
        {
            id = freeID;
            freeID++;
            cartAmount = 0;
        }
    }
}
