using System;
using System.Collections.Generic;

namespace DependencyInjectionDemo.Core
{
	public class RecipeRepositoryUsingFactory : IRecipeRepository
	{
		private readonly Dictionary<Guid, Recipe> _recipes = new Dictionary<Guid, Recipe>();
		public ILog Log { get; private set; }
		public IClock Clock { get; private set; }

		public RecipeRepositoryUsingFactory()
		{
			var logFactory = new LogFactory();
			Log = logFactory.Get();

			var clockFactory = new ClockFactory();
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

		public long Count { get { return _recipes.Count; } }
	}
}