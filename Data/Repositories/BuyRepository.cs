using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ap1_poo.Data.Repositories;
using ap1_poo.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace poo_ap1
{
    public class BuyRepository : IBuyRepository
    {
        private readonly DataContext context;

        public BuyRepository(DataContext context)
        {
            this.context = context;
        }
        public void Delete(int entityId)
        {
            var b = GetById(entityId);
            context.Buys.Remove(b);
            context.SaveChanges();
        }

        public IList<Buy> GetAll()
        {
            return context.Buys.ToList();
        }

        public Buy GetById(int entityId)
        {
            return context.Buys.SingleOrDefault(x => x.Id == entityId);
        }

        public void Save(Buy entity)
        {
            entity.Product = context.Products.Find(entity.Product.Id);
            context.Add(entity);
            context.SaveChanges();
        }

        public void Update(Buy entity)
        {
            entity.Product = context.Products.Find(entity.Product.Id);
            context.Buys.Update(entity);
            context.SaveChanges();
        }
    }
}
