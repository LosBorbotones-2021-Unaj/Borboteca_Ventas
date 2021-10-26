using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Domain.DTOs;
using Ventas_Domain.DTOs.CarroDtos;

namespace Ventas_Application.Services.Interface_Service
{
    public interface ICarroService
    {
        void CreateCarro(int UsuarioId);
        ResponseLibrosCarro GetLibrosDelCarro(int Usuarioid);

        void UpdateCarroActivo(int UsuarioId);
    }
}
