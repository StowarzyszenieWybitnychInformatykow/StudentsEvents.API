using System.ComponentModel.DataAnnotations;

namespace StudentsEvents.API.Models
{
    public class EventUpdateModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string Thumbnail { get; set; }
        [Required]
        public string Background { get; set; }
        public string Facebook { get; set; }
        public string Website { get; set; }
        [Required]
        public string Language { get; set; }
        public bool Registration { get; set; }
        public bool Tickets { get; set; }
        public bool Online { get; set; }
        public string Location { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string City { get; set; }
        public List<TagModel> Tags { get; set; }
        [Required]
        public DateTimeOffset StartDate { get; set; }
        [Required]
        public DateTimeOffset EndDate { get; set; }
        //public int StudentGovernmentId { get; set; }
        //public string Organization { get; set; }
    }
}
