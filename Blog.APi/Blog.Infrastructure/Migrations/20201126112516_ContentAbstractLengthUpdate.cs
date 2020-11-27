using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Infrastructure.Migrations
{
    public partial class ContentAbstractLengthUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContentAbstract",
                table: "Posts",
                maxLength: 420,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0a7fe9e9-f8cb-4237-a1ac-948e0ccf76f2"),
                column: "LastModified",
                value: new DateTime(2020, 11, 26, 19, 25, 16, 57, DateTimeKind.Local).AddTicks(4080));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0aa35bd0-c08f-485c-bdd8-62fc9cba9837"),
                column: "LastModified",
                value: new DateTime(2020, 11, 26, 19, 25, 16, 57, DateTimeKind.Local).AddTicks(4085));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0e419caa-22f7-41ac-8ee6-44e6e3ba27c8"),
                column: "LastModified",
                value: new DateTime(2020, 11, 26, 19, 25, 16, 57, DateTimeKind.Local).AddTicks(4046));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0ee57ed6-5f8b-49f7-933c-06d09e71ad1e"),
                column: "LastModified",
                value: new DateTime(2020, 11, 26, 19, 25, 16, 57, DateTimeKind.Local).AddTicks(4091));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("13ff2270-7776-4442-83bf-551d8bc72ff8"),
                column: "LastModified",
                value: new DateTime(2020, 11, 26, 19, 25, 16, 57, DateTimeKind.Local).AddTicks(4094));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("7f886dc4-48f9-479c-b10c-edb4451bfcbb"),
                column: "LastModified",
                value: new DateTime(2020, 11, 26, 19, 25, 16, 57, DateTimeKind.Local).AddTicks(4097));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("b2702cea-c9fc-4bbd-a755-53ea629c5c84"),
                column: "LastModified",
                value: new DateTime(2020, 11, 26, 19, 25, 16, 56, DateTimeKind.Local).AddTicks(410));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("d4b22650-8527-4325-b6b3-15828255dc47"),
                column: "LastModified",
                value: new DateTime(2020, 11, 26, 19, 25, 16, 57, DateTimeKind.Local).AddTicks(4088));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContentAbstract",
                table: "Posts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 420,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0a7fe9e9-f8cb-4237-a1ac-948e0ccf76f2"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 22, 24, 34, 961, DateTimeKind.Local).AddTicks(9941));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0aa35bd0-c08f-485c-bdd8-62fc9cba9837"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 22, 24, 34, 961, DateTimeKind.Local).AddTicks(9950));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0e419caa-22f7-41ac-8ee6-44e6e3ba27c8"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 22, 24, 34, 961, DateTimeKind.Local).AddTicks(9881));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0ee57ed6-5f8b-49f7-933c-06d09e71ad1e"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 22, 24, 34, 961, DateTimeKind.Local).AddTicks(9965));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("13ff2270-7776-4442-83bf-551d8bc72ff8"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 22, 24, 34, 961, DateTimeKind.Local).AddTicks(9974));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("7f886dc4-48f9-479c-b10c-edb4451bfcbb"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 22, 24, 34, 961, DateTimeKind.Local).AddTicks(9982));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("b2702cea-c9fc-4bbd-a755-53ea629c5c84"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 22, 24, 34, 959, DateTimeKind.Local).AddTicks(6986));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("d4b22650-8527-4325-b6b3-15828255dc47"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 22, 24, 34, 961, DateTimeKind.Local).AddTicks(9957));
        }
    }
}
