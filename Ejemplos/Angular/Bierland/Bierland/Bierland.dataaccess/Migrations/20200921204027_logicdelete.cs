using Microsoft.EntityFrameworkCore.Migrations;

namespace Bierland.dataaccess.Migrations
{
    public partial class logicdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Pubs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Beers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BeerFactorys",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Pubs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BeerFactorys");
        }
    }
}
