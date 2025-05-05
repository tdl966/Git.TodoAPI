using TodoAPI.DataLayer.Entities;

namespace TodoAPI.BusinessLayer.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Get category by public id
        /// </summary>
        /// <param name="publicId"></param>
        /// <returns>
        /// Entity <see cref="CategoryEntity"/>, or <c>null</c>, if no category with specific public id exists.
        /// </returns>
        Task<CategoryEntity?> GetByPublicIdAsync(Guid publicId);

        /// <summary>
        /// Get all category entities
        /// </summary>
        /// <returns>
        /// A collection of all <see cref="CategoryEntity"/>.
        /// </returns>
        Task<IEnumerable<CategoryEntity>> GetAllAsync();

        /// <summary>
        /// Add new category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task AddAsync(CategoryEntity category);

        /// <summary>
        /// Remove category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task RemoveAsync(CategoryEntity category);
    }
}
