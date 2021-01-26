using Microsoft.EntityFrameworkCore.Migrations;

namespace MerchandiseManager.DAL.Migrations
{
    public partial class ModifiedDiscriminatorForStorages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Storages");

            migrationBuilder.AddColumn<string>(
                name: "StorageType",
                table: "Storages",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StorageType",
                table: "Storages");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Storages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
