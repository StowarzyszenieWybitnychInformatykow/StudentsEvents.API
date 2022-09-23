using System;
using System.Collections.Generic;

namespace StudentsEvents.Library.DBEntityModels
{
    public partial class User
    {
        public string Id { get; set; } = null!;
        public int RoleId { get; set; }
    }
}
