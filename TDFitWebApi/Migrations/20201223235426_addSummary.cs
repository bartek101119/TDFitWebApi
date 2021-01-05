using Microsoft.EntityFrameworkCore.Migrations;

namespace TDFitWebApi.Migrations
{
    public partial class addSummary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Summaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<double>(nullable: false),
                    CarbohydrateKeep = table.Column<double>(nullable: false),
                    ProteinKeep = table.Column<double>(nullable: false),
                    FatKeep = table.Column<double>(nullable: false),
                    CarbohydrateLose = table.Column<double>(nullable: false),
                    ProteinLose = table.Column<double>(nullable: false),
                    FatLose = table.Column<double>(nullable: false),
                    CarbohydrateGain = table.Column<double>(nullable: false),
                    ProteinGain = table.Column<double>(nullable: false),
                    FatGain = table.Column<double>(nullable: false),
                    KcalKeep = table.Column<double>(nullable: false),
                    KcalLose = table.Column<double>(nullable: false),
                    KcalGain = table.Column<double>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summaries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Summaries");
        }
    }
}
