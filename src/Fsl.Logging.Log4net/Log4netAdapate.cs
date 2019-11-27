using Fsl.Abstractions.Logging;
using log4net;
using log4net.Config;
using log4net.Repository;
using System;

namespace Fsl.Logging.Log4net
{
	public class Log4netAdapate : ILogger
	{
		private readonly ILoggerRepository _repository;

		public Log4netAdapate()
		{
			_repository = LogManager.CreateRepository("NETCoreRepository");

			string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");

			XmlConfigurator.Configure(_repository, new System.IO.FileInfo(path));
		}

		public void Log(string category, LogLevel level, Exception ex, string message, params string[] args)
		{
			ILog logger = LogManager.GetLogger(_repository.Name, "NETCorelog4net");
			switch (level)
			{
				case LogLevel.Debug:
					
					logger.DebugFormat(string.Format(message, args), ex);
					break;
				case LogLevel.Information:
					logger.InfoFormat(string.Format(message, args), ex);
					break;
				case LogLevel.Warning:
					logger.WarnFormat(string.Format(message, args), ex);
					break;
				case LogLevel.Error:
					logger.ErrorFormat(string.Format(message, args), ex);
					break;
				case LogLevel.Critical:
					logger.FatalFormat(string.Format(message, args), args);
					break;
			}
		}

	}

	public class Log4netAdapate<T> : ILogger<T>
	{
		private readonly ILoggerRepository _repository;

		public Log4netAdapate()
		{
			_repository = LogManager.CreateRepository("NETCoreRepositoryRelation");

			string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");

			XmlConfigurator.Configure(_repository, new System.IO.FileInfo(path));

		}


		public void Log(LogLevel level, Exception ex, string message, params string[] args)
		{
			ILog logger = LogManager.GetLogger("NETCoreRepositoryRelation", typeof(T));

			switch (level)
			{
				case LogLevel.Debug:

					logger.DebugFormat(string.Format(message, args), ex);
					break;
				case LogLevel.Information:
					logger.InfoFormat(string.Format(message, args), ex);
					break;
				case LogLevel.Warning:
					logger.WarnFormat(string.Format(message, args), ex);
					break;
				case LogLevel.Error:
					logger.ErrorFormat(string.Format(message, args), ex);
					break;
				case LogLevel.Critical:
					logger.FatalFormat(string.Format(message, args), args);
					break;
			}

		}
	}
}
