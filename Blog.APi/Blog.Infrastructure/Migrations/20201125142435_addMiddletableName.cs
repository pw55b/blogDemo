using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Infrastructure.Migrations
{
    public partial class addMiddletableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCategory_Category_CategoryId",
                table: "PostCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_PostCategory_Posts_PostId",
                table: "PostCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostCategory",
                table: "PostCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "PostCategory",
                newName: "PostCategories");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_PostCategory_CategoryId",
                table: "PostCategories",
                newName: "IX_PostCategories_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "ContentAbstract",
                table: "Posts",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Categories",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostCategories",
                table: "PostCategories",
                columns: new[] { "PostId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategories_Categories_CategoryId",
                table: "PostCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategories_Posts_PostId",
                table: "PostCategories",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCategories_Categories_CategoryId",
                table: "PostCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PostCategories_Posts_PostId",
                table: "PostCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostCategories",
                table: "PostCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "PostCategories",
                newName: "PostCategory");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_PostCategories_CategoryId",
                table: "PostCategory",
                newName: "IX_PostCategory_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "ContentAbstract",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostCategory",
                table: "PostCategory",
                columns: new[] { "PostId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategory_Category_CategoryId",
                table: "PostCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategory_Posts_PostId",
                table: "PostCategory",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
