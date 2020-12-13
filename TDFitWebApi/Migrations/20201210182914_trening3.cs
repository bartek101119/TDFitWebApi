using Microsoft.EntityFrameworkCore.Migrations;

namespace TDFitWebApi.Migrations
{
    public partial class trening3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Users_UserId",
                table: "Trainings");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Trainings",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Trainings",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Users_UserId",
                table: "Trainings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Users_UserId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Trainings");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Trainings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Users_UserId",
                table: "Trainings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
