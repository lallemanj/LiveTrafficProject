using Newtonsoft.Json;

namespace LiveTrafficProject.Models
{
    public class Root
    {
            [JsonProperty("incidents")]
            public List<Incident> incidents { get; set; }
            //public Incident.Properties properties { get; set; }

            //public Incident.Event events { get; set; }
        }
}
