using System;
using DependencyInjectionDemo.Core;
using FluentAssertions;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyInjectionDemo.Tests
{
	[TestClass]
	public class UnityTest
	{
		[TestMethod]
		public void LogsInvalidGet()
		{
			var container = new UnityContainer();
			container
				.RegisterType<ILog, Log>(new ContainerControlledLifetimeManager())
				.RegisterType<IClock, StaticClock>()
				.RegisterType<IRecipeRepository, RecipeRepositoryUsingDependencyInjection>();

			var log = container.Resolve<ILog>();
			var repository = container.Resolve<IRecipeRepository>();

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();

			log.Get().Should().HaveCount(1);
		}

	}
}