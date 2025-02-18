using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommorce.API.Migrations
{
    /// <inheritdoc />
    public partial class producvartions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductVariations_VariationsId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_VariationsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VariationsId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductVariationVariationId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductVariationVariationId",
                table: "Products",
                column: "ProductVariationVariationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductVariations_ProductVariationVariationId",
                table: "Products",
                column: "ProductVariationVariationId",
                principalTable: "ProductVariations",
                principalColumn: "VariationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductVariations_ProductVariationVariationId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductVariationVariationId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductVariationVariationId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "VariationsId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_VariationsId",
                table: "Products",
                column: "VariationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductVariations_VariationsId",
                table: "Products",
                column: "VariationsId",
                principalTable: "ProductVariations",
                principalColumn: "VariationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
