using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MerchandiseManager.DAL.Migrations
{
    public partial class ModifiedStorageRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Storages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Storages_UserId",
                table: "Storages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Storages_Users_UserId",
                table: "Storages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Storages_Users_UserId",
                table: "Storages");

            migrationBuilder.DropIndex(
                name: "IX_Storages_UserId",
                table: "Storages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Storages");
        }
    }
}
