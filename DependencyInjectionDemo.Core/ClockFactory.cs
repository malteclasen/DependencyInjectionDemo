namespace DependencyInjectionDemo.Core
{
	public class ClockFactory
	{
		public IClock Get()
		{
			return new SystemClock();
		}
	}
}