using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MagazinOnline
{
        internal class Functionalitati
        {
            private Magazin magazin;
            private const string ProduseFilePath = "produse.txt";
            private const string ComenziFilePath = "comenzi.txt";

            public Functionalitati(Magazin magazin)
            {
                this.magazin = magazin;
                try
                {
                    IncarcaProduseDinFisier();
                    IncarcaComenziDinFisier();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Eroare la initializare: {ex.Message}");
                }
            }

            public void ViewAllProducts()
            {
                try
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
                catch (Exception ex)
                {
                    Console.WriteLine($"Eroare la vizualizarea produselor: {ex.Message}");
                }
            }

            public void SearchProductByName()
            {
                try
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
                catch (Exception ex)
                {
                    Console.WriteLine($"Eroare la cautarea produsului: {ex.Message}");
                }
            }

            public void SortProductsByPrice()
            {
                try
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
                catch (Exception ex)
                {
                    Console.WriteLine($"Eroare la sortarea produselor: {ex.Message}");
                }
            }

            public void AddProductToCart(List<Produs> cart)
            {
                try
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
                catch (Exception ex)
                {
                    Console.WriteLine($"Eroare la adaugarea produsului în cos: {ex.Message}");
                }
            }

            public void ViewCart(List<Produs> cart)
            {
                try
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
                catch (Exception ex)
                {
                    Console.WriteLine($"Eroare la vizualizarea cosului: {ex.Message}");
                }
            }

            public void PlaceOrder(List<Produs> cart)
            {
                try
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
                catch (Exception ex)
                {
                    Console.WriteLine($"Eroare la plasarea comenzii: {ex.Message}");
                }
            }

        public void AddProduct()
        {
            try
            {
                Console.WriteLine("Alege tipul produsului:");
                Console.WriteLine("1. Generice");
                Console.WriteLine("2. Electrocasnice");
                Console.WriteLine("3. Perisabile");
                Console.Write("Introduceti optiunea dorita (1/2/3): ");
                int option = int.Parse(Console.ReadLine());

                Console.Write("Introduceti numele produsului: ");
                string name = Console.ReadLine();
                Console.Write("Introduceti pretul: ");
                decimal price = decimal.Parse(Console.ReadLine());
                Console.Write("Introduceti stocul: ");
                int stock = int.Parse(Console.ReadLine());

                Produs product = null;

                
                switch (option)
                {
                    case 1: 
                        product = new Generice(name, price, stock);
                        break;
                    case 2: 
                        Console.Write("Introduceti clasa de eficienta energetica: ");
                        string energyEfficiencyClass = Console.ReadLine();
                        Console.Write("Introduceti puterea maxima: ");
                        int maxPower = int.Parse(Console.ReadLine());
                        product = new Electrocasnice(name, price, stock, energyEfficiencyClass, maxPower);
                        break;
                    case 3: 
                        Console.Write("Introduceti data expirarii (ex: 2025-12-31): ");
                        DateTime expiryDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Introduceti conditiile de depozitare: ");
                        string storageConditions = Console.ReadLine();
                        product = new Perisabile(name, price, stock, expiryDate, storageConditions);
                        break;
                    default:
                        Console.WriteLine("Optiune invalida.");
                        return;
                }

                
                magazin.AdaugaProdus(product);
                SalveazaProduseInFisier();

                Console.WriteLine("Produs adaugat cu succes.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la adaugarea produsului: {ex.Message}");
            }
            Console.ReadKey();
        }


        public void SalveazaProduseInFisier()
        {
            try
            {
                var lines = magazin.Produse.Select(p =>
                {
                    if (p is Generice)
                    {
                        var product = (Generice)p;
                        return $"Generice|{product.Name}|{product.Price}|{product.Stock}";
                    }
                    else if (p is Electrocasnice)
                    {
                        var product = (Electrocasnice)p;
                        return $"Electrocasnice|{product.Name}|{product.Price}|{product.Stock}|{product.EnergyEfficiencyClass}|{product.MaxPower}";
                    }
                    else if (p is Perisabile)
                    {
                        var product = (Perisabile)p;
                        return $"Perisabile|{product.Name}|{product.Price}|{product.Stock}|{product.ExpiryDate:yyyy-MM-dd}|{product.StorageConditions}";
                    }
                    else
                    {
                        return string.Empty;
                    }
                });

                File.WriteAllLines(ProduseFilePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la salvarea produselor in fisier: {ex.Message}");
            }
        }


        public void IncarcaProduseDinFisier()
        {
            try
            {
                if (File.Exists(ProduseFilePath))
                {
                    var lines = File.ReadAllLines(ProduseFilePath);
                    foreach (var line in lines)
                    {
                        var parts = line.Split('|');

                        
                        switch (parts[3])
                        {
                            case "Generice":
                                magazin.AdaugaProdus(new Generice(parts[0], decimal.Parse(parts[1]), int.Parse(parts[2])));
                                break;

                            case "Electrocasnice":
                                var energyEfficiencyClass = parts[4];
                                var maxPower = int.Parse(parts[5]);
                                magazin.AdaugaProdus(new Electrocasnice(parts[0], decimal.Parse(parts[1]), int.Parse(parts[2]), energyEfficiencyClass, maxPower));
                                break;

                            case "Perisabile":
                                var expiryDate = DateTime.Parse(parts[4]);
                                var storageConditions = parts[5];
                                magazin.AdaugaProdus(new Perisabile(parts[0], decimal.Parse(parts[1]), int.Parse(parts[2]), expiryDate, storageConditions));
                                break;

                            default:
                                Console.WriteLine("Tip de produs necunoscut.");
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la incarcarea produselor din fisier: {ex.Message}");
            }
        }


        public void SalveazaComenziInFisier()
            {
                try
                {
                    File.WriteAllLines(ComenziFilePath, magazin.Comenzi.Select(c => $"{c.CustomerName}|{c.Status}|{c.DeliveryDate}"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Eroare la salvarea comenzilor in fisier: {ex.Message}");
                }
            }

            public void IncarcaComenziDinFisier()
            {
                try
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
                catch (Exception ex)
                {
                    Console.WriteLine($"Eroare la incarcarea comenzilor din fisier: {ex.Message}");
                }
            }

        public void RemoveProduct()
        {
            try
            {
                Console.Write("Introduceti numele produsului de eliminat: ");
                string name = Console.ReadLine();

                Produs productToRemove = null;

                foreach (var product in magazin.Produse)
                {
                    if (product.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        productToRemove = product;
                        break;
                    }
                }

                if (productToRemove != null)
                {
                    magazin.Produse.Remove(productToRemove);
                    Console.WriteLine("Produsul a fost eliminat cu succes.");

                    SalveazaProduseInFisier();
                }
                else
                {
                    Console.WriteLine("Produsul nu a fost gasit.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la eliminarea produsului: {ex.Message}");
            }
            Console.ReadKey();
        }


        public void UpdateStock()
            {
                try
                {
                    Console.Write("Introduceti numele produsului: ");
                    string name = Console.ReadLine();
                    Console.Write("Introduceti noua valoare a stocului: ");
                    int newStock = int.Parse(Console.ReadLine());
                    magazin.ActualizeazaStoc(name, newStock);
                    Console.WriteLine("Stocul a fost actualizat cu succes.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Eroare la actualizarea stocului: {ex.Message}");
                }
                Console.ReadKey();
            }

        public void ViewOrders()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Toate Comenzile ===");
                if (magazin.Comenzi.Count == 0)
                {
                    Console.WriteLine("Nu sunt comenzi disponibile.");
                }
                else
                {
                    foreach (var order in magazin.Comenzi)
                    {
                        Console.WriteLine($"Client: {order.CustomerName}, Status: {order.Status}, Data livrarii: {order.DeliveryDate}");
                    }
                }
                Console.WriteLine("Apasati orice tasta pentru a reveni.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la vizualizarea comenzilor: {ex.Message}");
            }
        }

        public void ProcessOrders()
        {
            try
            {
                bool ordersProcessed = false;

                foreach (var order in magazin.Comenzi.Where(o => o.Status == "In asteptare"))
                {
                    order.Status = "In curs de livrare";
                    order.DeliveryDate = DateTime.Now.AddDays(3);
                    ordersProcessed = true;
                }

                if (ordersProcessed)
                {
                    Console.WriteLine("Comenzile au fost procesate cu succes.");
                }
                else
                {
                    Console.WriteLine("Nu exista comenzi in asteptare.");
                }

                Console.WriteLine("Apasati orice tasta pentru a reveni.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la procesarea comenzilor: {ex.Message}");
            }
        }

    }
}
