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
            Produs productToRemove = null;
            foreach (var product in Products)
            {
                if (product.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    productToRemove = product;
                    break;
                }
            }

            if (productToRemove != null)
            {
                Products.Remove(productToRemove);
            }
            else
            {
                throw new Exception("Product not found.");
            }
        }

        public void UpdateStock(string name, int newStock)
        {
            foreach (var product in Products)
            {
                if (product.Name == name)
                {
                    product.Stock = newStock;
                    return;
                }
            }

            throw new Exception("Product not found.");
        }

        public List<Produs> SearchByName(string name)
        {
            List<Produs> result = new List<Produs>();
            foreach (var product in Products)
            {
                if (product.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product);
                }
            }

            return result;
        }

        public List<Produs> SortByPrice(bool ascending = true)
        {
            List<Produs> sortedProducts = new List<Produs>(Products);

            for (int i = 0; i < sortedProducts.Count - 1; i++)
            {
                for (int j = i + 1; j < sortedProducts.Count; j++)
                {
                    if ((ascending && sortedProducts[i].Price > sortedProducts[j].Price) ||
                        (!ascending && sortedProducts[i].Price < sortedProducts[j].Price))
                    {
                        var temp = sortedProducts[i];
                        sortedProducts[i] = sortedProducts[j];
                        sortedProducts[j] = temp;
                    }
                }
            }

            return sortedProducts;
        }
    }
}
