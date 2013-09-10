using System;

namespace DependencyInjectionDemo.Core
{
	public class StaticClock : IClock
	{
		public DateTime Now { get; set; }

		public StaticClock()
		{
			Now = new DateTime(2013, 1, 1);
		}
	}
}