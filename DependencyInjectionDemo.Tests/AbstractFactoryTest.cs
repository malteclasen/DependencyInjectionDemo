using System;
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
			ILogFactory logFactory = new VolatileLogFactory();
			var repository = new VolatileRecipeRepositoryUsingAbstractFactory(logFactory);

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();

			repository.Log.Get().Should().HaveCount(1);
		}
	}
}