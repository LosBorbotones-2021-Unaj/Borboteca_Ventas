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
        [Route("GetByFechaId")]
        public IActionResult Get([FromQuery] string Fecha, [FromQuery] string VentaId)
        {
            VentasValidate FechaIdValidate = new VentasValidate(Fecha, VentaId);
            VentaByFechaIDValidation validator = new VentaByFechaIDValidation();
            ValidationResult result = validator.Validate(FechaIdValidate);
        
            if (!result.IsValid)
            {
                string DevolverErrores = "";
                foreach (var error in result.Errors)
                {
                    DevolverErrores += error.ErrorMessage;
                }
                return new JsonResult(DevolverErrores);
            }
            else
                return new JsonResult(service.GetVentaByFechaId(Fecha, VentaId)) { StatusCode = 200 };

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
