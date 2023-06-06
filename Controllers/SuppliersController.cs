using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ap1_poo.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using poo_ap1;

namespace ap1_poo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierRepository repository;

        public SuppliersController()
        {
            this.repository = new SupplierRepository();
        }

        [HttpGet]
        public IEnumerable<Supplier>Get()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public Supplier Get(int id)
        {
            return repository.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Supplier item)
        {
            repository.Save(item);
            return Ok(
                new
                {
                    statusCode = 200,
                    message = "Cadastrado com sucesso",
                    item
                }
            );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return Ok(new { statusCode = 200, message = "Fornecedor excluído com sucesso" });
        }

        [HttpPut]
        public IActionResult Put([FromBody] Supplier item)
        {
            repository.Update(item);
            return Ok(
                new
                {
                    statusCode = 200,
                    message = item.Name + " atualizado com sucesso",
                    item
                }
            );
        }
    }
}
