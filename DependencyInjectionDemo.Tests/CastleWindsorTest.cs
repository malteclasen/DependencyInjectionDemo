using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DependencyInjectionDemo.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyInjectionDemo.Tests
{
	[TestClass]
	public class CastleWindsorTest
	{
		[TestMethod]
		public void LogsInvalidGet()
		{
			var container = new WindsorContainer();
			container.Register(Component.For<ILog>().ImplementedBy<Log>().LifestyleSingleton());
			container.Register(Component.For<IClock>().ImplementedBy<StaticClock>());
			container.Register(Component.For<IRecipeRepository>().ImplementedBy<RecipeRepositoryUsingDependencyInjection>().LifestyleTransient());

			var log = container.Resolve<ILog>();
			var repository = container.Resolve<IRecipeRepository>();

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();

			log.Get().Should().HaveCount(1);
		}

	}
}