using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MerchandiseManager.DAL.Migrations
{
    public partial class AddedWarehouseConcept : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserStorages");

            migrationBuilder.CreateTable(
                name: "UserWarehouses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    UpdatedAt = table.Column<long>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    WarehouseId = table.Column<Guid>(nullable: false),
                    StorageId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWarehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWarehouses_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserWarehouses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWarehouses_Storages_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserWarehouses_StorageId",
                table: "UserWarehouses",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWarehouses_UserId",
                table: "UserWarehouses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWarehouses_WarehouseId",
                table: "UserWarehouses",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserWarehouses");

            migrationBuilder.CreateTable(
                name: "UserStorages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<long>(type: "bigint", nullable: false),
                    StorageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStorages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserStorages_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStorages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserStorages_StorageId",
                table: "UserStorages",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStorages_UserId",
                table: "UserStorages",
                column: "UserId");
        }
    }
}
