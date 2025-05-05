using TodoAPI.BusinessLayer.DTOs;
using TodoAPI.DataLayer.Entities;
using TodoAPI.BusinessLayer.Interfaces.Services;
using TodoAPI.BusinessLayer.Interfaces.Managers;
using AutoMapper;

namespace TodoAPI.BusinessLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CategoryService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateAsync(string name)
        {
            var categoryEntity = new CategoryEntity
            {
                CategoryPublicId = Guid.NewGuid(),
                Name = name
            };

            await _repository.Categories.AddAsync(categoryEntity);
            await _repository.SaveAsync();

            return _mapper.Map<CategoryDto>(categoryEntity);
        }

        public async Task<CategoryDto?> GetByPublicIdAsync(Guid publicId)
        {
            var categoryEntity = await _repository.Categories.GetByPublicIdAsync(publicId);
            
            return categoryEntity is null ? null : _mapper.Map<CategoryDto>(categoryEntity);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categoryEntityCollection = await _repository.Categories.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoryDto>>(categoryEntityCollection);
        }

        public async Task<CategoryDto> UpdateAsync(Guid publicId, string newName)
        {
            var categoryEntity = await _repository.Categories.GetByPublicIdAsync(publicId) ?? throw new KeyNotFoundException($"Category {publicId} not found");

            categoryEntity.Name = newName;

            await _repository.SaveAsync();

            return new CategoryDto(categoryEntity.CategoryPublicId, categoryEntity.Name);
        }

        public async Task DeleteAsync(Guid publicId)
        {
            var categoryEntity = await _repository.Categories.GetByPublicIdAsync(publicId) ?? throw new KeyNotFoundException($"Category {publicId} not found");

            await _repository.Categories.RemoveAsync(categoryEntity);
            await _repository.SaveAsync();
        }
    }
}
