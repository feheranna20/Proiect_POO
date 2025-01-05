namespace MagazinOnline
{
    internal class Program
    {
        private static Magazin magazin = new Magazin();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Main Menu ===\n");
                Console.WriteLine("1. User Menu");
                Console.WriteLine("2. Administrator Menu");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        UserMenu();
                        break;
                    case "2":
                        AdminMenu();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void UserMenu()
        {
            var cart = new List<Produs>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== User Menu ===\n");
                Console.WriteLine("1. View All Products");
                Console.WriteLine("2. Search Product by Name");
                Console.WriteLine("3. Sort Products by Price");
                Console.WriteLine("4. Add Product to Cart");
                Console.WriteLine("5. View Cart");
                Console.WriteLine("6. Place Order");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Choose an option: ");

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
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void AdminMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Admin Menu ===\n");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Remove Product");
                Console.WriteLine("3. Update Stock");
                Console.WriteLine("4. View Orders");
                Console.WriteLine("5. Process Orders");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Choose an option: ");

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
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ViewAllProducts()
        {
            Console.Clear();
            Console.WriteLine("=== All Products ===");
            foreach (var product in magazin.Produse)
            {
                Console.WriteLine(product.GetDetails());
            }
            Console.WriteLine("Press any key to return.");
            Console.ReadKey();
        }

        private static void SearchProductByName()
        {
            Console.Write("Enter product name to search: ");
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
                Console.WriteLine("No products found.");
            }
            Console.WriteLine("Press any key to return.");
            Console.ReadKey();
        }

        private static void SortProductsByPrice()
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
            Console.WriteLine("Press any key to return.");
            Console.ReadKey();
        }

        private static void AddProductToCart(List<Produs> cart)
        {
            Console.Write("Enter product name to add to cart: ");
            string name = Console.ReadLine();
            var product = magazin.Produse.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (product != null)
            {
                cart.Add(product);
                Console.WriteLine("Product added to cart.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
            Console.WriteLine("Press any key to return.");
            Console.ReadKey();
        }

        private static void ViewCart(List<Produs> cart)
        {
            Console.Clear();
            Console.WriteLine("=== Your Cart ===");
            foreach (var product in cart)
            {
                Console.WriteLine(product.GetDetails());
            }
            Console.WriteLine("Press any key to return.");
            Console.ReadKey();
        }

        private static void PlaceOrder(List<Produs> cart)
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

            Console.WriteLine("Order placed successfully.");
            Console.WriteLine("Press any key to return.");
            Console.ReadKey();
        }

        private static void AddProduct()
        {
            Console.Write("Enter product type (1-Generice, 2-Perisabile, 3-Electrocasnice): ");
            string type = Console.ReadLine();
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter product price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter product stock: ");
            int stock = int.Parse(Console.ReadLine());

            Produs product = null;

            switch (type)
            {
                case "1":
                    product = new Generice(name, price, stock);
                    break;
                case "2":
                    Console.Write("Enter expiry date (yyyy-mm-dd): ");
                    DateTime expiryDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter storage conditions: ");
                    string conditions = Console.ReadLine();
                    product = new Perisabile(name, price, stock, expiryDate, conditions);
                    break;
                case "3":
                    Console.Write("Enter energy efficiency class: ");
                    string efficiencyClass = Console.ReadLine();
                    Console.Write("Enter max power: ");
                    int maxPower = int.Parse(Console.ReadLine());
                    product = new Electrocasnice(name, price, stock, efficiencyClass, maxPower);
                    break;
                default:
                    Console.WriteLine("Invalid product type.");
                    return;
            }

            magazin.AdaugaProdus(product);
            Console.WriteLine("Product added successfully.");
            Console.WriteLine("Press any key to return.");
            Console.ReadKey();
        }

        private static void RemoveProduct()
        {
            Console.Write("Enter product name to remove: ");
            string name = Console.ReadLine();
            magazin.ScoateProdus(name);
            Console.WriteLine("Product removed successfully.");
            Console.WriteLine("Press any key to return.");
            Console.ReadKey();
        }

        private static void UpdateStock()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter new stock value: ");
            int newStock = int.Parse(Console.ReadLine());

            magazin.ActualizeazaStoc(name, newStock);
            Console.WriteLine("Stock updated successfully.");
            Console.WriteLine("Press any key to return.");
            Console.ReadKey();
        }

        private static void ViewOrders()
        {
            Console.Clear();
            Console.WriteLine("=== All Orders ===");
            foreach (var order in magazin.Comenzi)
            {
                Console.WriteLine($"Customer: {order.CustomerName}, Status: {order.Status}, Delivery Date: {order.DeliveryDate}");
            }
            Console.WriteLine("Press any key to return.");
            Console.ReadKey();
        }

        private static void ProcessOrders()
        {
            foreach (var order in magazin.Comenzi.Where(o => o.Status == "In asteptare"))
            {
                order.Status = "In curs de livrare";
                order.DeliveryDate = DateTime.Now.AddDays(3);
            }

            Console.WriteLine("Orders processed successfully.");
            Console.WriteLine("Press any key to return.");
            Console.ReadKey();
        }
    }
}
