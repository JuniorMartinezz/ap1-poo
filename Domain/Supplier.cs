using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ap2_poo.Domain;
using aula12_ef_test.Domain;

namespace poo_ap1
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public long Cnpj { get; set; }
        public City City { get; set; }
        public List<Product> Products { get; set; }

/*         public Supplier(string name, string phone, City city, long cnpj)
        {
            this.Name = name;
            this.Phone = phone;
            this.City = city;
            this.Cnpj = cnpj;
        } */
    }
}