using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Infrastructure.Migrations
{
    public partial class addMiddletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "ContentAbstract",
                table: "Posts",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "PostImages",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostCategory",
                columns: table => new
                {
                    PostId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategory", x => new { x.PostId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PostCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCategory_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "Note" },
                values: new object[,]
                {
                    { new Guid("24272cf6-79d3-4550-b5b9-a71297a04a75"), "C#", "一种编程语言" },
                    { new Guid("023cc1b2-1ef7-40d7-b07c-0164ed0bb44a"), "asp.net core", "是一个跨平台的高性能开源框架" },
                    { new Guid("7f65e5a6-00ab-4cf6-9c17-996905936406"), "EF", "一种关系映射器" }
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0a7fe9e9-f8cb-4237-a1ac-948e0ccf76f2"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 22, 17, 54, 121, DateTimeKind.Local).AddTicks(6554));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0aa35bd0-c08f-485c-bdd8-62fc9cba9837"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 22, 17, 54, 121, DateTimeKind.Local).AddTicks(6566));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0e419caa-22f7-41ac-8ee6-44e6e3ba27c8"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 22, 17, 54, 121, DateTimeKind.Local).AddTicks(6421));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0ee57ed6-5f8b-49f7-933c-06d09e71ad1e"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 22, 17, 54, 121, DateTimeKind.Local).AddTicks(6588));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("13ff2270-7776-4442-83bf-551d8bc72ff8"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 22, 17, 54, 121, DateTimeKind.Local).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("7f886dc4-48f9-479c-b10c-edb4451bfcbb"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 22, 17, 54, 121, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("b2702cea-c9fc-4bbd-a755-53ea629c5c84"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 22, 17, 54, 119, DateTimeKind.Local).AddTicks(5602));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("d4b22650-8527-4325-b6b3-15828255dc47"),
                column: "LastModified",
                value: new DateTime(2020, 11, 25, 22, 17, 54, 121, DateTimeKind.Local).AddTicks(6577));

            migrationBuilder.InsertData(
                table: "PostCategory",
                columns: new[] { "PostId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("7f886dc4-48f9-479c-b10c-edb4451bfcbb"), new Guid("24272cf6-79d3-4550-b5b9-a71297a04a75") },
                    { new Guid("13ff2270-7776-4442-83bf-551d8bc72ff8"), new Guid("24272cf6-79d3-4550-b5b9-a71297a04a75") },
                    { new Guid("0ee57ed6-5f8b-49f7-933c-06d09e71ad1e"), new Guid("023cc1b2-1ef7-40d7-b07c-0164ed0bb44a") },
                    { new Guid("d4b22650-8527-4325-b6b3-15828255dc47"), new Guid("023cc1b2-1ef7-40d7-b07c-0164ed0bb44a") },
                    { new Guid("0ee57ed6-5f8b-49f7-933c-06d09e71ad1e"), new Guid("7f65e5a6-00ab-4cf6-9c17-996905936406") },
                    { new Guid("d4b22650-8527-4325-b6b3-15828255dc47"), new Guid("7f65e5a6-00ab-4cf6-9c17-996905936406") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostCategory_CategoryId",
                table: "PostCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropColumn(
                name: "ContentAbstract",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Posts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "PostImages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0a7fe9e9-f8cb-4237-a1ac-948e0ccf76f2"),
                columns: new[] { "Author", "LastModified" },
                values: new object[] { "Dave", new DateTime(2020, 11, 25, 19, 14, 47, 319, DateTimeKind.Local).AddTicks(1822) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0aa35bd0-c08f-485c-bdd8-62fc9cba9837"),
                columns: new[] { "Author", "LastModified" },
                values: new object[] { "Dave", new DateTime(2020, 11, 25, 19, 14, 47, 319, DateTimeKind.Local).AddTicks(1827) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0e419caa-22f7-41ac-8ee6-44e6e3ba27c8"),
                columns: new[] { "Author", "LastModified" },
                values: new object[] { "Dave", new DateTime(2020, 11, 25, 19, 14, 47, 319, DateTimeKind.Local).AddTicks(1782) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0ee57ed6-5f8b-49f7-933c-06d09e71ad1e"),
                columns: new[] { "Author", "LastModified" },
                values: new object[] { "Dave", new DateTime(2020, 11, 25, 19, 14, 47, 319, DateTimeKind.Local).AddTicks(1835) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("13ff2270-7776-4442-83bf-551d8bc72ff8"),
                columns: new[] { "Author", "LastModified" },
                values: new object[] { "Dave", new DateTime(2020, 11, 25, 19, 14, 47, 319, DateTimeKind.Local).AddTicks(1839) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("7f886dc4-48f9-479c-b10c-edb4451bfcbb"),
                columns: new[] { "Author", "LastModified" },
                values: new object[] { "Dave", new DateTime(2020, 11, 25, 19, 14, 47, 319, DateTimeKind.Local).AddTicks(1842) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("b2702cea-c9fc-4bbd-a755-53ea629c5c84"),
                columns: new[] { "Author", "LastModified" },
                values: new object[] { "Dave", new DateTime(2020, 11, 25, 19, 14, 47, 317, DateTimeKind.Local).AddTicks(4979) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("d4b22650-8527-4325-b6b3-15828255dc47"),
                columns: new[] { "Author", "LastModified" },
                values: new object[] { "Dave", new DateTime(2020, 11, 25, 19, 14, 47, 319, DateTimeKind.Local).AddTicks(1830) });
        }
    }
}
