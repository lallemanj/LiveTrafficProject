using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveTrafficProject.Models
{
    public class Incident
    {
        public int Id { get; set; }

        [JsonProperty("type")]
        [Display(Name = "Type")]
        public string? type { get; set; }

        [JsonProperty("properties")]
        [Display(Name = "Properties")]
        public Properties? properties { get; set; }

        [ForeignKey("Properties")]
        [Display(Name = "PropertieID")]
        public int propertiesId { get; set; }

        [JsonProperty("geometry")]
        [Display(Name = "Geometry")]
        public Geometry? geometry { get; set; }
    }
}
