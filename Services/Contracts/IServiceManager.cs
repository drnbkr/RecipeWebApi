namespace Services.Contracts
{
    public interface IServiceManager
    {
        IRecipeService RecipeService { get; }
    }
}