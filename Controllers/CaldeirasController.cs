using ApiCaldeiras_MongoDB.Data.Repositories;
using ApiCaldeiras_MongoDB.Models;
using ApiCaldeiras_MongoDB.Models.InputModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCaldeiras_MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaldeirasController : ControllerBase
    {

        private ICaldeirasRepository _caldeirasRepository;


        public CaldeirasController(ICaldeirasRepository caldeirasRepository)
        {
            _caldeirasRepository = caldeirasRepository;
        }

        // GET: api/caldeiras
        [HttpGet]
      public IActionResult Get()
        {
            var caldeiras = _caldeirasRepository.Buscar();

            return Ok(caldeiras);
        }

        // GET api/caldeiras/{id}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {

            var caldeira = _caldeirasRepository.Buscar(id);

            if (caldeira == null)
            {
                return NotFound();
            }

            return Ok(caldeira);
        }

        // POST api/caldeiras
        [HttpPost]
        public IActionResult Post([FromBody] CaldeiraInputModel novaCaldeira)
        {
            string Status = "";

            if (novaCaldeira.Pressao > 1000 || novaCaldeira.Pressao < 350)
            {
                Status = "Irregular";
            }
            else if ( novaCaldeira.NivelCombustivel < 20)
            {
                Status = "Irregular";
            }
            else if (novaCaldeira.NivelAgua < 50)
            {
                Status = "Irregular";
            }
            else if (novaCaldeira.Temperatura > 500 || novaCaldeira.Temperatura < 50)
            {
                Status = "Irregular";
            }
            else
            {
                Status = "Regular";
            }
            var caldeira = new Caldeira(novaCaldeira.NomeCaldeira,Status, novaCaldeira.Pressao, novaCaldeira.NivelAgua, novaCaldeira.NivelCombustivel, novaCaldeira.Temperatura);

            _caldeirasRepository.Adicionar(caldeira);
            return Created("", caldeira);
        }

        // PUT api/caldeiras/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] CaldeiraInputModel caldeiraAtualizada)
        {
            var caldeira = _caldeirasRepository.Buscar(id);
            string Status = "";

            if (caldeiraAtualizada.Pressao > 100)
            {
                Status = "Irregular";
            }

            if (caldeira == null)
            {
                return NotFound();
            }

            caldeira.AtualizarCaldeira(Status, caldeiraAtualizada.Pressao, caldeiraAtualizada.NivelAgua, caldeiraAtualizada.NivelCombustivel, caldeiraAtualizada.Temperatura);

            _caldeirasRepository.Atualizar(id, caldeira);

            return Ok(caldeira);
        }

        // DELETE api/caldeiras/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var caldeira = _caldeirasRepository.Buscar(id);

            if (caldeira == null)
            {
                return NotFound();
            }

            _caldeirasRepository.Remover(id);

            return NoContent();
        }
    }
}
