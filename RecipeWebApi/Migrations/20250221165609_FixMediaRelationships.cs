using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebApi.Migrations
{
    /// <inheritdoc />
    public partial class FixMediaRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Recipes_RecipeId",
                table: "Medias");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9825bdbb-101d-49c0-82c8-6c4f54b93253",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "166cd379-ea10-4b17-8d0c-bfdae2b967c5", "AQAAAAIAAYagAAAAEATzCv6XiaG7o4fn2RRlG9V84svdmRQWAcq9/h3s+D/fvh/00TeC2TSgE3xLWGlplw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Recipes_RecipeId",
                table: "Medias",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Recipes_RecipeId",
                table: "Medias");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9825bdbb-101d-49c0-82c8-6c4f54b93253",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8a5233bd-0340-457a-9b43-b804c4271e79", "AQAAAAIAAYagAAAAELz63JezRLBS1d9rw492BWlXjwpI6Cp7G1npWgP4nF7KKRJ5XJu8KNBeCOgxd1WMZw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Recipes_RecipeId",
                table: "Medias",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}
