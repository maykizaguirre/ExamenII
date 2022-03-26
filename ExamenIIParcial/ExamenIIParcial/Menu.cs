using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExamenIIParcial
{
    public partial class Menu : Syncfusion.Windows.Forms.Office2010Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        FrmUsuario frmUsuario = null;
        FrmProducto frmProducto = null;
        FrmPedido frmPedido = null;

        private void UsuariosToolStripButton_Click(object sender, EventArgs e)
        {
            if (frmUsuario == null)
            {
                frmUsuario = new FrmUsuario();
                frmUsuario.MdiParent = this;
                frmUsuario.FormClosed += FrmUsuario_FormClosed;
                frmUsuario.Show();
            }
            else
            {
                frmUsuario.Activate();
            }
        }

        private void FrmUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmUsuario = null;
        }

        private void ListaProductosToolStripButton_Click(object sender, EventArgs e)
        {
            if (frmProducto == null)
            {
                frmProducto = new FrmProducto();
                frmProducto.MdiParent = this;
                frmProducto.FormClosed += FrmProducto_FormClosed;
                frmProducto.Show();
            }
            else
            {
                frmProducto.Activate();
            }
        }

        private void FrmProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmProducto = null;
        }

        private void ListaPedidosToolStripButton_Click(object sender, EventArgs e)
        {
            if (frmPedido == null)
            {
                frmPedido = new FrmPedido();
                frmPedido.MdiParent = this;
                frmPedido.FormClosed += FrmPedido_FormClosed;
                frmPedido.Show();
            }
            else
            {
                frmPedido.Activate();
            }
        }

        private void FrmPedido_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPedido = null;
        }
    }
}
