using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinOnline
{
    public class ServiciiComanda
    {
        public List<Comanda> Orders { get; private set; } = new List<Comanda>();

        public void PlaceOrder(Comanda order)
        {
            if (order != null)
            {
                Orders.Add(order);
            }
            else
            {
                throw new ArgumentNullException(nameof(order), "Order cannot be null");
            }
        }

    }
}
