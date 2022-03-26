using ExamenIIParcial.Accesos;
using ExamenIIParcial.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenIIParcial
{
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }

        UsuarioDA usuarioDA = new UsuarioDA();
        string operacion = string.Empty;
        Usuario usuario = new Usuario();

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        private void ListarUsuarios()
        {
            UsuariosDataGridView.DataSource = usuarioDA.ListarUsuarios();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }

        private void HabilitarControles()
        {
            IdUsuarioTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            CargoTextBox.Enabled = true;
            EstadoCheckBox.Enabled = true;
            ClaveTextBox.Enabled = true;

            NuevoButton.Enabled = false;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;


        }

        private void DesabilitarControles()
        {
            IdUsuarioTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            CargoTextBox.Enabled = false;
            EstadoCheckBox.Enabled = false;
            ClaveTextBox.Enabled = false;

            NuevoButton.Enabled = true;
            GuardarButton.Enabled = false;
            CancelarButton.Enabled = true;


        }

        private void LimpiarControles()
        {
            IdUsuarioTextBox.Clear();
            NombreTextBox.Text = "";
            CargoTextBox.Text = string.Empty;
            EstadoCheckBox.Enabled = false;
            ClaveTextBox.Text = string.Empty;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            usuario.IdUsuario = IdUsuarioTextBox.Text;
            usuario.Nombre = NombreTextBox.Text;
            usuario.Cargo = CargoTextBox.Text;
            usuario.Estado = EstadoCheckBox.Checked;
            usuario.Clave = ClaveTextBox.Text;

            if (operacion == "Nuevo")
            {
                bool inserto = usuarioDA.AgregarUsuario(usuario);

                if (inserto)
                {
                    MessageBox.Show("Usuario Creado");
                    ListarUsuarios();
                    LimpiarControles();
                    DesabilitarControles();
                }
                else
                {
                    MessageBox.Show("Usuario no se pudo Crear");
                }
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DesabilitarControles();
            LimpiarControles();
        }
    }
}
