using WeatherApplication.Ex.Entities;

namespace WeatherApplication.Ex.DTO
{
    public class CityDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Country { get; set; }

        List<FavoriteCities>? favoriteCities { get; set; }

    }
}
