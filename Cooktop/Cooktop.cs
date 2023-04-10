using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poo_ap1
{
    public class Cooktop : Product
    {
        public int Burners { get; set; }
        public string Material { get; set; }

        public Cooktop(long barCode, string name, string brand, double price, Supplier supplier, int burners, string material) : base(barCode, name, brand, price, supplier)
        {
            this.Burners = burners;
            this.Material = material;
        }

        public override void AddInterestRate(double interestRate)
        {
            double iRate = interestRate / 100;

            double valueWIR = this.Price+iRate;

            System.Console.WriteLine($"\nValor do cooktop com juros: {Product.CurrencyFormatter(valueWIR)}");
        }
    }
}