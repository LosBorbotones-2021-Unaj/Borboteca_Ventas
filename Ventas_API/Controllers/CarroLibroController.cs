using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ventas_Application.Services.Interface_Service;
using Ventas_Domain.DTOs.CarroLibroDtos;

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
        public IActionResult Get()
        {
            try
            {
                return new JsonResult(service.GetAllCarroLibros()) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<CarroLibroController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new JsonResult(service.GetCarroLibroById(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<CarroLibroController>
        [HttpPost]
        public IActionResult Post(RequestCarroLibro Carro)
        {
            try
            {
                return new JsonResult(service.CreateCarroLibro(Carro)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
