using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Group
    {
        public Group()
        {
            GroupMembers = new HashSet<GroupMember>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual User? CreatedByNavigation { get; set; }
        public virtual ICollection<GroupMember> GroupMembers { get; set; }
    }
}
