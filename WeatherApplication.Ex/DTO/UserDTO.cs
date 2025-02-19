using WeatherApplication.Ex.Entities;

namespace WeatherApplication.Ex.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        List<City>? cities { get; set; }

    }
}
