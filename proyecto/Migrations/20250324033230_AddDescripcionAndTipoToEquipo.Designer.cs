using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    public partial class AddDescripcionAndTipoToEquipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Agregar la columna 'Descripcion'
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Equipos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            // Agregar la columna 'Tipo'
            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Equipos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminar la columna 'Descripcion'
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Equipos");

            // Eliminar la columna 'Tipo'
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Equipos");
        }
    }
}
