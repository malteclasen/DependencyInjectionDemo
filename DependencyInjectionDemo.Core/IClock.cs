using System;

namespace DependencyInjectionDemo.Core
{
	public interface IClock
	{
		DateTime Now { get; }
	}
}