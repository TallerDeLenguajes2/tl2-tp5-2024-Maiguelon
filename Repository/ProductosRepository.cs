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

        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CreateCommand = "SELECT idProducto, Descripcion, Precio FROM Productos"
        }
    }
}