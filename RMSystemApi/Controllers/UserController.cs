using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models.ViewModel;
using Services;
using Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DataLayer;
using DataLayer.Entities;

namespace RMSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromForm]UserDto model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                return BadRequest(errors);
            }
            await _userService.CreateUser(model);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetuserById(int id)
        {
            
               var user = await _userService.GetUserById(id);
                return Ok(user);
            
        }



        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] UserLoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userService.LoginUserAsync(loginDto);


            if (user == null)
                return BadRequest("Username or password incorrects.");

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                return BadRequest("Username or password incorrect.");

            string token = GenerateToken(user);

            return Ok(new { token });
        }
        private string GenerateToken(ApplicationUser user)
        {
            List<Claim> authclaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                //new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
               // new Claim(ClaimTypes.Role, user.Role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Secret").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var expiretime = DateTime.Now.AddHours(1);
            var token = new JwtSecurityToken(
                claims: authclaims,
                expires: expiretime,
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            //CookieOptions cookieOptions = new CookieOptions()
            //{
            //    Expires = expiretime,
            //    Secure = true
            //};
            //Response.Cookies.Append("jwt-token", jwt, cookieOptions);

            return jwt;
        }
    }
}

