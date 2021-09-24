using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Domain.DTOs.VentasDtos;
using Ventas_Domain.Entities;

namespace Ventas_Domain.Queries
{
    public interface IVentasQuery
    {
        List<Ventas> GetAllVentasQuery();
        ResponseGetVenta GetVentaByIdQuery(int VentaId);
        List<ResponseGetVenta> GetVentaByFechaIdQuery(DateTime Fecha, int VentaId);
        
    }
}
