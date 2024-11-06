namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IRecipeRepository Recipe { get; }
        ICategoryRepository Category { get; }
        Task SaveAsync();
    }
}