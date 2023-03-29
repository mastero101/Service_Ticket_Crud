using System;
using System.Windows.Forms;
using capaEntidad;
using capaDatos;
using System.Data;

namespace capaNegocio
{
    public class CNCliente
    { 
        CDCliente cDCliente = new CDCliente();
        public bool ValidarDatos(CEClientes cliente)
        {

            bool Resultado = true;

            if (cliente.Nombre == string.Empty)
            {
                Resultado = false;
                MessageBox.Show("El Nombre es Obligatorio");
            }
            if (cliente.Apellido == string.Empty)
            {
                Resultado = false;
                MessageBox.Show("El Apellido es Obligatorio");
            }
            if (cliente.Foto == null)
            {
                Resultado = false;
                MessageBox.Show("La Foto es Obligatoria");
            }

            return Resultado;
        }

        public void PruebaMySql()
        {
            cDCliente.Pruebaconexion();
        }

        public void CrearCliente(CEClientes cE)
        {
            cDCliente.Crear(cE);
        }

        public void EditarCliente(CEClientes cE)
        {
            cDCliente.Editar(cE);
        }

        public void EliminarCliente(CEClientes cE)
        {
            cDCliente.Eliminar(cE);
        }

        public DataSet ObtenerDatos()
        {
            return cDCliente.Listar();
        }
    }
}
