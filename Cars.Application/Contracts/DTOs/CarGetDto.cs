using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Contracts.DTOs
{
    public class CarGetDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("carModel")]
        public string CarModel { get; set; } = default!;
        [JsonProperty("color")]
        public string Color { get; set; } = default!;
        [JsonProperty("tyreCount")]
        public int TyreCount { get; set; }
        [JsonProperty("numberPlate")]
        public string NumberPlate { get; set; } = default!;
        [JsonProperty("brandId")]
        public int BrandId { get; set; }
    }
}
