using Microsoft.EntityFrameworkCore.Migrations;

namespace MerchandiseManager.DAL.Migrations
{
    public partial class AddedBarcodesToDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarCode_Products_ProductId",
                table: "BarCode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarCode",
                table: "BarCode");

            migrationBuilder.RenameTable(
                name: "BarCode",
                newName: "Barcodes");

            migrationBuilder.RenameIndex(
                name: "IX_BarCode_ProductId",
                table: "Barcodes",
                newName: "IX_Barcodes_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Barcodes",
                table: "Barcodes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Barcodes_Products_ProductId",
                table: "Barcodes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barcodes_Products_ProductId",
                table: "Barcodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Barcodes",
                table: "Barcodes");

            migrationBuilder.RenameTable(
                name: "Barcodes",
                newName: "BarCode");

            migrationBuilder.RenameIndex(
                name: "IX_Barcodes_ProductId",
                table: "BarCode",
                newName: "IX_BarCode_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarCode",
                table: "BarCode",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BarCode_Products_ProductId",
                table: "BarCode",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
