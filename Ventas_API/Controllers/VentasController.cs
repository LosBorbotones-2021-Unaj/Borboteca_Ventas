using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ventas_AccessData.Validations.VentasValidations;
using Ventas_Application.Services.Interface_Service;
using Ventas_Domain.DTOs;
using Ventas_Domain.DTOs.VentasDtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ventas_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        IVentasService service;
        public VentasController(IVentasService xservice)
        {
            service = xservice;
        }

       
        //GET api/<VentasController>/Query Params
        [HttpGet]
        [Route("GetByFechaId")]
        public IActionResult Get([FromQuery] string Fecha, [FromQuery] string estado)
        {
            var Lista = service.GetVentaByFechaId(Fecha, estado);

            foreach (var response in Lista)
                if (response.Errors != null) return BadRequest(response.Errors);
            
             return new JsonResult(Lista) { StatusCode = 200 };

        }

        // GET api/<VentasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new JsonResult(service.GetVentaById(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<VentasController>
        [HttpPost]
        public IActionResult Post(RequestVenta Venta)
        {

            Response Respuesta = service.CreateVenta(Venta);

            if (Respuesta.IsValid) return new JsonResult(Respuesta) { StatusCode = 201 };

            return BadRequest(Respuesta.Errors);

        }

       
        // DELETE api/<VentasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
