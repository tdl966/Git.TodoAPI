using Microsoft.AspNetCore.Mvc;
using TodoAPI.BusinessLayer.DTOs;
using TodoAPI.BusinessLayer.Interfaces.Services;
using TodoAPI.Common.Models.User;

namespace TodoAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        /// <summary>
        /// Get user by publicId
        /// </summary>
        [HttpGet("Get{publicId:guid}")]
        public async Task<ActionResult<UserDto>> GetByPublicId(Guid publicId)
        {
            var user = await _userService.GetByPublicIdAsync(publicId);
            
            if (user is null)
            {
                return NotFound();
            }
                
            return Ok(user);
        }

        /// <summary>
        /// Create new user
        /// </summary>
        [HttpPost("Create")]
        public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserModel req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                
            var userDto = await _userService.CreateAsync(req.Username, req.Email);
            
            return CreatedAtAction(nameof(GetByPublicId), new { publicId = userDto.PublicId }, userDto);
        }

        /// <summary>
        /// Update user
        /// </summary>
        [HttpPut("Update{publicId:guid}")]
        public async Task<ActionResult<UserDto>> Update(Guid publicId, [FromBody] UpdateUserModel req)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updated = await _userService.UpdateAsync(publicId, req.Username, req.Email);
                return Ok(updated);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Remove user
        /// </summary>
        [HttpDelete("Delete{publicId:guid}")]
        public async Task<IActionResult> Delete(Guid publicId)
        {
            try
            {
                await _userService.DeleteAsync(publicId);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
