using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebApi.Migrations
{
    /// <inheritdoc />
    public partial class removeCalorieFromRecipIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "RecipeIngredients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Calories",
                table: "RecipeIngredients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Calories",
                value: 40m);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Calories",
                value: 90m);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 3,
                column: "Calories",
                value: 10m);
        }
    }
}
