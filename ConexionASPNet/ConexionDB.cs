using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ConexionASPNet
{
   
    public class ConexionDB : DbContext
    {
        public ConexionDB() : base("name=MiConexionDB") // El nombre coincide con la cadena de conexión definida en Web.config
        {
        }

        // Define las entidades (tablas) de tu base de datos como propiedades DbSet.
        public DbSet<Usuario> Usuarios { get; set; }
        // Añade otras DbSet para las otras tablas de tu base de datos.

        // Método para realizar consultas personalizadas si es necesario.
        public List<Usuario> ObtenerUsuariosActivos()
        {
            return Usuarios.Where(u => u.Activo).ToList();
        }
    }

    public class Usuario
    {
        int id;
        string nombre;
        string email;
        string password;
        Boolean activo;
        public Usuario() { }
        public Usuario(string nombre, string email, string password)
        {

            this.Nombre = nombre;
            this.Email = email;
            this.Password = password;
            this.Activo = true;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public bool Activo { get => activo; set => activo = value; }
    }
}