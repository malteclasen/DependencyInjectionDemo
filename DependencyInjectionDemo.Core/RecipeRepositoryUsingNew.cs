using System;
using System.Collections.Generic;

namespace DependencyInjectionDemo.Core
{
	public class RecipeRepositoryUsingNew : IRecipeRepository
	{
		private readonly Dictionary<Guid, Recipe> _recipes = new Dictionary<Guid, Recipe>();
		public IClock Clock { get; private set; }
		public ILog Log { get; private set; }

		public RecipeRepositoryUsingNew()
		{
			Clock = new SystemClock();
			Log = new Log();
		}

		public Recipe Get(Guid id)
		{
			Recipe result;
			if (!_recipes.TryGetValue(id, out result))
			{
				Log.Error(Clock.Now, "id not found");
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