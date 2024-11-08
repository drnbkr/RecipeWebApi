namespace Services.Contracts
{
    public interface IServiceManager
    {
        IRecipeService RecipeService { get; }
        ICategoryService CategoryService { get; }
        IAuthenticationService AuthenticationService { get; }
        IIngredientService IngredientService { get; }
    }
}