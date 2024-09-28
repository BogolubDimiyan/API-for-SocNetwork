using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class PrivacySetting
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? ProfileVisibility { get; set; }
        public string? PostVisibility { get; set; }
        public string? FriendRequests { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual User? User { get; set; }
    }
}
