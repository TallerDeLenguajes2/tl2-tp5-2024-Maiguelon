namespace Models;
public class Presupuestos
{
    private int idPresupuesto;
    private string nombreDestinatario;
    private DateTime fechaCreacion;
    private List<PresupuestosDetalle> detalle;
    public Presupuestos()
    {
        detalle = new List<PresupuestosDetalle>();
    }

    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    public string NombreDestinatario { get => nombreDestinatario; set => nombreDestinatario = value; }
    public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
    public List<PresupuestosDetalle> Detalle { get => detalle; }

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
        foreach (var item in Detalle)
        {
            cantidad += item.Cantidad;
        }
        return cantidad;
    }
}