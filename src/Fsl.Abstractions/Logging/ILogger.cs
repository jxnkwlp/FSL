using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsl.Abstractions.Logging
{
	public interface ILogger
	{
		void Log(string category, LogLevel level, Exception ex, string message, params string[] args);

		//void Log<T>(LogLevel level, Exception ex, string message, params string[] args);
	}

	public interface ILogger<T>
	{
		void Log(LogLevel level, Exception ex, string message, params string[] args);
	}
}
