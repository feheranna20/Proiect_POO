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
                        meniu.UserMenu();
                        break;
                    case "2":
                        meniu.AdminMenu();
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
