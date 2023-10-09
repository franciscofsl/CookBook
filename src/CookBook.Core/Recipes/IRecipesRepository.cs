﻿using CookBook.Core.Recipes.ValueObjects;
using Sawnet.Core.Contracts;

namespace CookBook.Core.Recipes;

public interface IRecipesRepository : IRepository<Recipe, RecipeId>
{

}
