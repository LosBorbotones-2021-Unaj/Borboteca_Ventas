using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas_Domain.DTOs.VentasDtos
{
    public class VentasValidate
    {
        public VentasValidate(string fecha, string id)
        {
            Id = id;
            Fecha = fecha;
        }
        public string Id { get; set; }

        public string Fecha { get; set; }

    }
}
