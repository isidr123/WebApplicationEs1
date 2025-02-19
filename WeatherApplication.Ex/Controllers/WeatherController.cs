using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApplication.Ex.DTO;
using WeatherApplication.Ex.Services;

namespace WeatherApplication.Ex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService weatherService;

        public WeatherController()
        {
            this.weatherService = new WeatherService();
        }

        [HttpGet("{cityId}")]
        public IActionResult GetWeatherForecast(int cityId)
        {
            var forecasts = weatherService.GetWeatherForecast(cityId);
            return Ok(forecasts);
        }
    }
}

