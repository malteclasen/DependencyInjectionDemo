namespace DependencyInjectionDemo.Core
{
	public class StaticClockFactory : IClockFactory
	{
		public IClock Get()
		{
			return new StaticClock();
		}
	}
}