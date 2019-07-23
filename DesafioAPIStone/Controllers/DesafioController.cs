using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAPIStone.Controllers
{
    [Route("api/Desafio")]
    [ApiController]
    public class DesafioController : ControllerBase
    {
        // GET api/desafio
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/desafio/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/desafio
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/desafio/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/desafio/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
