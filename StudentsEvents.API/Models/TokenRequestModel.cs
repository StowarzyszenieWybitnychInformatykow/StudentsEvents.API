﻿namespace StudentsEvents.API.Models
{
    public class TokenRequestModel
    {
        public string grant_type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
