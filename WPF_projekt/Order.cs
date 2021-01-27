using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_projekt
{
    public class Order
    {
        // Pola.
        public string id { get; set; }
        public Client client { get; set; }
        public Collection<Product> products { get; set; }
        public decimal price { get; set; }
        public string details { get; set; }
        public string everythingToString { get; }

        // Konstruktory.
        public Order(string id, Collection<Product> products, Client client)
        {
            this.id = id;
            this.products = products;
            this.client = client;
            details = "";
            price = 0;
            everythingToString = $"ID: {id}\nLogin: {client.login}\nNr telefonu: {client.PhoneNumber}\n";
            foreach (Product p in products)
            {
                details += $"- {p.name} x{p.cartAmount}\n";
                price += p.price * p.cartAmount;
            }
            everythingToString += $"Cena: {price}";
            details += $"\nCena: {price} zł";
        }
    }
}
