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
    public class PedidoDA
    {
        readonly string cadena = "Server=localhost; Port=3306; Database=examen2parcial; Uid=root; Pwd=MaykJIM007!IAFB;";

        MySqlConnection conn;
        MySqlCommand cmd;

        public DataTable ListaPedidos()
        {
            DataTable listaPedidos = new DataTable();

            try
            {
                string sql = "SELECT * FROM pedido;";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                listaPedidos.Load(reader);
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return listaPedidos;
        }

        public int RegistroPedido(Pedido pedido)
        {
            int idPedido = 0;
            try
            {
                string sql = "INSERT INTO pedido (Id, NombreCliente, CodigoProducto, Cantidad, Precio, Total, Descripcion, Fecha) VALUES (@Id, @NombreCliente, @CodigoProducto, @Cantidad, @Precio, @Total, @Descripcion, @Fecha); select last_insert_id();";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Id", pedido.Id);
                cmd.Parameters.AddWithValue("@NombreCliente", pedido.NombreCliente);
                cmd.Parameters.AddWithValue("@CodigoProducto", pedido.CodigoProducto);
                cmd.Parameters.AddWithValue("@Cantidad", pedido.Cantidad);
                cmd.Parameters.AddWithValue("@Precio", pedido.Precio);
                cmd.Parameters.AddWithValue("@Total", pedido.Total);
                cmd.Parameters.AddWithValue("@Descripcion", pedido.Descripcion);
                cmd.Parameters.AddWithValue("@Fecha", pedido.Fecha);
                idPedido =  Convert.ToInt32(cmd.ExecuteScalar());


                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return idPedido;
        }

        public bool InsertarPedido(Pedido pedido)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO pedido (Id, NombreCliente, CodigoProducto, Cantidad, Precio, Total, Descripcion, Fecha) VALUES (@Id, @NombreCliente, @CodigoProducto, @Cantidad, @Precio, @Total, @Descripcion, @Fecha);";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Id", pedido.Id);
                cmd.Parameters.AddWithValue("@NombreCliente", pedido.NombreCliente);
                cmd.Parameters.AddWithValue("@CodigoProducto", pedido.CodigoProducto);
                cmd.Parameters.AddWithValue("@Cantidad", pedido.Cantidad);
                cmd.Parameters.AddWithValue("@Precio", pedido.Precio);
                cmd.Parameters.AddWithValue("@Total", pedido.Total);
                cmd.Parameters.AddWithValue("@Descripcion", pedido.Descripcion);
                cmd.Parameters.AddWithValue("@Fecha", pedido.Fecha);
                cmd.ExecuteNonQuery();

                inserto = true;
                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return inserto;
        }
    }
}
