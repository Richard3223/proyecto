using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using proyecto.Models;
using Proyecto.Data;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto.Services
{
    public class UsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todos los usuarios
        public List<Usuario> ObtenerUsuarios()
        {
            var parametros = new List<SqlParameter>();
            var query = "EXEC ObtenerUsuarios";

            return _context.Usuarios.FromSqlRaw(query, parametros.ToArray()).ToList();
        }

        // Obtener usuario por ID
        public Usuario ObtenerUsuarioPorId(int id)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", id)
            };

            var query = "EXEC ObtenerUsuarioPorId @Id";

            return _context.Usuarios.FromSqlRaw(query, parametros.ToArray()).FirstOrDefault();
        }

        // Crear un nuevo usuario
        public void CrearUsuario(Usuario usuario)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Nombre", usuario.Nombre),
                new SqlParameter("@Email", usuario.Email),
                new SqlParameter("@Contraseña", usuario.Contraseña)
            };

            var query = "EXEC CrearUsuario @Nombre, @Email, @Contraseña";

            _context.Database.ExecuteSqlRaw(query, parametros.ToArray());
        }

        // Actualizar un usuario
        public void ActualizarUsuario(Usuario usuario)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", usuario.UsuarioID),
                new SqlParameter("@Nombre", usuario.Nombre),
                new SqlParameter("@Email", usuario.Email),
                new SqlParameter("@Contraseña", usuario.Contraseña)
            };

            var query = "EXEC ActualizarUsuario @Id, @Nombre, @Email, @Contraseña";

            _context.Database.ExecuteSqlRaw(query, parametros.ToArray());
        }

        // Eliminar un usuario
        public void EliminarUsuario(int id)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", id)
            };

            var query = "EXEC EliminarUsuario @Id";

            _context.Database.ExecuteSqlRaw(query, parametros.ToArray());
        }
    }
}
