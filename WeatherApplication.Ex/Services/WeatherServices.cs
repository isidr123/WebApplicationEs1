using WeatherApplication.Ex.DTO;

namespace WeatherApplication.Ex.Services
{
    public class WeatherService
    {
        public IEnumerable<WeatherForecastDTO> GetWeatherForecast(int cityId)
        {
            return new List<WeatherForecastDTO>
            {
                new WeatherForecastDTO { Date = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"), Weather = "Sunny", Temperature = 25 },
                new WeatherForecastDTO { Date = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd"), Weather = "Cloudy", Temperature = 22 },
                new WeatherForecastDTO { Date = DateTime.Now.AddDays(3).ToString("yyyy-MM-dd"), Weather = "Rainy", Temperature = 18 }
            };
        }
    }
}

