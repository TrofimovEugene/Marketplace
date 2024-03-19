using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.Context.Migrations
{
    /// <inheritdoc />
    public partial class AddAltNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AltName",
                table: "Subcategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AltName",
                table: "GlobalCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AltName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltName",
                table: "Subcategories");

            migrationBuilder.DropColumn(
                name: "AltName",
                table: "GlobalCategories");

            migrationBuilder.DropColumn(
                name: "AltName",
                table: "Categories");
        }
    }
}
