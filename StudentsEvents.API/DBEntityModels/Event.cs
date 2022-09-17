using System;
using System.Collections.Generic;

namespace StudentsEvents.API.DBEntityModels
{
    public partial class Event
    {
        public Event()
        {
            Tags = new HashSet<Tag>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string Thumbnail { get; set; } = null!;
        public string Background { get; set; } = null!;
        public string? Facebook { get; set; }
        public string? Website { get; set; }
        public string Language { get; set; } = null!;
        public int Upvotes { get; set; }
        public bool Registration { get; set; }
        public bool Tickets { get; set; }
        public bool? Online { get; set; }
        public string? Location { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int? StudentGovernmentId { get; set; }
        public bool Published { get; set; }
        public string OwnerId { get; set; } = null!;
        public string Organization { get; set; } = null!;
        public DateTimeOffset LastModified { get; set; }
        public bool IsDeleted { get; set; }

        public virtual StudentGovernment? StudentGovernment { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
