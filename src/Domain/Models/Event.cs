using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Event
    {
        public Event()
        {
            EventAttendees = new HashSet<EventAttendee>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Location { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual User? CreatedByNavigation { get; set; }
        public virtual ICollection<EventAttendee> EventAttendees { get; set; }
    }
}
