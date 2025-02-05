
using AutoMapper;
using Entities.Dtos;
using Entities.Dtos.Category;
using Entities.Dtos.Ingredient;
using Entities.Dtos.Media;
using Entities.Dtos.Recipe;
using Entities.Dtos.RecipeIngredient;
using Entities.Dtos.RecipeInstruction;
using Entities.Models;

namespace RecipeWebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RecipeDtoForUpdate, Recipe>().ReverseMap();
            CreateMap<Recipe, RecipeDto>().ReverseMap();
            CreateMap<RecipeDtoForInsertion, Recipe>();
            CreateMap<RecipeIngredient, RecipeIngredientDto>().ReverseMap();
            CreateMap<RecipeIngredientDtoForManipulation, RecipeIngredient>().ReverseMap();
            CreateMap<RecipeInstruction, RecipeInstructionDto>().ReverseMap();
            CreateMap<Media, MediaDto>().ReverseMap();


            CreateMap<UserForRegistrationDto, User>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDtoForInsertion, Category>();

            CreateMap<Ingredient, IngredientDto>().ReverseMap();
            CreateMap<IngredientDtoForManipulation, Ingredient>();
            CreateMap<IngredientDtoForUpdate, Ingredient>();
        }
    }
}