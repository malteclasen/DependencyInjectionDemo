using System;
using DependencyInjectionDemo.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyInjectionDemo.Tests
{
	[TestClass]
	public class NewTest
	{
		[TestMethod]
		public void ThrowsOnInvalidGet()
		{
			var repository = new VolatileRecipeRepositoryUsingNew();

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();
		}

		[TestMethod]
		public void LogsInvalidGet()
		{
			var repository = new VolatileRecipeRepositoryUsingNew();

			repository.Invoking(r=>r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();
	
			repository.Log.Get().Should().HaveCount(1);
		}
	}
}
