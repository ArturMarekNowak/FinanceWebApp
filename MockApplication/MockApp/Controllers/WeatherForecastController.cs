using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockApp.Models;

namespace MockApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static List<WeatherForecast> WeatherList = new List<WeatherForecast>
        {
            new WeatherForecast { Id = 0, Date = DateTime.Now, TemperatureC = 69, Summary = "XDDDD231"},
            new WeatherForecast { Id = 1, Date = DateTime.Now, TemperatureC = 41, Summary = "XDDDDqwe231"},
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> Get()
        {
            return Ok(WeatherList);
        }

        [HttpPost]
        public ActionResult<WeatherForecast> Post(WeatherForecast weatherForecast)
        {
            WeatherList.Add(weatherForecast);
            return CreatedAtAction(nameof(Post), new { id  = weatherForecast.Id});
        }

        [HttpDelete]
        public IActionResult Delete(UInt16 id)
        {
            var objToDelete = WeatherList.FirstOrDefault(w => w.Id == id);
            if (objToDelete is null)
            {
                return NotFound($"FAILED TO YEET OUT {id}");
            }

            WeatherList.Remove(objToDelete);
            return Ok($"YITTED OUT GOOD {id}");
        }

        [HttpPut]
        public IActionResult Put(WeatherForecast inObj)
        {
            var objToModify = WeatherList.FirstOrDefault(w => w.Id == inObj.Id);
            if (objToModify is null)
            {
                return NotFound($"FAILED TO MODIFY OBJ. NOT EXISITNIG {inObj.Id}");
            }

            WeatherList.Remove(objToModify);
            WeatherList.Add(inObj);
            return Ok($"OBJ MODIFIED GOOD {inObj.Id}");
        }
    }
}
