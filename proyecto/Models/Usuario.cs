namespace proyecto.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }  // Clave primaria
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }  
        public string Email { get; set; }      
    }
}
