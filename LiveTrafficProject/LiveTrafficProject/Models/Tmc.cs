using Newtonsoft.Json;

namespace LiveTrafficProject.Models
{
    public class Tmc
    {
        [JsonProperty("countryCode")]
        public string? CountryCode { get; set; }

        [JsonProperty("tableNumber")]
        public string? TableNumber { get; set; }

        [JsonProperty("tableVersion")]
        public string? TableVersion { get; set; }

        [JsonProperty("direction")]
        public string? Direction { get; set; }

        [JsonProperty("points")]
        public List<Point>? Points { get; set; }
    }
}
