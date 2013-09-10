using System;
using System.Collections.Generic;

namespace DependencyInjectionDemo.Core
{
	public interface ILog
	{
		void Error(DateTime time, string message);
		IEnumerable<LogEntry> Get();
	}
}