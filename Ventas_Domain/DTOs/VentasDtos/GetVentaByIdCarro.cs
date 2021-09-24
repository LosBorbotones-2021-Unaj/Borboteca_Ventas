using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Domain.Entities;

namespace Ventas_Domain.DTOs.VentasDtos
{
    public class GetVentaByIdCarro
    {
        public int Id { get; set; }

        public float Valor { get; set; }

        public Boolean Activo { get; set; }

        public int Usuarioid { get; set; }
    }
}
