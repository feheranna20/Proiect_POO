using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinOnline
{
    public class Generice : Produs
    {
        public Generice(string name, decimal price, int stock) : base(name, price, stock) { }

        public override string GetDetails()
        {
            return $"Name: {Name}, Price: {Price}, Stock: {Stock}";
        }
    }
}
