using System;

namespace DependencyInjectionDemo.Core
{
	public class SystemClock : IClock
	{
		public DateTime Now 
		{ 
			get { return DateTime.Now; }
		}
	}
}