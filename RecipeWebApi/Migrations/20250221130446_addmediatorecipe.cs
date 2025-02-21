using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addmediatorecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "eae0e6ee-61a1-4b10-a377-080f5b506cd4", "AQAAAAIAAYagAAAAEKbYJMt/3mzc17me0Yo1of6YP1rXD3DkicUIj7O7y+i2D4ccM+9nmXblP+Pb2rFkHA==" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Recipes_RecipeId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_RecipeId",
                table: "Medias");

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
    }
}
