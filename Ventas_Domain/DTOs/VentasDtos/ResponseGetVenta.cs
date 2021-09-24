using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas_Domain.DTOs.VentasDtos
{
    public class ResponseGetVenta
    {
        public int Id { get; set; }

        public string Fecha { get; set; }

        public string Comprobante { get; set; }

        public Boolean estado { get; set; }

        public GetVentaByIdCarro Carro { get; set; }
    }
}
