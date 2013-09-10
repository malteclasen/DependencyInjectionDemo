using System;
using System.Collections.Generic;

namespace DependencyInjectionDemo.Core
{
	public class RecipeRepositoryUsingAbstractFactory : IRecipeRepository
	{
		private readonly Dictionary<Guid, Recipe> _recipes = new Dictionary<Guid, Recipe>();
		public ILog Log { get; private set; }
		public IClock Clock { get; private set; }

		public RecipeRepositoryUsingAbstractFactory(ILogFactory logFactory, IClockFactory clockFactory)
		{
			Log = logFactory.Get();
			Clock = clockFactory.Get();
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