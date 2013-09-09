using System;
using System.Collections.Generic;

namespace DependencyInjectionDemo.Core
{
	public class VolatileRecipeRepositoryUsingNew : IRecipeRepository
	{
		private readonly Dictionary<Guid, Recipe> _recipes = new Dictionary<Guid, Recipe>();
		public ILog Log { get; private set; }

		public VolatileRecipeRepositoryUsingNew()
		{
			Log = new VolatileLog();
		}

		public Recipe Get(Guid id)
		{
			Recipe result;
			if (!_recipes.TryGetValue(id, out result))
			{
				Log.Error("id not found");
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