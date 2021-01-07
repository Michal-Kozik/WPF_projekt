using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_projekt
{
    public class Product
    {
        //pola
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string EverythingToString
        {
            get { return $"Nazwa: {Name}\nOpis: {Description}\nCena: {Price}\nIlość: {Amount}"; }
        }

        //metody
        public override string ToString()
        {
            return $"{Name} {Description} {Price} {Amount}";
        }
    }
}
