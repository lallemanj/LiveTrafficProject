using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveTrafficProject.Models
{
    public class Incident
    {
        [JsonProperty("type")]
        public string? type { get; set; }

        [JsonProperty("properties")]
        [Display(Name = "Properties")]
        public Properties? properties { get; set; }

        [ForeignKey("Properties")]
        [Display(Name = "PropertieID")]
        public int propertiesId { get; set; }

        [JsonProperty("geometry")]
        public Geometry? geometry { get; set; }
    }
}
