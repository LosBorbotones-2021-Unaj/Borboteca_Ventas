using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas_Domain.DTOs.CarroLibroDtos
{
    public class GetCarroLibroByCarroId
    {
        public int Id { get; set; }
        public int Libroid { get; set; }
        public int Carroid { get; set; }    
    }
}
