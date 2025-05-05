using Microsoft.AspNetCore.Mvc;
using TodoAPI.BusinessLayer.DTOs;
using TodoAPI.BusinessLayer.Interfaces.Services;
using TodoAPI.Common.Models.Category;

namespace TodoAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var cats = await _categoryService.GetAllAsync();
            return Ok(cats);
        }

        /// <summary>
        /// Get category by publicId
        /// </summary>
        [HttpGet("Get{publicId:guid}")]
        public async Task<ActionResult<CategoryDto>> GetByPublicId(Guid publicId)
        {
            var cat = await _categoryService.GetByPublicIdAsync(publicId);
            if (cat is null)
            {
                return NotFound();
            }          

            return Ok(cat);
        }

        /// <summary>
        /// Create new category
        /// </summary>
        [HttpPost("Create")]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] CreateCategoryModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dto = await _categoryService.CreateAsync(model.Name);
            return CreatedAtAction(nameof(GetByPublicId), new { publicId = dto.PublicId }, dto);
        }

        /// <summary>
        /// Update category
        /// </summary>
        [HttpPut("Update{publicId:guid}")]
        public async Task<ActionResult<CategoryDto>> Update(Guid publicId, [FromBody] UpdateCategoryModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updated = await _categoryService.UpdateAsync(publicId, model.Name);
                return Ok(updated);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Remove category
        /// </summary>
        [HttpDelete("Delete{publicId:guid}")]
        public async Task<IActionResult> Delete(Guid publicId)
        {
            try
            {
                await _categoryService.DeleteAsync(publicId);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
