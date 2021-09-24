using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ventas_Application.Services.Interface_Service;
using Ventas_Domain.DTOs.CarroDtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ventas_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        ICarroService service;
        public CarroController(ICarroService xservice)
        {
            service = xservice;
        }
        // GET: api/<CarroController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CarroController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CarroController>
        [HttpPost]    
           public IActionResult Post(RequestCarro Carro)
            {
                try
                {

                    return new JsonResult(service.CreateCarro(Carro)) { StatusCode = 201 };
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        

        // PUT api/<CarroController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarroController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
