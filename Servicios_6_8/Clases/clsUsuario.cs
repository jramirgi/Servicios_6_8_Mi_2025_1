using Servicios_6_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_6_8.Clases
{
    public class clsUsuario
    {
        private DBSuperEntities DBSuper = new DBSuperEntities();
        public Usuario usuario { get; set; }
        public string CrearUsuario(int idPerfil)
        {
            //Se van a crear el usuario y el usuario perfil
            clsCypher cypher = new clsCypher();
            string ClaveCifrada;
            cypher.Password = usuario.Clave;
            if (cypher.CifrarClave())
            {
                ClaveCifrada = cypher.PasswordCifrado;
            }
            else
            {
                return "Error al cifrar la clave";
            }
            //Graba el usuario
            usuario.Clave = ClaveCifrada;
            usuario.Salt = cypher.Salt;
            DBSuper.Usuarios.Add(usuario);
            DBSuper.SaveChanges();
            //Graba el usuario perfil
            Usuario_Perfil usuarioPerfil = new Usuario_Perfil();
            usuarioPerfil.idUsuario = usuario.id;
            usuarioPerfil.idPerfil = idPerfil;
            usuarioPerfil.Activo = true; //Cuando se crea normalmente, debe ser activo
            DBSuper.Usuario_Perfil.Add(usuarioPerfil);
            DBSuper.SaveChanges();
            return "Se creó el usuario exitosamente";
        }
    }
}