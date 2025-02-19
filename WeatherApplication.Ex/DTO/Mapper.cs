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
                Email = entity.Email
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
    }
}
