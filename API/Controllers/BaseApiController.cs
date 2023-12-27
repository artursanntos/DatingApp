using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // esse [controller] usa o nome do controller para criar a rota ("BaseApi")
public class BaseApiController : ControllerBase
{

}
