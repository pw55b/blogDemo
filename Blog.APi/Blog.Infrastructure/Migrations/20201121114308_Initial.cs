using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    Author = table.Column<string>(maxLength: 50, nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "Content", "LastModified", "Remark", "Title" },
                values: new object[,]
                {
                    { new Guid("b2702cea-c9fc-4bbd-a755-53ea629c5c84"), "Dave", "Post Content 1", new DateTime(2020, 11, 21, 19, 43, 8, 109, DateTimeKind.Local).AddTicks(889), null, "Post Title 1" },
                    { new Guid("0e419caa-22f7-41ac-8ee6-44e6e3ba27c8"), "Dave", "Post Content 2", new DateTime(2020, 11, 21, 19, 43, 8, 111, DateTimeKind.Local).AddTicks(3786), null, "Post Title 2" },
                    { new Guid("0a7fe9e9-f8cb-4237-a1ac-948e0ccf76f2"), "Dave", "Post Content 3", new DateTime(2020, 11, 21, 19, 43, 8, 111, DateTimeKind.Local).AddTicks(3835), null, "Post Title 3" },
                    { new Guid("0aa35bd0-c08f-485c-bdd8-62fc9cba9837"), "Dave", "Post Content 4", new DateTime(2020, 11, 21, 19, 43, 8, 111, DateTimeKind.Local).AddTicks(3840), null, "Post Title 4" },
                    { new Guid("d4b22650-8527-4325-b6b3-15828255dc47"), "Dave", "Post Content 5", new DateTime(2020, 11, 21, 19, 43, 8, 111, DateTimeKind.Local).AddTicks(3844), null, "Post Title 5" },
                    { new Guid("0ee57ed6-5f8b-49f7-933c-06d09e71ad1e"), "Dave", "Post Content 6", new DateTime(2020, 11, 21, 19, 43, 8, 111, DateTimeKind.Local).AddTicks(3850), null, "Post Title 6" },
                    { new Guid("13ff2270-7776-4442-83bf-551d8bc72ff8"), "Dave", "Post Content 7", new DateTime(2020, 11, 21, 19, 43, 8, 111, DateTimeKind.Local).AddTicks(3853), null, "Post Title 7" },
                    { new Guid("7f886dc4-48f9-479c-b10c-edb4451bfcbb"), "Dave", "Post Content 8", new DateTime(2020, 11, 21, 19, 43, 8, 111, DateTimeKind.Local).AddTicks(3856), null, "Post Title 8" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
