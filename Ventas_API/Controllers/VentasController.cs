using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ventas_Application.Services.Interface_Service;
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

        // GET: api/<VentasController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new JsonResult(service.GetAllVentas()) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //GET api/<VentasController>/Query Params
        [HttpGet]
        [Route("api/Ventas")]
        public IActionResult Get([FromQuery] DateTime Fecha, [FromQuery] int VentaId)
        {
            try
            {
                return new JsonResult(service.GetVentaByFechaId(Fecha, VentaId)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
            try
            {

                return new JsonResult(service.CreateVenta(Venta)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<VentasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VentasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
