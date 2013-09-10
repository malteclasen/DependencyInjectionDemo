namespace DependencyInjectionDemo.Core
{
	public static class ServiceLocator
	{
		public static ILog Log { get; set; }
		public static IClock Clock { get; set; }
	}
}