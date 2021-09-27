using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas_Domain.DTOs.CarroDtos
{
    public class ResponseAllCarros
    {
        public int Id { get; set; }

        public float Valor { get; set; }

        public Boolean Activo { get; set; }

        public int Usuarioid { get; set; }
    }
}
