using Fsl.Abstractions.Logging;
using log4net;
using System;
using System.Linq;

namespace Fsl.Logging.Log4net
{
	public class Log4netLogger : ILogger
	{
		private readonly Log4netLoggerOptions _options;

		private readonly ILog _logger = null;

		public Log4netLogger(Log4netLoggerOptions options)
		{
			_options = options;
			_logger = LogManager.GetLogger(options.Repository, options.Name);
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			switch (logLevel)
			{
				case LogLevel.Debug: return _logger.IsDebugEnabled;
				case LogLevel.Information: return _logger.IsInfoEnabled;
				case LogLevel.Warning: return _logger.IsWarnEnabled;
				case LogLevel.Error: return _logger.IsErrorEnabled;
				case LogLevel.Critical: return _logger.IsFatalEnabled;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public void Log(string category, LogLevel level, Exception ex, string message, params object[] args)
		{
			if (!IsEnabled(level))
				return;

			string logText = string.Format(message, args);

			var isNeedLog = ex != null || !string.IsNullOrEmpty(logText);

			if (isNeedLog)
			{
				switch (level)
				{
					case LogLevel.Debug: _logger.Debug(logText, ex); break;
					case LogLevel.Information: _logger.Info(logText, ex); break;
					case LogLevel.Warning: _logger.Warn(logText, ex); break;
					case LogLevel.Error: _logger.Error(logText, ex); break;
					case LogLevel.Critical: _logger.Fatal(logText, ex); break;
					default: throw new ArgumentOutOfRangeException();
				}
			}
		}
	}
}
