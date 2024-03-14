using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.Context.Migrations
{
    /// <inheritdoc />
    public partial class Add_Specifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdultOnly",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "Count",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    SpecificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecificationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecificationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.SpecificationId);
                    table.ForeignKey(
                        name: "FK_Specifications_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_ProductId",
                table: "Specifications",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropColumn(
                name: "AdultOnly",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Products");
        }
    }
}
