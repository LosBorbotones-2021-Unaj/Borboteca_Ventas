using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Domain.DTOs.VentasDtos;
using Ventas_Domain.Entities;

namespace Ventas_Domain.Queries
{
    public interface IVentasQuery
    {
        Ventas GetVentaByCarroIdQuery(int VentaId);
        List<ResponseGetVenta> GetVentaByFechaEstadoQuery(int UsuarioId,string Fecha, string VentaId);
        bool ExistVentaActive(int CarroId);

        List<string> GetAllVentasQuery(int UsuarioId);
    }
}
