using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addIdtoRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ea860d3-6139-453c-a487-649e250fb767");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc2e3b2b-d2fc-4798-b527-0b16854bf52a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b7afb518-6211-47f2-a7cb-95e7b500d74f", null, "User", "USER" },
                    { "f16264a2-d99b-4eaf-9052-8a5581e6ab85", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7afb518-6211-47f2-a7cb-95e7b500d74f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f16264a2-d99b-4eaf-9052-8a5581e6ab85");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7ea860d3-6139-453c-a487-649e250fb767", null, "Admin", "ADMIN" },
                    { "fc2e3b2b-d2fc-4798-b527-0b16854bf52a", null, "User", "USER" }
                });
        }
    }
}
