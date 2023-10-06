using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Property;
using Services.Interfaces;

namespace RMSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        public PropertyController( IPropertyService propertyService)
        {
            _propertyService = propertyService; 
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var property = await _propertyService.GetPropertyById(Id);
            return Ok(property);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProperty(PropertyDto model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                return BadRequest(errors);
            }
            model = await _propertyService.AddProperty(model);
            return CreatedAtAction(nameof(GetById), new { id = model.PropertyId }, model);
        }
    }
}
