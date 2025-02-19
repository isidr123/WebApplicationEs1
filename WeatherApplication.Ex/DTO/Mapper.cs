using WeatherApplication.Ex.DTO;
using WeatherApplication.Ex.Entities;

public static class Mapper
{
    public static UserDTO MapEntityToDto(User user)
    {
        return new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            FavoriteCities = user.FavoriteCities?.Select(fc => new CityDTO
            {
                Id = fc.CityId,
                Name = fc.City?.Name ?? "Undefined",
                Country = fc.City?.Country ?? "Undefined"
            }).ToList()
        };
    }

    public static User MapDtoToEntity(UserDTO userDto)
    {
        return new User
        {
            Id = userDto.Id,
            Name = userDto.Name,
            Email = userDto.Email,
            FavoriteCities = userDto.FavoriteCities?.Select(fc => new FavoriteCities
            {
                CityId = fc.Id,
                UserId = userDto.Id
            }).ToList()
        };
    }

    public static CityDTO MapEntityToDto(City city)
    {
        return new CityDTO
        {
            Id = city.Id,
            Name = city.Name,
            Country = city.Country
        };
    }

    public static City MapDtoToEntity(CityDTO cityDto)
    {
        return new City
        {
            Id = cityDto.Id,
            Name = cityDto.Name,
            Country = cityDto.Country
        };
    }
}
