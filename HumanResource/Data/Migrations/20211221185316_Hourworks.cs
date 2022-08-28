using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanResource.Data.Migrations
{
    public partial class Hourworks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HourWorks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeSSN = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Extra = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourWorks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HourWorks");
        }
    }
}
