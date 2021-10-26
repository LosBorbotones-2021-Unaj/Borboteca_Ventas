using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas_Domain.DTOs.CarroLibroDtos
{
    public class ResponseGetCarroLibro
    {
        public int Id { get; set; }
        public Guid Libroid { get; set; }
        public int Carroid { get; set; }
    }
}
