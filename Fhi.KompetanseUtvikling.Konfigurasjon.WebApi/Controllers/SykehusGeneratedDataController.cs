using Fhi.KompetanseUtvikling.Konfigurasjon.WebApi.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
        private readonly IOptions<SecretConfiguration> secretConfiguration;
        private readonly IOptions<AntallSykehusConfig> antallSykehusConfig;

        public SykehusGeneratedDataController(ILogger<SykehusGeneratedDataController> logger, IOptions<SecretConfiguration> secretConfiguration, IOptions<AntallSykehusConfig> antallSykehusConfig)
        {
            _logger = logger;
            this.secretConfiguration = secretConfiguration;
            this.antallSykehusConfig = antallSykehusConfig;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult<SykehusGeneratedData> Get([FromServices] IMyGenerator myGenerator)
        {
            SykehusGeneratedData sykehusGeneratedData = myGenerator.GenerateSykehusData(secretConfiguration.Value.SecretKey, secretConfiguration.Value.SecretValue, antallSykehusConfig.Value.AntallSykehus);
            return Ok(sykehusGeneratedData);
        }
    }
}