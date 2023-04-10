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

        public static void Get()
        {
            if (FridgesList.Count == 0)
            {
                System.Console.WriteLine("\nNenhuma geladeira cadastrada!");
            }
            else
            {
                foreach (var f in FridgesList)
                {
                    Console.WriteLine($"\nCódigo de barras: {f.BarCode} | Nome: {f.Name} | Marca: {f.Brand} | Capacidade: {f.Capacity} litros | Cor: {f.Color} | Fornecedor: {f.Supplier.Name} | Preço: {Product.CurrencyFormatter(f.Price)}");
                }
            }
        }

        public static void Get(long codeBar)
        {
            if (FridgesList.Count == 0)
            {
                System.Console.WriteLine("\nNenhum cooktop cadastrado!");
            }
            else
            {
                var fridgeFound = FridgesList.Find(f => f.BarCode == codeBar);

                Console.WriteLine($"\nCódigo de barras: {fridgeFound.BarCode} | Nome: {fridgeFound.Name} | Marca: {fridgeFound.Brand} | Capacidade: {fridgeFound.Capacity} | Cor: {fridgeFound.Color} | Fornecedor: {fridgeFound.Supplier.Name} | Preço: {Product.CurrencyFormatter(fridgeFound.Price)}");
            }

        }

        public static Fridge GetOne(long codeBar)
        {
            if (FridgesList.Count == 0)
            {
                System.Console.WriteLine("\nNenhuma geladeira cadastrada!");
            }

            return FridgesList.Find(f => f.BarCode == codeBar);
        }
    }
}