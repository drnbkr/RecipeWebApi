using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addmediatorecipenullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9825bdbb-101d-49c0-82c8-6c4f54b93253",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8a5233bd-0340-457a-9b43-b804c4271e79", "AQAAAAIAAYagAAAAELz63JezRLBS1d9rw492BWlXjwpI6Cp7G1npWgP4nF7KKRJ5XJu8KNBeCOgxd1WMZw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9825bdbb-101d-49c0-82c8-6c4f54b93253",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eae0e6ee-61a1-4b10-a377-080f5b506cd4", "AQAAAAIAAYagAAAAEKbYJMt/3mzc17me0Yo1of6YP1rXD3DkicUIj7O7y+i2D4ccM+9nmXblP+Pb2rFkHA==" });
        }
    }
}
