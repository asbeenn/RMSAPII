using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModel;
using Services;
using Services.Interfaces;

namespace RMSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
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

        //[HttpPost("login")]
        //public async Task<IActionResult> Login(UserLoginDto dto)
        //{
        //    var success = await _userService.Login(dto.Email, dto.Password);
        //    return Ok(success);
        //}
     }
}

