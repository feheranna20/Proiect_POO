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
            Produs produsDeSters = null;
            foreach (var produs in Produse)
            {
                if (produs.Name == name)
                {
                    produsDeSters = produs;
                    break;
                }
            }

            if (produsDeSters != null)
            {
                Produse.Remove(produsDeSters);
            }
            else
            {
                throw new Exception("Produsul nu a fost gasit.");
            }
        }

        public void ActualizeazaStoc(string name, int newStock)
        {
            bool produsGasit = false;
            foreach (var produs in Produse)
            {
                if (produs.Name == name)
                {
                    produs.Stock = newStock;
                    produsGasit = true;
                    break;
                }
            }

            if (!produsGasit)
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
