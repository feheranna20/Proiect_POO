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

        public void UserMenu()
        {
            var cart = new List<Produs>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Meniu Utilizator ===\n");
                Console.WriteLine("1. Vezi toate produsele");
                Console.WriteLine("2. Cauta un produs dupa nume");
                Console.WriteLine("3. Sorteaza produsele dupa pret");
                Console.WriteLine("4. Adauga produsul in cos");
                Console.WriteLine("5. Vezi cosul");
                Console.WriteLine("6. Plaseaza comanda");
                Console.WriteLine("0. Inapoi la meniul principal");
                Console.Write("Alege o optiune: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ViewAllProducts();
                        break;
                    case "2":
                        SearchProductByName();
                        break;
                    case "3":
                        SortProductsByPrice();
                        break;
                    case "4":
                        AddProductToCart(cart);
                        break;
                    case "5":
                        ViewCart(cart);
                        break;
                    case "6":
                        PlaceOrder(cart);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Optiune invalida. Apasa orice si incearca din nou.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void AdminMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Meniu Administrator ===\n");
                Console.WriteLine("1. Adauga un produs");
                Console.WriteLine("2. Scoate un produs");
                Console.WriteLine("3. Updateaza stocul");
                Console.WriteLine("4. Vezi comenzile");
                Console.WriteLine("5. Proceseaza comenzile");
                Console.WriteLine("0. Inapoi la meniul principal");
                Console.Write("Alege o optiune: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        RemoveProduct();
                        break;
                    case "3":
                        UpdateStock();
                        break;
                    case "4":
                        ViewOrders();
                        break;
                    case "5":
                        ProcessOrders();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Optiune invalida. Apasa orice si incearca din nou.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ViewAllProducts()
        {
            Console.Clear();
            Console.WriteLine("=== Toate Produsele ===");
            foreach (var product in magazin.Produse)
            {
                Console.WriteLine(product.GetDetails());
            }
            Console.WriteLine("Apasati orice pentru a va intoarce.");
            Console.ReadKey();
        }

        private void SearchProductByName()
        {
            Console.Write("Introduceti numele produsului cautat: ");
            string name = Console.ReadLine();
            var results = magazin.Produse.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

            if (results.Count > 0)
            {
                foreach (var product in results)
                {
                    Console.WriteLine(product.GetDetails());
                }
            }
            else
            {
                Console.WriteLine("Nici un produs gasit.");
            }
            Console.WriteLine("Apasati orice pentru a va intoarce.");
            Console.ReadKey();
        }

        private void SortProductsByPrice()
        {
            Console.Write("Sorteaza dupa pret (1 pentru Crescator, 2 pentru Descrescator): ");
            string sortChoice = Console.ReadLine();
            var sorted = sortChoice == "1" ? magazin.Produse.OrderBy(p => p.Price) : magazin.Produse.OrderByDescending(p => p.Price);

            foreach (var product in sorted)
            {
                Console.WriteLine(product.GetDetails());
            }
            Console.WriteLine("Apasati orice pentru a va intoarce.");
            Console.ReadKey();
        }

        private void AddProductToCart(List<Produs> cart)
        {
            Console.Write("Introduceti numele produsului pentru a-l adauga in cos: ");
            string name = Console.ReadLine();
            var product = magazin.Produse.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (product != null)
            {
                cart.Add(product);
                Console.WriteLine("Produs adaugat in cos.");
            }
            else
            {
                Console.WriteLine("Produsul nu a fost gasit.");
            }
            Console.WriteLine("Apasati orice pentru a va intoarce.");
            Console.ReadKey();
        }

        private void ViewCart(List<Produs> cart)
        {
            Console.Clear();
            Console.WriteLine("=== Cosul Dumneavoastra ===");
            foreach (var product in cart)
            {
                Console.WriteLine(product.GetDetails());
            }
            Console.WriteLine("Apasati orice pentru a va intoarce.");
            Console.ReadKey();
        }

        private void PlaceOrder(List<Produs> cart)
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
            Console.WriteLine("Apasati orice pentru a va intoarce.");
            Console.ReadKey();
        }

        private void AddProduct()
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

        private void SalveazaProduseInFisier()
        {
            File.WriteAllLines(ProduseFilePath, magazin.Produse.Select(p => $"{p.Name}|{p.Price}|{p.Stock}"));
        }

        private void IncarcaProduseDinFisier()
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

        private void SalveazaComenziInFisier()
        {
            File.WriteAllLines(ComenziFilePath, magazin.Comenzi.Select(c => $"{c.CustomerName}|{c.Status}|{c.DeliveryDate}"));
        }

        private void IncarcaComenziDinFisier()
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
    }
}
