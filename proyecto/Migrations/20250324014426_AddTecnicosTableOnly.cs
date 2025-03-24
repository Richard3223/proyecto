using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    public partial class AddTecnicosTableOnly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Crear solo la tabla Tecnicos
            migrationBuilder.CreateTable(
                name: "Tecnicos",
                columns: table => new
                {
                    TecnicoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnicos", x => x.TecnicoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminar solo la tabla Tecnicos
            migrationBuilder.DropTable(name: "Tecnicos");
        }
    }
}
