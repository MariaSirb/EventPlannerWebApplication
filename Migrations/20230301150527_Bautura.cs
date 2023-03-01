using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlannerWebApplication.Migrations
{
    public partial class Bautura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drink",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireBautura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PretBautura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BauturaImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drink", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drink");
        }
    }
}
