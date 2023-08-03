using Microsoft.AspNetCore.Mvc;
using PosVentas.Application.Dtos.Request;
using PosVentas.Application.Interfaces;
using PosVentas.Infrastructure.Commons.Bases.Request;

namespace PosVentas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryApplication _categoryApplication;

        public CategoryController(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }
        [HttpPost]
        public async Task<IActionResult> ListCategories([FromBody] BaseFiltersRequest filters)
        {
            var response = await _categoryApplication.ListCategories(filters);
            return Ok(response);
        }
        [HttpGet("select")]

        public async Task<IActionResult> ListSelectCategories()
        {
            var response = await _categoryApplication.ListSelectCategories();
            return Ok(response);
        }
        [HttpGet("{categoryId:int}")]

        public async Task<IActionResult>CategoryById(int categoryId)
        {
            var response = await _categoryApplication.CategoryById(categoryId);

            return Ok(response);
        }
        [HttpPost("Register")]

        public async Task<IActionResult> RegisterCategory([FromBody] CategoryRequestDto requestDto)
        {
            var response=_categoryApplication.registerCategory(requestDto);
            return Ok(response);
        }
        [HttpPut("Edit/{categoryId:int}")]

        public async Task<IActionResult> EditCategory(int categoryId,[FromBody] CategoryRequestDto requestDto)
        {
            var response = _categoryApplication.EditCategory(categoryId,requestDto);
            return Ok(response);
        }
        [HttpPut("Remove/{categoryId:int}")]

        public async Task<IActionResult> RenoveCategory(int categoryId)
        {
            var response = _categoryApplication.RemoveCategory(categoryId);
            return Ok(response);
        }


    }
}
