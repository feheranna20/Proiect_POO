using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinOnline
{
    public class Perisabile : Produs
    {
        public DateTime ExpiryDate { get; set; }
        public string StorageConditions { get; set; }
        public Perisabile(string name, decimal price, int stock, DateTime expiryDate, string storageConditions) : base(name, price, stock)
        { 
            ExpiryDate = expiryDate;
            StorageConditions = storageConditions;
        }

        public override string GetDetails()
        {
            return $"Name: {Name}, Price: {Price}, Stock: {Stock}, Expiry date: {ExpiryDate}, Storage conditions: {StorageConditions}";
        }
    }
}
