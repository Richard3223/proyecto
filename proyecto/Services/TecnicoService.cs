using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using proyecto.Models;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto.Services
{
    public class TecnicoService
    {
        private readonly ApplicationDbContext _context;

        public TecnicoService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todos los técnicos
        public List<Tecnico> ObtenerTecnicos()
        {
            var parametros = new List<SqlParameter>();
            var query = "EXEC ObtenerTecnicos";

            return _context.Tecnicos.FromSqlRaw(query, parametros.ToArray()).ToList();
        }

        // Obtener técnico por ID
        public Tecnico ObtenerTecnicoPorId(int id)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", id)
            };

            var query = "EXEC ObtenerTecnicoPorId @Id";

            return _context.Tecnicos.FromSqlRaw(query, parametros.ToArray()).FirstOrDefault();
        }

        // Crear un nuevo técnico
        public void CrearTecnico(Tecnico tecnico)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Nombre", tecnico.Nombre),
                new SqlParameter("@Especialidad", tecnico.Especialidad)
            };

            var query = "EXEC CrearTecnico @Nombre, @Especialidad";

            _context.Database.ExecuteSqlRaw(query, parametros.ToArray());
        }

        // Actualizar un técnico
        public void ActualizarTecnico(Tecnico tecnico)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", tecnico.TecnicoID),
                new SqlParameter("@Nombre", tecnico.Nombre),
                new SqlParameter("@Especialidad", tecnico.Especialidad),
                new SqlParameter("@Telefono", tecnico.Telefono)

            };

            var query = "EXEC ActualizarTecnico @Id, @Nombre, @Especialidad, @Telefono";

            _context.Database.ExecuteSqlRaw(query, parametros.ToArray());
        }

        // Eliminar un técnico
        public void EliminarTecnico(int id)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", id)
            };

            var query = "EXEC EliminarTecnico @Id";

            _context.Database.ExecuteSqlRaw(query, parametros.ToArray());
        }
    }
}
