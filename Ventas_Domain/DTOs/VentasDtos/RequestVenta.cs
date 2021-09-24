using System;
using System.Collections.Generic;
using System.Text;

namespace  Ventas_Domain.DTOs.VentasDtos

{
    public class RequestVenta
    {

        public string Fecha { get; set; }

        public string Comprobante { get; set; }

        public Boolean estado { get; set; }

        public int CarroId { get; set; }
    }
}
