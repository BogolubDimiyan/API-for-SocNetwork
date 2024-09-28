using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class User
    {
        public User()
        {
            BlockedUserBlockeds = new HashSet<BlockedUser>();
            BlockedUserBlockers = new HashSet<BlockedUser>();
            Comments = new HashSet<Comment>();
            EventAttendees = new HashSet<EventAttendee>();
            Events = new HashSet<Event>();
            FriendReceivers = new HashSet<Friend>();
            FriendRequesters = new HashSet<Friend>();
            GroupMembers = new HashSet<GroupMember>();
            Groups = new HashSet<Group>();
            Likes = new HashSet<Like>();
            MessageReceivers = new HashSet<Message>();
            MessageSenders = new HashSet<Message>();
            Notifications = new HashSet<Notification>();
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Gender { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Bio { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual PrivacySetting? PrivacySetting { get; set; }
        public virtual ICollection<BlockedUser> BlockedUserBlockeds { get; set; }
        public virtual ICollection<BlockedUser> BlockedUserBlockers { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<EventAttendee> EventAttendees { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Friend> FriendReceivers { get; set; }
        public virtual ICollection<Friend> FriendRequesters { get; set; }
        public virtual ICollection<GroupMember> GroupMembers { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Message> MessageReceivers { get; set; }
        public virtual ICollection<Message> MessageSenders { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
