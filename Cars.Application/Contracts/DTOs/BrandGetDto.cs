using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cars.Application.Contracts.DTOs
{
    public class BrandGetDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("modelName")]
        public string ModelName { get; set; } = default!;
        [JsonPropertyName("country")]
        public string Country { get; set; } = default!;
    }
}
