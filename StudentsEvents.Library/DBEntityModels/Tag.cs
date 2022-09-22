using System;
using System.Collections.Generic;

namespace StudentsEvents.Library.DBEntityModels
{
    public partial class Tag
    {
        public Tag()
        {
            Events = new HashSet<Event>();
            EventsNavigation = new HashSet<UpdateEvent>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<UpdateEvent> EventsNavigation { get; set; }
    }
}
