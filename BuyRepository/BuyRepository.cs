using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poo_ap1
{
    public class BuyRepository
    {
        public static List<Buy> BuysList = new List<Buy>();

        public static void Add(Buy buy)
        {
            BuysList.Add(buy);
        }

        public static void get()
        {
            if (BuysList.Count == 0)
            {
                System.Console.WriteLine("\nNenhuma compra cadastrada!");
            }

            foreach (var b in BuysList)
            {
                var product = b.Products.Find(p => p.Name == p.Name);

                Console.WriteLine($"\nId da compra: {b.Id} | Data da compra: {b.Date} | Produto: {product.Name} | Quantidade: {b.Amount} | Valor total: R${b.TotalPrice}");
            }
        }
    }
}