using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class BlockedUser
    {
        public int Id { get; set; }
        public int? BlockerId { get; set; }
        public int? BlockedId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual User? Blocked { get; set; }
        public virtual User? Blocker { get; set; }
    }
}
