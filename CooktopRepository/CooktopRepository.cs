using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poo_ap1
{
    public class CooktopRepository
    {
        public static List<Cooktop> CooktopsList = new List<Cooktop>();

        public static void Add(Cooktop cooktop)
        {
            CooktopsList.Add(cooktop);
        }

        public static void get()
        {
            if (CooktopsList.Count == 0)
            {
                System.Console.WriteLine("\nNenhum cooktop cadastrado!");
            }
            foreach (var c in CooktopsList)
            {
                Console.WriteLine($"\nCódigo de barras: {c.BarCode} | Nome: {c.Name} | Marca: {c.Brand} | Preço: {c.Price} | Bocas: {c.Burners} | Material: {c.Material} | Fornecedor: {c.Supplier.Name}");
            }
        }
        
        public static void get(long codeBar)
        {
            if (CooktopsList.Count == 0)
            {
                System.Console.WriteLine("\nNenhum cooktop cadastrado!");
            }

            var cooktopFound = CooktopsList.Find(c => c.BarCode == codeBar);

            Console.WriteLine($"\nCódigo de barras: {cooktopFound.BarCode} | Nome: {cooktopFound.Name} | Marca: {cooktopFound.Brand} | Preço: {cooktopFound.Price} | Bocas: {cooktopFound.Burners} | Material: {cooktopFound.Material} | Fornecedor: {cooktopFound.Supplier.Name}");
        }

        public static Cooktop getOne(long codeBar)
        {
            if (CooktopsList.Count == 0)
            {
                System.Console.WriteLine("\nNenhum cooktop cadastrado!");
            }

            return CooktopsList.Find(c => c.BarCode == codeBar);
        }
    }
}