using System;

namespace Fsl.Abstractions.Logging
{
	public interface ILoggerFactory : IDisposable
	{
		ILogger CreateLogger(string categoryName);

		void AddProvider(ILoggerProvider provider);
	}
}
