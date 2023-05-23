using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aula12_ef_test.Domain;
using aula14_ef_repositories.Domain.Interfaces;

namespace ap1_poo.Domain.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        
    }
}