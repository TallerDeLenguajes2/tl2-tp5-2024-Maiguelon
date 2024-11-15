public class Presupuestos {
        private int idPresupuesto;
        private string nombreDestinatario;
        private List<PresupuestosDetalle> detalle;
        Presupuestos()
        {
            detalle = new List<PresupuestosDetalle>();
        }

    public List<PresupuestosDetalle> Detalle { get => detalle; set => detalle = value; }
    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    public string NombreDestinatario { get => nombreDestinatario; set => nombreDestinatario = value; }

    // Métodos

    public float MontoPresupuesto() {  
        float monto = 0; 
        foreach (var item in detalle)
        {
            monto += item.Cantidad * item.Producto.Precio;
        }
        return monto;
    }
}