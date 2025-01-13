namespace MagazinOnline
{
    internal class Meniu
    {
        private Magazin magazin;

        public Meniu(Magazin magazin)
        {
            this.magazin = magazin;
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
            var sorted = magazin.Produse
                .OrderBy(p => sortChoice == "1" ? p.Price : -p.Price)
                .ToList();

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
            cart.Clear();

            Console.WriteLine("Comanda a fost plasata cu succes.");
            Console.WriteLine("Apasati orice pentru a va intoarce.");
            Console.ReadKey();
        }

        private void AddProduct()
        {
            Console.Write("Intruduceti tipul produsului (1-Generice, 2-Perisabile, 3-Electrocasnice): ");
            string type = Console.ReadLine();
            Console.Write("Introduceti numele produsului: ");
            string name = Console.ReadLine();
            Console.Write("Introduceti pretul produsului: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Introduceti numarul de produse in stoc: ");
            int stock = int.Parse(Console.ReadLine());

            Produs product = null;

            switch (type)
            {
                case "1":
                    product = new Generice(name, price, stock);
                    break;
                case "2":
                    Console.Write("Introduceti data de expirare (yyyy-mm-dd): ");
                    DateTime expiryDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Introduceti conditiile de depozitare: ");
                    string conditions = Console.ReadLine();
                    product = new Perisabile(name, price, stock, expiryDate, conditions);
                    break;
                case "3":
                    Console.Write("Introduceti clasa de eficienta energetica: ");
                    string efficiencyClass = Console.ReadLine();
                    Console.Write("Introduceti puterea maxima: ");
                    int maxPower = int.Parse(Console.ReadLine());
                    product = new Electrocasnice(name, price, stock, efficiencyClass, maxPower);
                    break;
                default:
                    Console.WriteLine("Tip invalid de produs.");
                    return;
            }

            magazin.AdaugaProdus(product);
            Console.WriteLine("Produs adaugat cu succes.");
            Console.WriteLine("Apasati orice pentru a va intoarce.");
            Console.ReadKey();
        }

        private void RemoveProduct()
        {
            Console.Write("Introduceti numele produsului care va fi sters: ");
            string name = Console.ReadLine();
            magazin.ScoateProdus(name);
            Console.WriteLine("Produsul a fost sters cu succes.");
            Console.WriteLine("Apasati orice pentru a va intoarce.");
            Console.ReadKey();
        }

        private void UpdateStock()
        {
            Console.Write("Introduceti numele produsului: ");
            string name = Console.ReadLine();
            Console.Write("Introduceti noul stoc: ");
            int newStock = int.Parse(Console.ReadLine());

            magazin.ActualizeazaStoc(name, newStock);
            Console.WriteLine("Stocul a fost updatat cu succes.");
            Console.WriteLine("Apasati orice pentru a va intoarce.");
            Console.ReadKey();
        }

        private void ViewOrders()
        {
            Console.Clear();
            Console.WriteLine("=== Toate Comenzile ===");
            foreach (var order in magazin.Comenzi)
            {
                Console.WriteLine($"Client: {order.CustomerName}, Status: {order.Status}, Data Livrarii: {order.DeliveryDate}");
            }
            Console.WriteLine("Apasati orice pentru a va intoarce.");
            Console.ReadKey();
        }

        private void ProcessOrders()
        {
            foreach (var order in magazin.Comenzi.Where(o => o.Status == "In asteptare"))
            {
                order.Status = "In curs de livrare";
                order.DeliveryDate = DateTime.Now.AddDays(3);
            }

            Console.WriteLine("Comenzile au fost plasate cu succes.");
            Console.WriteLine("Apasati orice pentru a va intoarce.");
            Console.ReadKey();
        }
    }
}
