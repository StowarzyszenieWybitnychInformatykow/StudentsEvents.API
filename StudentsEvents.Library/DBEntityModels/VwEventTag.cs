using System;
using System.Collections.Generic;

namespace StudentsEvents.Library.DBEntityModels
{
    public partial class VwEventTag
    {
        public Guid EventId { get; set; }
        public int TagId { get; set; }
    }
}
