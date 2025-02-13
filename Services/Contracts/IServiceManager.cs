namespace Services.Contracts
{
    public interface IServiceManager
    {
        IRecipeService RecipeService { get; }
        ICategoryService CategoryService { get; }
        IAuthenticationService AuthenticationService { get; }
        IIngredientService IngredientService { get; }
        IS3Service S3Service { get; }
    }
}