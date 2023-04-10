using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poo_ap1
{
    public class Fridge : Product
    {
        public int Capacity { get; set; }
        public string Color { get; set; }

        public Fridge(long barCode, string name, string brand, double price, Supplier supplier,
         int capacity, string color) : base(barCode, name, brand, price, supplier)
        {
            this.Capacity = capacity;
            this.Color = color;
        }

        public override void AddInterestRate(double interestRate)
        {
            double iRate = interestRate / 100;

            double valueWIR = this.Price+iRate;

            System.Console.WriteLine($"\nValor da geladeira com juros: {Product.CurrencyFormatter(valueWIR)}");
        }
    }
}