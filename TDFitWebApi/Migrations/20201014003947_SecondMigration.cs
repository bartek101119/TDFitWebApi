using Microsoft.EntityFrameworkCore.Migrations;

namespace TDFitWebApi.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Calories_DietId",
                table: "Calories");

            migrationBuilder.CreateIndex(
                name: "IX_Calories_DietId",
                table: "Calories",
                column: "DietId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Calories_DietId",
                table: "Calories");

            migrationBuilder.CreateIndex(
                name: "IX_Calories_DietId",
                table: "Calories",
                column: "DietId",
                unique: true);
        }
    }
}
