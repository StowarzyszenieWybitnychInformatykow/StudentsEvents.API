﻿namespace StudentsEvents.API.Models
{
    public class FilterModel
    {
        public int[]? TagsID { get; set; } = null;
        public string? City { get; set; } = null;
        public bool? IsRegistration { get; set; } = null;
        public bool? IsOnline { get; set; } = null;
        public DateTimeOffset? Start { get; set; } = null;
        public DateTimeOffset? End { get; set; } = null;
        public string? Text = null;
    }
}