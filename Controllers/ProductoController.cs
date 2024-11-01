using Microsoft.AspNetCore.Mvc;

namespace tl2_tp5_2024_mainaessens.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private readonly ProductoRepository productoRepository;

    public ProductoController(){
        productoRepository = new ProductoRepository(); 
    }

    //POST/api/Producto: crea un nuevo producto
    [HttpPost]
    public ActionResult CrearProducto([FromBody] Productos nuevoProducto){
        if (nuevoProducto == null || string.IsNullOrEmpty(nuevoProducto.Descripcion))
        {
            return BadRequest("El producto debe tener una descripción y un precio válido"); 
        }
        productoRepository.CrearNuevo(nuevoProducto); 
        return Ok(); 
    }

    //GET/api/Producto: Permite listar los Productos existentes. 
    [HttpGet]
    public ActionResult<List<Productos>> ListarProductos(){
        var productos = productoRepository.ListarProductos(); 
        return Ok(productos); 
    }

    // PUT/api/Producto/{Id}: Permite modificar un nombre de un Producto.
    [HttpPut("{id}")]
    public ActionResult ModificarProducto(int id, Productos productoActualizado)
    {
        if (productoActualizado == null || string.IsNullOrEmpty(productoActualizado.Descripcion))
        {
            return BadRequest("El producto debe tener una descripción y un precio válido");
        }

        var productoExistente = productoRepository.ObtenerProductoPorId(id);
        if (productoExistente == null)
        {
            return NotFound($"No se encontró un producto con el ID {id}");
        }

        // Actualiza los datos del producto
        productoExistente.Descripcion = productoActualizado.Descripcion;
        productoExistente.Precio = productoActualizado.Precio;

        // Llama al método de repositorio para actualizar en la base de datos
        productoRepository.ModificarProducto(productoExistente.IdProducto, productoExistente);

        return Ok();
    }


}
