using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Config.Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;
        private readonly string _version;
        private readonly IOptions<Custom> _custom;
        private readonly IConfiguration _configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, string version, IOptions<Custom> custom, IConfiguration configuration)
        {
            _logger = logger;
            this._version = version;
            this._custom = custom;
            this._configuration = configuration;
        }

        [HttpGet]
        public string Get()
        {
            //  return _version;
            //   return _custom.Value.ConfigValue;
            var version = _configuration["Version"];
            if (version != null)
            {
                return ($"Version: {version}");
            }
            else
            {
                return ("Version not found in configuration.");
            }
        }
    }

}
