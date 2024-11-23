namespace Models;
public class Presupuestos
{
    private int idPresupuesto;
    private string nombreDestinatario;
    private DateTime fechaCreacion;
    List<PresupuestosDetalle> detalle;

    public List<PresupuestosDetalle> Detalle { get => detalle; }
    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    public string NombreDestinatario { get => nombreDestinatario; set => nombreDestinatario = value; }
    public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }

    // Métodos

    public float MontoPresupuesto()
    {
        float monto = 0;
        foreach (var item in detalle)
        {
            monto += item.Cantidad * item.Producto.Precio;
        }
        return monto;
    }

    public float MontoPresupuestoConIva()
    {
        float montoIva;
        montoIva = MontoPresupuesto() + MontoPresupuesto() * 0.21f;
        return montoIva;
    }

    public int CantidadProductos()
    {
        int cantidad = 0;
        foreach (var item in detalle)
        {
            cantidad += item.Cantidad;
        }
        return cantidad;
    }
}