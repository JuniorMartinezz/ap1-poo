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
            int i = 0;
            if (CooktopsList == null)
            {
                System.Console.WriteLine("\nNenhum usuário cadastrado!");
            }
            foreach (var c in CooktopsList)
            {
                Console.WriteLine($"\nCódigo de barras: {c.BarCode} | Nome: {c.Name} | Marca: {c.Brand} | Preço: {c.Price} | Bocas: {c.Burners} | Material: {c.Material} | Fornecedor: {c.Supplier.Name}");
            }
        }

        public static Cooktop get(long codeBar)
        {
            if (CooktopsList == null)
            {
                System.Console.WriteLine("\nNenhum usuário cadastrado!");
            }

            return CooktopsList.Find(c => c.BarCode == codeBar);
        }

    }
}