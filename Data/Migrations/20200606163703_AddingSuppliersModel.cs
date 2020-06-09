using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalal.Data.Migrations
{
    public partial class AddingSuppliersModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "supplyerId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(nullable: true),
                    SupplierEmail = table.Column<string>(nullable: true),
                    SupplierPhoneNumber = table.Column<string>(nullable: true),
                    SupplierLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_supplyerId",
                table: "Products",
                column: "supplyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_supplyerId",
                table: "Products",
                column: "supplyerId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_supplyerId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Products_supplyerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "supplyerId",
                table: "Products");
        }
    }
}
