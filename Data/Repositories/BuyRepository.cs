using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ap1_poo.Data.Repositories;
using ap1_poo.Domain.Interfaces;

namespace poo_ap1
{
    public class BuyRepository : IBuyRepository
    {
        private readonly DataContext context;

        public void Delete(int entityId)
        {
            var b = GetById(entityId);
            context.Buys.Remove(b);
            context.SaveChanges();
        }

        public IList<Buy> GetAll()
        {
            throw new NotImplementedException();
        }

        public Buy GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Save(Buy entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Buy entity)
        {
            throw new NotImplementedException();
        }
    }
}
