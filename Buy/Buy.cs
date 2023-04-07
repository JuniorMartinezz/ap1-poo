using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poo_ap1
{
    public class Buy
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public int Amount { get; set; }

        public Buy(int id, DateTime date, Product product, int amount){
            this.Id = id;
            this.Date = date;
            Products.Add(product);
            this.Amount = amount;
        }
    }
}