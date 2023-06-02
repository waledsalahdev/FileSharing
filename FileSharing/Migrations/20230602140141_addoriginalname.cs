using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FileSharing.Migrations
{
    /// <inheritdoc />
    public partial class addoriginalname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84f1732f-7d57-4517-ae48-760ce77b6226");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b0752c-e50f-4846-8286-72193f1c1686");

            migrationBuilder.AddColumn<string>(
                name: "Originalname",
                table: "Uploads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "97d9e06d-b7c3-4ed5-a8e3-bca6a119a969", "2", "User", "User" },
                    { "ab3a8e4c-9b9b-4df6-91f4-1c518df1769e", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97d9e06d-b7c3-4ed5-a8e3-bca6a119a969");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab3a8e4c-9b9b-4df6-91f4-1c518df1769e");

            migrationBuilder.DropColumn(
                name: "Originalname",
                table: "Uploads");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "84f1732f-7d57-4517-ae48-760ce77b6226", "2", "User", "User" },
                    { "c7b0752c-e50f-4846-8286-72193f1c1686", "1", "Admin", "Admin" }
                });
        }
    }
}
