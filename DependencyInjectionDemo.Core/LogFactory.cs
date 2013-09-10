namespace DependencyInjectionDemo.Core
{
	public class LogFactory : ILogFactory
	{
		readonly ILog Log = new Log();

		public ILog Get()
		{
			return Log;
		}
	}
}