using Microsoft.AspNetCore.Mvc;

namespace tl2_tp5_2024_mainaessens.Controllers;

[ApiController]
[Route("[controller]")]
public class PresupuestosController : ControllerBase
{
    private readonly PresupuestosRepository presupuestosRepository;

    public PresupuestosController(){
        presupuestosRepository = new PresupuestosRepository(); 
    }

    //POST/api/Presupuesto: crea un nuevo presupuesto
    [HttpPost]
    public ActionResult CrearPresupuesto(Presupuestos nuevoPresupuesto){
        if(nuevoPresupuesto == null || string.IsNullOrEmpty(nuevoPresupuesto.NombreDestinatario)){
            return BadRequest("El presupuesto debe tener un nombre de destinatario y un detalle válido."); 
        }
        presupuestosRepository.CrearNuevo(nuevoPresupuesto);
        return Ok();
    }

    // POST /api/Presupuesto/{id}/ProductoDetalle
    [HttpPost("{id}/ProductoDetalle")]
    public ActionResult AgregarProductoDetalle(int id, PresupuestoDetalle detalle)
    {
        if (detalle == null || detalle.Cantidad <= 0 || detalle.Cantidad <= 0)
            return BadRequest("Detalles del producto son inválidos.");
        ProductoRepository repositorio = new ProductoRepository();// crear la instancia
        var producto = repositorio.ObtenerProductoPorId(detalle.Producto.IdProducto);
        if (producto == null)
            return NotFound("El producto no existe.");
        presupuestosRepository.AgregarProductoAPresupuesto(id, producto, detalle.Cantidad);
        return Ok();
    }

    // GET /api/Presupuesto
    [HttpGet]
    public ActionResult ListarPresupuestos()
    {
        return Ok(presupuestosRepository.ListasPresupuestos());
    }

    // GET /api/Presupuesto/{id}
    [HttpGet("{id}")]
    public ActionResult ObtenerPresupuestoPorId(int id)
    {
        var presupuesto = presupuestosRepository.ObtenerPresupuestoPorId(id);
        if (presupuesto == null)
            return NotFound("Presupuesto no encontrado.");

        return Ok(presupuesto);
    }




}
