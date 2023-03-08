using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlannerWebApplication.Migrations
{
    public partial class List : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyEventID",
                table: "Food",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyEventID",
                table: "Drink",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Food_MyEventID",
                table: "Food",
                column: "MyEventID");

            migrationBuilder.CreateIndex(
                name: "IX_Drink_MyEventID",
                table: "Drink",
                column: "MyEventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_MyEvent_MyEventID",
                table: "Drink",
                column: "MyEventID",
                principalTable: "MyEvent",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_MyEvent_MyEventID",
                table: "Food",
                column: "MyEventID",
                principalTable: "MyEvent",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_MyEvent_MyEventID",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_MyEvent_MyEventID",
                table: "Food");

            migrationBuilder.DropIndex(
                name: "IX_Food_MyEventID",
                table: "Food");

            migrationBuilder.DropIndex(
                name: "IX_Drink_MyEventID",
                table: "Drink");

            migrationBuilder.DropColumn(
                name: "MyEventID",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "MyEventID",
                table: "Drink");
        }
    }
}
