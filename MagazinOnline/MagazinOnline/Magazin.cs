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
            Produse.Add(produs);
        }

        public void ScoateProdus(string name)
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

        public void ActualizeazaStoc(string name, int newStock)
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
        public void SalveazaComanda(Comanda comanda)
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
        
    }
}
