using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace DesafioAPIStone.Controllers
{
    [Route("api/desafio")]
    [ApiController]
    public class DesafioController : ControllerBase
    {
        // GET api/desafio
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var funcionarios = Funcionario.CarregarFuncionariosList();

            return new string[] { "value1", "value2" };
        }     
       
    }
}
