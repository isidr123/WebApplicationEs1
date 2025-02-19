namespace WeatherApplication.Ex.Entities
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public required string City { get; set; }
        public required double Temperature { get; set; }
        public required string Condition { get; set; }
        public required DateTime date { get; set; }
    }
}
