using WeatherApplication.Ex.Entities;

namespace WeatherApplication.Ex.DTO
{
    public class Mapper
    {
        public UserDTO MapEntityToDto(User entity)
        {
            return new UserDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
            };
        }
        public User MapDtoToEntity(UserDTO user)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public CityDTO MapEntityToDto(City entity)
        {
            return new CityDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Country = entity.Country
            };
        }
        public City MapDtoToEntity(CityDTO city)
        {
            return new City
            {
                Id = city.Id,
                Name = city.Name,
                Country = city.Country
            };
        }
        public WeatherForecastDTO MapEntityToDto(WeatherForecast entity)
        {
            return new WeatherForecastDTO
            {
                City = entity.City,
                dateTime = entity.date,
                Humidity = entity.Humidity,
                Temperature = entity.Temperature
            };
        }
        public WeatherForecast MapDtoToEntity(WeatherForecastDTO weatherForecast)
        {
            return new WeatherForecast
            {
                City = weatherForecast.City,
                date = weatherForecast.dateTime,
                Humidity = weatherForecast.Humidity,
                Temperature = weatherForecast.Temperature
            };
        }

        public FavoriteCitiesDTO MapEntityToDto(FavoriteCities entity)
        {
            return new FavoriteCitiesDTO
            {
                CityId = entity.CityId,
                UserId = entity.UserId
            };
        }
        public FavoriteCities MapDtoToEntity(FavoriteCitiesDTO favoriteCities)
        {
            return new FavoriteCities
            {
                CityId = favoriteCities.CityId,
                UserId = favoriteCities.UserId
            };
        }
    }
}
