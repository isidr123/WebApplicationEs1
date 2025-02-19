using Microsoft.EntityFrameworkCore;

namespace WeatherApplication.Ex.Entities
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext() : base() { }

        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options) { }

public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FavoriteCity> FavoriteCities { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    }
}
