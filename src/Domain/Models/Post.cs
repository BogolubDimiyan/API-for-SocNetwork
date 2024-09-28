using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
            PostTags = new HashSet<PostTag>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}
