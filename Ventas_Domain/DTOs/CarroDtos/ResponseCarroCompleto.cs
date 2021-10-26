using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Domain.DTOs.CarroLibroDtos;
using Ventas_Domain.DTOs.VentasDtos;
using Ventas_Domain.Entities;

namespace Ventas_Domain.DTOs.CarroDtos
{
    public class ResponseCarroCompleto
    {
        public int Id { get; set; }
        public float Valor { get; set; }
        public Boolean Activo { get; set; }
        public int Usuarioid { get; set; }

        public List<RequestVenta> Ventas { get; set; }
        public List<GetCarroLibroByCarroId> CarroLibros { get; set; }
    }
}
