using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Domain.DTOs.VentasDtos;
using Ventas_Domain.Entities;

namespace Ventas_Domain.Queries
{
    public interface IVentasQuery
    {
        ResponseGetVenta GetVentaByIdQuery(int VentaId);
        List<ResponseGetVenta> GetVentaByFechaIdQuery(string Fecha, string VentaId);

    }
}
