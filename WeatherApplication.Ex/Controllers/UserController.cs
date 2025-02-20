﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherApplication.Ex.DTO;
using WeatherApplication.Ex.Entities;

namespace WeatherApplication.Ex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly WeatherDbContext ctx;

        public UserController(WeatherDbContext ctx)
        {
            this.ctx = ctx;
        }



        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = ctx.Users.Include(u => u.FavoriteCities)
                .ThenInclude(fc => fc.City)
                .SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound($"User con ID: {id} non trovato");
            }

            return Ok(Mapper.MapEntityToDto(user));
        }

        [HttpPost]
        public IActionResult Create(UserDTO dto)
        {
            try
            {
                var entity = Mapper.MapDtoToEntity(dto);

                ctx.Users.Add(entity);
                ctx.SaveChanges();
                return Created("", Mapper.MapEntityToDto(entity));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Update(UserDTO user)
        {
            try
            {
                var entity = ctx.Users.Include(u => u.FavoriteCities)
                    .SingleOrDefault(u => u.Id == user.Id);
                if (entity == null) return BadRequest();

                entity.Name = user.Name;
                entity.Email = user.Email;
                entity.FavoriteCities = user.FavoriteCities?.Select(fc => new FavoriteCities
                {
                    CityId = fc.Id,
                    UserId = user.Id
                }).ToList();

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
                var entity = ctx.Users.Find(id);
                if (entity == null) return BadRequest();
                ctx.Users.Remove(entity);
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
