using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace pryGimenezBD
{
    internal class SqlCliente1
    {
        string connectionString = "Server=localhost;Database=Comercio;Trusted_Connection=True;";
                                 //Server=DESKTOP-JT924IA(<--Ese es el servidor de mi compu en el SQL Server Management)


        public void Conectar(DataGridView Grilla)
          {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("✅ Conexión exitosa a la base de datos.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Error al conectar: " + ex.Message);
                }

                string query = "SELECT Nombre FROM Productos";
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Grilla.Columns.Add("Nombre","Nombre");

                    while (reader.Read())
                    {
                        Grilla.Rows.Add($"{reader["Nombre"]}");
                    }
                }
            }

        }
  
    }
}
