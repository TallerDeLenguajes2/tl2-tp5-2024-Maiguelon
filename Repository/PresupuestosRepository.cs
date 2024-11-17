using Microsoft.Data.Sqlite;
using Models;
namespace Repositories;

public class PresupuestosRepository
{
    // string con la direccion de la db
    private const string connectionString = @"Data Source=db\Tienda.db;Cache=Shared";

    public void CreatePresupuesto(Presupuestos presupuesto)
    {
        // query a realizar
        string queryString = "INSERT INTO Presupuestos (NombreDestinatario, FechaCreacion) VALUES (@NombreDestinatario, @FechaCreacion)";

        // Conexion
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            // Relacion de la query con la conexion
            SqliteCommand command = new SqliteCommand(queryString, connection);
            connection.Open();

            // Forma de añadir para evitar inyecciones de SQL
            command.Parameters.Add(new SqliteParameter("@NombreDestinatario", presupuesto.NombreDestinatario));
            command.Parameters.Add(new SqliteParameter("@FechaCreacion", presupuesto.FechaCreacion));

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}