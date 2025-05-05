using TodoAPI.BusinessLayer.Interfaces.Repositories;
using TodoAPI.DataLayer.Entities;
using TodoAPI.DataLayer;
using Microsoft.EntityFrameworkCore;

namespace TodoAPI.BusinessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity?> GetByPublicIdAsync(Guid publicId) =>
            await _context.Users.FirstOrDefaultAsync(u => u.UserPublicId == publicId);

        public async Task<IEnumerable<UserEntity>> GetAllAsync() =>
            await _context.Users.AsNoTracking().ToListAsync();

        public async Task AddAsync(UserEntity user) =>
            await _context.Users.AddAsync(user);

        public Task RemoveAsync(UserEntity user)
        {
            _context.Users.Remove(user);
            return Task.CompletedTask;
        }
    }
}
