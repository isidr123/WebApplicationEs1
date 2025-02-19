using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApplication.Ex.DTO;
using WeatherApplication.Ex.Entities;

namespace WeatherApplication.Ex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly WeatherDbContext ctx;
        private readonly Mapper mapper;

        public UserController(WeatherDbContext ctx, Mapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = ctx.Users.ToList().ConvertAll(mapper.MapEntityToDto);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(UserDTO dto) 
        {
            try
            {
                var entity = mapper.MapDtoToEntity(dto);
                entity.Id = 0;
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1
                    ? Created("", mapper.MapEntityToDto(entity))
                    : BadRequest();
            } catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            var result = ctx.Users.Find(id);

            if(result == null) return NotFound();
            return Ok(mapper.MapEntityToDto(result));
        }

        [HttpPut]
        public IActionResult Update(UserDTO user)
        {
            try
            {
                var entity = ctx.Users.Find(user.Id);
                if (entity == null) return BadRequest();

                entity.Name = user.Name;
                entity.Email = user.Email;
                return ctx.SaveChanges() == 1
                    ? Ok(mapper.MapEntityToDto(entity))
                    : BadRequest();
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
                var entity = ctx.Users.Find(id);
                if (entity == null) return BadRequest();
                ctx.Users.Remove(entity);
                return ctx.SaveChanges() == 1
                    ? Ok()
                    : BadRequest();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
