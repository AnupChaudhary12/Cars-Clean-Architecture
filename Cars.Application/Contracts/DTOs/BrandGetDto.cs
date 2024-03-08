using Newtonsoft.Json;
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
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("brandName")]
        public string BrandName { get; set; } = default!;
        [JsonProperty("country")]
        public string Country { get; set; } = default!;
    }
}
