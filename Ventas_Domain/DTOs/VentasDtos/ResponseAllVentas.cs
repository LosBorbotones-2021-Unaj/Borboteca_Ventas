using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Domain.Entities;

namespace Ventas_Domain.DTOs.VentasDtos
{
    public class ResponseAllVentas
    {
        public int Id { get; set; }

        public string Fecha { get; set; }

        public string Comprobante { get; set; }

        public Boolean estado { get; set; }

        public int CarroId { get; set; }
    }
}
