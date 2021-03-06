using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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


        // POST api/<CarroLibroController>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult Post(RequestCarroLibro Carro)
        {
            try
            {
                var Response = service.CreateCarroLibro(Carro);
                if (Response.IsValid) return new JsonResult(Response) { StatusCode = 201 };

                else return new JsonResult(Response.Errors) { StatusCode = 400 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("EliminarLibro/")]
        public IActionResult Delete(RequestCarroLibro CarroLibro)
        {
            return new JsonResult (service.DeleteCarroLibro(CarroLibro)) { StatusCode = 201 };
        }

    }
}
