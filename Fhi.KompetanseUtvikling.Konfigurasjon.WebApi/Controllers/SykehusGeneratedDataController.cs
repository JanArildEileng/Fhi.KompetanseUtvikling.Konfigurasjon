using Microsoft.AspNetCore.Mvc;
using Testdata.Generator;

namespace Fhi.KompetanseUtvikling.Konfigurasjon.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SykehusGeneratedDataController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<SykehusGeneratedDataController> _logger;

        public SykehusGeneratedDataController(ILogger<SykehusGeneratedDataController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult<SykehusGeneratedData> Get([FromServices] IMyGenerator myGenerator)
        {
            SykehusGeneratedData sykehusGeneratedData = myGenerator.GenerateSykehusData(10101, "Secret", 2);
            return Ok(sykehusGeneratedData);
        }
    }
}