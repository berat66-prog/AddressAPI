using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressAPI.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Straat = table.Column<string>(type: "TEXT", nullable: false),
                    Huisnummer = table.Column<int>(type: "INTEGER", nullable: false),
                    Postcode = table.Column<string>(type: "TEXT", nullable: false),
                    Plaats = table.Column<string>(type: "TEXT", nullable: false),
                    Land = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
