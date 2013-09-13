namespace DependencyInjectionDemo.Core
{
	public class ClockFactory
	{
		public IClock Get()
		{
			//todo: Context detection Voodoo to select clock type
			return new SystemClock();
		}
	}
}