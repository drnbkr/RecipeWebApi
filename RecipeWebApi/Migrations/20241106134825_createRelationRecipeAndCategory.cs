using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeWebApi.Migrations
{
    /// <inheritdoc />
    public partial class createRelationRecipeAndCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "40b16e49-098b-4bff-a461-4ad2a4690564", null, "Editor", "EDITOR" },
                    { "91b11b4f-680b-482f-93cc-c1c1bf6136ea", null, "Admin", "ADMIN" },
                    { "e8b08742-e048-426a-a6c6-12da9bc3efbf", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Categories_CategoryId",
                table: "Recipes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Categories_CategoryId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes");

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
    }
}
