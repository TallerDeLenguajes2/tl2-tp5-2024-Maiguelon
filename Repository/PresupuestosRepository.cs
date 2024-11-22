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

    public List<Presupuestos> ListarPresupuestos()
    {
        List<Presupuestos> ListaPresupuestos = new List<Presupuestos>();

        string queryString = "SELECT * FROM Presupuestos";

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            SqliteCommand command = new SqliteCommand(queryString, connection);
            connection.Open();

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Presupuestos NuevoPresupuesto = new Presupuestos();

                    NuevoPresupuesto.IdPresupuesto = Convert.ToInt32(reader["idPresupuesto"]);
                    NuevoPresupuesto.NombreDestinatario = Convert.ToString(reader["NombreDestinatario"]);
                    NuevoPresupuesto.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);

                    ListaPresupuestos.Add(NuevoPresupuesto);
                }
            }
            connection.Close();
        }
        return ListaPresupuestos;
    }

    public Presupuestos BuscarPresupuesto(int idBuscado)
    {
        Presupuestos presupuestoBuscado = new Presupuestos();
        string queryString = "SELECT * FROM Presupuestos WHERE idPresupuesto = @idPresupuesto";

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            SqliteCommand command = new SqliteCommand(queryString, connection);
            connection.Open();

            command.Parameters.Add(new SqliteParameter("@idPresupeusto", idBuscado));

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    presupuestoBuscado.IdPresupuesto = Convert.ToInt32(reader["idProducto"]);
                    presupuestoBuscado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                    presupuestoBuscado.NombreDestinatario = Convert.ToString(reader["NombreDestinatario"]);
                }
            }
            connection.Close();
        }
        return presupuestoBuscado;
    }

    public void DetallarPresupesto(int idBuscado, int idProducto, int cantidad)
    {
        string queryString = @"INSERT INTO PresupuestosDetalle (idPresupuesto, idProducto, Cantidad)
                            VALUES (@idBuscado, @idProducto, @Cantidad)";

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            SqliteCommand command = new SqliteCommand(queryString, connection);
            connection.Open();

            command.Parameters.Add(new SqliteParameter("@idpresupuesto", idBuscado));
            command.Parameters.Add(new SqliteParameter("@idProducto", idProducto));
            command.Parameters.Add(new SqliteParameter("@Cantidad", cantidad));

            command.ExecuteNonQuery();

            connection.Close();
        }
    }

    public void DeletearPresupuesto(int idABorrar)
    {
        string queryString = "DELETE FROM PresupuestosDetalle WHERE idPresupuesto = @idABorrar";
        string queryStringRequiem = "DELETE FROM Presupuestos WHERE idPresupuesto = @idABorrar";

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            SqliteCommand commandDetalle = new SqliteCommand(queryString, connection);
            commandDetalle.Parameters.Add(new SqliteParameter("@idPresupuesto", idABorrar));
            commandDetalle.ExecuteNonQuery();

            SqliteCommand commandPresupuesto = new SqliteCommand(queryStringRequiem, connection);
            commandPresupuesto.Parameters.Add( new SqliteParameter("@idPresupuesto", idABorrar));
            commandPresupuesto.ExecuteNonQuery();

            connection.Close();
        }
    }

}