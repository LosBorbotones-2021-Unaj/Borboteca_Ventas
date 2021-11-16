using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Ventas_Domain.DTOs
{
    public class Response
    {
        [JsonIgnore]
        public bool IsValid { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Id { get; set; }


     
        public string entity { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Object> Errors { get; set; }
    }
}
