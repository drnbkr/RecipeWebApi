using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebApi.Migrations
{
    /// <inheritdoc />
    public partial class FixMediaRelationshipss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9825bdbb-101d-49c0-82c8-6c4f54b93253",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1af99313-2169-4f0d-98a2-994466477a70", "AQAAAAIAAYagAAAAEBBbUqF1VhRQPe4op7kZup923uBwuRYIUJzoN/mCshovq0AySvcX/7kn/6TIVCQgvg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9825bdbb-101d-49c0-82c8-6c4f54b93253",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "166cd379-ea10-4b17-8d0c-bfdae2b967c5", "AQAAAAIAAYagAAAAEATzCv6XiaG7o4fn2RRlG9V84svdmRQWAcq9/h3s+D/fvh/00TeC2TSgE3xLWGlplw==" });
        }
    }
}
