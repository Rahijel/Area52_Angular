using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Area52_Angular.API.Data;
using Area52_Angular.API.DTOs;
using Area52_Angular.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Area52_Angular.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository repo;
        private readonly IConfiguration config;

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            this.repo = repo;
            this.config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserToRegisterDTO userToRegisterDTO)
        {            
            userToRegisterDTO.Username = userToRegisterDTO.Username.ToLower();

            if (await repo.UserExists(userToRegisterDTO.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = userToRegisterDTO.Username
            };

            var createdUser = await repo.Register(userToCreate, userToRegisterDTO.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserToLoginDTO userToLoginDTO)
        {
            var userFromRepo = await repo.Login(userToLoginDTO.Username.ToLower(), userToLoginDTO.Password);

            if(userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new{
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}