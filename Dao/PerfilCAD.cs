using CRUDUser.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CRUDUser.Dao
{
    public class PerfilCAD
    {
        private SqlConnection sqlConnection;
        private SqlCommand SqlCommand;
        private Conector conector;
        public PerfilCAD() {
            conector = new Conector();
            sqlConnection = new SqlConnection(conector.ConectionString());
            SqlCommand = new SqlCommand();
        }

        public List<Perfil> listarPerfil() {
            SqlDataReader rs;
            List<Perfil> perfils = new List<Perfil>();
            Perfil perfil;
            try
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand("Select * From usuarios.perfil", sqlConnection);
                SqlCommand.CommandType = System.Data.CommandType.Text;
                rs = SqlCommand.ExecuteReader();
                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        perfil = new Perfil();
                        perfil.Id = Convert.ToInt32(Convert.ToString(rs["perf_id"]));
                        perfil.nombre = Convert.ToString(rs["perf_nombre"]);
                        perfil.estado = Convert.ToInt32(Convert.ToString(rs["perf_estado"]));
                        perfils.Add(perfil);
                    }
                }
                return perfils;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public Perfil encontrarPerfil(Int32 perfilId) {
            SqlDataReader rs;
            List<Perfil> perfils = new List<Perfil>();
            Perfil perfil = new Perfil();
            try
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand("Select * From usuarios.perfil WHERE perf_id = "+perfilId, sqlConnection);
                SqlCommand.CommandType = System.Data.CommandType.Text;
                rs = SqlCommand.ExecuteReader();
                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        perfil.Id = Convert.ToInt32(Convert.ToString(rs["perf_id"]));
                        perfil.nombre = Convert.ToString(rs["perf_nombre"]);
                        perfil.estado = Convert.ToInt32(Convert.ToString(rs["perf_estado"]));
                    }
                }
                else
                {
                    perfil.Id = 0;
                }
                return perfil;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public Int32 agregarPerfil(Perfil perfil) {
            SqlDataReader rs;
            Int32 response = 0;
            try
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand("usuarios.sp_agregarPerfil", sqlConnection);
                SqlCommand.Parameters.AddWithValue("@perfil",perfil.nombre);
                SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                rs = SqlCommand.ExecuteReader();
                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        response = Convert.ToInt32(Convert.ToString(rs["perf_id"]));
                    }
                }
                return response;
            }
            finally
            {
                sqlConnection.Close();
            }

            }
        public Int32 editarPerfil(Int32 perfilId,Perfil perfil) {
            return 0;
        }
        public Boolean eliminarPerfil(Int32 perfilId) {

            return true;

        }
    }
}
