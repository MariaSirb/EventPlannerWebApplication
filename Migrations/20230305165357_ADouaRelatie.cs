using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlannerWebApplication.Migrations
{
    public partial class ADouaRelatie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocatieID",
                table: "MyEvent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MyEvent_LocatieID",
                table: "MyEvent",
                column: "LocatieID");

            migrationBuilder.AddForeignKey(
                name: "FK_MyEvent_Locatie_LocatieID",
                table: "MyEvent",
                column: "LocatieID",
                principalTable: "Locatie",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyEvent_Locatie_LocatieID",
                table: "MyEvent");

            migrationBuilder.DropIndex(
                name: "IX_MyEvent_LocatieID",
                table: "MyEvent");

            migrationBuilder.DropColumn(
                name: "LocatieID",
                table: "MyEvent");
        }
    }
}
