using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinOnline
{
    public class Comanda
    {
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<Produs> Products { get; set; } = new List<Produs>();
        public string Status { get; set; } = "In asteptare";
        public DateTime DeliveryDate { get; set; }

        public Comanda(string customerName, string phone, string email, string address, List<Produs> products, string status, DateTime deliveryDate) 
        { 
            CustomerName = customerName;
            Phone = phone;
            Email = email;
            Address = address;
            Products = products;
            Status = status;
            DeliveryDate = deliveryDate;
        }
    }
}
