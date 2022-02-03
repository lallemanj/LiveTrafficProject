using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public List<List<double>>? Coordinates { get; set; }
    }
}
