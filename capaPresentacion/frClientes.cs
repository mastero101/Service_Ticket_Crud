using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaEntidad;
using capaNegocio;

namespace capaPresentacion
{
    public partial class frClientes : Form
    {

        CNCliente cNCliente = new CNCliente();
        public frClientes()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarForm();
        }

        private void LimpiarForm()
        {
            txtId.Value = 0;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            picFoto.Image = null;
        }

        private void lnkFoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdFoto.FileName = string.Empty;

            if (ofdFoto.ShowDialog() == DialogResult.OK)
            {
                picFoto.Load(ofdFoto.FileName);
            }

            ofdFoto.FileName = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool Resultado;
            CEClientes cEClientes = new CEClientes();
            cEClientes.Id = (int)txtId.Value;
            cEClientes.Nombre = txtNombre.Text;
            cEClientes.Apellido = txtApellido.Text;
            cEClientes.Foto = picFoto.ImageLocation;

            Resultado = cNCliente.ValidarDatos(cEClientes);
            if (Resultado == false)
            {
                return;
            }

            if (cEClientes.Id == 0)
            {
                cNCliente.CrearCliente(cEClientes);
            }
            else
            {
                cNCliente.EditarCliente(cEClientes);
            }

            CargarDatos();
            LimpiarForm();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Value == 0) return;

            if (MessageBox.Show("¿Deseas Eliminar?","Titulo",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CEClientes cE = new CEClientes();
                cE.Id = (int)txtId.Value;
                cNCliente.EliminarCliente(cE);
                CargarDatos();
                LimpiarForm();
            }

        }

        private void frClientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        public void CargarDatos()
        {
            gridDatos.DataSource = cNCliente.ObtenerDatos().Tables["tbl"];
        }

        private void gridDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Value = (int)gridDatos.CurrentRow.Cells["id"].Value;
            txtNombre.Text = gridDatos.CurrentRow.Cells["nombre"].Value.ToString();
            txtApellido.Text = gridDatos.CurrentRow.Cells["apellido"].Value.ToString();
            picFoto.Load(gridDatos.CurrentRow.Cells["foto"].Value.ToString());
        }

        private void iniciarTabla_Click(object sender, EventArgs e)
        {
            CargarDatos();
            MessageBox.Show("Actualizado");
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
