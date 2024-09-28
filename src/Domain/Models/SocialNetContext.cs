using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Models
{
    public partial class SocialNetContext : DbContext
    {
        public SocialNetContext()
        {
        }

        public SocialNetContext(DbContextOptions<SocialNetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlockedUser> BlockedUsers { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventAttendee> EventAttendees { get; set; } = null!;
        public virtual DbSet<Friend> Friends { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<GroupMember> GroupMembers { get; set; } = null!;
        public virtual DbSet<Like> Likes { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<PostTag> PostTags { get; set; } = null!;
        public virtual DbSet<PrivacySetting> PrivacySettings { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlockedUser>(entity =>
            {
                entity.HasIndex(e => new { e.BlockerId, e.BlockedId }, "UQ__BlockedU__638690F2152588B3")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BlockedId).HasColumnName("blocked_id");

                entity.Property(e => e.BlockerId).HasColumnName("blocker_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Blocked)
                    .WithMany(p => p.BlockedUserBlockeds)
                    .HasForeignKey(d => d.BlockedId)
                    .HasConstraintName("FK__BlockedUs__block__4C6B5938");

                entity.HasOne(d => d.Blocker)
                    .WithMany(p => p.BlockedUserBlockers)
                    .HasForeignKey(d => d.BlockerId)
                    .HasConstraintName("FK__BlockedUs__block__4B7734FF");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__Comments__post_i__01142BA1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Comments__user_i__02084FDA");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_time");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("location");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_time");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Events__created___2180FB33");
            });

            modelBuilder.Entity<EventAttendee>(entity =>
            {
                entity.HasIndex(e => new { e.EventId, e.UserId }, "UQ__EventAtt__C8EB145693A46794")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.JoinedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("joined_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('going')");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventAttendees)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__EventAtte__event__2739D489");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventAttendees)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__EventAtte__user___282DF8C2");
            });

            modelBuilder.Entity<Friend>(entity =>
            {
                entity.HasIndex(e => new { e.RequesterId, e.ReceiverId }, "UQ__Friends__4D70308224FF92DE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReceiverId).HasColumnName("receiver_id");

                entity.Property(e => e.RequesterId).HasColumnName("requester_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('pending')");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.FriendReceivers)
                    .HasForeignKey(d => d.ReceiverId)
                    .HasConstraintName("FK__Friends__receive__0E6E26BF");

                entity.HasOne(d => d.Requester)
                    .WithMany(p => p.FriendRequesters)
                    .HasForeignKey(d => d.RequesterId)
                    .HasConstraintName("FK__Friends__request__0D7A0286");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Groups__created___151B244E");
            });

            modelBuilder.Entity<GroupMember>(entity =>
            {
                entity.HasIndex(e => new { e.GroupId, e.UserId }, "UQ__GroupMem__3EEC76D196A123A9")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.JoinedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("joined_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Role)
                    .HasMaxLength(20)
                    .HasColumnName("role")
                    .HasDefaultValueSql("('member')");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupMembers)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__GroupMemb__group__1AD3FDA4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupMembers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__GroupMemb__user___1BC821DD");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasIndex(e => new { e.PostId, e.UserId }, "UQ__Likes__D54C641721F49967")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__Likes__post_id__07C12930");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Likes__user_id__08B54D69");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReadStatus)
                    .HasColumnName("read_status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceiverId).HasColumnName("receiver_id");

                entity.Property(e => e.SenderId).HasColumnName("sender_id");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.MessageReceivers)
                    .HasForeignKey(d => d.ReceiverId)
                    .HasConstraintName("FK__Messages__receiv__2EDAF651");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.MessageSenders)
                    .HasForeignKey(d => d.SenderId)
                    .HasConstraintName("FK__Messages__sender__2DE6D218");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsRead)
                    .HasColumnName("is_read")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Notificat__user___339FAB6E");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .HasColumnName("image_url");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Posts__user_id__7C4F7684");
            });

            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.HasIndex(e => new { e.PostId, e.TagId }, "UQ__PostTags__4AFEED4C38B906C8")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostTags)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__PostTags__post_i__3C34F16F");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.PostTags)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK__PostTags__tag_id__3D2915A8");
            });

            modelBuilder.Entity<PrivacySetting>(entity =>
            {
                entity.HasIndex(e => e.UserId, "UQ__PrivacyS__B9BE370EE37D3B90")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FriendRequests)
                    .HasMaxLength(20)
                    .HasColumnName("friend_requests")
                    .HasDefaultValueSql("('everyone')");

                entity.Property(e => e.PostVisibility)
                    .HasMaxLength(20)
                    .HasColumnName("post_visibility")
                    .HasDefaultValueSql("('public')");

                entity.Property(e => e.ProfileVisibility)
                    .HasMaxLength(20)
                    .HasColumnName("profile_visibility")
                    .HasDefaultValueSql("('public')");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.PrivacySetting)
                    .HasForeignKey<PrivacySetting>(d => d.UserId)
                    .HasConstraintName("FK__PrivacySe__user___40F9A68C");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Tags__72E12F1B1A105CBB")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__AB6E6164FB61B3CA")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__Users__F3DBC572247FDA97")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bio).HasColumnName("bio");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(255)
                    .HasColumnName("password_hash");

                entity.Property(e => e.ProfilePicture)
                    .HasMaxLength(255)
                    .HasColumnName("profile_picture");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
