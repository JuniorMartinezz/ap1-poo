using ap1_poo.Data.Repositories;
using ap2_poo.Domain;
using ap2_poo.Domain.Interfaces;

namespace ap2_poo.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext context;

        public CityRepository(DataContext context)
        {
            this.context = context;
        }

        public void Delete(int entityId)
        {
            var c = GetById(entityId);
            context.Cities.Remove(c);
            context.SaveChanges();
        }

        public IList<City> GetAll()
        {
            return context.Cities.ToList();
        }

        public City GetById(int entityId)
        {
            return context.Cities.SingleOrDefault(x => x.Id == entityId);
        }

        public City GetByName(string entityName)
        {
            return context.Cities.SingleOrDefault(x => x.Name == entityName);
        }

        public void Save(City entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Update(City entity)
        {
            context.Cities.Update(entity);
            context.SaveChanges();
        }
    }
}
