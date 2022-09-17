using System;
using System.Collections.Generic;

namespace StudentsEvents.Library.DBEntityModels
{
    public partial class StudentGovernment
    {
        public StudentGovernment()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public string University { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string Facebook { get; set; } = null!;
        public string? Website { get; set; }
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; }
    }
}
