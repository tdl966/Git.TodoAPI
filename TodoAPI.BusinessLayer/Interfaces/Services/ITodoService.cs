using TodoAPI.BusinessLayer.DTOs;

namespace TodoAPI.BusinessLayer.Interfaces.Services
{
    public interface ITodoService
    {
        /// <summary>
        /// Create new todo item 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <returns>
        /// New <see cref="TodoItemDto"/>.
        /// </returns>
        Task<TodoItemDto> CreateAsync(string title, Guid categoryPublicId, Guid userPublicId);

        /// <summary>
        /// Get a user by public id
        /// </summary>
        /// <param name="publicId"></param>
        /// <returns>
        /// <see cref="TodoItemDto"/>, or <c>null</c>, if no item with specific public id exists.
        /// </returns>
        Task<TodoItemDto?> GetByPublicIdAsync(Guid publicId);

        /// <summary>
        /// Get all toto items
        /// </summary>
        /// <returns>
        /// A collection of all <see cref="TodoItemDto"/>.
        /// <returns>
        /// Updated <see cref="TodoItemDto"/>
        /// </returns>
        Task<IEnumerable<TodoItemDto>> GetAllAsync();

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="publicId"></param>
        /// <param name="newTitle"></param>
        /// <param name="isCompleted"></param>
        /// <returns>
        /// Updated <see cref="TodoItemDto"/>
        /// </returns>
        Task<TodoItemDto> UpdateAsync(Guid publicId, string newTitle, bool? isCompleted = null);

        /// <summary>
        /// Remove todo item by public id
        /// </summary>
        /// <param name="publicId"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid publicId);
    }
}
