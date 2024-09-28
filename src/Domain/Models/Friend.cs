using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Friend
    {
        public int Id { get; set; }
        public int? RequesterId { get; set; }
        public int? ReceiverId { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual User? Receiver { get; set; }
        public virtual User? Requester { get; set; }
    }
}
