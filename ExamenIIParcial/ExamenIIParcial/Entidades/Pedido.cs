using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenIIParcial.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public Pedido()
        {
        }

        public Pedido(int id, string nombreCliente, string codigoProducto, int cantidad, decimal precio, decimal total, string descripcion, DateTime fecha)
        {
            Id=id;
            NombreCliente=nombreCliente;
            CodigoProducto=codigoProducto;
            Cantidad=cantidad;
            Precio=precio;
            Total=total;
            Descripcion=descripcion;
            Fecha=fecha;
        }
    }
}
