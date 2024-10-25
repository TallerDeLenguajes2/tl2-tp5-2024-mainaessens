public class Presupuestos{
    private int idPresupuesto; 
    private string nombreDestinatario; 
    private List<PresupuestoDetalle> detalle;

    public int IdPresupuesto { get => idPresupuesto;}
    public string NombreDestinatario { get => nombreDestinatario;}
    public List<PresupuestoDetalle> Detalle { get => detalle; }

    public double MontoPresupuesto(){
        return detalle.Sum(d => d.Producto.Precio * d.Cantidad);
    }

    public double MontoPresupuestoConIva(){
        double iva = 1.21; 
        return MontoPresupuesto() * iva; 
    }

    public int CantidadProductos(){
        return Detalle.Sum(d => d.Cantidad); 
    }

    public void AgregarProducto(Productos prod, int cant){
        PresupuestoDetalle pd = new PresupuestoDetalle(); 
        pd.Producto = prod; 
        pd.Cantidad = cant; 
        detalle.Add(pd);
    }
}