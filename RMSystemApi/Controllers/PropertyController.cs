using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.PropertyModel;
using Services.Interfaces;

namespace RMSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }


        [HttpGet("GetAllProperty")]
        public async Task<IActionResult> GetAllProperty()
        {
            var property = await _propertyService.GetAllProperty();
            return Ok(property);
        }

        //[HttpGet("{id:int}")]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var property = await _propertyService.GetPropertyById(Id);
            return Ok(property);
        }

        [HttpGet("userId")]
        public async Task<IActionResult> GetPropertiesByUserId(int userId)
        {
            var property = await _propertyService.GetPropertiesByUserId(userId);
            return Ok(property);
        }

        [Authorize(Roles = "Admin, Tenant")]
        [HttpPost]
        public async Task<IActionResult> CreateProperty(PropertyDto model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                return BadRequest(errors);
            }
            model = await _propertyService.AddProperty(model);
            return Ok();

        }



        [HttpPut]
        public async Task<IActionResult> UpdateProperty(int Id, UpdatePropertyDto updatePropertyDto)
        {
            var property = await _propertyService.UpdateProperty(Id, updatePropertyDto);
            return Ok(property);
        }



    }

}
