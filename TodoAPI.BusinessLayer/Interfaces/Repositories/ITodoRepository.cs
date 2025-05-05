using TodoAPI.DataLayer.Entities;

namespace TodoAPI.BusinessLayer.Interfaces.Repositories
{
    public interface ITodoRepository
    {
        /// <summary>
        /// Get todo item entity by public id
        /// </summary>
        /// <param name="publicId"></param>
        /// <returns>
        /// Entity <see cref="TodoItemEntity"/>, or <c>null</c>, if no item with specific public id exists.
        /// </returns>
        Task<TodoItemEntity?> GetByPublicIdAsync(Guid publicId);

        /// <summary>
        /// Get all todo item entities
        /// </summary>
        /// <returns>
        /// A collection of all <see cref="TodoItemEntity"/>.
        /// </returns>
        Task<IEnumerable<TodoItemEntity>> GetAllAsync();
        
        /// <summary>
        /// Add new todo item
        /// </summary>
        /// <param name="item"></param>
        Task AddAsync(TodoItemEntity item);

        /// <summary>
        /// Remove todo item
        /// </summary>
        /// <param name="item"></param>
        Task RemoveAsync(TodoItemEntity item);
    }
}
