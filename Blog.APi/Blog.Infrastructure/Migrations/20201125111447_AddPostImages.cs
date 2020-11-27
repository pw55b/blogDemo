using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Infrastructure.Migrations
{
    public partial class AddPostImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FileName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostImages", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0a7fe9e9-f8cb-4237-a1ac-948e0ccf76f2"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 19, 14, 47, 319, DateTimeKind.Local).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0aa35bd0-c08f-485c-bdd8-62fc9cba9837"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 19, 14, 47, 319, DateTimeKind.Local).AddTicks(1827));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0e419caa-22f7-41ac-8ee6-44e6e3ba27c8"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 19, 14, 47, 319, DateTimeKind.Local).AddTicks(1782));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0ee57ed6-5f8b-49f7-933c-06d09e71ad1e"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 19, 14, 47, 319, DateTimeKind.Local).AddTicks(1835));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("13ff2270-7776-4442-83bf-551d8bc72ff8"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 19, 14, 47, 319, DateTimeKind.Local).AddTicks(1839));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("7f886dc4-48f9-479c-b10c-edb4451bfcbb"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 19, 14, 47, 319, DateTimeKind.Local).AddTicks(1842));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("b2702cea-c9fc-4bbd-a755-53ea629c5c84"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 19, 14, 47, 317, DateTimeKind.Local).AddTicks(4979));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("d4b22650-8527-4325-b6b3-15828255dc47"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 19, 14, 47, 319, DateTimeKind.Local).AddTicks(1830));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostImages");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0a7fe9e9-f8cb-4237-a1ac-948e0ccf76f2"),
                column: "LastModified",
                value: new DateTime(2020, 11, 21, 19, 43, 8, 111, DateTimeKind.Local).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0aa35bd0-c08f-485c-bdd8-62fc9cba9837"),
                column: "LastModified",
                value: new DateTime(2020, 11, 21, 19, 43, 8, 111, DateTimeKind.Local).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0e419caa-22f7-41ac-8ee6-44e6e3ba27c8"),
                column: "LastModified",
                value: new DateTime(2020, 11, 21, 19, 43, 8, 111, DateTimeKind.Local).AddTicks(3786));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0ee57ed6-5f8b-49f7-933c-06d09e71ad1e"),
                column: "LastModified",
                value: new DateTime(2020, 11, 21, 19, 43, 8, 111, DateTimeKind.Local).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("13ff2270-7776-4442-83bf-551d8bc72ff8"),
                column: "LastModified",
                value: new DateTime(2020, 11, 21, 19, 43, 8, 111, DateTimeKind.Local).AddTicks(3853));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("7f886dc4-48f9-479c-b10c-edb4451bfcbb"),
                column: "LastModified",
                value: new DateTime(2020, 11, 21, 19, 43, 8, 111, DateTimeKind.Local).AddTicks(3856));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("b2702cea-c9fc-4bbd-a755-53ea629c5c84"),
                column: "LastModified",
                value: new DateTime(2020, 11, 21, 19, 43, 8, 109, DateTimeKind.Local).AddTicks(889));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("d4b22650-8527-4325-b6b3-15828255dc47"),
                column: "LastModified",
                value: new DateTime(2020, 11, 21, 19, 43, 8, 111, DateTimeKind.Local).AddTicks(3844));
        }
    }
}
