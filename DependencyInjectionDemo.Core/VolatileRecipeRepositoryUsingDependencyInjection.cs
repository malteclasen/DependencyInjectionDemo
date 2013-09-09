using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.Core
{
	public class VolatileRecipeRepositoryUsingDependencyInjection : IRecipeRepository
	{
		private readonly Dictionary<Guid, Recipe> _recipes = new Dictionary<Guid, Recipe>();
		private readonly ILog _log;

		public VolatileRecipeRepositoryUsingDependencyInjection(ILog log)
		{
			_log = log;
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
