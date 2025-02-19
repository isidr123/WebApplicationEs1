using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApplication.Ex.DTO;
using WeatherApplication.Ex.Entities;

namespace WeatherApplication.Ex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteCitiesController : ControllerBase
    {
        private readonly WeatherDbContext ctx;
        private readonly Mapper mapper;

        public FavoriteCitiesController(WeatherDbContext ctx, Mapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        [HttpGet("{userId}")]
        public IActionResult GetSingle(int Id)
        {
            var entites = ctx.FavoriteCities.Where(fc => fc.UserId == Id)
                .Select(fc => fc.CityId)
                .ToList();
            if (!entites.Any())
            {
                return BadRequest();
            }
            return entites;
        }
        
    }
}
