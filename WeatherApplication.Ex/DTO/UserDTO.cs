using WeatherApplication.Ex.Entities;

namespace WeatherApplication.Ex.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public List<CityDTO>? FavoriteCities { get; set; }

    }
}
