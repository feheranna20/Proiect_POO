namespace MagazinOnline
{
    internal class Program
    {
        private static Magazin magazin = new Magazin();
        private static Meniu meniu = new Meniu(magazin);

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Meniu Principal ===\n");
                Console.WriteLine("1. Meniu Utilizator");
                Console.WriteLine("2. Meniu Administrator");
                Console.WriteLine("0. Iesire");
                Console.Write("Alege optiunea: ");

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
                        Console.WriteLine("Optiune invalida. Apasa orice si incearca din nou.");
                        Console.ReadKey();
                        break;
                }
            }

            static void UserMenu()
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
                            meniu.ViewAllProducts();
                            break;
                        case "2":
                            meniu.SearchProductByName();
                            break;
                        case "3":
                            meniu.SortProductsByPrice();
                            break;
                        case "4":
                            meniu.AddProductToCart(cart);
                            break;
                        case "5":
                            meniu.ViewCart(cart);
                            break;
                        case "6":
                            meniu.PlaceOrder(cart);
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Optiune invalida. Apasa orice tasta si incearca din nou.");
                            Console.ReadKey();
                            break;
                    }
                }
            }

            static void AdminMenu()
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
                            meniu.AddProduct();
                            break;
                        case "2":
                            meniu.RemoveProduct();
                            break;
                        case "3":
                            meniu.UpdateStock();
                            break;
                        case "4":
                            meniu.ViewOrders();
                            break;
                        case "5":
                            meniu.ProcessOrders();
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
        }
    }
}
