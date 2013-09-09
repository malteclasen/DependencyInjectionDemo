namespace DependencyInjectionDemo.Core
{
	public class VolatileLogFactory : ILogFactory
	{
		readonly ILog Log = new VolatileLog();

		public ILog Get()
		{
			return Log;
		}
	}
}