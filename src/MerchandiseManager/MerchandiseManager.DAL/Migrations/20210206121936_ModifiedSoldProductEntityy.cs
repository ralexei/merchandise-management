using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MerchandiseManager.DAL.Migrations
{
    public partial class ModifiedSoldProductEntityy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoldProducts_Storages_StoreId",
                table: "SoldProducts");

            migrationBuilder.DropIndex(
                name: "IX_SoldProducts_StoreId",
                table: "SoldProducts");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "SoldProducts");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "SalesReports",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SalesReports_StoreId",
                table: "SalesReports",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReports_Storages_StoreId",
                table: "SalesReports",
                column: "StoreId",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesReports_Storages_StoreId",
                table: "SalesReports");

            migrationBuilder.DropIndex(
                name: "IX_SalesReports_StoreId",
                table: "SalesReports");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "SalesReports");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "SoldProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SoldProducts_StoreId",
                table: "SoldProducts",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoldProducts_Storages_StoreId",
                table: "SoldProducts",
                column: "StoreId",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
