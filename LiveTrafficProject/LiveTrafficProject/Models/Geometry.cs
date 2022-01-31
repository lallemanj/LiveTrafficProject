using Newtonsoft.Json;

namespace LiveTrafficProject.Models
{
    public class Geometry
    {
        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("coordinates")]
        public List<List<double>>? Coordinates { get; set; }
    }
}
