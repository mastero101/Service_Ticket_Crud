using System;
using MySql.Data.MySqlClient;
using capaEntidad;
using System.Windows.Forms;
using System.Data;

namespace capaDatos
{
    public class CDCliente
    {
        string CadenaConexion = "Server=serviceticket23.mysql.database.azure.com;User=;Password=;Port=3306;database=tickets";

        public void Pruebaconexion()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);

            try
            {
                mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conextarse" + ex.Message);
                return;
            }

            mySqlConnection.Close();
            MessageBox.Show("Conectado");
        }

        public void Crear(CEClientes cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "insert into tickets (nombre, apellido, foto) VALUES ('" + cE.Nombre + "', '" + cE.Apellido + "', '" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Foto) + "');";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Creado");
        }

        public void Editar(CEClientes cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "UPDATE tickets SET `nombre` = '" + cE.Nombre +"', `apellido` = '"+ cE.Apellido + "', `foto` = '"+ MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Foto) +"' WHERE `id` = "+ cE.Id + ";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Actualizado");
        }

        public void Eliminar(CEClientes cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "DELETE FROM tickets WHERE `id` = " + cE.Id + ";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Eliminado");
        }

        public void Iniciar(CEClientes cE)
        {

        }

        public DataSet Listar()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "SELECT * FROM tickets LIMIT 1000;";
            MySqlDataAdapter Adaptador;
            DataSet dataSet = new DataSet();

            Adaptador = new MySqlDataAdapter(Query, mySqlConnection);
            Adaptador.Fill(dataSet,"tbl");

            return dataSet;
        }

    }
}
