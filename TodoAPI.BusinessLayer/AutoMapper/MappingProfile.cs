using AutoMapper;
using TodoAPI.BusinessLayer.DTOs;
using TodoAPI.DataLayer.Entities;

namespace TodoAPI.Api.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryEntity, CategoryDto>()
                .ForCtorParam("PublicId", opt => opt.MapFrom(src => src.CategoryPublicId))
                .ForCtorParam("Name", opt => opt.MapFrom(src => src.Name));

            CreateMap<UserEntity, UserDto>()
                .ForCtorParam("PublicId", opt => opt.MapFrom(src => src.UserPublicId))
                .ForCtorParam("Username", opt => opt.MapFrom(src => src.Username))
                .ForCtorParam("Email", opt => opt.MapFrom(src => src.Email));

            CreateMap<TodoItemEntity, TodoItemDto>()
                .ForCtorParam("PublicId", opt => opt.MapFrom(src => src.TodoItemPublicId))
                .ForCtorParam("Title", opt => opt.MapFrom(src => src.Title))
                .ForCtorParam("IsCompleted", opt => opt.MapFrom(src => src.IsCompleted))
                .ForCtorParam("CreatedAt", opt => opt.MapFrom(src => src.CreatedAt))
                .ForCtorParam("CategoryPublicId", opt => opt.MapFrom(src => src.Category.CategoryPublicId))
                .ForCtorParam("UserPublicId", opt => opt.MapFrom(src => src.User.UserPublicId));
        }
    }
}
