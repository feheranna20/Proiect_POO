using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinOnline
{
    public class Electrocasnice : Produs
    {
        private string EnergyEfficiencyClass { get; set; }
        private int MaxPower { get; set; }
        public Electrocasnice(string name, decimal price, int stock, string energyEfficiencyClass, int maxPower) : base(name, price, stock)
        { 
            EnergyEfficiencyClass = energyEfficiencyClass;
            MaxPower = maxPower;
        }
    }
}
