using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addDescriptionFieldToRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40b16e49-098b-4bff-a461-4ad2a4690564");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91b11b4f-680b-482f-93cc-c1c1bf6136ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8b08742-e048-426a-a6c6-12da9bc3efbf");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2bcaf9d9-fa5f-4188-811f-4b0268bfde60", null, "Editor", "EDITOR" },
                    { "7ea860d3-6139-453c-a487-649e250fb767", null, "Admin", "ADMIN" },
                    { "fc2e3b2b-d2fc-4798-b527-0b16854bf52a", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Menemen Menemen pişmandır yemeyen.");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Tereyağlı pilavdır");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Çorba severim.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bcaf9d9-fa5f-4188-811f-4b0268bfde60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ea860d3-6139-453c-a487-649e250fb767");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc2e3b2b-d2fc-4798-b527-0b16854bf52a");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Recipes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "40b16e49-098b-4bff-a461-4ad2a4690564", null, "Editor", "EDITOR" },
                    { "91b11b4f-680b-482f-93cc-c1c1bf6136ea", null, "Admin", "ADMIN" },
                    { "e8b08742-e048-426a-a6c6-12da9bc3efbf", null, "User", "USER" }
                });
        }
    }
}
