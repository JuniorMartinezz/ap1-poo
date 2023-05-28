using ap1_poo.Data.Repositories;
using ap1_poo.Domain.Interfaces;
using aula12_ef_test.Domain;

namespace ap2_poo.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext context;

        public ProductRepository(DataContext context)
        {
            this.context = context;
        }

        public void Delete(int entityId)
        {
            var p = GetById(entityId);
            context.Products.Remove(p);
            context.SaveChanges();
        }

        public IList<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product GetById(int entityId)
        {
            return context.Products.SingleOrDefault(x => x.Id == entityId);
        }

        public Product GetByBarCode(string productBarCode)
        {
            return context.Products.SingleOrDefault(x => x.BarCode == productBarCode);
        }

        public void Save(Product entity)
        {
            entity.Supplier = context.Suppliers.Find(entity.Supplier.Id);
            context.Add(entity);
            context.SaveChanges();
        }

        public void Update(Product entity)
        {
            entity.Supplier = context.Suppliers.Find(entity.Supplier.Id);
            context.Products.Update(entity);
            context.SaveChanges();
        }
    }
}
