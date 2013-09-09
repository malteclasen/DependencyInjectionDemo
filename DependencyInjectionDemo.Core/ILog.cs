using System.Collections.Generic;

namespace DependencyInjectionDemo.Core
{
	public interface ILog
	{
		void Error(string message);
		IEnumerable<string> Get();
	}
}