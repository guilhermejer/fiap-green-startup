using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Green.Startup.Domain.Entitidades;
using Fiap.Green.Startup.Domain.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fiap.Green.Startup.Api.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : Controller
    {

        private readonly PessoaServices pessoaService;

        public PessoaController()
        {
            pessoaService = new PessoaServices();
        }

        // GET api/values/5
        [HttpPost]
        [Route("CadastroPrimeiroAcesso")]
        public IActionResult Cadastrar (Pessoa Pessoa)
        {
            if (ModelState.IsValid)
            {
                var service = pessoaService.CadastrarPessoa(Pessoa);
                return  Ok(new
                    {
                        Result = 200,
                        data = Pessoa

                    });
            }
            return BadRequest();
        }

    }
}
