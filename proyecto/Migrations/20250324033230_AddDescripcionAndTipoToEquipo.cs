using Microsoft.EntityFrameworkCore.Migrations;

public partial class AddDescripcionAndTipoToEquipo : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "Descripcion",
            table: "Equipos",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "Tipo",
            table: "Equipos",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Descripcion",
            table: "Equipos");

        migrationBuilder.DropColumn(
            name: "Tipo",
            table: "Equipos");
    }
}
