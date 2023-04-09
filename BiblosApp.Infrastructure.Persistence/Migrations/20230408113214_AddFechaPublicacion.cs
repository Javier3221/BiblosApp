using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BiblosApp.Infrastructure.Persistence.Migrations
{
    public partial class AddFechaPublicacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Publicacion",
                table: "Libro",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha_Publicacion",
                table: "Libro");
        }
    }
}
