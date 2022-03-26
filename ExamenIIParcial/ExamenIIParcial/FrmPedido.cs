using ExamenIIParcial.Accesos;
using ExamenIIParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExamenIIParcial
{
    public partial class FrmPedido : Form
    {
        public FrmPedido()
        {
            InitializeComponent();
        }

        ProductoDA productoDA = new ProductoDA();
        Pedido pedido = new Pedido();
        Producto producto;
        PedidoDA pedidoDA = new PedidoDA();

        List<Pedido> pedidosLista = new List<Pedido>();


        private void ListarPedidos()
        {
            PedidosDataGridView.DataSource = pedidoDA.ListaPedidos();
        }

        decimal total = decimal.Zero;

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            PedidosDataGridView.DataSource = pedidosLista;
            
        }

        private void CodigoProductoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                producto = new Producto();
                producto = productoDA.GetProductoPorCodigo(CodigoProductoTextBox.Text);
                DescripcionTextBox.Text = producto.Descripcion;
                PrecioTextBox.Text = producto.Precio.ToString();
                CantidadTextBox.Focus();
            }
            else
            {
                producto = null;
                DescripcionTextBox.Clear();
                PrecioTextBox.Clear();
                CantidadTextBox.Clear();
            }
        }

        private void CantidadTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(CantidadTextBox.Text))
            {
                Pedido detallePedido = new Pedido();
                detallePedido.Id = Convert.ToInt32(IdTextBox.Text);
                detallePedido.NombreCliente = NombreTextBox.Text; 
                detallePedido.CodigoProducto = producto.Codigo;
                detallePedido.Descripcion = producto.Descripcion;
                detallePedido.Cantidad = Convert.ToInt32(CantidadTextBox.Text);
                detallePedido.Precio = producto.Precio;
                detallePedido.Total = producto.Precio * Convert.ToInt32(CantidadTextBox.Text);

                //pendiente de revisar
                total = detallePedido.Precio * detallePedido.Cantidad;
               

                TotalTextBox.Text = total.ToString();
                //
                pedido.Fecha = System.DateTime.Now;
                pedidosLista.Add(detallePedido);
                PedidosDataGridView.DataSource = null;
                PedidosDataGridView.DataSource = pedidosLista;

            }
        }

        private void RegistrarButton_Click(object sender, EventArgs e)
        {
            pedido.Id = Convert.ToInt32(IdTextBox.Text);
            pedido.NombreCliente = NombreTextBox.Text;
            pedido.CodigoProducto = CodigoProductoTextBox.Text;
            pedido.Cantidad = Convert.ToInt32(CantidadTextBox.Text);
            pedido.Precio = Convert.ToDecimal(PrecioTextBox.Text);
            
            pedido.Total = Convert.ToDecimal(TotalTextBox.Text);

            pedido.Descripcion = DescripcionTextBox.Text;
            
            
            int idPedido = 0;

            idPedido = pedidoDA.RegistroPedido(pedido);

            if (idPedido != 0)
            {
                foreach (var item in pedidosLista)
                {
                    item.Id = idPedido;
                    pedidoDA.InsertarPedido(item);
                }

               
                
            }

            DeshabilitarControles();
            LimpiarControles();
            ListarPedidos();

        }

    

        private void HabilitarControles()
        {
            IdTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            CodigoProductoTextBox.Enabled = true;
            CantidadTextBox.Enabled = true;
            

            NuevoPedidoButton.Enabled = false;
            RegistrarButton.Enabled = true;
            CancelarButton.Enabled = true;
        }

        private void DeshabilitarControles()
        {
            IdTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            CodigoProductoTextBox.Enabled = false;
            CantidadTextBox.Enabled = false;
            PrecioTextBox.Enabled = false;
            TotalTextBox.Enabled = false;
            DescripcionTextBox.Enabled = false;
            

            NuevoPedidoButton.Enabled = true;
            RegistrarButton.Enabled = false;
            CancelarButton.Enabled = false;
        }

        private void LimpiarControles()
        {
            IdTextBox.Clear();
            NombreTextBox.Clear();
            CodigoProductoTextBox.Clear();
            CantidadTextBox.Clear();
            PrecioTextBox.Clear();
            TotalTextBox.Clear();
            DescripcionTextBox.Clear();
            FechaDateTimePicker = null;
        }
        private void NuevoPedidoButton_Click(object sender, EventArgs e)
        {
            HabilitarControles();
        }
    }
}
