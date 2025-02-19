using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherApplication.Ex.DTO;
using WeatherApplication.Ex.Entities;

namespace WeatherApplication.Ex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteCitiesController : ControllerBase
    {
        private readonly WeatherDbContext ctx;

        public FavoriteCitiesController(WeatherDbContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet("{userId}")]
        public IActionResult GetFavoriteCities(int userId)
        {
            var favoriteCities = ctx.FavoriteCities
                .Include(fc => fc.City)
                .Where(fc => fc.UserId == userId)
                .ToList();

            if (!favoriteCities.Any())
            {
                return NotFound($"Nessuna città preferita trovata per l'utente con ID: {userId}");
            }

            return Ok(favoriteCities.Select(fc => Mapper.MapEntityToDto(fc.City)).ToList());
        }

        [HttpPost]
        public IActionResult AddFavoriteCity(int userId, int cityId)
        {
            try
            {
                var favoriteCity = new FavoriteCities
                {
                    UserId = userId,
                    CityId = cityId
                };
                ctx.FavoriteCities.Add(favoriteCity);
                ctx.SaveChanges();
                return Created("", favoriteCity);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public IActionResult RemoveFavoriteCity(int userId, int cityId)
        {
            try
            {
                var favoriteCity = ctx.FavoriteCities
                    .SingleOrDefault(fc => fc.UserId == userId && fc.CityId == cityId);
                if (favoriteCity == null) return BadRequest();

                ctx.FavoriteCities.Remove(favoriteCity);
                ctx.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
