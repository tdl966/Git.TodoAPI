using TodoAPI.BusinessLayer.DTOs;

namespace TodoAPI.BusinessLayer.Interfaces.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Create new user 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <returns>
        /// New <see cref="UserDto"/>.
        /// </returns>
        Task<UserDto> CreateAsync(string username, string email);

        /// <summary>
        /// Get a user by public id
        /// </summary>
        /// <param name="publicId"></param>
        /// <returns>
        /// <see cref="UserDto"/>, or <c>null</c>, if no user with specific public id exists.
        /// </returns>
        Task<UserDto?> GetByPublicIdAsync(Guid publicId);

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>
        /// A collection of all <see cref="UserDto"/>.
        /// </returns>
        Task<IEnumerable<UserDto>> GetAllAsync();

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="publicId"></param>
        /// <param name="newUsername"></param>
        /// <param name="newEmail"></param>
        /// <returns>
        /// Updated <see cref="UserDto"/>
        /// </returns>
        Task<UserDto> UpdateAsync(Guid publicId, string newUsername, string newEmail);

        /// <summary>
        /// Remove user by public id
        /// </summary>
        /// <param name="publicId"></param>
        Task DeleteAsync(Guid publicId);
    }
}
