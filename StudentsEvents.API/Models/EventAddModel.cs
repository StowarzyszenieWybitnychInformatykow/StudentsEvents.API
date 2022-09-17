namespace StudentsEvents.API.Models
{
    public class EventAddModel
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Thumbnail { get; set; }
        public string Background { get; set; }
        public string Facebook { get; set; }
        public string Website { get; set; }
        public string Language { get; set; }
        public bool Registration { get; set; }
        public int? Tickets { get; set; }
        public bool Online { get; set; }
        public string Location { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string City { get; set; }
        //public string Region { get; set; }
        public List<TagModel> Tags { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        //public int StudentGovernmentId { get; set; }
        //public bool Published { get; set; }
        //public int OwnerID { get; set; }
        //public string Organization { get; set; }
        //public DateTimeOffset LastModified { get; set; }
    }
}
