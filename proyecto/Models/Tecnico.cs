namespace proyecto.Models
{
    public class Tecnico
    {
        public int TecnicoID { get; set; }  // Esta es la clave primaria de la tabla

        public string Nombre { get; set; }  // El nombre del técnico

        public string Especialidad { get; set; }  // Especialidad del técnico

        public string Telefono { get; set; }  // Teléfono de contacto del técnico
    }
}
