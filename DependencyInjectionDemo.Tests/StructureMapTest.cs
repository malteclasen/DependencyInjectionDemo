using System;
using DependencyInjectionDemo.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace DependencyInjectionDemo.Tests
{
	[TestClass]
	public class StructureMapTest
	{
		[TestMethod]
		public void LogsInvalidGet()
		{
			var container = new Container(x =>
			{
				x.For<ILog>().Singleton().Use<Log>();
				x.For<IClock>().Use<StaticClock>();
				x.For<IRecipeRepository>().Use<RecipeRepositoryUsingDependencyInjection>();
			});

			var log = container.GetInstance<ILog>();
			var repository = container.GetInstance<IRecipeRepository>();

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();

			log.Get().Should().HaveCount(1);
		}

	}
}