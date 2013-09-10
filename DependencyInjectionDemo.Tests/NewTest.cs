using System;
using System.Linq;
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
			var repository = new RecipeRepositoryUsingNew();

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();
		}

		[TestMethod]
		public void LogsInvalidGet()
		{
			var repository = new RecipeRepositoryUsingNew();

			repository.Invoking(r=>r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();
	
			repository.Log.Get().Should().HaveCount(1);
		}

		[TestMethod]
		public void LogsTimeOnInvalidGet()
		{
			var repository = new RecipeRepositoryUsingNew();

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();

			var entry = repository.Log.Get().First();
			Math.Abs((entry.Time - DateTime.Now).TotalSeconds).Should().BeLessThan(1);
		}	
	}
}
