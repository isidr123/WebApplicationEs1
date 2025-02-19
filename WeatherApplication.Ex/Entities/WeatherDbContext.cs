using Microsoft.EntityFrameworkCore;

namespace WeatherApplication.Ex.Entities
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext() : base() { }

        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<FavoriteCities> FavoriteCities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurazione delle città preimpostate
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "New York", Country = "USA" },
                new City { Id = 2, Name = "Los Angeles", Country = "USA" },
                new City { Id = 3, Name = "Chicago", Country = "USA" },
                new City { Id = 4, Name = "Houston", Country = "USA" },
                new City { Id = 5, Name = "Phoenix", Country = "USA" }
            );
        }

    }
}
