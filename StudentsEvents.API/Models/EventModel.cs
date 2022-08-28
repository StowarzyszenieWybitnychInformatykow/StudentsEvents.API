namespace StudentsEvents.API.Models
{
    public class EventModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Thumbnail { get; set; }
        public int? Tickets { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<TagModel> Tags { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public Guid StudentGovernmentId { get; set; }
        public bool Published { get; set; }
        public string Owner { get; set; }
        public DateTimeOffset LastModified { get; set; }

    }
}
