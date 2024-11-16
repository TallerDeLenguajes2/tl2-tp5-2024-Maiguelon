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
        string queryString = "SELECT idProducto, Descripcion, Precio FROM Productos";

        try
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqliteCommand(queryString, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add(new Productos
                            {
                                IdProducto = reader.GetInt32(0), 
                                Descripcion = reader.GetString(1), 
                                Precio = reader.GetInt32(2) 
                            });
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
        throw new NotImplementedException();
    }

    public void Update(int id, Productos producto)
    {
        throw new NotImplementedException();
    }

    public Productos GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

}