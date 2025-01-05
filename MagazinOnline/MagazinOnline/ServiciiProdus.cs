using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinOnline
{
    public class ServiciiProdus
    {
        public List<Produs> Products { get; private set; } = new List<Produs>();

        public void AddProduct(Produs product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(string name)
        {
            var product = Products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                Products.Remove(product);
            }
            else
            {
                throw new Exception("Product not found.");
            }
        }

        public void UpdateStock(string name, int newStock)
        {
            var product = Products.FirstOrDefault(p => p.Name == name);
            if (product != null)
            {
                product.Stock = newStock;
            }
            else
            {
                throw new Exception("Product not found.");
            }
        }

        public List<Produs> SearchByName(string name)
        {
            return Products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Produs> SortByPrice(bool ascending = true)
        {
            return ascending
                ? Products.OrderBy(p => p.Price).ToList()
                : Products.OrderByDescending(p => p.Price).ToList();
        }
    }
}
