using Microsoft.AspNetCore.SignalR;

public class Productos {
    private int idProducto;
    private string descripcion;
    private int precio;

    public int IdProducto1 { get => idProducto; set => idProducto = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public int Precio { get => precio; set => precio = value; }

}