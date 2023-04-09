using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poo_ap1
{
    public class FridgeRepository
    {
        public static List<Fridge> FridgesList = new List<Fridge>();

        public static void Add(Fridge fridge)
        {
            FridgesList.Add(fridge);
        }

        public static void get()
        {
            int i = 0;
            if (FridgesList == null)
            {
                System.Console.WriteLine("\nNenhum usuário cadastrado!");
            }
            foreach (var f in FridgesList)
            {
                Console.WriteLine($"\nCódigo de barras: {f.BarCode} | Nome: {f.Name} | Marca: {f.Brand} | Marca: {f.Brand} | Capacidade: {f.Capacity} litros | Cor: {f.Color} | Fornecedor: {f.Supplier.Name}");
            }
        }

        public static Fridge get(long codeBar)
        {
            if (FridgesList == null)
            {
                System.Console.WriteLine("\nNenhum usuário cadastrado!");
            }

            return FridgesList.Find(f => f.BarCode == codeBar);
        }
    }
}