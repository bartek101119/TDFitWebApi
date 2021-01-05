using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TDFitWebApi.Migrations
{
    public partial class dodanie_tabeli_keepdiets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeepDiets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    TimeOfEat = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Kcal = table.Column<double>(nullable: false),
                    Protein = table.Column<double>(nullable: false),
                    Carbohydrate = table.Column<double>(nullable: false),
                    Fat = table.Column<double>(nullable: false),
                    MacroSum = table.Column<double>(nullable: false),
                    KcalSum = table.Column<double>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeepDiets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeepDiets");
        }
    }
}
