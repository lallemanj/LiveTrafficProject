using Newtonsoft.Json;

namespace LiveTrafficProject.Models
{
    public class Event
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}
