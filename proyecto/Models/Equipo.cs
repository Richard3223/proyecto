using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.Models
{
    public class Equipo
    {
        public int Id { get; set; }

        [Column("NombreEquipo")]
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
    }
}
