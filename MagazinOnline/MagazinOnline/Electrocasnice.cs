using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinOnline
{
    public class Electrocasnice : Produs
    {
        public string EnergyEfficiencyClass { get; set; }
        public int MaxPower { get; set; }
        public Electrocasnice(string name, decimal price, int stock, string energyEfficiencyClass, int maxPower) : base(name, price, stock)
        { 
            EnergyEfficiencyClass = energyEfficiencyClass;
            MaxPower = maxPower;
        }

        public override string GetDetails()
        {
            return $"Name: {Name}, Price: {Price}, Stock: {Stock}, Energy efficiency class: {EnergyEfficiencyClass}, Maximum power: {MaxPower}";
        }
    }
}
