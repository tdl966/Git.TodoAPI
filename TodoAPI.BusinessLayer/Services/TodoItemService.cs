using TodoAPI.BusinessLayer.DTOs;
using TodoAPI.DataLayer.Entities;
using TodoAPI.BusinessLayer.Interfaces.Services;
using TodoAPI.BusinessLayer.Interfaces.Managers;
using AutoMapper;

namespace TodoAPI.BusinessLayer.Services
{
    public class TodoService : ITodoService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public TodoService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TodoItemDto> CreateAsync(string title, Guid categoryPublicId, Guid userPublicId)
        {
            var userEntity = await _repository.Users.GetByPublicIdAsync(userPublicId) ?? throw new KeyNotFoundException($"User {userPublicId} not found");
            var categoryEntity = await _repository.Categories.GetByPublicIdAsync(categoryPublicId) ?? throw new KeyNotFoundException($"Category {categoryPublicId} not found");

            var item = new TodoItemEntity
            {
                TodoItemPublicId = Guid.NewGuid(),
                Title = title,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow,
                CategoryId = categoryEntity.CategoryId,
                UserId = userEntity.UserId   
            };

            await _repository.Todos.AddAsync(item);
            await _repository.SaveAsync();

            return _mapper.Map<TodoItemDto>(item);
        }

        public async Task<TodoItemDto?> GetByPublicIdAsync(Guid publicId)
        {
            var todoItemEntity = await _repository.Todos.GetByPublicIdAsync(publicId);

            return todoItemEntity is null ? null : _mapper.Map<TodoItemDto>(todoItemEntity);
        }

        public async Task<IEnumerable<TodoItemDto>> GetAllAsync()
        {
            var todoCollection = await _repository.Todos.GetAllAsync();
            
            return _mapper.Map<IEnumerable<TodoItemDto>>(todoCollection);
        }

        public async Task<TodoItemDto> UpdateAsync(Guid publicId, string newTitle, bool? isCompleted = null)
        {
            var todoItem = await _repository.Todos.GetByPublicIdAsync(publicId) ?? throw new KeyNotFoundException($"Todo item {publicId} not found");

            todoItem.Title = newTitle;  

            if (isCompleted == true)
            {
                todoItem.IsCompleted = true;
            }

            await _repository.SaveAsync();

            var reload = await GetByPublicIdAsync(publicId);

            return reload!;
        }

        public async Task DeleteAsync(Guid publicId)
        {
            var todoItem = await _repository.Todos.GetByPublicIdAsync(publicId) ?? throw new KeyNotFoundException($"Todo item {publicId} not found");

            await _repository.Todos.RemoveAsync(todoItem);
            await _repository.SaveAsync();
        }
    }
}