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
    }
}
