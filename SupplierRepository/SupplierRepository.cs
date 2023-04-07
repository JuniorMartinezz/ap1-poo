using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poo_ap1
{
    public class SupplierRepository
    {
        public static List<Supplier> SuppliersList = new List<Supplier>();

        public static void Add(Supplier supplier)
        {
            SuppliersList.Add(supplier);
        }

        public static void getAll()
        {
            int i = 0;
            if (SuppliersList == null)
            {
                System.Console.WriteLine("\nNenhum usuário cadastrado!");
            }

            foreach (var s in SuppliersList)
            {
                Console.WriteLine($"\nId: {s.Id} | Nome: {s.Name} | Telefone: {s.Phone.CompletePhone()} | Endereço: {s.Address.CompleteAddress()} | Cnpj: {s.Cnpj}");
                i++;
            }
        }

        public static Supplier get(long id)
        {
            if (SuppliersList == null)
            {
                System.Console.WriteLine("\nNenhum fornecedor cadastrado!");
            }

            return SuppliersList.Find(s => s.Id == id);
        }
    }
}
