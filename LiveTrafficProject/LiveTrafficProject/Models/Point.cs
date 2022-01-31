using Newtonsoft.Json;

namespace LiveTrafficProject.Models
{
    public class Point
    {
        [JsonProperty("location")]
        public int Location { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }
    }
}
