using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ap1_poo.Data.Repositories;
using ap1_poo.Domain.Interfaces;
using aula12_ef_test.Domain;
using Microsoft.EntityFrameworkCore;

namespace poo_ap1
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly DataContext context;

        public SupplierRepository(DataContext context)
        {
            this.context = context;
        }

        public void Delete(int entityId)
        {
            var s = GetById(entityId);
            context.Suppliers.Remove(s);
            context.SaveChanges();
        }
        
        public IList<Supplier> GetAll()
        {
            return context.Suppliers.Include(x => x.City).ToList();
        }

        public Supplier GetById(int entityId)
        {
            return context.Suppliers.Include(x => x.City).SingleOrDefault(x => x.Id == entityId);
        }

        public void Save(Supplier entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Update(Supplier entity)
        {
            context.Suppliers.Update(entity);
            context.SaveChanges();
        }
    }
}
