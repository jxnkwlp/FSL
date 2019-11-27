using System;
using System.Collections.Generic;
using System.Text;

namespace Fsl.Abstractions.Logging
{
	public static class LoggerExtensions
	{
		public static void Info(this ILogger logger, string category, string message, params string[] args)
		{
			logger.Log(category, LogLevel.Information, null, message, args);
		}

		public static void Info<T>(this ILogger<T> logger, string message, params string[] args)
		{
			logger.Log(LogLevel.Information, null, message, args);
		}


		public static void Debug(this ILogger logger, string category, string message, params string[] args)
		{
			logger.Log(category, LogLevel.Debug, null, message, args);
		}

		public static void Error(this ILogger logger, string category, Exception ex, string message, params string[] args)
		{
			logger.Log(category, LogLevel.Error, ex, message, args);
		}
	}
}
