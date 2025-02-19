using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using WeatherApplication.Ex.Entities;

namespace WeatherApplication.Ex.DTO
{
    public class FavoriteCityDTO
    {
        public int UserId { get; set; }
        public int CityId { get; set; }
    }
}

