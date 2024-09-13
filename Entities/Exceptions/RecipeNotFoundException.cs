namespace Entities.Exceptions
{
    public sealed class RecipeNotFoundException : NotFoundException
    {
        public RecipeNotFoundException(int id) : base($"The recipe with id: {id} could not found.")
        {
        }
    }
}