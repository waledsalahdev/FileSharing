using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FileSharing.Migrations
{
    /// <inheritdoc />
    public partial class adduploaddate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68cb3a42-ad08-42cf-83c9-a11e2189d74f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da74e395-3062-4fbb-8028-5a2d125dcd4d");

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadDate",
                table: "Uploads",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getDate()");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "84f1732f-7d57-4517-ae48-760ce77b6226", "2", "User", "User" },
                    { "c7b0752c-e50f-4846-8286-72193f1c1686", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84f1732f-7d57-4517-ae48-760ce77b6226");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b0752c-e50f-4846-8286-72193f1c1686");

            migrationBuilder.DropColumn(
                name: "UploadDate",
                table: "Uploads");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "68cb3a42-ad08-42cf-83c9-a11e2189d74f", "1", "Admin", "Admin" },
                    { "da74e395-3062-4fbb-8028-5a2d125dcd4d", "2", "User", "User" }
                });
        }
    }
}
