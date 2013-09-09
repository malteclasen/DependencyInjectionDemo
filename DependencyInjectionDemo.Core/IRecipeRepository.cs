using System;

namespace DependencyInjectionDemo.Core
{
	public interface IRecipeRepository
	{
		Recipe Get(Guid id);
		void Put(Recipe recipe);
	}
}