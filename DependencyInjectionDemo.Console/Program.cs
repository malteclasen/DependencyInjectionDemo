using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionDemo.Core;
using Ninject;

namespace DependencyInjectionDemo.Console
{
	class RecipeCounter
	{
		private readonly SystemClock _clock;
		private readonly RecipeRepositoryUsingDependencyInjection _repository;

		public RecipeCounter(SystemClock clock, RecipeRepositoryUsingDependencyInjection repository)
		{
			_clock = clock;
			_repository = repository;
		}

		public void Write()
		{
			System.Console.WriteLine("There are {0} recipes available at {1}.", _repository.Count, _clock.Now.ToLongTimeString());
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var kernel = new StandardKernel();
			kernel.Bind<IClock>().To<SystemClock>();
			kernel.Bind<ILog>().To<Log>();
			kernel.Bind<IRecipeRepository>().To<RecipeRepositoryUsingDependencyInjection>();

			var recipeCounter = kernel.Get<RecipeCounter>();
			recipeCounter.Write();
		}
	}
}
