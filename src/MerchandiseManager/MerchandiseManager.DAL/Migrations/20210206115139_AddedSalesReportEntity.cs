using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MerchandiseManager.DAL.Migrations
{
    public partial class AddedSalesReportEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SalesReportId",
                table: "SoldProducts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "SoldProducts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "SalesReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    UpdatedAt = table.Column<long>(nullable: true),
                    Day = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReports", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoldProducts_SalesReportId",
                table: "SoldProducts",
                column: "SalesReportId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldProducts_StoreId",
                table: "SoldProducts",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoldProducts_SalesReports_SalesReportId",
                table: "SoldProducts",
                column: "SalesReportId",
                principalTable: "SalesReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoldProducts_Storages_StoreId",
                table: "SoldProducts",
                column: "StoreId",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoldProducts_SalesReports_SalesReportId",
                table: "SoldProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SoldProducts_Storages_StoreId",
                table: "SoldProducts");

            migrationBuilder.DropTable(
                name: "SalesReports");

            migrationBuilder.DropIndex(
                name: "IX_SoldProducts_SalesReportId",
                table: "SoldProducts");

            migrationBuilder.DropIndex(
                name: "IX_SoldProducts_StoreId",
                table: "SoldProducts");

            migrationBuilder.DropColumn(
                name: "SalesReportId",
                table: "SoldProducts");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "SoldProducts");
        }
    }
}
