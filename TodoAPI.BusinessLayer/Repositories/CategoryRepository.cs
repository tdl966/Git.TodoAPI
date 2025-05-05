using TodoAPI.BusinessLayer.Interfaces.Repositories;
using TodoAPI.DataLayer.Entities;
using TodoAPI.DataLayer;
using Microsoft.EntityFrameworkCore;

namespace TodoAPI.BusinessLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<CategoryEntity?> GetByPublicIdAsync(Guid publicId) =>
            await _context.Categories.FirstOrDefaultAsync(c => c.CategoryPublicId == publicId);

        public async Task<IEnumerable<CategoryEntity>> GetAllAsync() =>
            await _context.Categories.AsNoTracking().ToListAsync();

        public async Task AddAsync(CategoryEntity category) =>
            await _context.Categories.AddAsync(category);

        public Task RemoveAsync(CategoryEntity category)
        {
            _context.Categories.Remove(category);
            return Task.CompletedTask;
        }
    }
}
