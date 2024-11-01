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

    // metodos

}
