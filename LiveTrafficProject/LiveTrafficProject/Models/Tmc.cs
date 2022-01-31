using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LiveTrafficProject.Models
{
    public class Tmc
    {
        public int Id { get; set; }

        [JsonProperty("countryCode")]
        [Display(Name = "Country code")]
        public string? CountryCode { get; set; }

        [JsonProperty("tableNumber")]
        [Display(Name = "Table nummer")]
        public string? TableNumber { get; set; }

        [JsonProperty("tableVersion")]
        [Display(Name = "Table version")]
        public string? TableVersion { get; set; }

        [JsonProperty("direction")]
        [Display(Name = "Direction")]
        public string? Direction { get; set; }

        [JsonProperty("points")]
        [Display(Name = "Points")]
        public List<Point>? Points { get; set; }
    }
}
