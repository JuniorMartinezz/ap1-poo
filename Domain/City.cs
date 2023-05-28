using poo_ap1;

namespace ap2_poo.Domain
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Supplier> Suppliers { get; set; }

/*         public City(string name, string state)
        {
            this.Name = name;
            this.State = state;
        } */
    }
}