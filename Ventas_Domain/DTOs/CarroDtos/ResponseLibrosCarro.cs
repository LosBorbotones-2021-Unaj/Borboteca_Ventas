using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Ventas_Domain.DTOs.CarroDtos
{
    public class ResponseLibrosCarro
    {
        public List<Guid> LibrosIds { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public float ValorTotalCarro { get; set; }
    }
}
