using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommorce.API.Migrations
{
    /// <inheritdoc />
    public partial class producvartion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductVariations",
                newName: "VariationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VariationId",
                table: "ProductVariations",
                newName: "Id");
        }
    }
}
