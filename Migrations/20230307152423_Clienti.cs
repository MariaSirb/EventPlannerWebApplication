using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlannerWebApplication.Migrations
{
    public partial class Clienti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "MyEvent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CreatingEvent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    MyEventID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatingEvent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CreatingEvent_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CreatingEvent_MyEvent_MyEventID",
                        column: x => x.MyEventID,
                        principalTable: "MyEvent",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyEvent_ClientID",
                table: "MyEvent",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_CreatingEvent_ClientID",
                table: "CreatingEvent",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_CreatingEvent_MyEventID",
                table: "CreatingEvent",
                column: "MyEventID");

            migrationBuilder.AddForeignKey(
                name: "FK_MyEvent_Client_ClientID",
                table: "MyEvent",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyEvent_Client_ClientID",
                table: "MyEvent");

            migrationBuilder.DropTable(
                name: "CreatingEvent");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_MyEvent_ClientID",
                table: "MyEvent");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "MyEvent");
        }
    }
}
