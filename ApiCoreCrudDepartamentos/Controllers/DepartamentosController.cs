using System.Runtime.InteropServices;
using ApiCoreCrudDepartamentos.Models;
using ApiCoreCrudDepartamentos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreCrudDepartamentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Departamento>>>
            GetDepartamentosAsync()
        {
            return await this.repo.GetDepartamentosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Departamento> FindDepartamentoAsync(int id)
        {
            return await this.repo.FindDepartamentoAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> InsertDepartamento(Departamento departamento)
        {
            await this.repo
                .InsertDepartamentoAsync(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartamento(int id)
        {
            await this.repo.DeleteDepartamentoAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDepartamento(Departamento departamento)
        {
            await this.repo
                .UpdateDepartamentoAsync(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            return Ok();
        }

        //accion mediante parametros
        [HttpPost]
        [Route("[action]/{id}/{nombre}/{localidad}")]
        public async Task<ActionResult> PostDepartamento(int id, string nombre, string localidad)
        {
            await this.repo.InsertDepartamentoAsync(id, nombre, localidad);
            return Ok();
        }

        //acion combinada: params + objeto
        //solo se enrutan los params
        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<ActionResult> PutDepartamento(int id, Departamento departamento)
        {
            await this.repo.UpdateDepartamentoAsync(id, departamento.Nombre, departamento.Localidad);
            return Ok();
        }
    }
}
