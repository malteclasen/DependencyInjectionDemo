using System;
using System.Linq;
using DependencyInjectionDemo.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyInjectionDemo.Tests
{
	[TestClass]
	public class AbstractFactoryTest
	{
		[TestMethod]
		public void LogsInvalidGet()
		{
			ILogFactory logFactory = new LogFactory();
			IClockFactory clockFactory = new StaticClockFactory();
			var repository = new RecipeRepositoryUsingAbstractFactory(logFactory, clockFactory);

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();

			repository.Log.Get().Should().HaveCount(1);
		}

		[TestMethod]
		public void LogsTimeOnInvalidGet()
		{
			ILogFactory logFactory = new LogFactory();
			IClockFactory clockFactory = new StaticClockFactory();
			var repository = new RecipeRepositoryUsingAbstractFactory(logFactory, clockFactory);
			var referenceTime = repository.Clock.Now;

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();

			repository.Log.Get().First().Time.Should().Be(referenceTime);
		}	
	}
}