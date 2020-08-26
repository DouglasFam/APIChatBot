using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repository;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : Controller
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        // GET: api/Pessoa
        [HttpGet]
        [Produces(typeof(Pessoa))]
        public IActionResult Get()
        {
            var pessoas = _pessoaRepository.GetAll();

            if (pessoas.Count() == 0)
                return NoContent();

            return Ok(pessoas);
        }

        // GET: api/Pessoa/5
        //[HttpGet("{id}", Name = "Get")]
        //public IActionResult GetById(int id)
        //{
        //    var pessoas = _pessoaRepository.Find(id);

        //    if (pessoas == null)
        //    {
        //        return NotFound();
        //    }

        //    return new ObjectResult(pessoas);

        //}
        //GET: api/Pessoa/string

        [HttpGet("{login}", Name = "get")]
        public IActionResult Login(string login)
        {
            //var loginpessoa = _pessoaRepository.GetAll();

            //if (loginpessoa.Count() == 0)
            //{
            //    return NotFound();
            //}
            //else

            //    loginpessoa.Where(x => x.Login.Contains(login));

            var pessoas = _pessoaRepository.FindLogin(login);

            if (pessoas == null)
            {
                return NotFound("Esse login não existe");
            }
            return Ok(pessoas);

        }

        [Route("[action]/{nome}")]
        [HttpGet]
        public IActionResult GetByNome(string nome)
        {

            var pessoas = _pessoaRepository.FindPessoa(nome);

            if (pessoas == null)
            {
                return NotFound("Essa pessoa não existe");
            }

            return Ok(pessoas);
        }


        // POST: api/Pessoa
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Pessoa/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
