using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using proyecto.Models;
using Proyecto.Data;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto.Services
{
    public class EquipoService
    {
        private readonly ApplicationDbContext _context;

        public EquipoService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todos los equipos
        public List<Equipo> ObtenerEquipos()
        {
            var parametros = new List<SqlParameter>();
            var query = "EXEC ObtenerEquipos";

            return _context.Equipos.FromSqlRaw(query, parametros.ToArray()).ToList();
        }

        // Obtener equipo por ID
        public Equipo ObtenerEquipoPorId(int id)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", id)
            };

            var query = "EXEC ObtenerEquipoPorId @Id";

            return _context.Equipos.FromSqlRaw(query, parametros.ToArray()).FirstOrDefault();
        }

        // Crear un nuevo equipo
        public void CrearEquipo(Equipo equipo)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Nombre", equipo.Nombre),
                new SqlParameter("@Descripcion", equipo.Descripcion),
                new SqlParameter("@Tipo", equipo.Tipo)
            };

            var query = "EXEC CrearEquipo @Nombre, @Descripcion, @Tipo";

            _context.Database.ExecuteSqlRaw(query, parametros.ToArray());
        }

        // Actualizar un equipo
        public void ActualizarEquipo(Equipo equipo)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", equipo.Id),
                new SqlParameter("@Nombre", equipo.Nombre),
                new SqlParameter("@Descripcion", equipo.Descripcion),
                new SqlParameter("@Tipo", equipo.Tipo)
            };

            var query = "EXEC ActualizarEquipo @Id, @Nombre, @Descripcion, @Tipo";

            _context.Database.ExecuteSqlRaw(query, parametros.ToArray());
        }

        // Eliminar un equipo
        public void EliminarEquipo(int id)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", id)
            };

            var query = "EXEC EliminarEquipo @Id";

            _context.Database.ExecuteSqlRaw(query, parametros.ToArray());
        }
    }
}
