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
			ServiceLocator.Log = new VolatileLog();
			var repository = new VolatileRecipeRepositoryUsingServiceLocator();

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();

			ServiceLocator.Log.Get().Should().HaveCount(1);
		}

		//[TestMethod]
		//public void LogsMultipleInvalidGets()
		//{
		//	var repository = new VolatileRecipeRepositoryUsingServiceLocator();

		//	repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();
		//	repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();

		//	ServiceLocator.Log.Get().Should().HaveCount(2);
		//}
	}


}