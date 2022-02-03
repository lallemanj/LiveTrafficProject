using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveTrafficProject.Models
{
    public class Properties
    { 
     [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("iconCategory")]
        [Display(Name = "Category")]
        public int IconCategory { get; set; }

    [JsonProperty("magnitudeOfDelay")]
        [Display(Name = "Magnitude of delay")]
        public int MagnitudeOfDelay { get; set; }

    [JsonProperty("startTime")]
    [Required]
    [Display(Name = "Start time")]
    [DataType(DataType.Date)]
    public DateTime StartTime { get; set; }

    [JsonProperty("endTime")]
        [Required]
        [Display(Name = "End time")]
        [DataType(DataType.Date)]
        public DateTime? EndTime { get; set; }

    [JsonProperty("from")]
        [Display(Name = "From")]
        public string? From { get; set; }

    [JsonProperty("to")]
        [Display(Name = "To")]
        public string? To { get; set; }

    [JsonProperty("length")]
        [Display(Name = "Length")]
        public double Length { get; set; }

    [JsonProperty("delay")]
        [Display(Name = "Delay")]
        public int Delay { get; set; }

    [JsonProperty("roadNumbers")]
    [NotMapped]
    public List<object>? RoadNumbers { get; set; }

    [JsonProperty("timeValidity")]
        [Display(Name = "Time Validity")]
        public string? TimeValidity { get; set; }

    [JsonProperty("events")]
        [Display(Name = "Events")]
        public List<Event>? Events { get; set; }

    [JsonProperty("aci")]
    [NotMapped]
    public object? Aci { get; set; }

    [JsonProperty("tmc")]
    [NotMapped]
    public Tmc? Tmc { get; set; }

    }
}
