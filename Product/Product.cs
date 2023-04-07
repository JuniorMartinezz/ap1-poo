using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poo_ap1
{
    public abstract class Product
    {
        public long BarCode { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public Supplier Supplier { get; set; }

        public Product(long barCode, string name, string brand, double price, Supplier supplier){
            this.BarCode = barCode;
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Supplier = supplier;
        }

    }
}