using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class IngredientNotFoundException : NotFoundException
    {
        public IngredientNotFoundException(int id) : base($"The ingredient with id: {id} could not found.")
        {
        }
    }
}