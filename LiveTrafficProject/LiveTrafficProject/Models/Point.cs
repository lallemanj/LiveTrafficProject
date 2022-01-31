using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LiveTrafficProject.Models
{
    public class Point
    {
        public int Id { get; set; }

        [JsonProperty("location")]
        [Display(Name = "Location")]
        public int Location { get; set; }

        [JsonProperty("offset")]
        [Display(Name = "Offset")]
        public int Offset { get; set; }
    }
}
