using LoginAPI.Models;
using LoginAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryAPIController : ControllerBase
    {
        private readonly ICategoryAPI _ICategoryApi;

        public CategoryAPIController(ICategoryAPI ICategoryApi)
        {
            _ICategoryApi = ICategoryApi;
        }

        [HttpPost("CreateCategory")]
        public async Task<ActionResult<string>> CreateCategory(Category category)
        {
            var result= await _ICategoryApi.CreateCategory(category);
            if(result is not null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetCategory")]
        public async Task<ActionResult<List<Category>>> GetCategory()
        {
            var result=await _ICategoryApi.GetCategory();
            if (result is not null)
            {
                return Ok(result.Value);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
