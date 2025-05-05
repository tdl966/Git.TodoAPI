using Microsoft.AspNetCore.Mvc;
using TodoAPI.BusinessLayer.Interfaces.Services;
using TodoAPI.Common.Models.Todo;
using TodoAPI.BusinessLayer.DTOs;

namespace TodoAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        /// <summary>
        /// Get all TODO items
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetAll()
        {
            var list = await _todoService.GetAllAsync();
            return Ok(list);
        }

        /// <summary>
        /// Get TODO item by publicId
        /// </summary>
        [HttpGet("Get{publicId:guid}")]
        public async Task<ActionResult<TodoItemDto>> GetByPublicId(Guid publicId)
        {
            var todoItemDto = await _todoService.GetByPublicIdAsync(publicId);
            
            if (todoItemDto is null) 
            {
                return NotFound();
            }
              
            return Ok(todoItemDto);
        }

        /// <summary>
        /// Create new TODO item
        /// </summary>
        [HttpPost("Create")]
        public async Task<ActionResult<TodoItemDto>> Create([FromBody] CreateTodoItemModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                
            var todoItemDto = await _todoService.CreateAsync(model.Title, model.CategoryPublicId, model.UserPublicId);
            return CreatedAtAction(nameof(GetByPublicId), new { publicId = todoItemDto.PublicId }, todoItemDto);
        }
         
        /// <summary>
        /// Update TODO item
        /// </summary>
        [HttpPut("Update{publicId:guid}")]
        public async Task<ActionResult<TodoItemDto>> Update(Guid publicId, [FromBody] UpdateTodoItemModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }           

            try
            {
                var updated = await _todoService.UpdateAsync(publicId, model.Title, model.IsCompleted);
                return Ok(updated);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Remove TODO item
        /// </summary>
        [HttpDelete("Delete{publicId:guid}")]
        public async Task<IActionResult> Delete(Guid publicId)
        {
            try
            {
                await _todoService.DeleteAsync(publicId);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
