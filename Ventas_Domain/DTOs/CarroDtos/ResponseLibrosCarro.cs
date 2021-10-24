using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas_Domain.DTOs.CarroDtos
{
    public class ResponseLibrosCarro
    {
        public List<int> LibrosIds { get; set; }
        public float ValorTotalCarro { get; set; }
    }
}
