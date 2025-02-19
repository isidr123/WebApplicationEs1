using WeatherApplication.Ex.Entities;

namespace WeatherApplication.Ex.Storage
{
    public class Data
    {
        public List<string> PredefinitedCities { get; } = new List<string>
        {
            "Milano",
            "Roma",
            "Torino",
            "Napoli"
        };

        public List<User> Users { get; } = new List<User>();
    }
}
