using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApplication.Ex.DTO;
using WeatherApplication.Ex.Entities;

namespace WeatherApplication.Ex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly WeatherDbContext ctx;

        public CityController(WeatherDbContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            var cities = ctx.Cities.ToList();
            return Ok(cities.Select(Mapper.MapEntityToDto).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var city = ctx.Cities.Find(id);
            if (city == null) return NotFound();
            return Ok(Mapper.MapEntityToDto(city));
        }

        [HttpPost]
        public IActionResult Create(CityDTO dto)
        {
            try
            {
                var entity = Mapper.MapDtoToEntity(dto);
                entity.Id = 0;
                ctx.Cities.Add(entity);
                ctx.SaveChanges();
                return Created("", Mapper.MapEntityToDto(entity));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Update(CityDTO city)
        {
            try
            {
                var entity = ctx.Cities.Find(city.Id);
                if (entity == null) return BadRequest();

                entity.Name = city.Name;
                entity.Country = city.Country;

                ctx.SaveChanges();
                return Ok(Mapper.MapEntityToDto(entity));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var entity = ctx.Cities.Find(id);
                if (entity == null) return BadRequest();
                ctx.Cities.Remove(entity);
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
