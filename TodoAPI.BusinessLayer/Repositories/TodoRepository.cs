using TodoAPI.BusinessLayer.Interfaces.Repositories;
using TodoAPI.DataLayer.Entities;
using TodoAPI.DataLayer;
using Microsoft.EntityFrameworkCore;

namespace TodoAPI.BusinessLayer.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;

        public TodoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TodoItemEntity?> GetByPublicIdAsync(Guid publicId) =>
            await _context.TodoItems.FirstOrDefaultAsync(t => t.TodoItemPublicId == publicId);

        public async Task<IEnumerable<TodoItemEntity>> GetAllAsync() =>
            await _context.TodoItems.AsNoTracking().ToListAsync();

        public async Task AddAsync(TodoItemEntity item) =>
            await _context.TodoItems.AddAsync(item);

        public Task RemoveAsync(TodoItemEntity item)
        {
            _context.TodoItems.Remove(item);
            return Task.CompletedTask;
        }
    }
}