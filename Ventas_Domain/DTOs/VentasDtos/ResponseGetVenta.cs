using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Ventas_Domain.DTOs.VentasDtos
{
    public class ResponseGetVenta
    {
        public int Id { get; set; }

        public string Fecha { get; set; }

        public string Comprobante { get; set; }

        public string estado { get; set; }

        [JsonIgnore]
        public bool IsValid { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Object> Errors { get; set; }

        public List<Guid> LibrosId { get; set; }
    }
}
