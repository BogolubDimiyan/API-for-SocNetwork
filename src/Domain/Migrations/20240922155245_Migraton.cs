using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class Migraton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    birthdate = table.Column<DateTime>(type: "date", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    profile_picture = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BlockedUsers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    blocker_id = table.Column<int>(type: "int", nullable: true),
                    blocked_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockedUsers", x => x.id);
                    table.ForeignKey(
                        name: "FK__BlockedUs__block__4B7734FF",
                        column: x => x.blocker_id,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__BlockedUs__block__4C6B5938",
                        column: x => x.blocked_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    start_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    end_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.id);
                    table.ForeignKey(
                        name: "FK__Events__created___2180FB33",
                        column: x => x.created_by,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    requester_id = table.Column<int>(type: "int", nullable: true),
                    receiver_id = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "('pending')"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.id);
                    table.ForeignKey(
                        name: "FK__Friends__receive__0E6E26BF",
                        column: x => x.receiver_id,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Friends__request__0D7A0286",
                        column: x => x.requester_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.id);
                    table.ForeignKey(
                        name: "FK__Groups__created___151B244E",
                        column: x => x.created_by,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sender_id = table.Column<int>(type: "int", nullable: true),
                    receiver_id = table.Column<int>(type: "int", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    read_status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.id);
                    table.ForeignKey(
                        name: "FK__Messages__receiv__2EDAF651",
                        column: x => x.receiver_id,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Messages__sender__2DE6D218",
                        column: x => x.sender_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    is_read = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.id);
                    table.ForeignKey(
                        name: "FK__Notificat__user___339FAB6E",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.id);
                    table.ForeignKey(
                        name: "FK__Posts__user_id__7C4F7684",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PrivacySettings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    profile_visibility = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "('public')"),
                    post_visibility = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "('public')"),
                    friend_requests = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "('everyone')"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivacySettings", x => x.id);
                    table.ForeignKey(
                        name: "FK__PrivacySe__user___40F9A68C",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "EventAttendees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    event_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "('going')"),
                    joined_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAttendees", x => x.id);
                    table.ForeignKey(
                        name: "FK__EventAtte__event__2739D489",
                        column: x => x.event_id,
                        principalTable: "Events",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__EventAtte__user___282DF8C2",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "GroupMembers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    group_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "('member')"),
                    joined_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMembers", x => x.id);
                    table.ForeignKey(
                        name: "FK__GroupMemb__group__1AD3FDA4",
                        column: x => x.group_id,
                        principalTable: "Groups",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__GroupMemb__user___1BC821DD",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    post_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK__Comments__post_i__01142BA1",
                        column: x => x.post_id,
                        principalTable: "Posts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Comments__user_i__02084FDA",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    post_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.id);
                    table.ForeignKey(
                        name: "FK__Likes__post_id__07C12930",
                        column: x => x.post_id,
                        principalTable: "Posts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Likes__user_id__08B54D69",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    post_id = table.Column<int>(type: "int", nullable: true),
                    tag_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => x.id);
                    table.ForeignKey(
                        name: "FK__PostTags__post_i__3C34F16F",
                        column: x => x.post_id,
                        principalTable: "Posts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__PostTags__tag_id__3D2915A8",
                        column: x => x.tag_id,
                        principalTable: "Tags",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlockedUsers_blocked_id",
                table: "BlockedUsers",
                column: "blocked_id");

            migrationBuilder.CreateIndex(
                name: "UQ__BlockedU__638690F2152588B3",
                table: "BlockedUsers",
                columns: new[] { "blocker_id", "blocked_id" },
                unique: true,
                filter: "[blocker_id] IS NOT NULL AND [blocked_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_post_id",
                table: "Comments",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_user_id",
                table: "Comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendees_user_id",
                table: "EventAttendees",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__EventAtt__C8EB145693A46794",
                table: "EventAttendees",
                columns: new[] { "event_id", "user_id" },
                unique: true,
                filter: "[event_id] IS NOT NULL AND [user_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Events_created_by",
                table: "Events",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_receiver_id",
                table: "Friends",
                column: "receiver_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Friends__4D70308224FF92DE",
                table: "Friends",
                columns: new[] { "requester_id", "receiver_id" },
                unique: true,
                filter: "[requester_id] IS NOT NULL AND [receiver_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_user_id",
                table: "GroupMembers",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__GroupMem__3EEC76D196A123A9",
                table: "GroupMembers",
                columns: new[] { "group_id", "user_id" },
                unique: true,
                filter: "[group_id] IS NOT NULL AND [user_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_created_by",
                table: "Groups",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_user_id",
                table: "Likes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Likes__D54C641721F49967",
                table: "Likes",
                columns: new[] { "post_id", "user_id" },
                unique: true,
                filter: "[post_id] IS NOT NULL AND [user_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_receiver_id",
                table: "Messages",
                column: "receiver_id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_sender_id",
                table: "Messages",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_user_id",
                table: "Notifications",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_user_id",
                table: "Posts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_tag_id",
                table: "PostTags",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "UQ__PostTags__4AFEED4C38B906C8",
                table: "PostTags",
                columns: new[] { "post_id", "tag_id" },
                unique: true,
                filter: "[post_id] IS NOT NULL AND [tag_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__PrivacyS__B9BE370EE37D3B90",
                table: "PrivacySettings",
                column: "user_id",
                unique: true,
                filter: "[user_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Tags__72E12F1B1A105CBB",
                table: "Tags",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__AB6E6164FB61B3CA",
                table: "Users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__F3DBC572247FDA97",
                table: "Users",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockedUsers");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "EventAttendees");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "GroupMembers");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "PrivacySettings");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
