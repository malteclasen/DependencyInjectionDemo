namespace DependencyInjectionDemo.Core
{
	public class SystemClockFactory : IClockFactory
	{
		public IClock Get()
		{
			return new SystemClock();
		}
	}
}