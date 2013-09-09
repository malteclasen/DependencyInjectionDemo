using System;
using DependencyInjectionDemo.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace DependencyInjectionDemo.Tests
{
	[TestClass]
	public class DependencyInjectionTest
	{
		[TestMethod]
		public void LogsInvalidGet()
		{
			var log = new VolatileLog();
			var repository = new VolatileRecipeRepositoryUsingDependencyInjection(log);

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();

			log.Get().Should().HaveCount(1);
		}

		[TestMethod]
		public void LogsInvalidGetWithMock()
		{
			var log = new Mock<ILog>();
			log.Setup(l => l.Error(It.IsAny<string>()));

			var repository = new VolatileRecipeRepositoryUsingDependencyInjection(log.Object);

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();

			log.Verify(l => l.Error(It.IsAny<string>()), Times.Exactly(1));			
		}

		[TestMethod]
		public void ThrowsOnInvalidGet()
		{
			var fixture = new Fixture().Customize(new AutoMoqCustomization());
			var repository = fixture.Create<VolatileRecipeRepositoryUsingDependencyInjection>();

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();
		}

	}
}