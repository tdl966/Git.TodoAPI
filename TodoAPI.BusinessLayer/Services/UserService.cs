using AutoMapper;
using TodoAPI.BusinessLayer.DTOs;
using TodoAPI.BusinessLayer.Interfaces.Managers;
using TodoAPI.BusinessLayer.Interfaces.Services;
using TodoAPI.DataLayer.Entities;

namespace TodoAPI.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateAsync(string username, string email)
        {
            var user = new UserEntity()
            {
                Email = email,
                Username = username,
                UserPublicId = Guid.NewGuid()
            };

            await _repository.Users.AddAsync(user);
            await _repository.SaveAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto?> GetByPublicIdAsync(Guid userPublicId)
        {
            var userEntity = await _repository.Users.GetByPublicIdAsync(userPublicId);

            return userEntity is null ? null : _mapper.Map<UserDto>(userEntity);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var userCollection = await _repository.Users.GetAllAsync();

            return _mapper.Map<IEnumerable<UserDto>>(userCollection);
        }

        public async Task<UserDto> UpdateAsync(Guid publicId, string newUsername, string newEmail)
        {
            var userEntity = await _repository.Users.GetByPublicIdAsync(publicId) ?? throw new KeyNotFoundException($"User {publicId} not found");

            userEntity.Email = newEmail;
            userEntity.Username = newUsername;

            await _repository.SaveAsync();
                
            return _mapper.Map<UserDto>(userEntity);
        }

        public async Task DeleteAsync(Guid publicId)
        {
            var userEntity = await _repository.Users.GetByPublicIdAsync(publicId) ?? throw new KeyNotFoundException($"User {publicId} not found");
            
            await _repository.Users.RemoveAsync(userEntity);
            await _repository.SaveAsync();
        }
    }
}