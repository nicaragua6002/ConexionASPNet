using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConexionASPNet
{
    public class Global
    {
        //Instanciamiento a la clase ConexionDB
        public static ConexionDB db = new ConexionDB();

        //Listar a todos los usuarios contenidos en la tabla Usuarios de la BD
        public static List<Usuario> ListarUsuarios() {
            
            return db.Usuarios.ToList();
        } 

        public static Boolean RegistrarUsuario(string nombre, string email, string pass)
        {
            db.Usuarios.Add(new Usuario(nombre, email, pass));
            Boolean Result = true;
            if(!(db.SaveChanges() > 0)){
                Result = false;
            }
            return Result;
        }

        public static Boolean Login(string email, string pass)
        {
            if(db.Usuarios.Where(x=>x.Email==email && x.Password == pass).FirstOrDefault() !=null)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}