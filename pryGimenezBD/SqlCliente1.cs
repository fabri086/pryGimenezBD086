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

                string query = "SELECT Nombre, Descripcion, Precio, Stock, CategoriaId FROM Productos";
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Grilla.Columns.Add("Nombre", "Nombre");
                    Grilla.Columns.Add("Descripcion", "Descripcion");
                    Grilla.Columns.Add("Precio", "Precio");
                    Grilla.Columns.Add("Stock", "Stock");
                    Grilla.Columns.Add("CategoriaId", "CategoriaId");

                    while (reader.Read())
                    {
                        Grilla.Rows.Add($"{reader["Nombre"]}", $"{reader["Descripcion"]}", $"{reader["Precio"]}", $"{reader["Stock"]}", $"{reader["CategoriaId"]}");
                    }
                }
            }
        }
        public void Agregar(DataGridView Grilla)
        {
            using (SqlConnection connec1 = new SqlConnection(connectionString))
            {
                try
                {
                    connec1.Open();
                    MessageBox.Show("✅ Conexión exitosa a la base de datos.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Error al conectar: " + ex.Message);
                }
                string insertQuery = "INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, CategortiaId)" +
                    " VALUES (@nombre, @descripcion, @precio, @stock, @categoriaid)";

                SqlCommand cmd= new SqlCommand(insertQuery, connec1);

                cmd.Parameters.AddWithValue("@nombre","");
                cmd.Parameters.AddWithValue("@descripcion", "");
                cmd.Parameters.AddWithValue("@precio", "");
                cmd.Parameters.AddWithValue("@stock", "");
                cmd.Parameters.AddWithValue("@categoriaid", "");
                cmd.ExecuteNonQuery();
                Console.WriteLine("✅ Producto agregado con éxito");

            }
        }
    }
}
