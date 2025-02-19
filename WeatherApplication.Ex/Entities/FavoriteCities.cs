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
        City? city { get; set; }

        [ForeignKey(nameof(UserId))]
        User? user { get; set; }

    }
}

