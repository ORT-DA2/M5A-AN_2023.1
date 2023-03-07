using Microsoft.EntityFrameworkCore.Migrations;

namespace Bierland.dataaccess.Migrations
{
    public partial class agregaFactory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BeerFactoryId",
                table: "Beers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BeerFactoryId",
                table: "Beers",
                column: "BeerFactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_BeerFactorys_BeerFactoryId",
                table: "Beers",
                column: "BeerFactoryId",
                principalTable: "BeerFactorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_BeerFactorys_BeerFactoryId",
                table: "Beers");

            migrationBuilder.DropIndex(
                name: "IX_Beers_BeerFactoryId",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "BeerFactoryId",
                table: "Beers");
        }
    }
}
