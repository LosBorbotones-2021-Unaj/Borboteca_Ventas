using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ventas_Application.Services.Interface_Service;
using Ventas_Domain.DTOs;
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
        [HttpGet("{Usuarioid}")]
        public IActionResult Get(int Usuarioid)
        {
            try
            {
                return new JsonResult(service.GetLibrosDelCarro(Usuarioid)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message) { StatusCode = 400 };
            }
        }

        [HttpPost]
        public IActionResult Post(int UsuarioId)
        {
            return new JsonResult(service.CreateCarro(UsuarioId)) { StatusCode = 201 };

        }

        // PUT api/<CarroController>/5
        [HttpPut("{UsuarioId}")]
        public void Put(int UsuarioId)
        {
            service.UpdateCarroActivo(UsuarioId);
        }

        
    }
}