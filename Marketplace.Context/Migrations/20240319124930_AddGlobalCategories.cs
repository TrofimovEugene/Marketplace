using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.Context.Migrations
{
    /// <inheritdoc />
    public partial class AddGlobalCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GlobalCategoryId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GlobalCategories",
                columns: table => new
                {
                    GlobalCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameGlobalCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalCategories", x => x.GlobalCategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_GlobalCategoryId",
                table: "Categories",
                column: "GlobalCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_GlobalCategories_GlobalCategoryId",
                table: "Categories",
                column: "GlobalCategoryId",
                principalTable: "GlobalCategories",
                principalColumn: "GlobalCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_GlobalCategories_GlobalCategoryId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "GlobalCategories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_GlobalCategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "GlobalCategoryId",
                table: "Categories");
        }
    }
}
