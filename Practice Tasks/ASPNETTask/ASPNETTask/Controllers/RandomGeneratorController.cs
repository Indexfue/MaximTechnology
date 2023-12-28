using ASPNETTask.Utility.Networking;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETTask.Controllers;

[ApiController]
[Route("[controller]")]
public class RandomGeneratorController : ControllerBase
{
    private readonly IConfiguration _configuration;
    
    public RandomGeneratorController(IConfiguration configuration) 
    {
        _configuration = configuration;
        
        AppSettings appSettings = _configuration.GetSection("Settings").Get<AppSettings>();
        RandomGenerator.RequestUri = appSettings.RandomApi;
    }
}