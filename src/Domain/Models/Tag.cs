using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Tag
    {
        public Tag()
        {
            PostTags = new HashSet<PostTag>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}
