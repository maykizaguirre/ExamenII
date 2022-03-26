using ExamenIIParcial.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenIIParcial.Accesos
{
    public class UsuarioDA
    {
        readonly string cadena = "Server=localhost; Port=3306; Database=examen2parcial; Uid=root; Pwd=MaykJIM007!IAFB;";

        MySqlConnection conn;
        MySqlCommand cmd;

        public Usuario InicioSesion(string idUsuario, string clave)
        {
            Usuario usuario = null;

            try
            {
                string sql = "SELECT * FROM usuario WHERE IdUsuario = @IdUsuario AND Clave = @Clave;";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@Clave", clave);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    usuario = new Usuario();
                    usuario.IdUsuario = reader[0].ToString();
                    usuario.Nombre = reader[1].ToString();
                    usuario.Cargo = reader[2].ToString();
                    usuario.Estado = Convert.ToBoolean(reader[3]);
                    usuario.Clave = reader[4].ToString();
                    
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
            return usuario;
        }

        public DataTable ListarUsuarios()
        {
            DataTable listaUsuariosDT = new DataTable();

            try
            {
                string sql = "SELECT * FROM usuario;";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                listaUsuariosDT.Load(reader);
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return listaUsuariosDT;
        }

        public bool AgregarUsuario(Usuario usuario)
        {
            bool agrego = false;
            try
            {
                string sql = "INSERT INTO usuario VALUES (@IdUsuario, @Nombre, @Cargo, @Estado, @Clave);";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Cargo", usuario.Cargo);
                cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);

                cmd.ExecuteNonQuery();
                agrego = true;

                conn.Close();
            }
            catch (Exception)
            {
            }
            return agrego;
        }

    }
}
