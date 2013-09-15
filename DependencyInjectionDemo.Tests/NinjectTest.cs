using System;
using DependencyInjectionDemo.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace DependencyInjectionDemo.Tests
{
	[TestClass]
	public class NinjectTest
	{
		[TestMethod]
		public void LogsInvalidGet()
		{
			var kernel = new StandardKernel();
			kernel.Bind<IClock>().To<StaticClock>();
			kernel.Bind<ILog>().To<Log>().InSingletonScope();
			kernel.Bind<IRecipeRepository>().To<RecipeRepositoryUsingDependencyInjection>();

			var log = kernel.Get<ILog>();
			var repository = kernel.Get<IRecipeRepository>();

			repository.Invoking(r => r.Get(Guid.NewGuid())).ShouldThrow<ArgumentException>();

			log.Get().Should().HaveCount(1);
		}
		
		private static class KernelLocator
		{
			public static IKernel Kernel { get; set; }
		}

		private class SelfInjectingClass
		{
			[Inject]
			public ILog Log { get; set; }

			public SelfInjectingClass()
			{
				KernelLocator.Kernel.Inject(this);
			}

			public SelfInjectingClass(ILog log)
			{
				Log = log;
			}
		}

		[TestMethod]
		public void Inject()
		{
			var kernel = new StandardKernel();
			kernel.Bind<ILog>().To<Log>().InSingletonScope();

			var selfInjectingClass = kernel.Get<SelfInjectingClass>();

			selfInjectingClass.Log.Should().NotBeNull();
		}

		[TestMethod]
		public void InjectThis()
		{
			var kernel = new StandardKernel();
			KernelLocator.Kernel = kernel;
			kernel.Bind<ILog>().To<Log>().InSingletonScope();

			var selfInjectingClass = new SelfInjectingClass();

			selfInjectingClass.Log.Should().NotBeNull();
		}

	}
}