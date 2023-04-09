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
            if (FridgesList.Count == 0)
            {
                System.Console.WriteLine("\nNenhuma geladeira cadastrada!");
            }
            foreach (var f in FridgesList)
            {
                Console.WriteLine($"\nCódigo de barras: {f.BarCode} | Nome: {f.Name} | Marca: {f.Brand} | Preço: {f.Price} | Capacidade: {f.Capacity} litros | Cor: {f.Color} | Fornecedor: {f.Supplier.Name}");
            }
        }

        public static void get(long codeBar)
        {
            if (FridgesList.Count == 0)
            {
                System.Console.WriteLine("\nNenhum cooktop cadastrado!");
            }

            var fridgeFound = FridgesList.Find(f => f.BarCode == codeBar);

            Console.WriteLine($"\nCódigo de barras: {fridgeFound.BarCode} | Nome: {fridgeFound.Name} | Marca: {fridgeFound.Brand} | Preço: {fridgeFound.Price} | Capacidade: {fridgeFound.Capacity} | Cor: {fridgeFound.Color} | Fornecedor: {fridgeFound.Supplier.Name}");
        }

        public static Fridge getOne(long codeBar)
        {
            if (FridgesList.Count == 0)
            {
                System.Console.WriteLine("\nNenhuma geladeira cadastrada!");
            }

            return FridgesList.Find(f => f.BarCode == codeBar);
        }
    }
}