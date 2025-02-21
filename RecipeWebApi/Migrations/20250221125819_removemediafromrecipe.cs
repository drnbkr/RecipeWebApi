using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebApi.Migrations
{
    /// <inheritdoc />
    public partial class removemediafromrecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Recipes_RecipeId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_RecipeId",
                table: "Medias");

            migrationBuilder.DeleteData(
                table: "Medias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Medias");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9825bdbb-101d-49c0-82c8-6c4f54b93253",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c634c119-3755-4b8b-85b8-001c0690c979", "AQAAAAIAAYagAAAAEAWxLaIIoNBPURSQ7HpIg7IjlQVjibwhi0Zvh2hnJuFcu1v/pQSc1ElNAeaaTEiIcQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Medias",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9825bdbb-101d-49c0-82c8-6c4f54b93253",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "83d08f4b-30e4-4a89-b15b-84afa05eb8b2", "AQAAAAIAAYagAAAAEFn+MEqYBFNMZbabTIK3BVzIAC/rL3/WqRT7Hl/rL+/Ru76VK+hcD6wDPYuA+AMGpQ==" });

            migrationBuilder.UpdateData(
                table: "Medias",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecipeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Medias",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecipeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Medias",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecipeId",
                value: null);

            migrationBuilder.InsertData(
                table: "Medias",
                columns: new[] { "Id", "CreatedBy", "IsCover", "MediaPath", "MediaType", "RecipeId", "RecipeInstructionId" },
                values: new object[] { 4, null, false, "https://via.placeholder.com/250", "image", 3, null });

            migrationBuilder.CreateIndex(
                name: "IX_Medias_RecipeId",
                table: "Medias",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Recipes_RecipeId",
                table: "Medias",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}
