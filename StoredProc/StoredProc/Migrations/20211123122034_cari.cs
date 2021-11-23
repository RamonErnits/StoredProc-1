using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoredProc.Migrations
{
    public partial class cari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    carManufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    carModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    carModelYear = table.Column<int>(type: "int", nullable: false),
                    carColor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
