using System;
using System.Collections.Generic;

namespace StudentsEvents.Library.DBEntityModels
{
    public partial class Tag
    {
        public Tag()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; }
    }
}
