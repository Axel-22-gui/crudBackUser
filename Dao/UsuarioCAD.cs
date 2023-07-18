using CRUDUser.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CRUDUser.Dao
{
    public class UsuarioCAD
    {
        private SqlConnection sqlConnection;
        private SqlCommand SqlCommand;
        private Conector conector;
        public UsuarioCAD(){
            conector = new Conector();
            sqlConnection = new SqlConnection(conector.ConectionString());
            SqlCommand = new SqlCommand();
        }


        public List<Usuario> listarUsuarios() {
            SqlDataReader rs;
            List<Usuario> usuarios = new List<Usuario>();
            Usuario Usuario;
            try
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand("Select * From usuarios.Usuario", sqlConnection);
                SqlCommand.CommandType = System.Data.CommandType.Text;
                rs = SqlCommand.ExecuteReader();
                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        Usuario = new Usuario();
                        Usuario.Id = Convert.ToInt64(Convert.ToString(rs["usu_id"]));
                        Usuario.nombre = Convert.ToString(rs["usu_nombre"]);
                        Usuario.apellido = Convert.ToString(rs["usu_apellido"]);
                        Usuario.correoElectronico = Convert.ToString(rs["usu_correo"]);
                        Usuario.edad= Convert.ToInt32(Convert.ToString(rs["usu_edad"]));
                        usuarios.Add(Usuario);
                    }
                }
                return usuarios;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public Usuario encontrarUsuario(Int64 id) {
            SqlDataReader rs;
            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario = new Usuario();
            try
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand("Select * From usuarios.usuario WHERE usu_id = " + id, sqlConnection);
                SqlCommand.CommandType = System.Data.CommandType.Text;
                rs = SqlCommand.ExecuteReader();
                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        usuario.Id = Convert.ToInt64(Convert.ToString(rs["usu_id"]));
                        usuario.nombre = Convert.ToString(rs["usu_nombre"]);
                        usuario.apellido = Convert.ToString(rs["usu_apellido"]);
                        usuario.correoElectronico = Convert.ToString(rs["usu_correo"]);
                        usuario.edad = Convert.ToInt32(Convert.ToString(rs["usu_edad"]));
                    }
                }
                else
                {
                    usuario.Id = 0;
                }
                return usuario;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public Int64 agregarUsuario(Usuario usuario) { return 0; }

        public Int64 editarUsuario(Int64 id, Usuario usuario) { return 0;  }

        public Boolean eliminarUsuario(Int64 id) { return true; }
    }
}
