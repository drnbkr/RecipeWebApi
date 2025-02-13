using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebApi.Migrations
{
    /// <inheritdoc />
    public partial class userIDToRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "9825bdbb-101d-49c0-82c8-6c4f54b93253");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "9825bdbb-101d-49c0-82c8-6c4f54b93253");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "9825bdbb-101d-49c0-82c8-6c4f54b93253");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "ade27b87-2cb8-4f43-a9fc-eb6db952793c");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "ade27b87-2cb8-4f43-a9fc-eb6db952793c");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "ade27b87-2cb8-4f43-a9fc-eb6db952793c");
        }
    }
}
