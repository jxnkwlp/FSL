using System;

namespace Fsl.Abstractions.Logging
{
	/// <summary>
	/// Define an logger
	/// </summary>
	public interface ILogger
	{
		bool IsEnabled(LogLevel logLevel);

		void Log(string category, LogLevel level, Exception ex, string message, params object[] args);
	}

	/// <summary>
	/// Define an logger for <typeparamref name="T"/>
	/// </summary>
	public interface ILogger<T> : ILogger
	{
	}
}
