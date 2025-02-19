using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApplication.Ex.Entities
{
    [PrimaryKey(nameof(UserId), nameof(CityId))]
    public class FavoriteCities
    {
        public int UserId { get; set; }
        public int CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public City? City { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
    }
}
