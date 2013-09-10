using System;
using System.Linq;
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
			var log = new Log();
			var clock = new StaticClock();
			var repository = new RecipeRepositoryUsingDependencyInjection(log, clock);

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();

			log.Get().Should().HaveCount(1);
		}

		[TestMethod]
		public void LogsTimeOnInvalidGet()
		{
			var log = new Log();
			var clock = new StaticClock();
			var repository = new RecipeRepositoryUsingDependencyInjection(log, clock);

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();

			log.Get().First().Time.Should().Be(clock.Now);
		}

		[TestMethod]
		public void LogsInvalidGetWithMock()
		{
			var log = new Mock<ILog>();
			log.Setup(l => l.Error(It.IsAny<DateTime>(), It.IsAny<string>()));
			var clock = new Mock<IClock>();

			var repository = new RecipeRepositoryUsingDependencyInjection(log.Object, clock.Object);

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();

			log.Verify(l => l.Error(It.IsAny<DateTime>(), It.IsAny<string>()), Times.Exactly(1));			
		}

		[TestMethod]
		public void ThrowsOnInvalidGet()
		{
			var fixture = new Fixture().Customize(new AutoMoqCustomization());
			var repository = fixture.Create<RecipeRepositoryUsingDependencyInjection>();

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();
		}

	}
}