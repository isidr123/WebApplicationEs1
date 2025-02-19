namespace WeatherApplication.Ex.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        List<WeatherForecast>? WeatherForecasts { get; set; }

    }
}
