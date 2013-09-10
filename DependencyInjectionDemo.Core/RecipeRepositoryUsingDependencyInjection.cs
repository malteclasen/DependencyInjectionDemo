using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.Core
{
	public class RecipeRepositoryUsingDependencyInjection : IRecipeRepository
	{
		private readonly Dictionary<Guid, Recipe> _recipes = new Dictionary<Guid, Recipe>();
		private readonly ILog _log;
		private readonly IClock _clock;

		public RecipeRepositoryUsingDependencyInjection(ILog log, IClock clock)
		{
			_log = log;
			_clock = clock;
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
	}
}
