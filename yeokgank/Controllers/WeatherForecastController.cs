using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yeokgank.Repository.Region.Query;

namespace yeokgank.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
     
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRegionQueries _regionQuery;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRegionQueries regionQuery)
        {
            _logger = logger;
            _regionQuery = regionQuery;
        }

        [HttpGet]
        public dynamic Get()
        {
            var rng = new Random();

            var weathers = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray();

      
            return weathers;



        }
    }
}
