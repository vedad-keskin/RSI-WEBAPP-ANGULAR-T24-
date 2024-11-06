using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class dftopstina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultOpstinaId",
                table: "KorisnickiNalog",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KorisnickiNalog_DefaultOpstinaId",
                table: "KorisnickiNalog",
                column: "DefaultOpstinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnickiNalog_Opstina_DefaultOpstinaId",
                table: "KorisnickiNalog",
                column: "DefaultOpstinaId",
                principalTable: "Opstina",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorisnickiNalog_Opstina_DefaultOpstinaId",
                table: "KorisnickiNalog");

            migrationBuilder.DropIndex(
                name: "IX_KorisnickiNalog_DefaultOpstinaId",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "DefaultOpstinaId",
                table: "KorisnickiNalog");
        }
    }
}
