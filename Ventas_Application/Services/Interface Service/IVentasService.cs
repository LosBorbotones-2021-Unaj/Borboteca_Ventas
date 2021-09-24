using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Domain.DTOs.VentasDtos;
using Ventas_Domain.DTOs;

namespace Ventas_Application.Services.Interface_Service
{
    public interface IVentasService
    {
        List<ResponseAllVentas> GetAllVentas();
        ResponseGetVenta GetVentaById(int id);
        List<ResponseGetVenta> GetVentaByFechaId(DateTime fecha, int id);
        GenericCreatedDto CreateVenta(RequestVenta venta);
    }
}
