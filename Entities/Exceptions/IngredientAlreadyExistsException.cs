namespace Entities.Exceptions
{
    public sealed class IngredientAlreadyExistsException : Exception
    {
        public IngredientAlreadyExistsException(string name)
            : base($"An ingredient with the name '{name}' already exists.")
        {
        }
    }
}