using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.BusinessLayer.DTOs;

namespace TodoAPI.BusinessLayer.Interfaces.Services
{
    public interface ICategoryService
    {
        /// <summary>
        /// Create new category 
        /// </summary>
        /// <param name="username"></param>
        /// <returns>
        /// New <see cref="CategoryDto"/>.
        /// </returns>
        Task<CategoryDto> CreateAsync(string name);

        /// <summary>
        /// Get a category by public id
        /// </summary>
        /// <param name="publicId"></param>
        /// <returns>
        /// <see cref="CategoryDto"/>, or <c>null</c>, if no category with specific public id exists.
        /// </returns>
        Task<CategoryDto?> GetByPublicIdAsync(Guid publicId);

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>
        /// A collection of all <see cref="CategoryDto"/>.
        /// </returns>
        Task<IEnumerable<CategoryDto>> GetAllAsync();

        /// <summary>
        /// Update category
        /// </summary>
        /// <param name="publicId"></param>
        /// <param name="newName"></param>
        /// <returns>
        /// Updated <see cref="CategoryDto"/>
        /// </returns>
        Task<CategoryDto> UpdateAsync(Guid publicId, string newName);

        /// <summary>
        /// Remove category by public id
        /// </summary>
        /// <param name="publicId"></param>
        Task DeleteAsync(Guid publicId);
    }
}
