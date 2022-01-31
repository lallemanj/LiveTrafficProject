using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LiveTrafficProject.Models
{
    public class Geometry
    {
        public int Id { get; set; }

        [JsonProperty("type")]
        [Display(Name = "Types")]
        public string? Type { get; set; }

        [JsonProperty("coordinates")]
        [Display(Name = "Coordinates")]
        public double? Coordinates { get; set; }
    }
}
