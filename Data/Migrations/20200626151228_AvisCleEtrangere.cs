using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AvisCleEtrangere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Avis_FormationId",
                table: "Avis",
                column: "FormationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avis_Formations_FormationId",
                table: "Avis",
                column: "FormationId",
                principalTable: "Formations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avis_Formations_FormationId",
                table: "Avis");

            migrationBuilder.DropIndex(
                name: "IX_Avis_FormationId",
                table: "Avis");
        }
    }
}
