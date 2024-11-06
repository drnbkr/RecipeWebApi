using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeWebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRecipeConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a32e0ad8-eec1-45a9-96ee-f367cf2981c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8ca8033-de61-4481-8a5e-e06cac8e7f33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1566e95-2f1e-4584-8dcd-068f2276665d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a1d9a1d-d481-4000-8077-defc958f1ecb", null, "User", "USER" },
                    { "21ca44df-7fe8-4cd5-bafd-88cb86d08e83", null, "Editor", "EDITOR" },
                    { "c4019ce6-6852-4890-9a91-074eca708dc8", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a1d9a1d-d481-4000-8077-defc958f1ecb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21ca44df-7fe8-4cd5-bafd-88cb86d08e83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4019ce6-6852-4890-9a91-074eca708dc8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a32e0ad8-eec1-45a9-96ee-f367cf2981c2", null, "Admin", "ADMIN" },
                    { "b8ca8033-de61-4481-8a5e-e06cac8e7f33", null, "User", "USER" },
                    { "c1566e95-2f1e-4584-8dcd-068f2276665d", null, "Editor", "EDITOR" }
                });
        }
    }
}
