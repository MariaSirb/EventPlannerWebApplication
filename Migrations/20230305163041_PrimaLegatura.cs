using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlannerWebApplication.Migrations
{
    public partial class PrimaLegatura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyEvent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mentiune = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipEvenimentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyEvent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MyEvent_TipEveniment_TipEvenimentID",
                        column: x => x.TipEvenimentID,
                        principalTable: "TipEveniment",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyEvent_TipEvenimentID",
                table: "MyEvent",
                column: "TipEvenimentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyEvent");
        }
    }
}
