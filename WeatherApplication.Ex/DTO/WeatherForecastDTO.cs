namespace WeatherApplication.Ex.DTO
{
    public class WeatherForecastDTO
    {
        public required string Date { get; set; }
        public required string Weather { get; set; }
        public double Temperature { get; set; }
    }
}
