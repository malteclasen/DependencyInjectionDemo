using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionDemo.Core;

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
			//todo: use dependency injection			
			var log = new Log();
			var clock = new SystemClock();
			var repository = new RecipeRepositoryUsingDependencyInjection(log, clock);
			
			var recipeCounter = new RecipeCounter(clock, repository);
			recipeCounter.Write();
		}
	}
}
