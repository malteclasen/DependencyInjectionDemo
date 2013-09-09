using System;
using DependencyInjectionDemo.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyInjectionDemo.Tests
{
	[TestClass]
	public class FactoryTest
	{
		[TestMethod]
		public void LogsInvalidGet()
		{
			var repository = new VolatileRecipeRepositoryUsingFactory();

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();

			repository.Log.Get().Should().HaveCount(1);
		}
	}
}