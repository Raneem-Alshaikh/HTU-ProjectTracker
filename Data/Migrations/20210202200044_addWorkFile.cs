using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Data.Migrations
{
    public partial class addWorkFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "CvFile",
                table: "Works",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Works",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "Works",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CvFile",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "Works");
        }
    }
}
