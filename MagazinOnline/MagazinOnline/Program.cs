namespace MagazinOnline
{
    internal class Program
    {
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
                        
                        break;
                    case "2":
                        
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
                Console.WriteLine("=== User Menu ===");
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
                        
                        break;
                    case "2":
                        
                        break;
                    case "3":
                        
                        break;
                    case "4":
                        
                        break;
                    case "5":
                        
                        break;
                    case "6":
                        
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
                Console.WriteLine("=== Admin Menu ===");
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
                        
                        break;
                    case "2":
                        
                        break;
                    case "3":
                        
                        break;
                    case "4":
                        
                        break;
                    case "5":
                        
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
    }
}