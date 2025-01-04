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
    }
}