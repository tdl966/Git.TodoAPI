using Microsoft.EntityFrameworkCore;
using TodoAPI.BusinessLayer.Interfaces.Managers;
using TodoAPI.BusinessLayer.Interfaces.Repositories;
using TodoAPI.DataLayer;

namespace TodoAPI.BusinessLayer.Managers
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _context;
        public IUserRepository Users { get; }
        public ICategoryRepository Categories { get; }
        public ITodoRepository Todos { get; }

        public RepositoryManager(AppDbContext context, IUserRepository users, ICategoryRepository categories, ITodoRepository todos)
        {
            _context = context;
            Users = users;
            Categories = categories;
            Todos = todos;
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Chyba pri ukladaní zmien do DB.", ex);
            }
        }
    }
}
