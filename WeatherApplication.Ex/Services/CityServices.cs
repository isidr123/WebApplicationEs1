namespace WeatherApplication.Ex.Services
{
    public class CityService
    {
        private readonly List<DTO.CityDTO> _cities = new()
        {
            new DTO.CityDTO { Id = 1, Name = "Rome", Country = "Italy" },
            new DTO.CityDTO { Id = 2, Name = "Paris", Country = "France" },
            new DTO.CityDTO { Id = 3, Name = "New York", Country = "USA" } 
        };

        public List<DTO.CityDTO> GetCities()
        {
            return _cities;
        }
    }
}
