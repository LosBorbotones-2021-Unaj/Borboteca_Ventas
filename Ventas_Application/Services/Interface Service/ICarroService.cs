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
        List<ResponseAllCarros> GetAllCarros();
        ResponseCarroCompleto GetCarroCompleto(int Usuarioid);

        void UpdateCarroActivo(int UsuarioId);
    }
}
