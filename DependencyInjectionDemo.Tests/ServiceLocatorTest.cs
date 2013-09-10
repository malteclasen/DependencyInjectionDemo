using System;
using DependencyInjectionDemo.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyInjectionDemo.Tests
{
	[TestClass]
	public class ServiceLocatorTest
	{
		[TestMethod]
		public void LogsInvalidGet()
		{
			ServiceLocator.Log = new Log();
			ServiceLocator.Clock = new StaticClock();
			var repository = new RecipeRepositoryUsingServiceLocator();

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();

			ServiceLocator.Log.Get().Should().HaveCount(1);
		}

		[TestMethod]
		public void LogsMultipleInvalidGets()
		{
			ServiceLocator.Log = new Log();
			var repository = new RecipeRepositoryUsingServiceLocator();

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();
			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();

			ServiceLocator.Log.Get().Should().HaveCount(2);
		}
	}


}