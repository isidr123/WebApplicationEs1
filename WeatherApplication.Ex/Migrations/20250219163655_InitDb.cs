using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApplication.Ex.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecasts");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCities_CityId",
                table: "FavoriteCities",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCities_Cities_CityId",
                table: "FavoriteCities",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCities_Users_UserId",
                table: "FavoriteCities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCities_Cities_CityId",
                table: "FavoriteCities");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCities_Users_UserId",
                table: "FavoriteCities");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteCities_CityId",
                table: "FavoriteCities");

            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Humidity = table.Column<double>(type: "float", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                });
        }
    }
}
