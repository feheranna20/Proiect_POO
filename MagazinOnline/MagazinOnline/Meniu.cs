using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MagazinOnline
{
    internal class Meniu
    {
        private Magazin magazin;
        private const string ProduseFilePath = "produse.txt";
        private const string ComenziFilePath = "comenzi.txt";

        public Meniu(Magazin magazin)
        {
            this.magazin = magazin;
            IncarcaProduseDinFisier();
            IncarcaComenziDinFisier();
        }

        public void ViewAllProducts()
        {
            Console.Clear();
            Console.WriteLine("=== Toate Produsele ===");
            foreach (var product in magazin.Produse)
            {
                Console.WriteLine(product.GetDetails());
            }
            Console.WriteLine("Apasati orice tasta pentru a va intoarce.");
            Console.ReadKey();
        }

        public void SearchProductByName()
        {
            Console.Write("Introduceti numele produsului cautat: ");
            string name = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Numele produsului nu poate fi gol.");
                return;
            }

            List<Produs> results = new List<Produs>();

            foreach (var product in magazin.Produse)
            {
                string productNameLower = product.Name.ToLower();
                string searchNameLower = name.ToLower();

                if (productNameLower.Contains(searchNameLower))
                {
                    results.Add(product);
                }
            }

            if (results.Count > 0)
            {
                foreach (var product in results)
                {
                    Console.WriteLine(product.GetDetails());
                }
            }
            else
            {
                Console.WriteLine("Nu s-a gasit niciun produs care sa corespunda cautarii.");
            }

            Console.WriteLine("Apasati orice tasta pentru a va intoarce.");
            Console.ReadKey();
        }

        public void SortProductsByPrice()
        {
            Console.Write("Sorteaza dupa pret (1 pentru Crescator, 2 pentru Descrescator): ");
            string sortChoice = Console.ReadLine();

            List<Produs> sorted;

            if (sortChoice == "1")
            {
                sorted = magazin.Produse.OrderBy(p => p.Price).ToList();
            }
            else if (sortChoice == "2")
            {
                sorted = magazin.Produse.OrderByDescending(p => p.Price).ToList();
            }
            else
            {
                Console.WriteLine("Optiune invalida.");
                return;
            }

            foreach (var product in sorted)
            {
                Console.WriteLine(product.GetDetails());
            }

            Console.WriteLine("Apasati orice tasta pentru a va intoarce.");
            Console.ReadKey();
        }

        public void AddProductToCart(List<Produs> cart)
        {
            Console.Write("Introduceti numele produsului pentru a-l adauga in cos: ");
            string name = Console.ReadLine();

            Produs product = null;

            foreach (var p in magazin.Produse)
            {
                if (p.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    product = p;
                    break;
                }
            }

            if (product != null)
            {
                cart.Add(product);
                Console.WriteLine("Produs adaugat in cos.");
            }
            else
            {
                Console.WriteLine("Produsul nu a fost gasit.");
            }

            Console.WriteLine("Apasati orice tasta pentru a va intoarce.");
            Console.ReadKey();
        }

        public void ViewCart(List<Produs> cart)
        {
            Console.Clear();
            Console.WriteLine("=== Cosul Dumneavoastra ===");
            foreach (var product in cart)
            {
                Console.WriteLine(product.GetDetails());
            }
            Console.WriteLine("Apasati orice tasta pentru a va intoarce.");
            Console.ReadKey();
        }

        public void PlaceOrder(List<Produs> cart)
        {
            Console.Write("Numele: ");
            string name = Console.ReadLine();
            Console.Write("Numarul de telefon: ");
            string phone = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Adresa: ");
            string address = Console.ReadLine();

            var order = new Comanda(name, phone, email, address, new List<Produs>(cart), DateTime.Now.AddDays(3));
            magazin.SalveazaComanda(order);
            SalveazaComenziInFisier();
            cart.Clear();

            Console.WriteLine("Comanda a fost plasata cu succes.");
            Console.WriteLine("Apasati orice tasta pentru a va intoarce.");
            Console.ReadKey();
        }

        public void AddProduct()
        {
            Console.Write("Introduceti numele produsului: ");
            string name = Console.ReadLine();
            Console.Write("Introduceti pretul: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Introduceti stocul: ");
            int stock = int.Parse(Console.ReadLine());

            var product = new Generice(name, price, stock);
            magazin.AdaugaProdus(product);
            SalveazaProduseInFisier();

            Console.WriteLine("Produs adaugat cu succes.");
            Console.ReadKey();
        }

        public void SalveazaProduseInFisier()
        {
            File.WriteAllLines(ProduseFilePath, magazin.Produse.Select(p => $"{p.Name}|{p.Price}|{p.Stock}"));
        }

        public void IncarcaProduseDinFisier()
        {
            if (File.Exists(ProduseFilePath))
            {
                var lines = File.ReadAllLines(ProduseFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    magazin.AdaugaProdus(new Generice(parts[0], decimal.Parse(parts[1]), int.Parse(parts[2])));
                }
            }
        }

        public void SalveazaComenziInFisier()
        {
            File.WriteAllLines(ComenziFilePath, magazin.Comenzi.Select(c => $"{c.CustomerName}|{c.Status}|{c.DeliveryDate}"));
        }

        public void IncarcaComenziDinFisier()
        {
            if (File.Exists(ComenziFilePath))
            {
                var lines = File.ReadAllLines(ComenziFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    magazin.SalveazaComanda(new Comanda(parts[0], "", "", "", new List<Produs>(), DateTime.Parse(parts[2])));
                }
            }
        }

        public void RemoveProduct()
        {
            Console.Write("Introduceti numele produsului de eliminat: ");
            string name = Console.ReadLine();
            magazin.ScoateProdus(name);
            Console.WriteLine("Produsul a fost eliminat cu succes.");
            Console.WriteLine("Apasati orice tasta pentru a reveni.");
            Console.ReadKey();
        }

        public void UpdateStock()
        {
            Console.Write("Introduceti numele produsului: ");
            string name = Console.ReadLine();
            Console.Write("Introduceti noua valoare a stocului: ");
            int newStock = int.Parse(Console.ReadLine());
            magazin.ActualizeazaStoc(name, newStock);
            Console.WriteLine("Stocul a fost actualizat cu succes.");
            Console.WriteLine("Apasati orice tasta pentru a reveni.");
            Console.ReadKey();
        }


        public void ViewOrders()
        {
            Console.Clear();
            Console.WriteLine("=== Toate Comenzile ===");
            foreach (var order in magazin.Comenzi)
            {
                Console.WriteLine($"Client: {order.CustomerName}, Status: {order.Status}, Data livrarii: {order.DeliveryDate}");
            }
            Console.WriteLine("Apasati orice tasta pentru a reveni.");
            Console.ReadKey();
        }

        public void ProcessOrders()
        {
            foreach (var order in magazin.Comenzi.Where(o => o.Status == "In asteptare"))
            {
                order.Status = "În curs de livrare";
                order.DeliveryDate = DateTime.Now.AddDays(3);
            }
            Console.WriteLine("Comenzile au fost procesate cu succes.");
            Console.WriteLine("Apasati orice tasta pentru a reveni.");
            Console.ReadKey();
        }

    }
}
