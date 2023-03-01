using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlannerWebApplication.Migrations
{
    public partial class Photograph : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photograph",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumirePhotograph = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PretPhotograph = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhotographImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photograph", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photograph");
        }
    }
}
