using System;
using System.Collections.Generic;

namespace DependencyInjectionDemo.Core
{
	public class RecipeRepositoryUsingServiceLocator : IRecipeRepository
	{
		private readonly Dictionary<Guid, Recipe> _recipes = new Dictionary<Guid, Recipe>();
		private readonly ILog _log;
		private readonly IClock _clock;

		public RecipeRepositoryUsingServiceLocator()
		{
			_log = ServiceLocator.Log;
			_clock = ServiceLocator.Clock;
		}

		public Recipe Get(Guid id)
		{
			Recipe result;
			if (!_recipes.TryGetValue(id, out result))
			{
				_log.Error(_clock.Now, "id not found");
				throw new ArgumentException("id not found");
			}
			return result;
		}

		public void Put(Recipe recipe)
		{
			_recipes[recipe.Id] = recipe;
		}

		public long Count { get { return _recipes.Count; } }
	}
}