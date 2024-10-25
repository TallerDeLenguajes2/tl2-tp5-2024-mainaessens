public class Productos{
    private int idProducto; 
    private string descripcion; 
    private int precio;

    public int IdProducto { get => idProducto;} //saco los sets, no quiero que me editen el producto después de cargado el objeto. 
    public string Descripcion { get => descripcion; }
    public int Precio { get => precio;}
}