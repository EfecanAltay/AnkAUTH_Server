using Microsoft.AspNetCore.Mvc;

namespace AnkaAUTH_Server.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    //private readonly ILogger<WeatherForecastController> _logger;

    public AuthController()
    {
       // _logger = logger;
    }

    [HttpGet(Name = "HealthCheck")]
    public string Get()
    {
        return "It's Live!";
    }
}
