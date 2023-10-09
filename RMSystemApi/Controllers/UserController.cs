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
        private readonly IRoleService _roleService;
        public UserController(IUserService userService, IConfiguration configuration, IRoleService roleService)
        {
            _userService = userService;
            _configuration = configuration;
            _roleService = roleService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDto model)
        {
            #region User Validation
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                return BadRequest(errors);
            }

            // check if role exist before assigning role to user
            var role = await _roleService.GetByName(model.RoleName);
            if (role == null)
            {
                return BadRequest("Role does not exist.");
            }

            // Check if a user with the same email already exists
            var existingUser = await _userService.GetByEmail(model.Email);
            if (existingUser != null)
            {
                return BadRequest($"User with {model.Email} already exist.");
            }
            #endregion

            await _userService.CreateUser(model);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetuserById(int id)
        {
            
               var user = await _userService.GetUserById(id);
                return Ok(user);
            
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto model)
        {

            var userDto = await _userService.GetByEmail(model.Email);
            if (userDto == null)
                return BadRequest("Username or password is invalid");

            userDto.Password = model.Password;
            var result = await _userService.ValidateUser(userDto, model.Password);
            if (result == null)
                return BadRequest("Username or password is invalid");

            var token = await _userService.GenerateJwtToken(userDto);
            return Ok(new { token });
        }
    }
}

