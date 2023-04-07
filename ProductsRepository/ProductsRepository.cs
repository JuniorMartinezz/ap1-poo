using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poo_ap1
{
    public class ProductsRepository
    {
        public static List<Product> ProductsList = new List<Product>();

        public static void Add(Product product)
        {
            ProductsList.Add(product);
        }
        public static void get()
        {
            int i = 0;
            if (ProductsList == null)
            {
                System.Console.WriteLine("\nNenhum usuário cadastrado!");
            }
            foreach (var c in ProductsList)
            {
                Console.WriteLine($"\nCódigo de barras: {c.BarCode} | Nome: {c.Name} | Marca: {c.Brand} | Marca: {c.Price}");
            }
        }
        public static Product get(long codeBar)
        {
            if (ProductsList == null)
            {
                System.Console.WriteLine("\nNenhum usuário cadastrado!");
            }

            return ProductsList.Find(p => p.BarCode == codeBar);
        }

    }
}