using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Data.Migrations
{
    public partial class editFileColName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CvFile",
                table: "Works");

            migrationBuilder.AddColumn<byte[]>(
                name: "workFile",
                table: "Works",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "workFile",
                table: "Works");

            migrationBuilder.AddColumn<byte[]>(
                name: "CvFile",
                table: "Works",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
