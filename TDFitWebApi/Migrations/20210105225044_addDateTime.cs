using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TDFitWebApi.Migrations
{
    public partial class addDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DateDMYs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateDMYs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DietPlan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeOfEat = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Kcal = table.Column<double>(nullable: false),
                    Protein = table.Column<double>(nullable: false),
                    Carbohydrate = table.Column<double>(nullable: false),
                    Fat = table.Column<double>(nullable: false),
                    MacroSum = table.Column<double>(nullable: false),
                    KcalSum = table.Column<double>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    DateDMYId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DietPlan_DateDMYs_DateDMYId",
                        column: x => x.DateDMYId,
                        principalTable: "DateDMYs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietPlan_DateDMYId",
                table: "DietPlan",
                column: "DateDMYId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DietPlan");

            migrationBuilder.DropTable(
                name: "DateDMYs");
        }
    }
}
