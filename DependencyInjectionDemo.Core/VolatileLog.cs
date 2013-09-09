using System.Collections.Generic;

namespace DependencyInjectionDemo.Core
{
	public class VolatileLog : ILog
	{
		private readonly List<string> _errors = new List<string>(); 

		public void Error(string message)
		{
			_errors.Add(message);
		}

		public IEnumerable<string> Get()
		{
			return _errors;
		}
	}
}