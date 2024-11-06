
using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace RecipeWebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RecipeDtoForUpdate, Recipe>().ReverseMap();
            CreateMap<Recipe, RecipeDto>();
            CreateMap<RecipeDtoForInsertion, Recipe>();
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDtoForInsertion, Category>();
        }
    }
}