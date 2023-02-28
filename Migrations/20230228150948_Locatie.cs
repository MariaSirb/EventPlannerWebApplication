using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlannerWebApplication.Migrations
{
    public partial class Locatie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locatie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DenumireLocatie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacitateMaxima = table.Column<int>(type: "int", nullable: false),
                    PretLocatie = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locatie", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locatie");
        }
    }
}
