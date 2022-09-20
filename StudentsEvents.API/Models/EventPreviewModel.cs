namespace StudentsEvents.API.Models
{
    public class EventPreviewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string Background { get; set; }
        public bool Online { get; set; }
        public string Location { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string City { get; set; }
        public List<TagModel> Tags { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}
