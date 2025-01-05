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

        public void ProcessOrders()
        {
            foreach (var order in Orders)
            {
                if (order.Status == "In asteptare")
                {
                    order.Status = "In curs de livrare";
                    order.DeliveryDate = DateTime.Now.AddDays(3); 
                }
            }
        }

        public List<Comanda> GetDeliveredOrders()
        {
            foreach (var order in Orders)
            {
                if (order.DeliveryDate < DateTime.Now)
                {
                    order.Status = "Livrat";
                }
            }

            return Orders.Where(o => o.Status == "Livrat").ToList();
        }
    }
}
