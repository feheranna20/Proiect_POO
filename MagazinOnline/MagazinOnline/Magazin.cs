using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinOnline
{
    public class Magazin
    {
        public List<Produs> Produse { get; private set; } = new List<Produs>();
        public List<Comanda> Comenzi { get; private set; } = new List<Comanda>();

        public void AdaugaProdus(Produs produs)
        {
            try
            {
                Produse.Add(produs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la adaugarea produsului: {ex.Message}");
            }
        }

        public void ScoateProdus(string name)
        {
            try
            {
                var produs = Produse.FirstOrDefault(p => p.Name == name);
                if (produs != null)
                {
                    Produse.Remove(produs);
                }
                else
                {
                    throw new Exception("Produsul nu a fost gasit.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la stergerea produsului: {ex.Message}");
            }
        }

        public void ActualizeazaStoc(string name, int newStock)
        {
            try
            {
                var produs = Produse.FirstOrDefault(p => p.Name == name);
                if (produs != null)
                {
                    produs.Stock = newStock;
                }
                else
                {
                    throw new Exception("Produsul nu a fost gasit.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la actualizarea stocului: {ex.Message}");
            }
        }

        public void SalveazaComanda(Comanda comanda)
        {
            try
            {
                if (comanda != null)
                {
                    Comenzi.Add(comanda);
                }
                else
                {
                    throw new ArgumentNullException(nameof(comanda), "Comanda nu poate fi null.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la salvarea comenzii: {ex.Message}");
            }
        }
    }
}
