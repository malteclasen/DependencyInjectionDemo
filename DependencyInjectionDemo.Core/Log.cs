using System;
using System.Collections.Generic;

namespace DependencyInjectionDemo.Core
{
	public class Log : ILog
	{
		private readonly List<LogEntry> _errors = new List<LogEntry>(); 

		public void Error(DateTime time, string message)
		{
			_errors.Add(
				new LogEntry
					{
						Time = time, 
						Message = message
					});
		}

		public IEnumerable<LogEntry> Get()
		{
			return _errors;
		}
	}
}