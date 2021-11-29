using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Ventas_Domain.DTOs.CarroLibroDtos
{
    public class ResponseGetCarroLibro
    {
        public int Id { get; set; }
        public Guid Libroid { get; set; }
        public int Carroid { get; set; }

        [JsonIgnore]
        public bool IsValid { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Object> Errors { get; set; }
    }
}
