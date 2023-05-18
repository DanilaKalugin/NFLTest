using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Coursework.BLL;
using Entities.DTOs;
using Entities.Tables;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace CourseworkApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/auth")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration { get; set; }
        private readonly UserBL _userBl;

        public TokenController(IConfiguration config, UserBL userBl)
        {
            _configuration = config;
            _userBl = userBl;
        }

        [HttpPost("login", Name = "10")]
        [ProducesResponseType(typeof(OkResult), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public async Task<IActionResult> Post([FromBody] UserDto _userData)
        {
            if (_userData is not { Email: not null, Password: not null })
            {
                return BadRequest();
            }

            var user = await _userBl.GetUserAsync(_userData.Email, _userData.Password);

            if (user == null)
                return BadRequest(JsonConvert.SerializeObject("Invalid Credentials"));

            var token = CreateJWTToken(user);

            return Ok(JsonConvert.SerializeObject(new JwtSecurityTokenHandler().WriteToken(token)));
        }

        private JwtSecurityToken CreateJWTToken(User user)
        {
            //create claims details based on the user information
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Id", user.UserId.ToString()),
                new Claim("Email", user.Email),
                new Claim("Password", user.Password),
                new Claim("Team", user.FavoriteTeamAbbreviation!),
                new Claim("color", user.FavoriteTeam.Colors[0].Color)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            return new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);
        }

        [HttpPost("register", Name = "11")]
        [ProducesResponseType(typeof(CreatedResult), 201)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDto user)
        {
            if (user is not { Email: not null, Password: not null })
            {
                return BadRequest();
            }

            var emailIsBusy = await _userBl.CheckUserWithThiEmailIsExistsAsync(user.Email);

            if (emailIsBusy) return BadRequest("User with this e-mail already exists");

            await _userBl.RegisterUser(user);
            return Created("~/api/register", new {id = user.Email});
        }
    }
}
