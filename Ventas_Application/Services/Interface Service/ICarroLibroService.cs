using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Domain.DTOs;
using Ventas_Domain.DTOs.CarroLibroDtos;

namespace Ventas_Application.Services.Interface_Service
{
    public interface ICarroLibroService
    {
        ResponseGetCarroLibro CreateCarroLibro(RequestCarroLibro carroLibro);
        Response DeleteCarroLibro(RequestCarroLibro CarroLibro);

    }
}
