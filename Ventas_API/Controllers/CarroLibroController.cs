using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ventas_Application.Services.Interface_Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ventas_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroLibroController : ControllerBase
    {
        ICarroLibroService service;
        public CarroLibroController(ICarroLibroService xservice)
        {
            service = xservice;
        }
        // GET: api/<CarroLibroController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CarroLibroController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CarroLibroController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CarroLibroController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarroLibroController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
