using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AppSettings_Read.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly AppSettingsClass _optionsAppSettingsClass;

        public WeatherForecastController(IOptions<AppSettingsClass> optionsAppSettingsClass)
        {
            _optionsAppSettingsClass = optionsAppSettingsClass.Value;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_optionsAppSettingsClass);
        }
    }
}
