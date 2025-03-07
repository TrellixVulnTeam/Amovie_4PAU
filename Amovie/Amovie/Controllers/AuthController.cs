﻿
using Behaviour.Interfaces;
using Entities.Entities;
using Entities.Models.UserDto;
using Microsoft.AspNetCore.Mvc;

namespace Amovie.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService repository)
        {
            _userService = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                UserRole = "user"
            };

            await _userService.Create(user);

            return Created("succes", user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userService.GetByEmail(loginDto.Email);

            if (user == null)
            {
                return BadRequest("Invalid credentials!");
            }

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return BadRequest("Invalid credentials!");
            }

            var jwt = await _userService.Generate(user);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true,
            });

            return Ok(new
            {
                jwt, user
            });
        }

        [HttpGet("user")]
        public async Task<IActionResult> User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = await _userService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = await _userService.GetById(userId);

                return Ok(user);
            }

            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok("Succes");
        }
    }
}