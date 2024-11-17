using Microsoft.Data.Sqlite;

public interface IProductosRepository
{
    void Add(Productos producto);
    void Update(int id, Productos producto);
    List<Productos> GetAll();
    Productos GetById(int id);
    void Delete(int id);
}

public class ProductosRepository : IProductosRepository
{
    private readonly string ConnectionString = "Data Source=db/Tienda.db;Cache=Shared;";

    public ProductosRepository()
    {

    }

    public List<Productos> GetAll()
    {
        var productos = new List<Productos>();
        string query = "SELECT * FROM Productos";

        try
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqliteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var producto = new Productos
                            {
                                IdProducto = Convert.ToInt32(reader["idProducto"]),
                                Descripcion = reader["Descripcion"].ToString(),
                                Precio = Convert.ToInt32(reader["Precio"])
                            };

                            productos.Add(producto);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener productos: {ex.Message}");
        }

        return productos;
    }


    public void Add(Productos producto)
    {
        using (SqliteConnection connection = new SqliteConnection(ConnectionString))
        {
            var query = "INSERT INTO Productos (Descripcion, Precio) VALUES (@Descripcion, @Precio)";
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@Descripcion", producto.Descripcion));
            command.Parameters.Add(new SqliteParameter("@Precio", producto.Precio));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public void Update(int id, Productos producto)
    {
        using (SqliteConnection connection = new SqliteConnection(ConnectionString))
        {
            string query = "UPDATE Productos SET Descripcion = @Descripcion, Precio = @Precio WHERE idProducto = @id";
            connection.Open();

            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@Descripcion", producto.Descripcion));
            command.Parameters.Add(new SqliteParameter("@Precio", producto.Precio));
            command.Parameters.Add(new SqliteParameter("@id", id));
            command.ExecuteNonQuery();
            connection.Close();
        }
        throw new NotImplementedException();
    }

    public Productos GetById(int id)
    {
        Productos producto = null;

        using (SqliteConnection connection = new SqliteConnection(ConnectionString))
        {
            string query = "SELECT idProducto, Descripcion, Precio FROM Productos WHERE idProducto = @id";
            connection.Open();

            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@id", id));

            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    producto = new Productos
                    {
                        IdProducto = Convert.ToInt32(reader["idProducto"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        Precio = Convert.ToInt32(reader["Precio"])
                    };
                }
            }

            connection.Close();
        }

        return producto;
    }


    public void Delete(int id)
    {
        using (SqliteConnection connection = new SqliteConnection(ConnectionString))
        {
            string query = "DELETE FROM Productos WHERE idProducto = @id";
            connection.Open();

            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@id", id));

            command.ExecuteNonQuery(); // Ejecuta el comando de eliminación
            connection.Close();
        }
    }

}