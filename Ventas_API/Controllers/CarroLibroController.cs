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

       
    }
}
