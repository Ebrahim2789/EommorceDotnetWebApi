using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommorce.API.Migrations
{
    /// <inheritdoc />
    public partial class config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Makes_MakeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryToDrivers_Cars_InventoryId",
                schema: "dbo",
                table: "InventoryToDrivers");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryToDrivers_Drivers_DriverId",
                schema: "dbo",
                table: "InventoryToDrivers");

            migrationBuilder.DropTable(
                name: "CarDriver");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryToDrivers",
                schema: "dbo",
                table: "InventoryToDrivers");

            migrationBuilder.DropIndex(
                name: "IX_InventoryToDrivers_InventoryId",
                schema: "dbo",
                table: "InventoryToDrivers");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDrivable",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Display",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                computedColumnSql: "[PetName] + ' (' + [Color] + ')'",
                stored: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryToDrivers",
                schema: "dbo",
                table: "InventoryToDrivers",
                columns: new[] { "InventoryId", "DriverId" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" },
                    { 3, "Customer" },
                    { 4, "Marchent" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Makes_MakeId",
                table: "Cars",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDriver_Drivers_DriverId",
                schema: "dbo",
                table: "InventoryToDrivers",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDriver_Inventory_InventoryId",
                schema: "dbo",
                table: "InventoryToDrivers",
                column: "InventoryId",
                principalTable: "Cars",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Makes_MakeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDriver_Drivers_DriverId",
                schema: "dbo",
                table: "InventoryToDrivers");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDriver_Inventory_InventoryId",
                schema: "dbo",
                table: "InventoryToDrivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryToDrivers",
                schema: "dbo",
                table: "InventoryToDrivers");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDrivable",
                table: "Cars",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Display",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComputedColumnSql: "[PetName] + ' (' + [Color] + ')'");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryToDrivers",
                schema: "dbo",
                table: "InventoryToDrivers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CarDriver",
                columns: table => new
                {
                    CarsId = table.Column<int>(type: "int", nullable: false),
                    DriversId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDriver", x => new { x.CarsId, x.DriversId });
                    table.ForeignKey(
                        name: "FK_CarDriver_Cars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarDriver_Drivers_DriversId",
                        column: x => x.DriversId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryToDrivers_InventoryId",
                schema: "dbo",
                table: "InventoryToDrivers",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CarDriver_DriversId",
                table: "CarDriver",
                column: "DriversId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Makes_MakeId",
                table: "Cars",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryToDrivers_Cars_InventoryId",
                schema: "dbo",
                table: "InventoryToDrivers",
                column: "InventoryId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryToDrivers_Drivers_DriverId",
                schema: "dbo",
                table: "InventoryToDrivers",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
