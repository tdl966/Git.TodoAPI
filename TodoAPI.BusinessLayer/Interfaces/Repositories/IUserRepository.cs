using TodoAPI.DataLayer.Entities;

namespace TodoAPI.BusinessLayer.Interfaces.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get user entity by public id
        /// </summary>
        /// <param name="publicId"></param>
        /// <returns>
        /// Entity <see cref="UserEntity"/>, or <c>null</c>, if no userEntity with specific public id exists.
        /// </returns>
        Task<UserEntity?> GetByPublicIdAsync(Guid publicId);

        /// <summary>
        /// Get all category entities
        /// </summary>
        /// <returns>
        /// A collection of all <see cref="UserEntity"/>.
        /// </returns>
        Task<IEnumerable<UserEntity>> GetAllAsync();

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="userEntity"></param>
        Task AddAsync(UserEntity userEntity);

        /// <summary>
        /// Remove user
        /// </summary>
        /// <param name="userEntity"></param>
        Task RemoveAsync(UserEntity userEntity);
    }
}
