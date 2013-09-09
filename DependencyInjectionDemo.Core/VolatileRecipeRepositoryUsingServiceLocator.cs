using System;
using System.Collections.Generic;

namespace DependencyInjectionDemo.Core
{
	public class VolatileRecipeRepositoryUsingServiceLocator : IRecipeRepository
	{
		private readonly Dictionary<Guid, Recipe> _recipes = new Dictionary<Guid, Recipe>();
		private readonly ILog _log;

		public VolatileRecipeRepositoryUsingServiceLocator()
		{
				_log = ServiceLocator.Log;
		}

		public Recipe Get(Guid id)
		{
			Recipe result;
			if (!_recipes.TryGetValue(id, out result))
			{
				_log.Error("id not found");
				throw new ArgumentException("id not found");
			}
			return result;
		}

		public void Put(Recipe recipe)
		{
			_recipes[recipe.Id] = recipe;
		}		
	}
}