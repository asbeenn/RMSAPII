using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.PropertyModel;
using Services.Interfaces;
using DataLayer.Entities;

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

        [HttpGet("GetPropertiesByUserId/{userId}")]
        public async Task<IActionResult> GetPropertiesByUserId(int userId)
        {
            var property = await _propertyService.GetPropertiesByUserId(userId);
            return Ok(property);
        }

        //[Authorize(Roles="Tenant")]
        [HttpPost]
        public async Task<IActionResult> CreateProperty([FromForm] PropertyDto propertyDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                return BadRequest(errors);
            }
             await _propertyService.AddProperty(propertyDto);
            return Ok();
        }



        [HttpPut]
        public async Task<IActionResult> UpdateProperty([FromForm] UpdatePropertyDto updatePropertyDto)
        {
            var property = await _propertyService.UpdateProperty(updatePropertyDto);
            return Ok(property);
        }



    }

}
