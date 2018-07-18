using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Repository.Migrations
{
    public partial class MigrationA1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                "dbo");

            migrationBuilder.CreateTable(
                "custumer",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>("varchar(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<decimal>(nullable: false),
                    Email = table.Column<string>("varchar(30)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_custumer", x => x.id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "custumer",
                "dbo");
        }
    }
}