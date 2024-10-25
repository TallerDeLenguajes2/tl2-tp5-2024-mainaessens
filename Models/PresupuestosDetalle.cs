public class PresupuestoDetalle{
    private Productos producto; 
    private int cantidad;

    public Productos Producto { get => producto;} //saco set para que no se modifique el objeto
    public int Cantidad { get => cantidad; set => cantidad = value; } //no hace falta sacar el set porque es un entero.

    public void CargaProducto(Productos prod){
        producto = prod; 
    }
}