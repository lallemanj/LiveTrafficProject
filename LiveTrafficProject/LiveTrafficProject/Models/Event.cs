using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LiveTrafficProject.Models
{
    public class Event
    {
        public int Id { get; set; }

        [JsonProperty("code")]
        [Display(Name = "Code")]
        public int Code { get; set; }

        [JsonProperty("description")]
        [Display(Name = "Description")]
        public string? Description { get; set; }
    }
}
