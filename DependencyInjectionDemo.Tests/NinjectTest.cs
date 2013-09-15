using System;
using DependencyInjectionDemo.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace DependencyInjectionDemo.Tests
{
	[TestClass]
	public class NinjectTest
	{
		[TestMethod]
		public void LogsInvalidGet()
		{
			var kernel = new StandardKernel();
			kernel.Bind<IClock>().To<StaticClock>();
			kernel.Bind<ILog>().To<Log>().InSingletonScope();
			kernel.Bind<IRecipeRepository>().To<RecipeRepositoryUsingDependencyInjection>();

			var log = kernel.Get<ILog>();
			var repository = kernel.Get<IRecipeRepository>();

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();

			log.Get().Should().HaveCount(1);
		}
		
	}
}