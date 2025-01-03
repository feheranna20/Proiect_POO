using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinOnline
{
    public class Perisabile : Produs
    {
        public Perisabile(string name, decimal price, int stock) : base(name, price, stock) { }
    }
}
