namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IRecipeRepository Recipe {get;}
        void Save();
    }
}