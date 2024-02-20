using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _20240216imageUrlpremiumratingaddedrelatedtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Models",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Premium",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Brands",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Premium",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Brands");
        }
    }
}
