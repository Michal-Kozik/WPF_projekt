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
        // pola
        public int id { get; set; }
        public Client client { get; set; }
        public Collection<Product> products { get; set; }
        public decimal price { get; set; }
        public string details { get; set; }
        public string everythingToString { get; }

        // konstruktory
        public Order(int id, Collection<Product> products, Client client)
        {
            this.id = id;
            this.products = products;
            this.client = client;
            details = $"Imię kupującego: {client.name}, Nazwisko kupującego: {client.surname}";
            price = 0;
            everythingToString = $"ID: {id}\nNr telefonu: {client.phoneNumber}\nProdukty:\n";
            foreach (Product p in products)
            {
                everythingToString += $"- {p.name}\n";
                price += p.price;
            }
            everythingToString += $"Cena: {price}";
        }

        // metody
    }
}
