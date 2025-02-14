﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinOnline
{
    public abstract class Produs
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Produs(string name, decimal price, int stock) 
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public abstract string GetDetails();
    }
}
