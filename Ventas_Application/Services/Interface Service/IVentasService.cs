using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Domain.DTOs.VentasDtos;
using Ventas_Domain.DTOs;
using Ventas_Domain.Entities;

namespace Ventas_Application.Services.Interface_Service
{
    public interface IVentasService
    {
        List<ResponseGetVenta> GetVentaByFechaId(string fecha, string estado);
        Response CreateVenta(int UsuarioId);

        Ventas VentaCerrada(int VentaId);

        Response DeleteVenta(int UsuarioId);
    }
}
