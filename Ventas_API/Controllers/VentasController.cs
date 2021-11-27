using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ventas_AccessData.Validations.VentasValidations;
using Ventas_Application.Services.Interface_Service;
using Ventas_Domain.DTOs;
using Ventas_Domain.DTOs.VentasDtos;
using Ventas_Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ventas_API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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



        // POST api/<VentasController>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult Post(int UsuarioId)
        {

            Response Respuesta = service.CreateVenta(UsuarioId);

            if (Respuesta.IsValid) return new JsonResult(Respuesta) { StatusCode = 201 };

            return BadRequest(Respuesta.Errors);

        }


        // DELETE api/<VentasController>/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{Usuarioid}")]
        public IActionResult Delete(int Usuarioid)
        {
            var Response = service.DeleteVenta(Usuarioid);

            if (Response.IsValid) return new JsonResult(Response) { StatusCode = 200 };

            else return new JsonResult(Response.Errors) { StatusCode = 404 };
        }

        // PUT api/<CarroController>/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{UsuarioId}")]
        public Ventas Put(int UsuarioId)
        {
            return service.VentaCerrada(UsuarioId);
        }
    }
}
