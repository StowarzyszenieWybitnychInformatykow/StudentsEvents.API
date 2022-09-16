using System;
using System.Collections.Generic;

namespace StudentsEvents.Library.DBEntityModels
{
    public partial class User
    {
        public User()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
