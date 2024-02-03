using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class dodajDFTOpstinu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultnaOpstinaId",
                table: "KorisnickiNalog",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KorisnickiNalog_DefaultnaOpstinaId",
                table: "KorisnickiNalog",
                column: "DefaultnaOpstinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnickiNalog_Opstina_DefaultnaOpstinaId",
                table: "KorisnickiNalog",
                column: "DefaultnaOpstinaId",
                principalTable: "Opstina",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorisnickiNalog_Opstina_DefaultnaOpstinaId",
                table: "KorisnickiNalog");

            migrationBuilder.DropIndex(
                name: "IX_KorisnickiNalog_DefaultnaOpstinaId",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "DefaultnaOpstinaId",
                table: "KorisnickiNalog");
        }
    }
}
