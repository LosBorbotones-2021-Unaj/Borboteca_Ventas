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
        public IActionResult Get()
        {
            try
            {
                return new JsonResult(service.GetAllCarros()) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/<CarroController>
        [HttpGet("{Usuarioid}")]
        public IActionResult Get(int Usuarioid)
        {
            try
            {
                return new JsonResult(service.GetCarroCompleto(Usuarioid)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
       
        [HttpPost]
        public void Post(int UsuarioId)
        {
            
            service.CreateCarro(UsuarioId);
            
        }

        // PUT api/<CarroController>/5
        [HttpPut]
        public void Put(int UsuarioId)
        {
            service.UpdateCarroActivo(UsuarioId);
        }

        // DELETE api/<CarroController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
